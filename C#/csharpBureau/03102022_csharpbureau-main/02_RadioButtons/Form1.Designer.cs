namespace _02_RadioButtons
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
            this.btnValider = new System.Windows.Forms.Button();
            this.radioDepot = new System.Windows.Forms.RadioButton();
            this.radioRetrait = new System.Windows.Forms.RadioButton();
            this.txtMontant = new System.Windows.Forms.TextBox();
            this.txtSolde = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnValider);
            this.groupBox1.Controls.Add(this.radioDepot);
            this.groupBox1.Controls.Add(this.radioRetrait);
            this.groupBox1.Controls.Add(this.txtMontant);
            this.groupBox1.Controls.Add(this.txtSolde);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(238, 314);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opérations";
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(59, 246);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(127, 44);
            this.btnValider.TabIndex = 6;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // radioDepot
            // 
            this.radioDepot.AutoSize = true;
            this.radioDepot.Location = new System.Drawing.Point(135, 180);
            this.radioDepot.Name = "radioDepot";
            this.radioDepot.Size = new System.Drawing.Size(70, 25);
            this.radioDepot.TabIndex = 5;
            this.radioDepot.TabStop = true;
            this.radioDepot.Text = "Depot";
            this.radioDepot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioDepot.UseVisualStyleBackColor = true;
            // 
            // radioRetrait
            // 
            this.radioRetrait.AutoSize = true;
            this.radioRetrait.Location = new System.Drawing.Point(18, 180);
            this.radioRetrait.Name = "radioRetrait";
            this.radioRetrait.Size = new System.Drawing.Size(74, 25);
            this.radioRetrait.TabIndex = 4;
            this.radioRetrait.TabStop = true;
            this.radioRetrait.Text = "Retrait";
            this.radioRetrait.UseVisualStyleBackColor = true;
            // 
            // txtMontant
            // 
            this.txtMontant.Location = new System.Drawing.Point(109, 120);
            this.txtMontant.Name = "txtMontant";
            this.txtMontant.Size = new System.Drawing.Size(100, 29);
            this.txtMontant.TabIndex = 3;
            // 
            // txtSolde
            // 
            this.txtSolde.Location = new System.Drawing.Point(109, 48);
            this.txtSolde.Name = "txtSolde";
            this.txtSolde.Size = new System.Drawing.Size(100, 29);
            this.txtSolde.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Montant";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Solde :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 342);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Radio Buttons";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Button btnValider;
        private RadioButton radioDepot;
        private RadioButton radioRetrait;
        private TextBox txtMontant;
        private TextBox txtSolde;
        private Label label2;
        private Label label1;
    }
}