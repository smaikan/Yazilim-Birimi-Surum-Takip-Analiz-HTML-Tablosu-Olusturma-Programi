namespace Proje.Forms
{
    partial class frmHelp
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
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 188);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(829, 211);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10F, FontStyle.Bold);
            label1.Location = new Point(12, 52);
            label1.Name = "label1";
            label1.Size = new Size(643, 38);
            label1.TabIndex = 1;
            label1.Text = "Yüklenecek dosya bir Excel dosyası olmalı ve uzantısı \"xlsx\" ya da \"xls\" olmalıdır.\r\n\r\n";
            label1.Click += label1_Click_1;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(12, 405);
            button1.Name = "button1";
            button1.Size = new Size(219, 43);
            button1.TabIndex = 2;
            button1.Text = "Örnek dosyayı indir";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(342, 123);
            label2.Name = "label2";
            label2.Size = new Size(509, 20);
            label2.TabIndex = 3;
            label2.Text = "Ekip adı, Sürüm Numarası, Güncelleme tarihi, Güncelleme tipi, Açıklama";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 123);
            label3.Name = "label3";
            label3.Size = new Size(335, 20);
            label3.TabIndex = 4;
            label3.Text = "Tablo \"A1\" kolonundan başlayıp sütunlar sırasıyla;";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 143);
            label4.Name = "label4";
            label4.Size = new Size(388, 20);
            label4.TabIndex = 5;
            label4.Text = "Bilgilerini vermelidir. Sürüm numarası \"v\" ile başlamalıdır.";
            // 
            // frmHelp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(855, 472);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "frmHelp";
            Text = "HelpForm";
            Load += HelpForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button button1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}