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
using iGYM_MS.EDM;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace iGYM_MS.PL
{
    public partial class frmAddUser : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();

        public frmAddUser()
        {
            InitializeComponent();
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gymDataSet1.UsersAccess' table. You can move, or remove it, as needed.
            this.usersAccessTableAdapter.Fill(this.gymDataSet1.UsersAccess);
            var employees = from emp in db.Employees
                            select new { م = emp.EmployeeID, الإسم = emp.EmployeeName, الهاتف = emp.Phone, العنوان = emp.Address };

            cmbEmployees.Properties.DataSource = employees.ToList();
            cmbEmployees.Properties.DisplayMember = "الإسم";
            cmbEmployees.Properties.ValueMember = "م";
            cmbEmployees.Properties.PopulateViewColumns();
            cmbEmployees.Properties.View.Columns["م"].Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        { 
            int EmployeeID = Convert.ToInt32(cmbEmployees.EditValue);
            var x = db.Users.Find(EmployeeID);
            if (x != null)
            {
                XtraMessageBox.Show("هذا الموظف مسجل كمستخدم بالفعل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!valPassword.Validate())
            { return; }
            
            var emp = db.Employees.Find(EmployeeID);
            User u = new User()
            {
                EmployeeID = Convert.ToInt32(cmbEmployees.EditValue),
                UserName = cmbEmployees.Text,
                Password = txtPassword.Text,
                CardNumber = emp.CardNumber,
            };
            db.Users.Add(u);
            db.SaveChanges();

            UsersAccess ua = new UsersAccess()
            {
                UserID = u.EmployeeID,
                AddNewTrainee = Convert.ToBoolean(AddNewTraineeCheckEdit.EditValue),
                SearchMen = Convert.ToBoolean(SearchMenCheckEdit.EditValue),
                SearchWomen = Convert.ToBoolean(SearchWomenCheckEdit.EditValue),
                AddOffer = Convert.ToBoolean(AddOfferCheckEdit.EditValue),
                EditOffer = Convert.ToBoolean(EditOfferCheckEdit.EditValue),
                ShowTrainees = Convert.ToBoolean(ShowTraineesCheckEdit.EditValue),
                CancelTraineeProfile = Convert.ToBoolean(CancelTraineeProfileCheckEdit.EditValue),
                AddIncomeOutCome = Convert.ToBoolean(AddIncomeOutComeCheckEdit.EditValue),
                Settings = Convert.ToBoolean(SettingsCheckEdit.EditValue),
                EditTraineeProfile = Convert.ToBoolean(EditTraineeProfileCheckEdit.EditValue),
                Reports = Convert.ToBoolean(ReportsCheckEdit.EditValue),
                NewIncomeOutCome = Convert.ToBoolean(NewIncomeOutComeCheckEdit.EditValue),
                AddNewUser = Convert.ToBoolean(AddNewUserCheckEdit.EditValue),
                EditUsers = Convert.ToBoolean(EditUsersCheckEdit.EditValue),
                DeleteTrainee = Convert.ToBoolean(DeleteTraineeCheckEdit.EditValue),
                FreezeTrainee = Convert.ToBoolean(FreezeTraineeCheckEdit.EditValue)
            };
            db.UsersAccesses.Add(ua);
            db.SaveChanges();
            XtraMessageBox.Show("تم إضافة المستخدم", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

    }
}