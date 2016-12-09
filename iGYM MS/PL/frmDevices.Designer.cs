namespace iGYM_MS.PL
{
    partial class frmDevices
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbFirst = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbSecond = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFirst.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSecond.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.labelControl1.Location = new System.Drawing.Point(350, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(257, 33);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "الجهاز الأول متصل علي";
            // 
            // cmbFirst
            // 
            this.cmbFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFirst.Location = new System.Drawing.Point(154, 14);
            this.cmbFirst.Name = "cmbFirst";
            this.cmbFirst.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.cmbFirst.Properties.Appearance.Options.UseFont = true;
            this.cmbFirst.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFirst.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbFirst.Size = new System.Drawing.Size(190, 40);
            this.cmbFirst.TabIndex = 1;
            // 
            // cmbSecond
            // 
            this.cmbSecond.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSecond.Location = new System.Drawing.Point(154, 65);
            this.cmbSecond.Name = "cmbSecond";
            this.cmbSecond.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.cmbSecond.Properties.Appearance.Options.UseFont = true;
            this.cmbSecond.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSecond.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbSecond.Size = new System.Drawing.Size(190, 40);
            this.cmbSecond.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.labelControl2.Location = new System.Drawing.Point(350, 68);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(273, 33);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "الجهاز الثاني متصل علي";
            // 
            // btnSave1
            // 
            this.btnSave1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave1.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btnSave1.Appearance.Options.UseFont = true;
            this.btnSave1.Location = new System.Drawing.Point(5, 12);
            this.btnSave1.Name = "btnSave1";
            this.btnSave1.Size = new System.Drawing.Size(145, 93);
            this.btnSave1.TabIndex = 4;
            this.btnSave1.Text = "Save";
            this.btnSave1.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmDevices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 117);
            this.Controls.Add(this.btnSave1);
            this.Controls.Add(this.cmbSecond);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cmbFirst);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDevices";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إعدادات الأجهزة";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDevices_FormClosing);
            this.Load += new System.EventHandler(this.frmDevices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbFirst.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSecond.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbFirst;
        private DevExpress.XtraEditors.ComboBoxEdit cmbSecond;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnSave1;






    }
}