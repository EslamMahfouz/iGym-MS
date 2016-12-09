namespace iGYM_MS.PL
{
    partial class frmChangeID
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangeID));
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtNew = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNew.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl20
            // 
            this.labelControl20.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl20.Location = new System.Drawing.Point(12, 11);
            this.labelControl20.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(271, 29);
            this.labelControl20.TabIndex = 27;
            this.labelControl20.Text = "من فضلك مرر الكارت الجديد";
            // 
            // btnSave
            // 
            this.btnSave.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSave.Location = new System.Drawing.Point(28, 84);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(220, 49);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "حفظ";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtNew
            // 
            this.txtNew.EnterMoveNextControl = true;
            this.txtNew.Location = new System.Drawing.Point(12, 46);
            this.txtNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNew.Name = "txtNew";
            this.txtNew.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNew.Properties.Appearance.Options.UseFont = true;
            this.txtNew.Properties.ReadOnly = true;
            this.txtNew.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNew.Size = new System.Drawing.Size(271, 34);
            this.txtNew.TabIndex = 30;
            // 
            // frmChangeID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 140);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.labelControl20);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangeID";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تغيير رقم الكارت";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChangeID_FormClosing);
            this.Load += new System.EventHandler(this.frmChangeID_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNew.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtNew;
    }
}