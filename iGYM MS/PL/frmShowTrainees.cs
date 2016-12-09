using System;
using System.Collections.Generic;
using System.Linq;


namespace iGYM_MS.PL
{
    public partial class frmShowTrainees : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();

        public frmShowTrainees()
        {
            InitializeComponent();
        }

        private void frmShowTrainees_Load(object sender, EventArgs e)
        {
            var trainees = from t in db.TraineeProfiles
                           select new { م = t.Trainee.TraineeID, الإسم = t.Trainee.TraineeName, الجنس = t.Trainee.Gender, الجنسية = t.Trainee.Nationality, الإنضمام = t.Trainee.JoiningDate, الهاتف = t.Trainee.Phone, العرض = t.Offer.OfferName, من = t.From, إلي = t.To, السعر = t.Price, دفع = t.Paid, متبقي = t.Carry, نشط = t.Active, ملغي = t.Canceled, freezed = t.Frozen, transfered = t.Transfered };
            gridControl1.DataSource = trainees.ToList();
            gridView1.PopulateColumns();
            gridView1.Columns["السعر"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "السعر", "الإجمالي ={0:n2}");
            gridView1.Columns["دفع"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "دفع", "الإجمالي ={0:n2}");
            gridView1.Columns["متبقي"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "متبقي", "الإجمالي ={0:n2}");
            gridView1.Columns["السعر"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            gridView1.Columns["السعر"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            gridView1.Columns["دفع"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            gridView1.Columns["دفع"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            gridView1.Columns["متبقي"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            gridView1.Columns["متبقي"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            gridView1.Columns["م"].Visible = false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
                e.Info.Kind = DevExpress.Utils.Drawing.IndicatorKind.Row;
            }
        }
    }
}