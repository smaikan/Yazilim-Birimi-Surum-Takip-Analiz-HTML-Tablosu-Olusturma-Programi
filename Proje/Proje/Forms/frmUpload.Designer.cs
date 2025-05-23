namespace Proje.Forms
{
    partial class frmUpload
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
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            ok = new Button();
            iptal = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI Light", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox1.Location = new Point(34, 67);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(277, 31);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft Sans Serif", 10F);
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(317, 67);
            button1.Name = "button1";
            button1.Size = new Size(114, 32);
            button1.TabIndex = 1;
            button1.Text = "İçe Aktar";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Microsoft Sans Serif", 10F);
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(537, 12);
            button2.Name = "button2";
            button2.Size = new Size(222, 32);
            button2.TabIndex = 2;
            button2.Text = "Örnek Excel Dosyası";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(34, 163);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(725, 395);
            dataGridView1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Menu;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(34, 137);
            label1.Name = "label1";
            label1.Size = new Size(82, 23);
            label1.TabIndex = 4;
            label1.Text = "Önizleme";
            // 
            // ok
            // 
            ok.Font = new Font("Segoe UI", 10F);
            ok.ImageAlign = ContentAlignment.MiddleLeft;
            ok.Location = new Point(500, 582);
            ok.Name = "ok";
            ok.Padding = new Padding(5);
            ok.Size = new Size(125, 45);
            ok.TabIndex = 5;
            ok.Text = "Onayla";
            ok.TextAlign = ContentAlignment.MiddleRight;
            ok.UseVisualStyleBackColor = true;
            ok.Click += ok_Click;
            // 
            // iptal
            // 
            iptal.Font = new Font("Segoe UI", 10F);
            iptal.ImageAlign = ContentAlignment.MiddleLeft;
            iptal.Location = new Point(659, 582);
            iptal.Name = "iptal";
            iptal.Padding = new Padding(5);
            iptal.Size = new Size(100, 45);
            iptal.TabIndex = 6;
            iptal.Text = "İptal";
            iptal.TextAlign = ContentAlignment.MiddleRight;
            iptal.UseVisualStyleBackColor = true;
            iptal.Click += iptal_Click;
            // 
            // frmUpload
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 788);
            Controls.Add(iptal);
            Controls.Add(ok);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "frmUpload";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private DataGridView dataGridView1;
        private Label label1;
        private Button ok;
        private Button iptal;
    }
}