using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using OfficeOpenXml;


namespace Proje.Forms
{
    public partial class frmHelp : Form
    {
        DataTable example = new DataTable();
        public frmHelp()
        {
            InitializeComponent();
            string solutionRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            button1.Image = Image.FromFile(Path.Combine(solutionRoot, "Resources\\icons8-excel-32 (1).png"));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void HelpForm_Load(object sender, EventArgs e)
        {

            string solutionRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            string filePath = Path.Combine(solutionRoot, "Resources", "ornek.xlsx");
            if (File.Exists(filePath))
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];

                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;



                    example.Clear();

                    Datagrid.HeaderColons(example);
                    for (int row = 2; row <= rowCount; row++)
                    {
                        if (DateTime.TryParse(worksheet.Cells[row, 3].Text, out DateTime updateDate))
                        {
                            DataRow trow = example.NewRow();
                            trow["teams"] = worksheet.Cells[row, 1].Text;
                            trow["version"] = worksheet.Cells[row, 2].Text; ;
                            trow["updateTime"] = updateDate;
                            trow["type"] = worksheet.Cells[row, 4].Text;
                            trow["description"] = worksheet.Cells[row, 5].Text; ;
                            example.Rows.Add(trow);
                        }
                    }

                    
                    Datagrid.DataGridView(dataGridView1, example);
                    dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dataGridView1.AutoResizeRows();












                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string solutionRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            string filePath = Path.Combine(solutionRoot, "Resources", "ornek.xlsx");

            
            if (File.Exists(filePath))
            {
                
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "ornek.xlsx"; 
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*"; 
                saveFileDialog.DefaultExt = "xlsx";

                
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        
                        File.Copy(filePath, saveFileDialog.FileName, true);
                        MessageBox.Show("Dosya başarıyla indirildi.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Dosya indirilirken hata oluştu: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Dosya bulunamadı.");
            }
        }
    }
}
