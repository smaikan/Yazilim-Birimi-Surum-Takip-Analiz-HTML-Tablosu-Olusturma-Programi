namespace Proje.Forms
{
    partial class frmHTML
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHTML));
            htmltext = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // htmltext
            // 
            htmltext.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            htmltext.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            htmltext.Location = new Point(73, 101);
            htmltext.Name = "htmltext";
            htmltext.Size = new Size(657, 31);
            htmltext.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(73, 37);
            button1.Name = "button1";
            button1.Size = new Size(191, 58);
            button1.TabIndex = 1;
            button1.Text = "Kodu Kopyala";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frmHTML
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(htmltext);
            Name = "frmHTML";
            Text = "frmHTML";
            Load += frmHTML_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox htmltext;
        private Button button1;
    }
}