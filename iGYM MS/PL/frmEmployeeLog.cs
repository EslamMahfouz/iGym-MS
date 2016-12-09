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
    public partial class frmEmployeeLog : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        public int EmployeeID;
        DataTable dtSrc = new DataTable();
        TimeSpan ts = new TimeSpan(0);

        public frmEmployeeLog()
        {
            InitializeComponent();
            dtSrc.Columns.Add("حضور");
            dtSrc.Columns.Add("إنصراف");
            dtSrc.Columns.Add("عدد الساعات");
            dtMonth.EditValue = DateTime.Now.Date;
        }

        private void dtMonth_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtSrc.Clear();
                DateTime dt = Convert.ToDateTime(dtMonth.EditValue);
                int year = dt.Year;
                int month = dt.Month;

                var log = from em in db.EmployeesDailies
                          where em.EmployeeID == EmployeeID
                          select new { حضور = em.DateComing, إنصراف = em.DateLeaving, الساعات = em.Hours };

                foreach (var item in log)
                {
                    DateTime dtTemp = item.حضور;
                    int yearTemp = dtTemp.Year;
                    int monthTemp = dtTemp.Month;

                    if (yearTemp == year && monthTemp == month)
                    {
                        dtSrc.Rows.Add(item.حضور, item.إنصراف, item.الساعات);
                    }
                }
                gridControl1.DataSource = dtSrc;


                ts = ts.Add(TimeSpan.Parse(dtSrc.Rows[0]["عدد الساعات"].ToString()));
                for (int i = 1; i < dtSrc.Rows.Count; i++)
                {
                    ts = ts.Add(TimeSpan.Parse(dtSrc.Rows[i]["عدد الساعات"].ToString()));
                }
                txtTotal.Text = ts.ToString();
                int hours = ts.Hours;
            }
            catch 
            {
                return;
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            double hours = ts.TotalHours;
            double price = Convert.ToDouble(txtPrice.Text);
            txtSalary.Text = (hours * price).ToString();
        }

        private void frmEmployeeLog_Load(object sender, EventArgs e)
        {
            dtMonth_EditValueChanged(sender, e);
        }
    }
}