namespace iGYM_MS.PL
{
    partial class frmDailyEmployees
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDailyEmployees));
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtComing = new DevExpress.XtraEditors.DateEdit();
            this.dtLeaving = new DevExpress.XtraEditors.DateEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtJob = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.pBox = new DevExpress.XtraEditors.PictureEdit();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtComing.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtComing.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLeaving.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLeaving.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJob.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl19
            // 
            this.labelControl19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl19.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl19.Location = new System.Drawing.Point(277, 269);
            this.labelControl19.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(61, 29);
            this.labelControl19.TabIndex = 26;
            this.labelControl19.Text = "الإسم";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Location = new System.Drawing.Point(274, 341);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(67, 29);
            this.labelControl6.TabIndex = 30;
            this.labelControl6.Text = "الحضور";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(266, 377);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(83, 29);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "الإنصراف";
            // 
            // dtComing
            // 
            this.dtComing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtComing.EditValue = null;
            this.dtComing.Location = new System.Drawing.Point(29, 341);
            this.dtComing.Name = "dtComing";
            this.dtComing.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dtComing.Properties.Appearance.Options.UseFont = true;
            this.dtComing.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtComing.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtComing.Properties.CalendarTimeProperties.Mask.EditMask = "d";
            this.dtComing.Properties.Mask.EditMask = "g";
            this.dtComing.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtComing.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtComing.Size = new System.Drawing.Size(235, 30);
            this.dtComing.TabIndex = 35;
            // 
            // dtLeaving
            // 
            this.dtLeaving.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtLeaving.EditValue = null;
            this.dtLeaving.Location = new System.Drawing.Point(29, 377);
            this.dtLeaving.Name = "dtLeaving";
            this.dtLeaving.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.dtLeaving.Properties.Appearance.Options.UseFont = true;
            this.dtLeaving.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtLeaving.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtLeaving.Properties.Mask.EditMask = "g";
            this.dtLeaving.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtLeaving.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtLeaving.Size = new System.Drawing.Size(235, 30);
            this.dtLeaving.TabIndex = 36;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(30, 269);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtName.Properties.Appearance.Options.UseFont = true;
            this.txtName.Size = new System.Drawing.Size(234, 30);
            this.txtName.TabIndex = 37;
            // 
            // txtJob
            // 
            this.txtJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJob.Location = new System.Drawing.Point(30, 305);
            this.txtJob.Name = "txtJob";
            this.txtJob.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtJob.Properties.Appearance.Options.UseFont = true;
            this.txtJob.Size = new System.Drawing.Size(234, 30);
            this.txtJob.TabIndex = 39;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(270, 305);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 29);
            this.labelControl2.TabIndex = 38;
            this.labelControl2.Text = "الوظيفة";
            // 
            // pBox
            // 
            this.pBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pBox.EditValue = ((object)(resources.GetObject("pBox.EditValue")));
            this.pBox.Location = new System.Drawing.Point(12, 12);
            this.pBox.Name = "pBox";
            this.pBox.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pBox.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pBox.Size = new System.Drawing.Size(357, 251);
            this.pBox.TabIndex = 40;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmDailyEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 418);
            this.Controls.Add(this.pBox);
            this.Controls.Add(this.txtJob);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.dtLeaving);
            this.Controls.Add(this.dtComing);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl19);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDailyEmployees";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تحضير يومي للموظفين";
            ((System.ComponentModel.ISupportInitialize)(this.dtComing.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtComing.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLeaving.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtLeaving.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJob.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtComing;
        private DevExpress.XtraEditors.DateEdit dtLeaving;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PictureEdit pBox;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtJob;
        private System.Windows.Forms.Timer timer1;
    }
}