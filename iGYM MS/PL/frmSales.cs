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
using System.Data.Objects;

namespace iGYM_MS.PL
{
    public partial class frmSales : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();

        public int EmployeeID;

        public frmSales()
        {
            InitializeComponent();
            dtBegin.EditValue = DateTime.Now.Date;
            dtEnd.EditValue = DateTime.Now.Date;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DateTime dtbegin = Convert.ToDateTime(dtBegin.EditValue);
            DateTime dtend = Convert.ToDateTime(dtEnd.EditValue);

            var sales = from s in db.TraineeProfiles
                        where s.EmployeeID == EmployeeID  && s.From <= dtend && s.From >= dtbegin && s.Canceled == false
                        select new { إسم_المشترك = s.Trainee.TraineeName, الإشتراك = s.Offer.OfferName, التاريخ = s.From, السعر = s.Price };
            gridControl1.DataSource = sales.ToList();
            gridView1.PopulateColumns();
            gridView1.Columns["السعر"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "السعر", "الإجمالي ={0:n2}");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void frmSales_Load(object sender, EventArgs e)
        {
            btnShow_Click(sender, e);
        }
    }
}