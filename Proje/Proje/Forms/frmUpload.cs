using System;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OfficeOpenXml;

namespace Proje.Forms
{
    public partial class frmUpload : Form
    {
        private DataTable dataTable;
        private DataTable dt;
        public event Action DataUploaded;
        public bool FirstLoadChanged { get; set; } = false;

        public frmUpload(ref DataTable dt)
        {
            InitializeComponent();
            dataGridView1.BackgroundColor = Color.White;
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            this.dt = dt;
            
            
            this.dataTable = new DataTable();
            this.Text = "Dosya Yükleme Ekranı";
            string solutionRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            button2.Image = Image.FromFile(Path.Combine(solutionRoot, "Resources\\icons8-excel-32 (1).png"));
            ok.Image = Image.FromFile(Path.Combine(solutionRoot, "Resources\\icons8-ok-32 (1).png"));
            button1.Image = Image.FromFile(Path.Combine(solutionRoot, "Resources\\icons8-upload-32.png"));
            iptal.Image = Image.FromFile(Path.Combine(solutionRoot, "Resources\\icons8-reject-32.png"));
            textBox1.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) 
                {
                    string path = textBox1.Text;
                    LoadExcel(path);
                }
            };
            dataGridView1.AllowDrop = true;
            dataGridView1.DragEnter += (s, e) =>
            {
                
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;  
                }
                else
                {
                    e.Effect = DragDropEffects.None;  
                }
            };
            dataGridView1.DragDrop += (s, e) =>
            {
                string[] dosyaYolları = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (dosyaYolları.Length > 0)
                {
                    string dosyaYolu = dosyaYolları[0];  
                    textBox1.Text = dosyaYolu;
                    LoadExcel(dosyaYolu);
                }
            }
                ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xls",
                Title = "Excel dosyasını seçin",
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string filePath = openFileDialog.FileName;

            LoadExcel(filePath);
        }

        private void LoadExcel(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            using (var package = new ExcelPackage(fileInfo))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int rowcount = worksheet.Dimension?.Rows ?? 0;
                string[] categories = { "erp", "dbd", "web", "mobil" };

                if (rowcount == 0)
                {
                    MessageBox.Show("Veri bulunamadı.");
                    return;
                }


                bool ok = true;
                dataTable.Clear();
                Datagrid.HeaderColons(dataTable);
               
                for (int row = 2; row <= rowcount; row++)
                {
                    if (categories.Contains(worksheet.Cells[row, 1].Text.ToLower()) &&
                        Regex.IsMatch(worksheet.Cells[row, 2].Text, @"^v\d+(\.\d+)*$") &&
                        DateTime.TryParse(worksheet.Cells[row, 3].Text, out DateTime updateDate))
                    {
                        DataRow trow = dataTable.NewRow();
                        trow["teams"] = worksheet.Cells[row, 1].Text;
                        trow["version"] = worksheet.Cells[row, 2].Text;
                        trow["updateTime"] = updateDate;
                        trow["type"] = worksheet.Cells[row, 4].Text;
                        trow["description"] = worksheet.Cells[row, 5].Text;
                        dataTable.Rows.Add(trow);
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show(
                "Seçtiğiniz Excel tablosu desteklenmiyor. Örnek bir excel dosyası görmek ister misiniz?",
                "Dosya Desteklenmiyor",
                MessageBoxButtons.YesNo, MessageBoxIcon.Error);



                        if (result == DialogResult.Yes)
                        {

                            frmHelp helpform = new frmHelp();
                            helpform.Show();
                            dataGridView1.DataSource = null;
                        }
                        else
                        {
                            dataGridView1.DataSource = null;
                        }
                        break;
                    }


                }
                Datagrid.DataGridView(dataGridView1, dataTable);
                textBox1.Text = filePath;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                checkbutton();
                if (dataGridView1.Rows.Count == 0)
                {
                    dataGridView1.DataSource = null;
                }

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataBindingComplete += (a, d) => checkbutton();
            checkbutton();
        }

        private void checkbutton()
        {
            ok.Enabled = dataGridView1.Rows.Count > 0 && dataGridView1.DataSource != null;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            dt.Clear();


             foreach (DataRow row in dataTable.Rows)
             {
                 dt.ImportRow(row);
             }



            DataUploaded?.Invoke();


            FirstLoadChanged = false;
           
            this.Close();
        }

        private void iptal_Click(object sender, EventArgs e)
        {
            dataTable.Clear();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmHelp help = new frmHelp();
            help.Show();
        }
    }
}
