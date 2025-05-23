using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using Newtonsoft.Json;
using Proje.Models;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Proje.Forms
{
    public partial class frmMain : Form
    {
        public static DataTable dt = new DataTable();
        public static DataTable dbdt = new DataTable();


        public frmMain()
        {
            InitializeComponent();
            this.Text = "Proje Sürüm Takibi";
            string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\unnamed.ico");

            if (File.Exists(iconPath))
            {
                this.Icon = new Icon(iconPath);
            }
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
            //toolStripButton1.Padding = new Padding(10, 5, 10, 5);
            toolStripButton2.Padding = new Padding(10, 5, 10, 5);
            toolStripButton3.Padding = new Padding(10, 5, 10, 5);
            toolStripButton4.Padding = new Padding(10, 5, 10, 5);
            toolStripButton5.Padding = new Padding(15, 5, 15, 5);
            //toolStripButton1.Font = new Font("Arial", 11);
            toolStripButton2.Font = new Font("Arial", 11);
            toolStripButton3.Font = new Font("Arial", 11);
            toolStripButton4.Font = new Font("Arial", 11);
            toolStripButton5.Font = new Font("Arial", 11);
            toolStripButton4.Alignment = ToolStripItemAlignment.Right;
            //toolStripButton3.Alignment = ToolStripItemAlignment.Right;
            string solutionRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            //toolStripButton1.Image = Image.FromFile(Path.Combine(solutionRoot, "Resources\\icons8-upload-32.png"));
            toolStripButton2.Image = Image.FromFile(Path.Combine(solutionRoot, "Resources\\icons8-help-48.png"));
            toolStripButton3.Image = Image.FromFile(Path.Combine(solutionRoot, "Resources\\icons8-page-64.png"));
            toolStripButton4.Image = Image.FromFile(Path.Combine(solutionRoot, "Resources\\icons8-html-32.png"));
            toolStripButton5.Image = Image.FromFile(Path.Combine(solutionRoot, "Resources\\icons8-homepage-32.png"));
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Hide();
            }
            frmDB db = new frmDB(ref dbdt, ref dt);
            db.MdiParent = this;
            db.FormBorderStyle = FormBorderStyle.None;
            db.Dock = DockStyle.Fill;
            db.Show();
        }
        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            frmHome homeForm = new frmHome(ref dt, ref dbdt);
            homeForm.MdiParent = this;
            homeForm.FormBorderStyle = FormBorderStyle.None;
            homeForm.Dock = DockStyle.Fill;

            homeForm.Show();
        }


        //private void toolStripButton1_Click(object sender, EventArgs e)
        //{
        //    frmUpload fileUploadForm = new frmUpload(ref dt );
           
           
        //    fileUploadForm.FormBorderStyle = FormBorderStyle.FixedDialog;
        //    fileUploadForm.StartPosition = FormStartPosition.CenterParent;
        //    fileUploadForm.Size = new System.Drawing.Size(800, 700);
        //    fileUploadForm.ShowDialog();
        //}

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Hide();
            }
            frmHelp helpForm = new frmHelp();
            helpForm.MdiParent = this;
            helpForm.FormBorderStyle = FormBorderStyle.None;
            helpForm.Dock = DockStyle.Fill;
            helpForm.Show();
        }
        



        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Hide();
            }
            frmDB db = new frmDB(ref dbdt, ref dt);
            db.MdiParent = this;
            db.FormBorderStyle = FormBorderStyle.None;
            db.Dock = DockStyle.Fill;
            db.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (dbdt.Rows.Count > 0)
            {
                foreach (Form childForm in this.MdiChildren)
                {
                    childForm.Hide();
                }
                frmHTML html = new frmHTML(ref dbdt);
                html.MdiParent = this;  
                html.FormBorderStyle = FormBorderStyle.None;
                html.Dock = DockStyle.Fill;
                html.Show();
            }
            else { MessageBox.Show("Lütfen ana sayfadan koda dönüştürülecek veriyi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
                    }
                    
                }
                
            
       
    

