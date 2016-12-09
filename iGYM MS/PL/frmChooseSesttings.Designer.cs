namespace iGYM_MS.PL
{
    partial class frmChooseSesttings
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.frmShowCategory = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddCategory = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnAddOutCome = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl1.Controls.Add(this.frmShowCategory);
            this.groupControl1.Controls.Add(this.simpleButton2);
            this.groupControl1.Controls.Add(this.btnAddCategory);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(439, 180);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "الإيرادات";
            // 
            // frmShowCategory
            // 
            this.frmShowCategory.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.frmShowCategory.Appearance.Options.UseFont = true;
            this.frmShowCategory.Location = new System.Drawing.Point(5, 108);
            this.frmShowCategory.Name = "frmShowCategory";
            this.frmShowCategory.Size = new System.Drawing.Size(420, 66);
            this.frmShowCategory.TabIndex = 2;
            this.frmShowCategory.Text = "عرض قسم + أصنافه";
            this.frmShowCategory.Click += new System.EventHandler(this.frmShowCategory_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(5, 36);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(207, 66);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "إضافة أصناف البيع";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnAddCategory.Appearance.Options.UseFont = true;
            this.btnAddCategory.Location = new System.Drawing.Point(218, 36);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(207, 66);
            this.btnAddCategory.TabIndex = 0;
            this.btnAddCategory.Text = "إضافة أقسام مبيعات";
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl2.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl2.Controls.Add(this.btnAddOutCome);
            this.groupControl2.Location = new System.Drawing.Point(12, 198);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(439, 107);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "المصروفات";
            // 
            // btnAddOutCome
            // 
            this.btnAddOutCome.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnAddOutCome.Appearance.Options.UseFont = true;
            this.btnAddOutCome.Location = new System.Drawing.Point(111, 36);
            this.btnAddOutCome.Name = "btnAddOutCome";
            this.btnAddOutCome.Size = new System.Drawing.Size(207, 66);
            this.btnAddOutCome.TabIndex = 1;
            this.btnAddOutCome.Text = "إضافة حساب مصروف";
            this.btnAddOutCome.Click += new System.EventHandler(this.btnAddOutCome_Click);
            // 
            // frmChooseSesttings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 316);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChooseSesttings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "إعدادات الحسابات";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton btnAddCategory;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnAddOutCome;
        private DevExpress.XtraEditors.SimpleButton frmShowCategory;
    }
}