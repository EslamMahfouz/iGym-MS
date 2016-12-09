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
    public partial class FrmTraineeLog : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        public int TraineeID;
        DataTable dtSrc = new DataTable();

        public FrmTraineeLog()
        {
            InitializeComponent(); 
            dtSrc.Columns.Add("حضور");
            dtMonth.EditValue = DateTime.Now.Date;
        }

        public void dtMonth_EditValueChanged(object sender, EventArgs e)
        {
            dtSrc.Clear();
            DateTime dt = Convert.ToDateTime(dtMonth.EditValue);
            int year = dt.Year;
            int month = dt.Month;

            var log = from tr in db.TraineesDailies
                      where tr.TraineeID == TraineeID
                      select new { حضور = tr.Date};

            foreach (var item in log)
            {
                DateTime dtTemp = item.حضور;
                int yearTemp = dtTemp.Year;
                int monthTemp = dtTemp.Month;

                if (yearTemp == year && monthTemp == month)
                    dtSrc.Rows.Add(item.حضور);
            }
            gridControl1.DataSource = dtSrc;
        }

        private void FrmTraineeLog_Load(object sender, EventArgs e)
        {
            dtMonth_EditValueChanged(sender, e);
        }
    }
}