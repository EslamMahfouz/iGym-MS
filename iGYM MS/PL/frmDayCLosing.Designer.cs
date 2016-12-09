namespace iGYM_MS.PL
{
    partial class frmDayCLosing
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
            this.rgMode = new DevExpress.XtraEditors.RadioGroup();
            this.timeEdit = new DevExpress.XtraEditors.TimeEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.rgMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Location = new System.Drawing.Point(269, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(136, 24);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "طريقة غلق اليوم";
            // 
            // rgMode
            // 
            this.rgMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rgMode.EditValue = "manual";
            this.rgMode.Location = new System.Drawing.Point(12, 12);
            this.rgMode.Name = "rgMode";
            this.rgMode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.rgMode.Properties.Appearance.Options.UseFont = true;
            this.rgMode.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("manual", "manual"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Automatic", "Automatic")});
            this.rgMode.Size = new System.Drawing.Size(251, 36);
            this.rgMode.TabIndex = 1;
            this.rgMode.SelectedIndexChanged += new System.EventHandler(this.rgMode_SelectedIndexChanged);
            // 
            // timeEdit
            // 
            this.timeEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeEdit.EditValue = new System.DateTime(2016, 11, 18, 0, 0, 0, 0);
            this.timeEdit.Enabled = false;
            this.timeEdit.Location = new System.Drawing.Point(12, 54);
            this.timeEdit.Name = "timeEdit";
            this.timeEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.timeEdit.Properties.Appearance.Options.UseFont = true;
            this.timeEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEdit.Size = new System.Drawing.Size(251, 30);
            this.timeEdit.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(12, 90);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(251, 68);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "حفظ";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmDayCLosing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 163);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.timeEdit);
            this.Controls.Add(this.rgMode);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmDayCLosing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إعدادات غلق اليوم";
            this.Load += new System.EventHandler(this.frmDayCLosing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.RadioGroup rgMode;
        private DevExpress.XtraEditors.TimeEdit timeEdit;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}