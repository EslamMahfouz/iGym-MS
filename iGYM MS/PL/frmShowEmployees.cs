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
    public partial class frmShowEmployees : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();

        public frmShowEmployees()
        {
            InitializeComponent();
        }

        private void frmShowEmployees_Load(object sender, EventArgs e)
        {
            var employees = from emp in db.Employees
                            select new { م = emp.EmployeeID, الإسم = emp.EmployeeName, الهاتف = emp.Phone, الوظيفة = emp.Job.JobName };
            gridControl1.DataSource = employees.ToList();
        }
    }
}