namespace iGYM_MS.PL
{
    partial class frmTraffic
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
            this.dtDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtCredit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtOutCome = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtIncome = new DevExpress.XtraEditors.TextEdit();
            this.btnShow = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCredit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutCome.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIncome.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dtDate
            // 
            this.dtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDate.EditValue = null;
            this.dtDate.Location = new System.Drawing.Point(118, 9);
            this.dtDate.Name = "dtDate";
            this.dtDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.dtDate.Properties.Appearance.Options.UseFont = true;
            this.dtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtDate.Size = new System.Drawing.Size(181, 40);
            this.dtDate.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.labelControl1.Location = new System.Drawing.Point(305, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(262, 33);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "عرض حركة النقدية ليوم";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.labelControl2.Location = new System.Drawing.Point(298, 67);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(183, 33);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "إجمالي الإيرادات";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 18F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl1.Controls.Add(this.txtCredit);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txtOutCome);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtIncome);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Location = new System.Drawing.Point(11, 61);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(556, 211);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "حركة النقدية";
            // 
            // txtCredit
            // 
            this.txtCredit.Location = new System.Drawing.Point(63, 156);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.txtCredit.Properties.Appearance.Options.UseFont = true;
            this.txtCredit.Properties.ReadOnly = true;
            this.txtCredit.Size = new System.Drawing.Size(213, 40);
            this.txtCredit.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.labelControl4.Location = new System.Drawing.Point(326, 159);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(127, 33);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "صافي الربح";
            // 
            // txtOutCome
            // 
            this.txtOutCome.Location = new System.Drawing.Point(63, 110);
            this.txtOutCome.Name = "txtOutCome";
            this.txtOutCome.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.txtOutCome.Properties.Appearance.Options.UseFont = true;
            this.txtOutCome.Properties.ReadOnly = true;
            this.txtOutCome.Size = new System.Drawing.Size(213, 40);
            this.txtOutCome.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.labelControl3.Location = new System.Drawing.Point(286, 113);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(207, 33);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "إجمالي المصروفات";
            // 
            // txtIncome
            // 
            this.txtIncome.Location = new System.Drawing.Point(63, 64);
            this.txtIncome.Name = "txtIncome";
            this.txtIncome.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.txtIncome.Properties.Appearance.Options.UseFont = true;
            this.txtIncome.Properties.ReadOnly = true;
            this.txtIncome.Size = new System.Drawing.Size(213, 40);
            this.txtIncome.TabIndex = 3;
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnShow.Appearance.Options.UseFont = true;
            this.btnShow.Location = new System.Drawing.Point(9, 3);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(101, 52);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "عرض";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // frmTraffic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 276);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dtDate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTraffic";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "حركة النقدية";
            this.Load += new System.EventHandler(this.frmTraffic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCredit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutCome.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIncome.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dtDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtIncome;
        private DevExpress.XtraEditors.TextEdit txtCredit;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtOutCome;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnShow;
    }
}