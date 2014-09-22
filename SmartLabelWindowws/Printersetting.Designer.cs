namespace SmartLabelWindowws
{
    partial class Printersetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Printersetting));
            this.InstalledPrintersCMB = new System.Windows.Forms.ComboBox();
            this.Save = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // InstalledPrintersCMB
            // 
            this.InstalledPrintersCMB.FormattingEnabled = true;
            this.InstalledPrintersCMB.Location = new System.Drawing.Point(16, 30);
            this.InstalledPrintersCMB.Name = "InstalledPrintersCMB";
            this.InstalledPrintersCMB.Size = new System.Drawing.Size(235, 21);
            this.InstalledPrintersCMB.TabIndex = 0;
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.Transparent;
            this.Save.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save.Location = new System.Drawing.Point(106, 289);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 1;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.InstalledPrintersCMB);
            this.groupBox1.Location = new System.Drawing.Point(20, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 74);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose printer";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(22, 19);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(115, "Medium"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(50, "Small")});
            this.radioGroup1.Size = new System.Drawing.Size(100, 75);
            this.radioGroup1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioGroup1);
            this.groupBox2.Location = new System.Drawing.Point(20, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Choose label size";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkEdit1);
            this.groupBox3.Location = new System.Drawing.Point(20, 209);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(266, 60);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Advanced";
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(20, 26);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Automatically print first GRN in the List";
            this.checkEdit1.Size = new System.Drawing.Size(231, 19);
            this.checkEdit1.TabIndex = 7;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // Printersetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(302, 323);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Printersetting";
            this.Text = "Printersetting";
            this.Load += new System.EventHandler(this.Printersetting_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox InstalledPrintersCMB;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
    }
}