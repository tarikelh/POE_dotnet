namespace _03_Files
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLire = new System.Windows.Forms.Button();
            this.btnEcrire = new System.Windows.Forms.Button();
            this.txtLecture = new System.Windows.Forms.TextBox();
            this.txtEcriture = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLire);
            this.groupBox1.Controls.Add(this.btnEcrire);
            this.groupBox1.Controls.Add(this.txtLecture);
            this.groupBox1.Controls.Add(this.txtEcriture);
            this.groupBox1.Location = new System.Drawing.Point(15, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(507, 434);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnLire
            // 
            this.btnLire.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLire.Location = new System.Drawing.Point(219, 300);
            this.btnLire.Margin = new System.Windows.Forms.Padding(4);
            this.btnLire.Name = "btnLire";
            this.btnLire.Size = new System.Drawing.Size(235, 32);
            this.btnLire.TabIndex = 3;
            this.btnLire.Text = "Lire dans un fichier";
            this.btnLire.UseVisualStyleBackColor = true;
            this.btnLire.Click += new System.EventHandler(this.btnLire_Click);
            // 
            // btnEcrire
            // 
            this.btnEcrire.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEcrire.Location = new System.Drawing.Point(219, 90);
            this.btnEcrire.Margin = new System.Windows.Forms.Padding(4);
            this.btnEcrire.Name = "btnEcrire";
            this.btnEcrire.Size = new System.Drawing.Size(235, 32);
            this.btnEcrire.TabIndex = 2;
            this.btnEcrire.Text = "Ecrire dans un fichier";
            this.btnEcrire.UseVisualStyleBackColor = true;
            this.btnEcrire.Click += new System.EventHandler(this.btnEcrire_Click);
            // 
            // txtLecture
            // 
            this.txtLecture.Location = new System.Drawing.Point(31, 238);
            this.txtLecture.Margin = new System.Windows.Forms.Padding(4);
            this.txtLecture.Multiline = true;
            this.txtLecture.Name = "txtLecture";
            this.txtLecture.Size = new System.Drawing.Size(151, 145);
            this.txtLecture.TabIndex = 1;
            // 
            // txtEcriture
            // 
            this.txtEcriture.Location = new System.Drawing.Point(31, 41);
            this.txtEcriture.Margin = new System.Windows.Forms.Padding(4);
            this.txtEcriture.Multiline = true;
            this.txtEcriture.Name = "txtEcriture";
            this.txtEcriture.Size = new System.Drawing.Size(151, 145);
            this.txtEcriture.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 501);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Files";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Button btnLire;
        private Button btnEcrire;
        private TextBox txtLecture;
        private TextBox txtEcriture;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
    }
}