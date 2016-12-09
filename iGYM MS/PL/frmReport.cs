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
    public partial class frmReport : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        public string type;
        DateTime fromDate, toDate;

        public frmReport()
        {
            InitializeComponent();
            dtFrom.EditValue = DateTime.Now.Date;
            dtTo.EditValue = DateTime.Now.Date;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (type == "income")
            {
                var cash = from c in db.CashIns
                           where ((EntityFunctions.TruncateTime(c.Date)) >= fromDate && (EntityFunctions.TruncateTime(c.Date)) <= toDate) && c.Desc != "دعوة" && c.Desc != "زيارة" && c.Desc != "عرض" && c.Desc != "حذف مشترك" && c.Desc != "تجميد إشتراك" && c.Desc != "إلغاء تجميد إشتراك"
                           select new { التاريخ = c.Date, القسم = c.Category.CategoryName, الوصف = c.Desc, رقم_الإيصال = c.RecieptID, المبلغ = c.Price, الدفع = c.Type};
                gridControl1.DataSource = cash.ToList();
                gridView1.PopulateColumns();
                gridView1.Columns["المبلغ"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "المبلغ", "الإجمالي ={0:n2}");
            }
            else if (type == "outcome")
            {
                var cash = from c in db.Outcomes
                           where ((EntityFunctions.TruncateTime(c.Date)) >= fromDate && (EntityFunctions.TruncateTime(c.Date)) <= toDate)
                           select new { التاريخ = c.Date, مصروف = c.Category.CategoryName, الوصف = c.Desc, رقم_الإيصال = c.RecieptID, المبلغ = c.Price };
                gridControl1.DataSource = cash.ToList();
                gridView1.PopulateColumns();
                gridView1.Columns["المبلغ"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "المبلغ", "الإجمالي ={0:n2}");
            }
        }

        private void dtFrom_EditValueChanged(object sender, EventArgs e)
        {
            fromDate = Convert.ToDateTime(dtFrom.EditValue);
        }

        private void dtTo_EditValueChanged(object sender, EventArgs e)
        {
            toDate = Convert.ToDateTime(dtTo.EditValue);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            if(type == "outcome")
                this.Text = "تقرير مصروفات";
            btnShow_Click(sender, e);
        }
    }
}