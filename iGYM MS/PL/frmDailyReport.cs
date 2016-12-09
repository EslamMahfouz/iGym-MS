using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Windows.Forms;


namespace iGYM_MS.PL
{
    public partial class frmDailyReport : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        DateTime dt;
        string type;

        void labels(bool status)
        {
            labelControl2.Visible = status;
            labelControl3.Visible = status;
            labelControl4.Visible = status;
            txtTotal.Visible = status;
            txtMen.Visible = status;
            txtWomen.Visible = status;
        }
        public void fill()
        {
            gridControl1.DataSource = null;
            if (type == "المشتركين")
            {
                labels(true);
                var d = from x in db.TraineesDailies
                        let DateComing = EntityFunctions.CreateTime(x.Date.Hour, x.Date.Minute, x.Date.Second)
                        where EntityFunctions.TruncateTime(x.Date) == dt
                        select new { المشترك = x.Trainee.TraineeName, الإشتراك = x.TraineeProfile.Offer.OfferName, المحمول = x.Trainee.Phone, الوقت = DateComing, النوع = x.Trainee.Gender, };

                var m = from x in db.TraineesDailies
                        let DateComing = EntityFunctions.CreateTime(x.Date.Hour, x.Date.Minute, x.Date.Second)
                        where x.Date > dt && x.Trainee.Gender == "ذكر"
                        select new { المشترك = x.Trainee.TraineeName, الإشتراك = x.TraineeProfile.Offer.OfferName, المحمول = x.Trainee.Phone, الوقت = DateComing, النوع = x.Trainee.Gender };
                
                var w = from x in db.TraineesDailies
                        let DateComing = EntityFunctions.CreateTime(x.Date.Hour, x.Date.Minute, x.Date.Second)
                        where x.Date > dt && x.Trainee.Gender == "أنثي"
                        select new { المشترك = x.Trainee.TraineeName, الإشتراك = x.TraineeProfile.Offer.OfferName, المحمول = x.Trainee.Phone, الوقت = DateComing, النوع = x.Trainee.Gender };

                gridView1.PopulateColumns();
                gridControl1.DataSource = d.ToList();
                txtTotal.Text = (m.ToList().Count + w.ToList().Count).ToString();
                txtMen.Text = m.ToList().Count.ToString();
                txtWomen.Text = w.ToList().Count.ToString();
            }
            if (type == "الموظفين")
            {
                labels(false);
                var emp = from x in db.EmployeesDailies

                          let DateComing = EntityFunctions.CreateTime(x.DateComing.Hour, x.DateComing.Minute, x.DateComing.Second)
                          let DateLeaving = EntityFunctions.CreateTime(x.DateLeaving.Value.Hour, x.DateLeaving.Value.Minute, x.DateLeaving.Value.Second)

                          where x.DateComing > dt
                          select new { الموظف = x.Employee.EmployeeName, حضور = DateComing, إنصراف = DateLeaving, المحمول = x.Employee.Phone, الوظيفة = x.Employee.Job.JobName };
                gridView1.PopulateColumns();
                gridControl1.DataSource = emp.ToList();
            }
        }
        public frmDailyReport()
        {
            InitializeComponent();
            dt = dt.Date;
        }

        private void frmDailyReport_Load(object sender, EventArgs e)
        {
            dtDate.EditValue = DateTime.Now.Date;
            type = radioGroup1.Text;
            fill();
        }

        private void dtDate_EditValueChanged(object sender, EventArgs e)
        {
            dt = Convert.ToDateTime(dtDate.EditValue);
            dt = dt.Date;
            fill();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            type = radioGroup1.Text;
            fill();
        }
    }
}