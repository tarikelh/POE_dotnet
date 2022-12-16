namespace _05_Serialization
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnEffacer = new System.Windows.Forms.Button();
            this.txtSolde = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.lstAccounts = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRestCSV = new System.Windows.Forms.Button();
            this.btnSaveCSV = new System.Windows.Forms.Button();
            this.btnRestJSON = new System.Windows.Forms.Button();
            this.btnSaveJSON = new System.Windows.Forms.Button();
            this.btnRestXML = new System.Windows.Forms.Button();
            this.btnSaveXML = new System.Windows.Forms.Button();
            this.btnRestBin = new System.Windows.Forms.Button();
            this.btnSaveBin = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnSupprimer);
            this.groupBox1.Controls.Add(this.lstAccounts);
            this.groupBox1.Location = new System.Drawing.Point(28, 31);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(324, 582);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comptes";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAjouter);
            this.groupBox3.Controls.Add(this.btnEffacer);
            this.groupBox3.Controls.Add(this.txtSolde);
            this.groupBox3.Controls.Add(this.txtNumero);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(19, 363);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 204);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gestion de compte";
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(169, 141);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(89, 44);
            this.btnAjouter.TabIndex = 4;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnEffacer
            // 
            this.btnEffacer.Location = new System.Drawing.Point(21, 141);
            this.btnEffacer.Name = "btnEffacer";
            this.btnEffacer.Size = new System.Drawing.Size(89, 44);
            this.btnEffacer.TabIndex = 5;
            this.btnEffacer.Text = "Effacer";
            this.btnEffacer.UseVisualStyleBackColor = true;
            this.btnEffacer.Click += new System.EventHandler(this.btnEffacer_Click);
            // 
            // txtSolde
            // 
            this.txtSolde.Location = new System.Drawing.Point(95, 87);
            this.txtSolde.Name = "txtSolde";
            this.txtSolde.Size = new System.Drawing.Size(163, 29);
            this.txtSolde.TabIndex = 3;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(95, 44);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(163, 29);
            this.txtNumero.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Solde :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numéro :";
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(170, 284);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(4);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(124, 48);
            this.btnSupprimer.TabIndex = 1;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // lstAccounts
            // 
            this.lstAccounts.FormattingEnabled = true;
            this.lstAccounts.ItemHeight = 21;
            this.lstAccounts.Location = new System.Drawing.Point(19, 46);
            this.lstAccounts.Margin = new System.Windows.Forms.Padding(4);
            this.lstAccounts.Name = "lstAccounts";
            this.lstAccounts.Size = new System.Drawing.Size(275, 214);
            this.lstAccounts.TabIndex = 0;
            this.lstAccounts.SelectedIndexChanged += new System.EventHandler(this.lstAccounts_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRestCSV);
            this.groupBox2.Controls.Add(this.btnSaveCSV);
            this.groupBox2.Controls.Add(this.btnRestJSON);
            this.groupBox2.Controls.Add(this.btnSaveJSON);
            this.groupBox2.Controls.Add(this.btnRestXML);
            this.groupBox2.Controls.Add(this.btnSaveXML);
            this.groupBox2.Controls.Add(this.btnRestBin);
            this.groupBox2.Controls.Add(this.btnSaveBin);
            this.groupBox2.Location = new System.Drawing.Point(401, 31);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(324, 582);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Serialization";
            // 
            // btnRestCSV
            // 
            this.btnRestCSV.BackColor = System.Drawing.Color.Yellow;
            this.btnRestCSV.Location = new System.Drawing.Point(37, 495);
            this.btnRestCSV.Name = "btnRestCSV";
            this.btnRestCSV.Size = new System.Drawing.Size(229, 51);
            this.btnRestCSV.TabIndex = 7;
            this.btnRestCSV.Text = "Restaure CSV";
            this.btnRestCSV.UseVisualStyleBackColor = false;
            this.btnRestCSV.Click += new System.EventHandler(this.btnRestCSV_Click);
            // 
            // btnSaveCSV
            // 
            this.btnSaveCSV.BackColor = System.Drawing.Color.Yellow;
            this.btnSaveCSV.Location = new System.Drawing.Point(37, 438);
            this.btnSaveCSV.Name = "btnSaveCSV";
            this.btnSaveCSV.Size = new System.Drawing.Size(229, 51);
            this.btnSaveCSV.TabIndex = 6;
            this.btnSaveCSV.Text = "Sauvegarder CSV";
            this.btnSaveCSV.UseVisualStyleBackColor = false;
            this.btnSaveCSV.Click += new System.EventHandler(this.btnSaveCSV_Click);
            // 
            // btnRestJSON
            // 
            this.btnRestJSON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRestJSON.Location = new System.Drawing.Point(37, 365);
            this.btnRestJSON.Name = "btnRestJSON";
            this.btnRestJSON.Size = new System.Drawing.Size(229, 51);
            this.btnRestJSON.TabIndex = 5;
            this.btnRestJSON.Text = "Restaure JSON";
            this.btnRestJSON.UseVisualStyleBackColor = false;
            this.btnRestJSON.Click += new System.EventHandler(this.btnRestJSON_Click);
            // 
            // btnSaveJSON
            // 
            this.btnSaveJSON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSaveJSON.Location = new System.Drawing.Point(37, 308);
            this.btnSaveJSON.Name = "btnSaveJSON";
            this.btnSaveJSON.Size = new System.Drawing.Size(229, 51);
            this.btnSaveJSON.TabIndex = 4;
            this.btnSaveJSON.Text = "Sauvegarder JSON";
            this.btnSaveJSON.UseVisualStyleBackColor = false;
            this.btnSaveJSON.Click += new System.EventHandler(this.btnSaveJSON_Click);
            // 
            // btnRestXML
            // 
            this.btnRestXML.BackColor = System.Drawing.Color.Lime;
            this.btnRestXML.Location = new System.Drawing.Point(37, 237);
            this.btnRestXML.Name = "btnRestXML";
            this.btnRestXML.Size = new System.Drawing.Size(229, 51);
            this.btnRestXML.TabIndex = 3;
            this.btnRestXML.Text = "Restaure XML";
            this.btnRestXML.UseVisualStyleBackColor = false;
            this.btnRestXML.Click += new System.EventHandler(this.btnRestXML_Click);
            // 
            // btnSaveXML
            // 
            this.btnSaveXML.BackColor = System.Drawing.Color.Lime;
            this.btnSaveXML.Location = new System.Drawing.Point(37, 180);
            this.btnSaveXML.Name = "btnSaveXML";
            this.btnSaveXML.Size = new System.Drawing.Size(229, 51);
            this.btnSaveXML.TabIndex = 2;
            this.btnSaveXML.Text = "Sauvegarder XML";
            this.btnSaveXML.UseVisualStyleBackColor = false;
            this.btnSaveXML.Click += new System.EventHandler(this.btnSaveXML_Click);
            // 
            // btnRestBin
            // 
            this.btnRestBin.Location = new System.Drawing.Point(37, 109);
            this.btnRestBin.Name = "btnRestBin";
            this.btnRestBin.Size = new System.Drawing.Size(229, 51);
            this.btnRestBin.TabIndex = 1;
            this.btnRestBin.Text = "Restaure Bin";
            this.btnRestBin.UseVisualStyleBackColor = true;
            this.btnRestBin.Click += new System.EventHandler(this.btnRestBin_Click);
            // 
            // btnSaveBin
            // 
            this.btnSaveBin.Location = new System.Drawing.Point(37, 52);
            this.btnSaveBin.Name = "btnSaveBin";
            this.btnSaveBin.Size = new System.Drawing.Size(229, 51);
            this.btnSaveBin.TabIndex = 0;
            this.btnSaveBin.Text = "Sauvegarder Bin";
            this.btnSaveBin.UseVisualStyleBackColor = true;
            this.btnSaveBin.Click += new System.EventHandler(this.btnSaveBin_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 630);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Serialization";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private Label label2;
        private Label label1;
        private Button btnSupprimer;
        private ListBox lstAccounts;
        private GroupBox groupBox2;
        private Button btnAjouter;
        private Button btnEffacer;
        private TextBox txtSolde;
        private TextBox txtNumero;
        private Button btnRestBin;
        private Button btnSaveBin;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private Button btnRestXML;
        private Button btnSaveXML;
        private Button btnRestJSON;
        private Button btnSaveJSON;
        private Button btnRestCSV;
        private Button btnSaveCSV;
    }
}