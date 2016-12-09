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
    public partial class frmShowUser : DevExpress.XtraEditors.XtraForm
    {
        GymEntities1 db = new GymEntities1();
        public int UserID;
        public SerialPort sp = new SerialPort(Properties.Settings.Default.FirstDevice);
        public string cardNumber;

        public void getUser()
        {
            var user = db.Users.Find(UserID);
            txtName.Text = user.UserName;
            cmbUsers.EditValue = UserID;
            CardNumberTextEdit.Text = user.CardNumber;
            AddNewTraineeCheckEdit.EditValue = user.UsersAccess.AddNewTrainee;
            SearchMenCheckEdit.EditValue = user.UsersAccess.SearchMen;
            SearchWomenCheckEdit.EditValue = user.UsersAccess.SearchWomen;
            AddOfferCheckEdit.EditValue = user.UsersAccess.AddOffer;
            EditOfferCheckEdit.EditValue = user.UsersAccess.EditOffer;
            ShowTraineesCheckEdit.EditValue = user.UsersAccess.ShowTrainees;
            CancelTraineeProfileCheckEdit.EditValue = user.UsersAccess.CancelTraineeProfile;
            AddIncomeOutComeCheckEdit.EditValue = user.UsersAccess.AddIncomeOutCome;
            SettingsCheckEdit.EditValue = user.UsersAccess.Settings;
            EditTraineeProfileCheckEdit.EditValue = user.UsersAccess.EditTraineeProfile;
            ReportsCheckEdit.EditValue = user.UsersAccess.Reports;
            NewIncomeOutComeCheckEdit.EditValue = user.UsersAccess.NewIncomeOutCome;
            AddNewUserCheckEdit.EditValue = user.UsersAccess.AddNewUser;
            EditUsersCheckEdit.EditValue = user.UsersAccess.EditUsers;
            DeleteTraineeCheckEdit.EditValue = user.UsersAccess.DeleteTrainee;
            FreezeTraineeCheckEdit.EditValue = user.UsersAccess.FreezeTrainee;
        }
        public frmShowUser()
        {
            InitializeComponent();
        }

        void chkCardNumber()
        {
            var x = (from y in db.Employees
                     where y.CardNumber == cardNumber
                     select y).ToList();

            var xx = (from yy in db.Trainees
                      where yy.CardNumber == cardNumber
                      select yy).ToList();

            var xxx = (from yyy in db.Users
                       where yyy.CardNumber == cardNumber
                       select yyy).ToList();

            if (xx.Count>0)
            {
                sp.Write("error");
            }
            else if (xxx.Count > 0)
            {
                var user = from u in db.Users
                              where u.CardNumber == cardNumber
                              select u;
                foreach (var item in user)
                {
                    UserID = item.EmployeeID;
                    break;
                }

                btnDelete.Enabled = true;
                btnChangePassword.Enabled = true;
                btnSave.Enabled = true;
                getUser();
            }
            else
                sp.Write("error");
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            cardNumber = sp.ReadLine();
            Thread.Sleep(100);

            if (this.InvokeRequired)
            {
                this.Invoke((Action)chkCardNumber);
            }
        }

        private void frmShowUser_Load(object sender, EventArgs e)
        {
            string[] comPorts = SerialPort.GetPortNames();
            foreach (string com in comPorts)
            {
                if (Properties.Settings.Default.FirstDevice == com)
                {
                    frmMain.sp1.Dispose();
                    frmMain.sp1.Close();
                    sp.BaudRate = 9600;
                    sp.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    sp.Open();
                    sp.Write("connected");
                }
            }

            var users = from u in db.Users
                        select new { م = u.EmployeeID, الإسم = u.UserName };
            cmbUsers.Properties.DataSource = users.ToList();
            cmbUsers.Properties.PopulateViewColumns();
            cmbUsers.Properties.DisplayMember = "الإسم";
            cmbUsers.Properties.ValueMember = "م";
        }

        private void cmbUsers_EditValueChanged(object sender, EventArgs e)
        {
            btnChangePassword.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = true;
            UserID = Convert.ToInt32(cmbUsers.EditValue);
            getUser();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("تأكيد الحذف؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var user = db.Users.Find(UserID);
                db.Users.Remove(user);
                db.SaveChanges();
                frmShowUser_Load(sender, e);
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();
            frm.userID = UserID;
            frm.ShowDialog();
        }

        private void frmShowUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            string[] comPorts = SerialPort.GetPortNames();
            foreach (string com in comPorts)
            {
                if (Properties.Settings.Default.FirstDevice == com)
                {
                    sp.Dispose();
                    sp.Close();
                    frmMain.sp1.Open();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var user = db.Users.Find(UserID);
            user.UserName = txtName.Text;
            user.CardNumber = CardNumberTextEdit.Text;
            user.UsersAccess.AddNewTrainee = Convert.ToBoolean(AddNewTraineeCheckEdit.EditValue);
            user.UsersAccess.SearchMen = Convert.ToBoolean(SearchMenCheckEdit.EditValue);
            user.UsersAccess.SearchWomen = Convert.ToBoolean(SearchWomenCheckEdit.EditValue);
            user.UsersAccess.AddOffer = Convert.ToBoolean(AddOfferCheckEdit.EditValue);
            user.UsersAccess.EditOffer = Convert.ToBoolean(EditOfferCheckEdit.EditValue);
            user.UsersAccess.ShowTrainees = Convert.ToBoolean(ShowTraineesCheckEdit.EditValue);
            user.UsersAccess.CancelTraineeProfile = Convert.ToBoolean(CancelTraineeProfileCheckEdit.EditValue);
            user.UsersAccess.AddIncomeOutCome = Convert.ToBoolean(AddIncomeOutComeCheckEdit.EditValue);
            user.UsersAccess.Settings = Convert.ToBoolean(SettingsCheckEdit.EditValue);
            user.UsersAccess.EditTraineeProfile = Convert.ToBoolean(EditTraineeProfileCheckEdit.EditValue);
            user.UsersAccess.Reports = Convert.ToBoolean(ReportsCheckEdit.EditValue);
            user.UsersAccess.NewIncomeOutCome = Convert.ToBoolean(NewIncomeOutComeCheckEdit.EditValue);
            user.UsersAccess.AddNewUser = Convert.ToBoolean(AddNewUserCheckEdit.EditValue);
            user.UsersAccess.EditUsers = Convert.ToBoolean(EditUsersCheckEdit.EditValue);
            user.UsersAccess.DeleteTrainee = Convert.ToBoolean(DeleteTraineeCheckEdit.EditValue);
            user.UsersAccess.FreezeTrainee = Convert.ToBoolean(FreezeTraineeCheckEdit.EditValue);
            db.SaveChanges();
            XtraMessageBox.Show("تم حفظ التعديلات بنجاح", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}