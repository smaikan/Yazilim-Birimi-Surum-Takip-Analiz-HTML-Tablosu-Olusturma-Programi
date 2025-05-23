using Proje.Properties;

namespace Proje.Forms
{
    partial class frmHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            Upload = new Button();
            label1 = new Label();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = Color.White;
            dataGridView1.Location = new Point(40, 214);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1057, 657);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Upload
            // 
            Upload.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            Upload.ImageAlign = ContentAlignment.MiddleLeft;
            Upload.Location = new Point(40, 81);
            Upload.Name = "Upload";
            Upload.Size = new Size(239, 60);
            Upload.TabIndex = 2;
            Upload.Text = "Excel Dosyası Yükle";
            Upload.TextAlign = ContentAlignment.MiddleRight;
            Upload.UseVisualStyleBackColor = true;
            Upload.Click += Upload_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(-101, 191);
            label1.Name = "label1";
            label1.Size = new Size(1198, 23);
            label1.TabIndex = 3;
            label1.Text = "Henüz bir dosya yüklemediniz. Kolon sırası; Ekip adı, Sürüm numarası, Güncelleme tarihi, Güncelleme tipi, Açıklama olacak şekilde bir excel tablosu yükleyin";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 11F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(40, 178);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 33);
            comboBox1.TabIndex = 4;
            comboBox1.Text = "Ekip adı ";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox1.Font = new Font("Segoe UI", 13F);
            textBox1.Location = new Point(765, 175);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(332, 36);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.Location = new Point(726, 178);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(33, 33);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(206, 188);
            label2.Name = "label2";
            label2.Size = new Size(62, 23);
            label2.TabIndex = 7;
            label2.Text = "label2";
            label2.Click += label2_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.BackColor = Color.FromArgb(128, 255, 128);
            button2.Font = new Font("Segoe UI Semibold", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button2.ForeColor = SystemColors.ControlText;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(869, 12);
            button2.Name = "button2";
            button2.Size = new Size(228, 53);
            button2.TabIndex = 10;
            button2.Text = "Tabloyu Veri Tabanına Kaydet";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // frmHome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1161, 872);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(Upload);
            Controls.Add(dataGridView1);
            Name = "frmHome";
            Text = "HomeForm";
            Load += HomeForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Button Upload;
        private Label label1;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private PictureBox pictureBox1;
        private Label label2;
        private Button button2;
    }
}