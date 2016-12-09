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
using System.IO;

namespace iGYM_MS.PL
{
    public partial class frmDailyEmployees : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        public int EmployeeID;
        bool add = true;

        public void getEmployee()
        {
            var emp = db.Employees.Find(EmployeeID);
            txtName.Text = emp.EmployeeName;
            txtJob.Text = emp.Job.JobName;
            byte[] img = emp.Photo;
            MemoryStream ms = new MemoryStream(img);
            pBox.Image = Image.FromStream(ms);

            timer1.Enabled = true;

            var _emp = (from em in db.EmployeesDailies
                      where em.EmployeeID == EmployeeID
                      select em).ToList();

            if (_emp.Count == 0)
            {
                EDM.EmployeesDaily ed = new EDM.EmployeesDaily()
                {
                    EmployeeID = EmployeeID,
                    DateComing = DateTime.Now,
                    Editable = true,
                };
                db.EmployeesDailies.Add(ed);
            }
            else
            {
                foreach (var item in _emp)
                {
                    if (item.Editable == true)
                    {
                        dtComing.EditValue = item.DateComing;
                        dtLeaving.EditValue = DateTime.Now;
                        item.DateLeaving = Convert.ToDateTime(dtLeaving.EditValue);
                        item.Editable = false;
                        item.Hours = (item.DateLeaving - item.DateComing).ToString();
                        add = false;
                    }
                }
                if (add)
                {
                    EDM.EmployeesDaily ed = new EDM.EmployeesDaily()
                    {
                        EmployeeID = EmployeeID,
                        DateComing = DateTime.Now,
                        Editable = true,
                    };
                    db.EmployeesDailies.Add(ed);
                }
            }
            db.SaveChanges();
        }

        public frmDailyEmployees()
        {
            InitializeComponent();
            dtComing.EditValue = DateTime.Now;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}