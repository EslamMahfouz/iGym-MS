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
using DevExpress.XtraTabbedMdi;
using System.IO.Ports;
using System.Threading;
using DevExpress.XtraCharts;
using System.Data.Objects;
using System.Data.SqlClient;
using System.IO;
using iGYM_MS.BL;

namespace iGYM_MS.PL
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        public static SerialPort sp1 = new SerialPort(Properties.Settings.Default.FirstDevice);
        public static SerialPort sp2 = new SerialPort(Properties.Settings.Default.SecondDevice);
        clsAdd a = new clsAdd();

        public string cardNumber1, cardNumber2;
        string temp;
        public static bool exit = false;

        void chkDayClosing()
        {
            if (Properties.Settings.Default.Mode == "Automatic" && DateTime.Now.TimeOfDay > Properties.Settings.Default.Time)
            {
                DateTime dt = DateTime.Now.Date;
                dt = dt.AddDays(-1);
                var traffic = (from x in db.Traffic
                               where x.Status == false
                               select x).ToList();

                if (traffic.Count > 0)
                {
                    foreach (var item in traffic)
                    {
                        if (item.DayDate <= dt)
                        {
                            item.Status = true;
                            a.addCash("غلق اليوم", DateTime.Now);
                        }
                    }
                }
                db.SaveChanges();
            }
        }

        public void checkTraineesProfile()
        {
            var trainees = from tr in db.TraineeProfiles
                           select tr;

            foreach (var item in trainees)
            {
                if (item.To >= DateTime.Now.Date && item.From <= DateTime.Now.Date && item.Canceled != true && item.Frozen != true)
                {
                    item.Active = true;
                }
            }
            db.SaveChanges();

            foreach (var item in trainees)
            {
                if (item.To < DateTime.Now.Date || (item.Type == "جلسات" && item.SessionsNum == 0) || item.From > DateTime.Now.Date)
                {
                    item.Active = false;
                }
            }
            db.SaveChanges();
        }

        void chkAccess()
        {
            if (Program.addNewTrainee)
                btnAddTrainee.Enabled = true;
            if(!Program.addNewTrainee)
                btnAddTrainee.Enabled = false;

            if (Program.editTraineeProfile)
                btnShowTrainee.Enabled = true;
            if (!Program.editTraineeProfile)
                btnShowTrainee.Enabled = false;

            if (Program.showTrainees)
                btnShowTrainees.Enabled = true;
            if (!Program.showTrainees)
                btnShowTrainees.Enabled = false;

            if (Program.addOffer)
                btnAddOffer.Enabled = true;
            if (!Program.addOffer)
                btnAddOffer.Enabled = false;

            if (Program.editOffer)
                btnShowOffer.Enabled = true;
            if (!Program.editOffer)
                btnShowOffer.Enabled = false;

            if (Program.addIncomeOutcome)
            {
                btnAddIncome.Enabled = true;
                btnAddOutcome.Enabled = true;
            }
            if (!Program.addIncomeOutcome)
            {
                btnAddIncome.Enabled = false;
                btnAddOutcome.Enabled = false;
            }

            if (Program.newIncomeOutcome)
                btnSettings.Enabled = true;
            if (!Program.newIncomeOutcome)
                btnSettings.Enabled = false;

            if (Program.settings)
            {
                btnDevices.Enabled = true;
                btnGymSettings.Enabled = true;
                btnAddSessionType.Enabled = true;
                btnJobs.Enabled = true;
                btnDayCloseSetting.Enabled = true;
            }
            if (!Program.settings)
            {
                btnDevices.Enabled = false;
                btnGymSettings.Enabled = false;
                btnAddSessionType.Enabled = false;
                btnJobs.Enabled = false;
                btnDayCloseSetting.Enabled = false;
            }

            if (Program.reports)
            {
                btnIncomeReport.Enabled = true;
                btnOutcomeReport.Enabled = true;
                btnTraffic.Enabled = true;
                btnDaily.Enabled = true;
                btnDebits.Enabled = true;
                btnSysLog.Enabled = true;
            }
            if (!Program.reports)
            {
                btnIncomeReport.Enabled = false;
                btnOutcomeReport.Enabled = false;
                btnTraffic.Enabled = false;
                btnDaily.Enabled = false;
                btnDebits.Enabled = false;
                btnSysLog.Enabled = false;
            }

            if (Program.addNewUser)
                btnAddUser.Enabled = true;
            if (!Program.addNewUser)
                btnAddUser.Enabled = false;

            if (Program.editUsers)
                btnShowUser.Enabled = true;
            if (!Program.editUsers)
                btnShowUser.Enabled = false;
        }
        public frmMain()
        {
            InitializeComponent();
        }
         
        void showSharts(bool status)
        {
            chartGender.Visible = status;
            chartNewDaily.Visible = status;
            chartSocial.Visible = status;
            chartOffers.Visible = status;
            chartSessions.Visible = status;
            groupControl1.Visible = status;
            panel1.Visible = status;
        }
        void fillCharts()
        {
            int monthlyC = 0, month, year;
            DateTime dt = DateTime.Now.Date;
            DateTime dtyday = dt.AddDays(-1);
            var men = (from g in db.TraineesDailies
                       where g.Trainee.Gender == "ذكر" && EntityFunctions.TruncateTime(g.Date) == EntityFunctions.TruncateTime(dt.Date)
                       select g).ToList();

            var women = (from g in db.TraineesDailies
                         where g.Trainee.Gender == "أنثي" && EntityFunctions.TruncateTime(g.Date) == EntityFunctions.TruncateTime(dt.Date)
                         select g).ToList();

            var yday = (from g in db.TraineesDailies
                        where EntityFunctions.TruncateTime(g.Date) == EntityFunctions.TruncateTime(dtyday.Date)
                        select g).ToList();

            int daily = men.Count + women.Count;

            var newTD = (from g in db.Trainees
                         where EntityFunctions.TruncateTime(g.JoiningDate) == EntityFunctions.TruncateTime(dt.Date)
                         select g).ToList();
            
            var monthly = from x in db.Trainees
                           select x;

            foreach (var item in monthly)
            {
                DateTime x = Convert.ToDateTime(item.JoiningDate);
                month = x.Month;
                year = x.Year;
                if (month == dt.Month && year == dt.Year)
                    monthlyC = monthlyC + 1;
            }

            var tp = from x in db.TraineeProfiles
                     where x.Active == true
                     select x;

            var o = from of in db.Offers
                    select of;

            Series offer = new Series("الإشتراكات", ViewType.Bar);

            foreach (var item in o)
            {
                int number = 0;
                foreach (var item_ in tp)
                {
                    if (item_.OfferID == item.OfferID)
                    {
                        number++;
                    }
                }
                offer.Points.Add(new SeriesPoint(item.OfferName, number));
            }
            chartOffers.Series.Add(offer);

            var i = from x in db.Invitations
                    where x.Date.Value.Year == dt.Year && x.Date.Value.Month == dt.Month && x.Date.Value.Day == dt.Day
                    select x;

            Series session = new Series("الجلسات", ViewType.Bar);
            
            int numberOffer = 0;
            foreach (var item in i)
            {
                if (item.Type == "عرض")
                    numberOffer++;
            }
            session.Points.Add(new SeriesPoint("عرض", numberOffer));
            int numberSession = 0;
            foreach (var item in i)
            {
                if (item.Type == "جلسة")
                    numberSession++;
            }
            session.Points.Add(new SeriesPoint("جلسة", numberSession));
            int numberInv = 0;
            foreach (var item in i)
            {
                if (item.Type == "دعوة")
                    numberInv++;
            }
            session.Points.Add(new SeriesPoint("دعوة", numberInv));
            int numberVisit = 0;
            foreach (var item in i)
            {
                if (item.Type == "زيارة")
                    numberVisit++;
            }
            session.Points.Add(new SeriesPoint("زيارة", numberVisit));
            chartSessions.Series.Add(session);

            var facebook = db.SocialMedias.Find(1);
            var twitter = db.SocialMedias.Find(2);
            var Youtube = db.SocialMedias.Find(3);
            var Google = db.SocialMedias.Find(4);
            var Instagram = db.SocialMedias.Find(5);
            var whatsapp = db.SocialMedias.Find(6);
            var ourwebsite = db.SocialMedias.Find(7);
            var sawoursign = db.SocialMedias.Find(8);
            var friend = db.SocialMedias.Find(9);
            var other = db.SocialMedias.Find(10);

            Series gen = new Series("حضور يومي", ViewType.Bar);
            gen.Points.Add(new SeriesPoint("رجال", men.Count));
            gen.Points.Add(new SeriesPoint("نساء", women.Count));

            Series gen_ = new Series("مقارنة", ViewType.Bar);
            gen_.Points.Add(new SeriesPoint("اليوم", daily));
            gen_.Points.Add(new SeriesPoint("أمس", yday.Count));
            chartGender.Series.Add(gen);
            chartGender.Series.Add(gen_);

            Series newT = new Series("إشتراكات اليوم", ViewType.Bar);
            newT.Points.Add(new SeriesPoint("العدد", newTD.Count));

            Series newM = new Series("إشتراكات الشهر", ViewType.Bar);
            newM.Points.Add(new SeriesPoint("العدد", monthlyC));
            chartNewDaily.Series.Add(newT);
            chartNewDaily.Series.Add(newM);

            Series social = new Series("Social Media", ViewType.Bar);
            social.Points.Add(new SeriesPoint("Facebook", facebook.number));
            social.Points.Add(new SeriesPoint("Twitter", twitter.number));
            social.Points.Add(new SeriesPoint("Youtube", Youtube.number));
            social.Points.Add(new SeriesPoint("Google+", Google.number));
            social.Points.Add(new SeriesPoint("Instagram", Instagram.number));
            social.Points.Add(new SeriesPoint("Whatsapp", whatsapp.number));
            social.Points.Add(new SeriesPoint("Our website", ourwebsite.number));
            social.Points.Add(new SeriesPoint("Saw our sign", sawoursign.number));
            social.Points.Add(new SeriesPoint("Friend", friend.number));
            social.Points.Add(new SeriesPoint("Other", other.number));
            chartSocial.Series.Add(social);

            var ended = from x in db.TraineeProfiles
                        where x.To == dt
                        select new { الإسم = x.Trainee.TraineeName, العرض = x.Offer.OfferName, المحمول = x.Trainee.Phone};
            gridControl1.DataSource = ended.ToList();
        }

        void addForm(XtraForm frm)
        {
            showSharts(false);

            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name != "frmMain")
                    f.Close();
            }

            frm.MdiParent = this;
            frm.Show();
        }

        void chkCardNumber1()
        {
            int empID = 0, traineeID = 0, UserID = 0;

            var em = (from y in db.Employees
                    where y.CardNumber == cardNumber1
                    select y).ToList();

            var tr = (from yy in db.Trainees
                      where yy.CardNumber == cardNumber1
                      select yy).ToList();

            var us = (from yy in db.Users
                      where yy.CardNumber == cardNumber1
                      select yy).ToList();

            if (em.Count > 0)
            {
                foreach (var item in em)
                {
                    empID = item.EmployeeID;
                    break;
                }
                frmShowEmpolyee frm = new frmShowEmpolyee();
                frm.EmployeeID = empID;
                frm.getEmployee();
                addForm(frm);
            }
            else if (tr.Count > 0)
            {
                foreach (var item in tr)
                {
                    traineeID = item.TraineeID;
                    break;
                }
                frmShowTrainee frm = new frmShowTrainee();
                frm.TraineeID = traineeID;
                frm.getTrainee();
                addForm(frm);
            }
            else if (us.Count > 0)
            {
                foreach (var item in us)
                {
                    UserID = item.EmployeeID;
                    break;
                }
                frmShowUser frm = new frmShowUser();
                frm.UserID = UserID;
                frm.getUser();
                addForm(frm);
            }
            else
            {
                frmAddTrainee frm = new frmAddTrainee();
                frm.txtCardNumber.Text = cardNumber1;
                addForm(frm);
            }
        }
        void chkCardNumber2()
        {
            if (temp == cardNumber2)
            {
                return;
            }
            int empID = 0, traineeID = 0, logID = 0;

            var em = (from y in db.Employees
                      where y.CardNumber == cardNumber2
                      select y).ToList();

            var tr = (from yy in db.TraineeProfiles
                      where yy.Trainee.CardNumber == cardNumber2 && yy.Active==true
                      select yy).ToList();

            if (em.Count > 0)
            {
                foreach (var item in em)
                {
                    empID = item.EmployeeID;
                    break;
                }
                frmDailyEmployees frm = new frmDailyEmployees();
                frm.EmployeeID = empID;
                frm.getEmployee();
                frm.Show();
            }
            else if (tr.Count > 0)
            {
                foreach (var item in tr)
                {
                    traineeID = Convert.ToInt32(item.TraineeID);
                    logID = Convert.ToInt32(item.LogID);
                    break;
                }
                frmDaily frm = new frmDaily();
                frm.traineeID = traineeID;
                frm.logID = logID;
                frm.function();

                if (frm.close)
                {
                    XtraMessageBox.Show("هذا المشترك غير مصرح له بالدخول في هذا الوقت", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (frm.frozen)
                {
                    XtraMessageBox.Show("هذا الإشتراك مجمد", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (frm.ended)
                {
                    XtraMessageBox.Show("لقد إنتهي عدد الجلسات لهذا المشترك", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    sp2.Write("ok");
                    frm.Show();
                }
            }
            else
            {
                sp2.Write("error");
                XtraMessageBox.Show("هذا الكارت غير مسجل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            temp = cardNumber2;
        }

        private void DataReceivedHandler1(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort _sp = (SerialPort)sender;
            cardNumber1 = _sp.ReadLine();
            Thread.Sleep(50);
            if (this.InvokeRequired)
            {
                this.BeginInvoke((Action)chkCardNumber1);
            }
        }
        private void DataReceivedHandler2(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort _sp = (SerialPort)sender;
            cardNumber2 = _sp.ReadLine();
            if (this.InvokeRequired)
            {
                this.BeginInvoke((Action)chkCardNumber2);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.FirstDevice = "COM5";
            Properties.Settings.Default.SecondDevice = "COM";
            Properties.Settings.Default.Save();
            if (Properties.Settings.Default.firstTimeUse)
            {
                Properties.Settings.Default.setupDate = DateTime.Now.Date;
                frmLogin frmlgn = new frmLogin();
                frmlgn.ShowDialog();
                menuUser.Caption = Program.Username;
                frmGymData Gfrm = new frmGymData();
                Gfrm.ShowDialog();
                Properties.Settings.Default.firstTimeUse = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                frmLogin frmlgn_ = new frmLogin();
                frmlgn_.ShowDialog();
                menuUser.Caption = Program.Username;
            }

            TimeSpan days = DateTime.Now.Date - Properties.Settings.Default.setupDate;
            int num = days.Days;

            if (Properties.Settings.Default.PaidEver)
            {
                goto procceed;
            }
            else if (num > 14 && !Properties.Settings.Default.PaidYear)
            {
                XtraMessageBox.Show("لقد إنتهت المدة التجريبية للبرنامج، برحاء شراء البرنامج", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmActivate frm = new frmActivate();
                frm.ShowDialog();
            }
            else if (num > 365 && !Properties.Settings.Default.PaidEver)
            {
                XtraMessageBox.Show("لقد إنتهت المدة التجريبية للبرنامج، برحاء شراء البرنامج", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmActivate frm = new frmActivate();
                frm.ShowDialog();
            }
 

procceed:   string[] comPorts = SerialPort.GetPortNames();
            foreach (string com in comPorts)
            {
                if (Properties.Settings.Default.FirstDevice == com)
                {
                    sp1.BaudRate = 9600;
                    sp1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler1);
                    sp1.Open();
                    sp1.Write("connected");
                }
                if (Properties.Settings.Default.SecondDevice == com)
                {
                    sp2.BaudRate = 9600;
                    sp2.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler2);
                    sp2.Open();
                    sp2.Write("connected");
                }
            }
           
            chkDayClosing();
            checkTraineesProfile();
            chkAccess();
            fillCharts();
            showSharts(true);
        }
        
        private void btnAddTrainee_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmAddTrainee frm = new frmAddTrainee();
            try
            {
                sp1.Dispose();
                sp1.Close();
                addForm(frm);
            }
            catch
            {
                addForm(frm);
            }
        }
        private void btnShowTrainee_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmShowTrainee frm = new frmShowTrainee();
            try
            {
                sp1.Dispose();
                sp1.Close();
                addForm(frm);
            }
            catch
            {
                addForm(frm);
            }
        }
        private void btnShowTrainees_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmShowTrainees frm = new frmShowTrainees();
            addForm(frm);
        }

        private void btnAddEmployee_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmAddEmplyee frm = new frmAddEmplyee();
            try
            {
                sp1.Dispose();
                sp1.Close();
                addForm(frm);
            }
            catch
            {
                addForm(frm);
            }
        }
        private void btnShowEmployee_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmShowEmpolyee frm = new frmShowEmpolyee();
            try
            {
                sp1.Dispose();
                sp1.Close();
                addForm(frm);
            }
            catch
            {
                addForm(frm);
            }
        }
        private void btnShowEmployees_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmShowEmployees frm = new frmShowEmployees();
            addForm(frm);
        }

        private void btnAddIncome_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmAddOrder frm = new frmAddOrder();
            addForm(frm);
        }
        private void btnAddOutcome_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmAddOutcome frm = new frmAddOutcome();
            addForm(frm);
        }
        private void btnSettings_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmChooseSesttings frm = new frmChooseSesttings();
            addForm(frm);
        }

        private void btnAddOffer_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmAddOffer frm = new frmAddOffer();
            addForm(frm);
        }

        private void btnAddSession_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmAddSession frm = new frmAddSession();
            addForm(frm);
        }
        private void btnShowSessions_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmShowInvitations frm = new frmShowInvitations();
            addForm(frm);
        }

        private void btnAddJob_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmAddJob frm = new frmAddJob();
            frm.ShowDialog();
        }

        private void btnAddUser_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmAddUser frm = new frmAddUser();
            addForm(frm);
        }

        private void btnShowUser_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmShowUser frm = new frmShowUser();
            addForm(frm);
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmDailyEmployees frm = new frmDailyEmployees();
            addForm(frm);
        }

        private void btnDevices_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDevices frm = new frmDevices();
            addForm(frm);
        }
        private void btnJobs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAddJob frm = new frmAddJob();
            addForm(frm);
        }
        private void btnGymSettings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmGymData frm = new frmGymData();
            addForm(frm);
        }

        private void btnAddSessionType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAddSessionType frm = new frmAddSessionType();
            addForm(frm);
        }

        private void btnChangePassword_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmUserPassword frm = new frmUserPassword();
            addForm(frm);
        }

        private void btnLogout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<Form> openForms = new List<Form>();
            foreach (Form f in Application.OpenForms)
                openForms.Add(f);
            foreach (Form f in openForms)
            {
                if (f.Name != "frmMain")
                    f.Close();
            }
            showSharts(false);

            a.addLoginLog("تسجيل دخول");
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
            menuUser.Caption = Program.Username;

            chkDayClosing();
            chkAccess();
            chartGender.Series.RemoveAt(0);
            chartGender.Series.RemoveAt(0);
            chartNewDaily.Series.RemoveAt(0);
            chartNewDaily.Series.RemoveAt(0);
            chartSocial.Series.RemoveAt(0);
            chartOffers.Series.RemoveAt(0);
            chartSessions.Series.RemoveAt(0);
            showSharts(true);
            fillCharts();
        }

        private void xtraTabbedMdiManager1_PageRemoved(object sender, MdiTabPageEventArgs e)
        {
            chartGender.Series.RemoveAt(0);
            chartGender.Series.RemoveAt(0);
            chartNewDaily.Series.RemoveAt(0);
            chartNewDaily.Series.RemoveAt(0);
            chartSocial.Series.RemoveAt(0);
            chartOffers.Series.RemoveAt(0);
            chartSessions.Series.RemoveAt(0);
            showSharts(true);
            fillCharts();
        }

        private void btnShowOffer_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmEditOffer frm = new frmEditOffer();
            addForm(frm);
        }

        private void xtraTabbedMdiManager1_SelectedPageChanged(object sender, EventArgs e)
        {
            showSharts(false);
        }

        private void btnShowOffers_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmShowOffers frm = new frmShowOffers();
            addForm(frm);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sp1.IsOpen)
            { sp1.Write("disconnected"); }
            if (sp2.IsOpen)
            { sp2.Write("disconnected"); }
            a.addLoginLog("تسجيل خروج");
            try
            {
                SqlConnection sqlconnection = new SqlConnection(@"Server=.\SQLEXPRESS; Database=master; Integrated Security=true");
                SqlCommand cmd;

                string combined = Path.Combine(Properties.Settings.Default.BackupFolder, "gymBackup.bak");
                File.Delete(combined);
                string query = "Backup Database Gym to Disk='" + combined + "'";
                cmd = new SqlCommand(query, sqlconnection);
                sqlconnection.Open();
                cmd.ExecuteNonQuery();
                sqlconnection.Close();
            }
            catch
            {
                return;
            }
        }

        private void btnDaily_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmDailyReport frm = new frmDailyReport();
            addForm(frm);
        }

        private void btnDebits_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmDebits frm = new frmDebits();
            addForm(frm);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Properties.Settings.Default.Mode == "Manual")
            {
                if (XtraMessageBox.Show("تأكيد غلق اليوم", "غلق اليوم", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var traffic = (from x in db.Traffic
                                   where x.Status == false
                                   select x).ToList();

                    if (traffic.Count > 0)
                    {
                        foreach (var item in traffic)
                        {
                            item.Status = true;
                            break;
                        }
                    }
                    db.SaveChanges();
                    a.addCash("غلق اليوم", DateTime.Now);
                    XtraMessageBox.Show("تم غلق اليوم", "غلق اليوم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                XtraMessageBox.Show("غلق اليوم في الوضع الأوتوماتيكي", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnIncomeReport_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmReport frm = new frmReport();
            frm.type = "income";
            addForm(frm);
        }

        private void btnOutcomeReport_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmReport frm = new frmReport();
            frm.type = "outcome";
            addForm(frm);
        }

        private void btnTraffic_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmTraffic frm = new frmTraffic();
            frm.ShowDialog();
        }

        private void btnOpenGate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                sp2.Write("ok");
            }
            catch
            { 
                return; 
            }
        }

        private void btnSysLog_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmSystemLog frm = new frmSystemLog();
            addForm(frm);
        }

        private void btnDayCloseSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDayCLosing frm = new frmDayCLosing();
            addForm(frm);
        }

        private void btnActivate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmActivate frm = new frmActivate();
            addForm(frm);
        }       
    }
}