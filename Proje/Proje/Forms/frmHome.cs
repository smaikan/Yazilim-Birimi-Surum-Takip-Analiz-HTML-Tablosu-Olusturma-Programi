using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Proje.Models;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Xml.Linq;

namespace Proje.Forms
{
    public partial class frmHome : Form
    {
        public DataTable dt;
        DataTable dbdt;
        readonly APIService api;
        bool eslesenVarMi;
        static bool selected = false;
        bool firstLoad = false;
        static DataTable dt2 = new DataTable();




        public frmHome(ref DataTable dt, ref DataTable dbdt )
        {
            InitializeComponent();
            this.dt = dt;
            this.dbdt = dbdt;
            api = new APIService();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.Text = "Horoz IT Sürüm Takip Uygulaması";
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.Manual;
            this.FormBorderStyle = FormBorderStyle.None;
            dataGridView1.BackgroundColor = Color.White;
            
            Upload.Padding = new Padding(5, 5, 5, 5);
            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.BackColor = Color.FromArgb(220, 235, 240);
            this.Controls.Add(panel);
            comboBox1.Items.Add("Tümü");
            comboBox1.Items.Add("ERP");
            comboBox1.Items.Add("WEB");
            comboBox1.Items.Add("Mobil");
            comboBox1.Items.Add("DBD");
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            pictureBox1.BackColor = Color.FromArgb(220, 235, 240);
            string solutionRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            Upload.Image = Image.FromFile(Path.Combine(solutionRoot, "Resources\\icons8-excel-32 (1).png"));
            button2.Image = Image.FromFile(Path.Combine(solutionRoot, "Resources\\icons8-save-32 (1).png"));
            pictureBox1.Image = Image.FromFile(Path.Combine(solutionRoot, "Resources\\icons8-search-32.png"));
            button2.Enabled = false;
            dataGridView1.DataBindingComplete += (a, e) =>
            {
                if (this.dt.Rows.Count > 0)
                {
                    button2.Enabled = true;
                }
                else { button2.Enabled = false; }
            };
            comboBox1.Visible = false;
            textBox1.Visible = false;
            pictureBox1.Visible = false;
            label2.BackColor = Color.FromArgb(220, 235, 240);

            label2.Visible = false;

            dataGridView1.DataBindingComplete += (sender, e) =>
            {
                Datagrid.SetColor(dataGridView1);
                string countinfo = "Veri sayısı: " + dataGridView1.Rows.Count.ToString();
                label2.Text = countinfo;
            };

            

            label1.BackColor = Color.FromArgb(220, 235, 240);
            dataGridView1.DataBindingComplete += (s, e) =>
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    label1.Visible = false;
                    comboBox1.Visible = true;
                    textBox1.Visible = true;
                    pictureBox1.Visible = true;
                    label2.Visible = true;
                }
                else
                {
                }
            };
        }

        private void Upload_Click(object sender, EventArgs e)
        {
            frmUpload fileUploadForm = new frmUpload(ref dt );
            fileUploadForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            fileUploadForm.StartPosition = FormStartPosition.CenterParent;
            fileUploadForm.Size = new System.Drawing.Size(800, 700);
            fileUploadForm.DataUploaded += () =>
            {
                selected = false;
                
                     comboBox1.SelectedIndex = 0;  
            }
                ;
            fileUploadForm.ShowDialog();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox1_SelectedIndexChanged(comboBox1, EventArgs.Empty);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secilenEkip = comboBox1.SelectedItem.ToString().ToLower();
            
            Datagrid.HeaderColons(dt2);
            
                if (!selected)
                {
                    dt2.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        dt2.ImportRow(row);
                    }
                    selected = true;

                }


            dt.Clear();
            
            
            foreach (DataRow row in dt2.Rows)
            {
                dt.ImportRow(row);
            }
            

            if (secilenEkip != "tümü")
            {
                
                    var filteredRows = dt.AsEnumerable()
                .Where(x => x.Field<string>("teams").ToLower().Contains(secilenEkip))
                .ToList();
                if (filteredRows.Count > 0)
                {
                    DataTable filteredDataTable = filteredRows.CopyToDataTable();
                    dt.Clear();
                    foreach (DataRow row in filteredDataTable.Rows)
                    {
                        dt.ImportRow(row);
                    }
                    Datagrid.DataGridView(dataGridView1, filteredDataTable);
                    dataGridView1.Refresh();
                }
                else
                {
                    DataTable removed = dt.Clone();
                    dataGridView1.DataSource = removed;
                }



                    
            }
            else
            {
                
                dataGridView1.DataSource = null;
                Datagrid.DataGridView(dataGridView1, dt);
                dataGridView1.DataBindingComplete += (sender, e) =>
                {

                    Datagrid.SetColor(dataGridView1);
                };
                dataGridView1.Refresh();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                var searchText = textBox1.Text.Trim().ToLower();
                if (dt.Rows.Count > 0)
                {
                    var filteredData = dt.AsEnumerable()
                    .Where(x => x.Field<string>("description").ToLower().Contains(searchText))
                    .ToList();
                    if (filteredData.Count > 0)
                    {
                        DataTable filteredDataTable = filteredData.CopyToDataTable();
                        Datagrid.DataGridView(dataGridView1, filteredDataTable);
                    }
                    else
                    {
                        DataTable removed = dt.Clone();
                        dataGridView1.DataSource = removed;

                    }
                }

            }
            else
            {
                if (dt.Rows.Count > 0) { Datagrid.DataGridView(dataGridView1, dt); }

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            bool added = false;
            DialogResult result = MessageBox.Show("Veri tabanına kaydetmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                var selectAll = await api.GetAllAPIsAsync();

                

                foreach (DataRow row in dt.Rows)
                {
                    
                    string ekip = row["teams"].ToString();
                    string version = row["version"].ToString();
                    DateTime date = Convert.ToDateTime(row["updateTime"]);
                    string type = row["type"].ToString();
                    string description = row["description"].ToString();

                    eslesenVarMi = selectAll.Any(d =>
                       d.teams == ekip &&
                       d.version == version &&
                       d.updateTime.Date == date.Date &&
                       d.type == type &&
                       d.description == description
                   );
                   

                    if (!eslesenVarMi)
                    {
                        var model = new SourceModel()
                        {
                            teams = row["teams"].ToString(),
                            version = row["version"].ToString(),
                            updateTime = Convert.ToDateTime(row["updateTime"]),
                            type = row["type"].ToString(),
                            description = row["description"].ToString()
                        };
                        bool success = await api.AddAPIAsync(model);

                        if (!success)
                        {
                            break;
                           
                        }
                        else
                        {
                            added = true;
                        }
                       

                    }
                }
                
                if (eslesenVarMi)
                {
                    MessageBox.Show("Veri tabanında zaten var olan verileri yüklemeye çalışıyorsunuz");
                }
                else
                {
                    if (added)
                    {
                        MessageBox.Show("Tüm kayıtlar başarıyla eklendi!");
                    }
                    
                }

            }
        }   
    }
}
