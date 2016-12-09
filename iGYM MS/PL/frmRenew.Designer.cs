namespace iGYM_MS.PL
{
    partial class frmRenew
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRenew));
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.txtCarry = new DevExpress.XtraEditors.TextEdit();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.dtEnd = new DevExpress.XtraEditors.DateEdit();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.dtBegin = new DevExpress.XtraEditors.DateEdit();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.cmbOffers = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.txtPaid = new DevExpress.XtraEditors.TextEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.valOffer = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cmbTrainers = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cmbEmployees = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCarry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBegin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBegin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOffers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valOffer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTrainers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEmployees.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl3
            // 
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 14F);
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl3.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl3.Controls.Add(this.cmbEmployees);
            this.groupControl3.Controls.Add(this.cmbTrainers);
            this.groupControl3.Controls.Add(this.labelControl2);
            this.groupControl3.Controls.Add(this.labelControl3);
            this.groupControl3.Controls.Add(this.labelControl1);
            this.groupControl3.Controls.Add(this.radioGroup1);
            this.groupControl3.Controls.Add(this.txtCarry);
            this.groupControl3.Controls.Add(this.labelControl22);
            this.groupControl3.Controls.Add(this.dtEnd);
            this.groupControl3.Controls.Add(this.labelControl21);
            this.groupControl3.Controls.Add(this.dtBegin);
            this.groupControl3.Controls.Add(this.labelControl20);
            this.groupControl3.Controls.Add(this.cmbOffers);
            this.groupControl3.Controls.Add(this.labelControl14);
            this.groupControl3.Controls.Add(this.txtPaid);
            this.groupControl3.Controls.Add(this.labelControl17);
            this.groupControl3.Controls.Add(this.txtPrice);
            this.groupControl3.Controls.Add(this.labelControl16);
            this.groupControl3.Location = new System.Drawing.Point(12, 11);
            this.groupControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(666, 241);
            this.groupControl3.TabIndex = 27;
            this.groupControl3.Text = "بيانات الإشتراك";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(532, 165);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(117, 29);
            this.labelControl1.TabIndex = 49;
            this.labelControl1.Text = "طريقة الدفع";
            // 
            // radioGroup1
            // 
            this.radioGroup1.EditValue = "نقداً";
            this.radioGroup1.Location = new System.Drawing.Point(332, 159);
            this.radioGroup1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.radioGroup1.Properties.Appearance.Options.UseFont = true;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("نقداً", "نقداً"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("فيزا", "فيزا")});
            this.radioGroup1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioGroup1.Size = new System.Drawing.Size(188, 38);
            this.radioGroup1.TabIndex = 48;
            // 
            // txtCarry
            // 
            this.txtCarry.EnterMoveNextControl = true;
            this.txtCarry.Location = new System.Drawing.Point(8, 119);
            this.txtCarry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCarry.Name = "txtCarry";
            this.txtCarry.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarry.Properties.Appearance.Options.UseFont = true;
            this.txtCarry.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCarry.Size = new System.Drawing.Size(165, 34);
            this.txtCarry.TabIndex = 41;
            // 
            // labelControl22
            // 
            this.labelControl22.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl22.Location = new System.Drawing.Point(210, 122);
            this.labelControl22.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(80, 29);
            this.labelControl22.TabIndex = 42;
            this.labelControl22.Text = "المتبقي";
            // 
            // dtEnd
            // 
            this.dtEnd.EditValue = null;
            this.dtEnd.EnterMoveNextControl = true;
            this.dtEnd.Location = new System.Drawing.Point(332, 121);
            this.dtEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd.Properties.Appearance.Options.UseFont = true;
            this.dtEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEnd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtEnd.Size = new System.Drawing.Size(189, 34);
            this.dtEnd.TabIndex = 39;
            // 
            // labelControl21
            // 
            this.labelControl21.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl21.Location = new System.Drawing.Point(532, 124);
            this.labelControl21.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(117, 29);
            this.labelControl21.TabIndex = 40;
            this.labelControl21.Text = "تاريخ النهاية";
            // 
            // dtBegin
            // 
            this.dtBegin.EditValue = null;
            this.dtBegin.Enabled = false;
            this.dtBegin.EnterMoveNextControl = true;
            this.dtBegin.Location = new System.Drawing.Point(332, 81);
            this.dtBegin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtBegin.Name = "dtBegin";
            this.dtBegin.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtBegin.Properties.Appearance.Options.UseFont = true;
            this.dtBegin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtBegin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtBegin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtBegin.Size = new System.Drawing.Size(189, 34);
            this.dtBegin.TabIndex = 25;
            this.dtBegin.Leave += new System.EventHandler(this.dtBegin_Leave);
            // 
            // labelControl20
            // 
            this.labelControl20.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl20.Location = new System.Drawing.Point(532, 84);
            this.labelControl20.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(116, 29);
            this.labelControl20.TabIndex = 26;
            this.labelControl20.Text = "تاريخ البداية";
            // 
            // cmbOffers
            // 
            this.cmbOffers.Location = new System.Drawing.Point(332, 46);
            this.cmbOffers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbOffers.Name = "cmbOffers";
            this.cmbOffers.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cmbOffers.Properties.Appearance.Options.UseFont = true;
            this.cmbOffers.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.cmbOffers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbOffers.Properties.NullText = "";
            this.cmbOffers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbOffers.Size = new System.Drawing.Size(189, 30);
            this.cmbOffers.TabIndex = 38;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "برجاء إختيار العرض";
            this.valOffer.SetValidationRule(this.cmbOffers, conditionValidationRule1);
            this.cmbOffers.EditValueChanged += new System.EventHandler(this.cmbOffers_EditValueChanged);
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl14.Location = new System.Drawing.Point(527, 46);
            this.labelControl14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(127, 29);
            this.labelControl14.TabIndex = 37;
            this.labelControl14.Text = "نوع الإشتراك";
            // 
            // txtPaid
            // 
            this.txtPaid.EditValue = 0D;
            this.txtPaid.EnterMoveNextControl = true;
            this.txtPaid.Location = new System.Drawing.Point(8, 79);
            this.txtPaid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaid.Properties.Appearance.Options.UseFont = true;
            this.txtPaid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPaid.Size = new System.Drawing.Size(165, 34);
            this.txtPaid.TabIndex = 19;
            this.txtPaid.EditValueChanged += new System.EventHandler(this.txtPaid_EditValueChanged);
            // 
            // labelControl17
            // 
            this.labelControl17.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl17.Location = new System.Drawing.Point(212, 82);
            this.labelControl17.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(77, 29);
            this.labelControl17.TabIndex = 36;
            this.labelControl17.Text = "المدفوع";
            // 
            // txtPrice
            // 
            this.txtPrice.EnterMoveNextControl = true;
            this.txtPrice.Location = new System.Drawing.Point(8, 39);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Properties.Appearance.Options.UseFont = true;
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.Size = new System.Drawing.Size(165, 34);
            this.txtPrice.TabIndex = 18;
            // 
            // labelControl16
            // 
            this.labelControl16.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl16.Location = new System.Drawing.Point(180, 43);
            this.labelControl16.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(140, 29);
            this.labelControl16.TabIndex = 30;
            this.labelControl16.Text = "سعر الإشتراك";
            // 
            // btnAdd
            // 
            this.btnAdd.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnAdd.Location = new System.Drawing.Point(12, 269);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(189, 49);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "تجديد";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(175, 202);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(151, 29);
            this.labelControl2.TabIndex = 50;
            this.labelControl2.Text = "موظف المبيعات";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(558, 202);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(69, 29);
            this.labelControl3.TabIndex = 51;
            this.labelControl3.Text = "المدرب";
            // 
            // cmbTrainers
            // 
            this.cmbTrainers.Location = new System.Drawing.Point(332, 202);
            this.cmbTrainers.Name = "cmbTrainers";
            this.cmbTrainers.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cmbTrainers.Properties.Appearance.Options.UseFont = true;
            this.cmbTrainers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTrainers.Properties.NullText = "";
            this.cmbTrainers.Properties.View = this.searchLookUpEdit1View;
            this.cmbTrainers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbTrainers.Size = new System.Drawing.Size(188, 30);
            this.cmbTrainers.TabIndex = 52;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // cmbEmployees
            // 
            this.cmbEmployees.Location = new System.Drawing.Point(8, 202);
            this.cmbEmployees.Name = "cmbEmployees";
            this.cmbEmployees.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cmbEmployees.Properties.Appearance.Options.UseFont = true;
            this.cmbEmployees.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbEmployees.Properties.NullText = "";
            this.cmbEmployees.Properties.View = this.gridView1;
            this.cmbEmployees.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbEmployees.Size = new System.Drawing.Size(165, 30);
            this.cmbEmployees.TabIndex = 53;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // frmRenew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 325);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupControl3);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRenew";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تجديد الإشتراك";
            this.Load += new System.EventHandler(this.frmRenew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCarry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBegin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBegin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOffers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valOffer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTrainers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEmployees.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.XtraEditors.DateEdit dtEnd;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.LookUpEdit cmbOffers;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        public DevExpress.XtraEditors.TextEdit txtPaid;
        public DevExpress.XtraEditors.DateEdit dtBegin;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        public DevExpress.XtraEditors.TextEdit txtCarry;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider valOffer;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbEmployees;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SearchLookUpEdit cmbTrainers;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}