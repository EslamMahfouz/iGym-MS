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
using System.IO;
using DevExpress.XtraReports.UI;
using iGYM_MS.BL;

namespace iGYM_MS.PL
{
    public partial class frmAddSession : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        clsFill f = new clsFill(); clsAdd a = new clsAdd(); clsUpdate u = new clsUpdate();
        bool have = true;
        public SerialPort sp = new SerialPort(Properties.Settings.Default.FirstDevice);
        public string cardNumber;  public int TraineeID = 0;

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
        void chkCardNumber()
        {
            var tr = (from yy in db.Trainees
                      where yy.CardNumber == cardNumber
                      select yy).ToList();

            if (tr.Count > 0)
            {
                foreach (var item in tr)
                {
                    TraineeID = item.TraineeID;
                    break;
                }
                cmbTrainees.EditValue = TraineeID;
                chkRadioBtns();
                chkTrainee();
            }
            else
                sp.Write("error");
        }

        void chkRadioBtns()
        {
            if (radioChk.SelectedIndex == 0)
            {
                ItemForSessionID.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                ItemForPrice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                ItemForTraineeID.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                rd.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                ItemForTraineeID.Text = "دعوة من";
                panelControl1.Visible = false;
                SPA.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                Massage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                Other.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                payment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else if (radioChk.SelectedIndex == 1)
            {
                ItemForSessionID.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                ItemForPrice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                ItemForTraineeID.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                panelControl1.Visible = true;
                rd.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                SPA.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                Massage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                Other.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                payment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else if (radioChk.SelectedIndex == 2)
            {
                ItemForSessionID.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                ItemForPrice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                ItemForTraineeID.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                ItemForTraineeID.Text = "إسم المشترك";
                panelControl1.Visible = false;
                rd.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                SPA.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                Massage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                Other.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                payment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else if (radioChk.SelectedIndex == 3)
            {
                ItemForSessionID.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                ItemForPrice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                ItemForTraineeID.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                rd.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                panelControl1.Visible = true;
                SPA.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                Massage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                Other.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                payment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }
        void chkTrainee()
        {
            var t = from tp in db.TraineeProfiles
                    where tp.TraineeID == TraineeID && tp.Active == true
                    select tp;

            if (radioChk.SelectedIndex == 0)
            {
                foreach (var item in t)
                {
                    if (item.Invitations == 0)
                    {
                        have = false;
                    }
                }
            }
            if (radioChk.SelectedIndex == 2)
            {
                foreach (var item in t)
                {
                    txtSpa.Text = item.SPA.ToString();
                    txtMassage.Text = item.Massage.ToString();
                    txtOther.Text = item.Others.ToString();
                    break;
                }
            }
        }

        void add()
        {
            if (radioChk.SelectedIndex == 0)
            {
                if (have)
                {
                    var t = from tp in db.TraineeProfiles
                            where tp.TraineeID == TraineeID && tp.Active == true
                            select tp;
                    foreach (var item in t)
                    {
                        item.Invitations = --item.Invitations;
                    }
                    EDM.Invitation i = new EDM.Invitation()
                    {
                        Name = txtName.Text,
                        Address = txtAddress.Text,
                        Phone = txtPhone.Text,
                        Gender = cmbGender.Text,
                        Nationality = txtNationality.Text,
                        EmployeeID = Convert.ToInt32(cmbEmployee.EditValue),
                        Date = Convert.ToDateTime(dtDate.EditValue),
                        TraineeID = TraineeID,
                        Type = radioChk.Text,
                    };
                    db.Invitations.Add(i);
                    db.SaveChanges();
                    a.addCash(2, radioChk.Text, "", 0.ToString(), "", txtName.Text, radioGroup2.Text);
                    XtraMessageBox.Show("تم إضافة الدعوة بنجاح", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    XtraMessageBox.Show("هذا المشترك لا يمتلك دعوات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (radioChk.SelectedIndex == 1)
            {
                EDM.Invitation inv = new EDM.Invitation()
                {
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text,
                    Gender = cmbGender.Text,
                    Nationality = txtNationality.Text,
                    EmployeeID = Convert.ToInt32(cmbEmployee.EditValue),
                    Date = Convert.ToDateTime(dtDate.EditValue),
                    SessionID = Convert.ToInt32(cmbSessions.EditValue),
                    Price = txtPrice.Text,
                    Type = radioChk.Text,
                };
                db.Invitations.Add(inv);
                db.SaveChanges();
                a.addCash(2, radioChk.Text, Properties.Settings.Default.RecieptID.ToString(), txtPrice.Text, radioGroup3.Text, txtName.Text, radioGroup2.Text, Convert.ToDateTime(dtDate.EditValue));

                if (radioGroup3.SelectedIndex == 0)
                {
                    u.updateTraffic(Convert.ToDouble(txtPrice.Text), 0);   
                }
                
                int SocialID = Convert.ToInt32(radioGroup1.EditValue);
                a.incrementSocialMedia(SocialID);
                Properties.Settings.Default.RecieptID = ++Properties.Settings.Default.RecieptID;
                Properties.Settings.Default.Save();
                XtraMessageBox.Show("تم إضافة الجلسة بنجاح", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (radioChk.SelectedIndex == 2)
            {
                var t = from tp in db.TraineeProfiles
                        where tp.TraineeID == TraineeID && tp.Active == true
                        select tp;
                foreach (var item in t)
                {
                    if (radioGroup2.SelectedIndex == 0)
                        item.SPA = --item.SPA;
                    else if (radioGroup2.SelectedIndex == 1)
                        item.Massage = --item.Massage;
                    else if (radioGroup2.SelectedIndex == 2)
                        item.Others = --item.Others;
                    break;
                }
                var z = db.Trainees.Find(TraineeID);
                EDM.Invitation i = new EDM.Invitation()
                {
                    Name = cmbTrainees.Text,
                    Address = z.Address,
                    Phone = z.Phone,
                    Gender = z.Gender,
                    Nationality = z.Nationality,
                    EmployeeID = Convert.ToInt32(cmbEmployee.EditValue),
                    Date = Convert.ToDateTime(dtDate.EditValue),
                    TraineeID = TraineeID,
                    Type = radioChk.Text,
                };
                db.Invitations.Add(i);
                db.SaveChanges();
                a.addCash(2, radioChk.Text, "", 0.ToString(), "", cmbTrainees.Text, radioGroup2.Text);
                XtraMessageBox.Show("تمت الإضافة بنجاح", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (radioChk.SelectedIndex == 3)
            {
                EDM.Invitation i = new EDM.Invitation()
                {
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text,
                    Gender = cmbGender.Text,
                    Nationality = txtNationality.Text,
                    EmployeeID = Convert.ToInt32(cmbEmployee.EditValue),
                    Date = Convert.ToDateTime(dtDate.EditValue),
                    Type = radioChk.Text,
                };
                db.Invitations.Add(i);

                int SocialID = Convert.ToInt32(radioGroup1.EditValue);
                var sm = db.SocialMedias.Find(SocialID);
                sm.number = ++sm.number;

                db.SaveChanges();
                a.addCash(2, radioChk.Text, "", 0.ToString(), "", txtName.Text, radioGroup2.Text);
                XtraMessageBox.Show("تم إضافة الزيارة بنجاح", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
                    
        public frmAddSession()
        {
            InitializeComponent();
            dtDate.EditValue = DateTime.Now;
        }

        private void frmAddSession_Load(object sender, EventArgs e)
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

            f.fillSessions(cmbSessions);
            f.fillEmployees(cmbEmployee);
            f.fillTrainees(cmbTrainees);
            chkRadioBtns();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            chkRadioBtns();
            chkTrainee();
            add();
        }

        private void cmbSessions_EditValueChanged(object sender, EventArgs e)
        {
            int sessionID = Convert.ToInt32(cmbSessions.EditValue);
            var session = db.Sessions.Find(sessionID);
            txtPrice.Text = session.SessionPrice;
        }

        private void radioChk_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkRadioBtns();
            chkTrainee();
        }

        private void cmbTrainees_EditValueChanged(object sender, EventArgs e)
        {
            TraineeID = Convert.ToInt32(cmbTrainees.EditValue);
            chkRadioBtns();
            chkTrainee();
        }
            
        private void radioGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioGroup2.SelectedIndex == 0 && Convert.ToInt32(txtSpa.Text) == 0)
                {
                    XtraMessageBox.Show("لا توجد جلسات متاحة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    radioGroup2.SelectedIndex = -1;
                    return;
                }
                else if (radioGroup2.SelectedIndex == 1 && Convert.ToInt32(txtMassage.Text) == 0)
                {
                    XtraMessageBox.Show("لا توجد جلسات متاحة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    radioGroup2.SelectedIndex = -1;
                    return;
                }
                else if (radioGroup2.SelectedIndex == 2 && Convert.ToInt32(txtOther.Text) == 0)
                {
                    XtraMessageBox.Show("لا توجد جلسات متاحة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    radioGroup2.SelectedIndex = -1;
                    return;
                }
            }
            catch
            {
                radioGroup2.SelectedIndex = -1;
                return;
            }
        }

        private void frmAddSession_FormClosing(object sender, FormClosingEventArgs e)
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

        
    }
}