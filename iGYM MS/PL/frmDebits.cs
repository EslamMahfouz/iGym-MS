using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace iGYM_MS.PL
{
    public partial class frmDebits : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();

        public frmDebits()
        {
            InitializeComponent();
        }

        private void frmDebits_Load(object sender, EventArgs e)
        {
            var tp = from x in db.TraineeProfiles
                     where x.Carry > 0
                     select new { الإسم = x.Trainee.TraineeName, العرض = x.Offer.OfferName, من = x.From, إلي = x.To, المتبقي = x.Carry, نشط = x.Active };
            gridControl1.DataSource = tp.ToList();
            gridView1.PopulateColumns();
            gridView1.Columns["المتبقي"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "المتبقي", "الإجمالي ={0:n2}");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
        }
    }
}