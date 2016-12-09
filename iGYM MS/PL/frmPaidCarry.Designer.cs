namespace iGYM_MS.PL
{
    partial class frmPaidCarry
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
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.txtPaid = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtCarry = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCarry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.Location = new System.Drawing.Point(12, 136);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(146, 59);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "حفظ";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPaid
            // 
            this.txtPaid.Location = new System.Drawing.Point(12, 52);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtPaid.Properties.Appearance.Options.UseFont = true;
            this.txtPaid.Size = new System.Drawing.Size(146, 34);
            this.txtPaid.TabIndex = 8;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.labelControl2.Location = new System.Drawing.Point(164, 55);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(77, 29);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "المدفوع";
            // 
            // txtCarry
            // 
            this.txtCarry.Enabled = false;
            this.txtCarry.Location = new System.Drawing.Point(12, 12);
            this.txtCarry.Name = "txtCarry";
            this.txtCarry.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtCarry.Properties.Appearance.Options.UseFont = true;
            this.txtCarry.Size = new System.Drawing.Size(146, 34);
            this.txtCarry.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.labelControl1.Location = new System.Drawing.Point(164, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(80, 29);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "المتبقي";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(171, 98);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(117, 29);
            this.labelControl3.TabIndex = 51;
            this.labelControl3.Text = "طريقة الدفع";
            // 
            // radioGroup1
            // 
            this.radioGroup1.EditValue = "نقداً";
            this.radioGroup1.Location = new System.Drawing.Point(12, 92);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.radioGroup1.Properties.Appearance.Options.UseFont = true;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("نقداً", "نقداً"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("فيزا", "فيزا")});
            this.radioGroup1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioGroup1.Size = new System.Drawing.Size(146, 38);
            this.radioGroup1.TabIndex = 50;
            // 
            // frmPaidCarry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 203);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPaid);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtCarry);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPaidCarry";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "دفع متبقي";
            ((System.ComponentModel.ISupportInitialize)(this.txtPaid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCarry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.TextEdit txtPaid;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit txtCarry;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
    }
}