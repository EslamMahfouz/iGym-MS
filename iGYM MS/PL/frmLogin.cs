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
using System.IO.Ports;
using System.Threading;
using iGYM_MS.BL;

namespace iGYM_MS.PL
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        clsAdd a = new clsAdd();

        public SerialPort sp1 = new SerialPort(Properties.Settings.Default.FirstDevice);
        string cardNumber;

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort _sp = (SerialPort)sender;
            cardNumber = _sp.ReadLine();
            Thread.Sleep(100);
            if (this.InvokeRequired)
            {
                this.Invoke((Action)getUser);
            }
        }
        void getUser()
        {
            var user = (from u in db.Users
                        where ((u.UserName == txtName.Text && u.Password == txtPassword.Text) || u.CardNumber == cardNumber) 
                        select u).ToList();

            if (user.Count > 0)
            {
                foreach (var item in user)
                {
                    Program.UserID = item.EmployeeID;
                    Program.Username = item.UserName;

                    Program.addNewTrainee = Convert.ToBoolean(item.UsersAccess.AddNewTrainee);
                    Program.editTraineeProfile = Convert.ToBoolean(item.UsersAccess.EditTraineeProfile);
                    Program.cancelTraineeProfile = Convert.ToBoolean(item.UsersAccess.CancelTraineeProfile);
                    Program.showTrainees = Convert.ToBoolean(item.UsersAccess.ShowTrainees);
                    Program.deleteTrainee = Convert.ToBoolean(item.UsersAccess.DeleteTrainee);
                    Program.freezeTrainee = Convert.ToBoolean(item.UsersAccess.FreezeTrainee);

                    Program.searchMen = Convert.ToBoolean(item.UsersAccess.SearchMen);
                    Program.searchWomen = Convert.ToBoolean(item.UsersAccess.SearchWomen);

                    Program.addOffer = Convert.ToBoolean(item.UsersAccess.AddOffer);
                    Program.editOffer = Convert.ToBoolean(item.UsersAccess.EditOffer);

                    Program.addIncomeOutcome = Convert.ToBoolean(item.UsersAccess.AddIncomeOutCome);
                    Program.newIncomeOutcome = Convert.ToBoolean(item.UsersAccess.NewIncomeOutCome);

                    Program.settings = Convert.ToBoolean(item.UsersAccess.Settings);
                    Program.reports = Convert.ToBoolean(item.UsersAccess.Reports);

                    Program.addNewUser = Convert.ToBoolean(item.UsersAccess.AddNewUser);
                    Program.editUsers = Convert.ToBoolean(item.UsersAccess.EditUsers);
                }
                a.addLoginLog("تسجيل دخول");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                XtraMessageBox.Show("برجاء التأكد من بيانات الدخول", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public frmLogin()
        {
            InitializeComponent();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                frmMain.sp1.Dispose();
                frmMain.sp1.Close();
                sp1.BaudRate = 9600;
                sp1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                sp1.Open();
                sp1.Write("connected");
            }

            catch
            {
                XtraMessageBox.Show("الجهاز غير متصل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            getUser();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            string[] comPorts = SerialPort.GetPortNames();
            foreach (string com in comPorts)
            {
                if (Properties.Settings.Default.FirstDevice == com)
                {
                    sp1.Dispose();
                    sp1.Close();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}