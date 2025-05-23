using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Proje.Forms
{
    public partial class frmDB : Form
    {
        DataTable dbdt;
        DataTable j = new DataTable();
        int secilenIndex;

        public List<string> dates = new List<string>();
        readonly APIService api;
        public frmDB(ref DataTable dbdt, ref DataTable dt)
        {
            InitializeComponent();
            this.dbdt = dbdt;
            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.BackColor = Color.FromArgb(235, 235, 255);
            this.Controls.Add(panel);

            dataGridView1.BackgroundColor = Color.White;
            api = new APIService();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            textBox1.Visible = false;
            pictureBox1.Visible = false;
            label1.BackColor = Color.FromArgb(235, 235, 255);
            label2.BackColor = Color.FromArgb(235, 235, 255);
            pictureBox1.BackColor = Color.FromArgb(235, 235, 255);
            label1.Visible = false;
            comboBox1.Items.Add("Tüm Veriler");
            comboBox1.SelectedIndex = 0;
            string solutionRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            button3.Image = Image.FromFile(Path.Combine(solutionRoot, "Resources\\icons8-database-32.png"));
            button1.Image = Image.FromFile(Path.Combine(solutionRoot, "Resources\\icons8-delete-32 (1).png"));
            pictureBox1.Image = Image.FromFile(Path.Combine(solutionRoot, "Resources\\icons8-search-32.png"));
            dataGridView1.DataBindingComplete += (sender, e) =>
        {
            Datagrid.SetColor(dataGridView1);
            label1.Visible = true;
            dataGridView1.BeginInvoke(new MethodInvoker(() =>
            {
                int count = dataGridView1.Rows.Count;
                label1.Text = "Veri sayısı: " + count.ToString();
            }));
            if (dataGridView1.Rows.Count > 0)
            {
                textBox1.Visible = true;
                pictureBox1.Visible = true;
            }



        };
        }

        private async void frmDB_Load(object sender, EventArgs e)
        {

            int count = await api.GetCountAsync();
            this.label2.Text = "Veritabanında toplam " + count + " veri bulunmaktadır.";

            var allData = await api.GetAllAPIsAsync();

            List<string> UpdateTimes = allData
              .Select(x => new DateTime(x.updateTime.Year, x.updateTime.Month, 1))
                 .Distinct()
                 .OrderByDescending(x => x)
                 .Select(d => d.ToString("M.yyyy", new CultureInfo("tr-TR")))
                 .ToList();



            dates.AddRange(UpdateTimes);

            string[] aylar = { "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" };

            foreach (var item in UpdateTimes)
            {

                string[] parts = item.Split('.');

                if (parts.Length == 2)
                {
                    int ayindex = Convert.ToInt32(parts[0]) - 1;
                    string yil = parts[1];
                    comboBox1.Items.Add(aylar[ayindex] + " " + yil);
                }



            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {



            Datagrid.HeaderColons(dbdt);

            dbdt.Clear();



            foreach (DataRow row in j.Rows)
            {
                dbdt.ImportRow(row);
            }

            dataGridView1.DataSource = null;

            if (dbdt.Rows.Count == 0)
            {
                MessageBox.Show("Veri tabanında hiç veri yok!");
            }
            else { Datagrid.DataGridView(dataGridView1, dbdt); }
            dataGridView1.Refresh();

        }




        private async void button1_Click(object sender, EventArgs e)
        {
            DialogResult result;
            if (comboBox1.SelectedIndex == 0)
            { result = MessageBox.Show("Veri tabanını temizlemek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); }
            else { result = MessageBox.Show("Seçilen ayın verilerini temizlemek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); }

            if (result == DialogResult.Yes)
            {

                if (comboBox1.SelectedIndex == 0)
                {
                    bool success = await api.ClearAPIAsync();
                    if (success)
                    {
                        MessageBox.Show("Tüm veriler başarıyla silindi.");
                        dataGridView1.DataSource = null;
                        j.Rows.Clear();
                        comboBox1.SelectedIndex = -1;
                        comboBox1.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("Veriler silinirken bir hata oluştu.");
                    }
                }

                else
                {
                    var Sources = await api.GetAllAPIsAsync();
                    var silinecekler = Sources
                         .Where(x => x.updateTime.ToString("M.yyyy", new CultureInfo("tr-TR")) == dates[secilenIndex - 1]).ToList();

                    try
                    {
                        foreach (var item in silinecekler)
                        {
                            await api.DeleteAPIAsync(item.Id);
                        }
                        MessageBox.Show("Seçilen veriler silindi");
                        dataGridView1.DataSource = null;
                        comboBox1.SelectedIndex = -1;
                        comboBox1.SelectedIndex = 0;
                        j.Rows.Clear();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Silinemeyen veriler var");
                        throw;
                    }
                    comboBox1.Refresh();
                }
                int count = await api.GetCountAsync();
                dataGridView1.DataSource = null;
                label1.Text = "Veri sayısı: " + dataGridView1.Rows.Count.ToString();
                this.label2.Text = "Veritabanında toplam " + count + " veri bulunmaktadır.";
                textBox1.Visible = false;
                pictureBox1.Visible = false;
            }
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Datagrid.HeaderColons(j);
            secilenIndex = comboBox1.SelectedIndex;
            var allData = await api.GetAllAPIsAsync();

            if (secilenIndex != 0)
            {
                allData = await api.GetAllAPIsAsync();

                var TimesColon = allData
                  .Where(x => x.updateTime.ToString("M.yyyy", new CultureInfo("tr-TR")) == dates[secilenIndex - 1])
                  .Distinct()
                  .OrderByDescending(x => x.updateTime)
                  .ToList();

                j.Clear();
                foreach (var item in TimesColon)
                {
                    j.Rows.Add(item.teams, item.version, item.updateTime, item.type, item.description);
                }
            }
            else
            {
                j.Clear();
                foreach (var item in allData)
                {
                    j.Rows.Add(item.teams, item.version, item.updateTime, item.type, item.description);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text;
            if (dbdt.Rows.Count >= 0)
            {
                var filteredData = dbdt.AsEnumerable()
                .Where(x => x.Field<string>("description").ToLower().Contains(searchText))
                .ToList();
                if (filteredData.Count > 0)
                {
                    DataTable filteredDataTable = filteredData.CopyToDataTable();
                    Datagrid.DataGridView(dataGridView1, filteredDataTable);
                }
                else
                {
                    DataTable removed = dbdt.Clone();
                    dataGridView1.DataSource = removed;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

