using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO.Ports;
using iGYM_MS.EDM;
using iGYM_MS.BL;
using System.IO;
using System.Threading;

namespace iGYM_MS.PL
{
    public partial class frmAddTrainee : DevExpress.XtraEditors.XtraForm
    {
        GymEntities1 db = new GymEntities1();
        clsFill f = new clsFill();
        clsCalc c = new clsCalc();
        clsGet g = new clsGet();
        clsAdd a = new clsAdd();
        clsUpdate u = new clsUpdate();

        SerialPort sp = new SerialPort(Properties.Settings.Default.FirstDevice);

        int OfferID, sessionNum, freezing, invitations, spa, massage, others, inbody, TraineeID, LogID;
        string offerName, cardNumber, type;

        private void DataReceivedHandler1(object sender, SerialDataReceivedEventArgs e)
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
            var x = (from y in db.Employees
                     where y.CardNumber == cardNumber
                     select y).ToList();

            var xx = (from yy in db.Trainees
                      where yy.CardNumber == cardNumber
                      select yy).ToList();

            if (x.Count > 0 || xx.Count > 0)
            {
                XtraMessageBox.Show("هذا الكارت مستخدم بالفعل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                txtCardNumber.Text = cardNumber;
            }
        }

        public frmAddTrainee()
        {
            InitializeComponent();
            dtHiring.EditValue = DateTime.Now.Date;
            dtBegin.EditValue = DateTime.Now.Date;
        }

        private void frmAddTrainee_Load(object sender, EventArgs e)
        {
            string[] comPorts = SerialPort.GetPortNames();
            foreach (string com in comPorts)
            {
                if (Properties.Settings.Default.FirstDevice == com)
                {
                    frmMain.sp1.Dispose();
                    frmMain.sp1.Close();
                    sp.BaudRate = 9600;
                    sp.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler1);
                    sp.Open();
                    sp.Write("connected");
                }
            }

            f.fillEmployees(cmbEmployee);
            f.fillEmployees(cmbTrainers);
            f.fillOffers(cmbOffers);
        }

        private void dtBegin_Leave(object sender, EventArgs e)
        {
            c.calcDuration(OfferID, dtBegin, dtEnd);
        }
        private void txtPaid_EditValueChanged(object sender, EventArgs e)
        {
            c.calcCarry(txtPaid, txtCarry, txtPrice);
        }
        private void cmbOffers_EditValueChanged(object sender, EventArgs e)
        {
            OfferID = Convert.ToInt32(cmbOffers.EditValue);
            g.getOffer(OfferID, ref offerName, ref freezing, ref invitations, ref spa, ref massage, ref others, ref inbody, ref sessionNum, ref type, txtPrice);
            c.calcDuration(OfferID, dtBegin, dtEnd);
            c.calcCarry(txtPaid, txtCarry, txtPrice);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!valName.Validate())
            {
                txtName.Focus();
                return;
            }
            if (!valBirth.Validate())
            {
                dtBirthdate.Focus();
                return; 
            }
            if (!valGender.Validate())
            {
                cmbGender.Focus();
                return;
            }
            if (!valPhone.Validate())
            {
                txtPhone.Focus();
                return; 
            }
            if (!valOffer.Validate())
            {
                cmbOffers.Focus();
                return;
            }

            MemoryStream ms = new MemoryStream();
            pBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] img = ms.ToArray();
            DateTime dt = Convert.ToDateTime(dtBirthdate.EditValue);
            int SocialID = Convert.ToInt32(radioGroup1.EditValue);

            if (txtCardNumber.Text != "")
            {
                a.addTrainee(txtCardNumber, txtName, dt, cmbGender, cmbStatus, txtNationality, txtDegree, txtNationalID, txtNotes, dtHiring, txtTel, txtPhone, txtAddress, txtMail,
                            img, radioGroup1, ref TraineeID);
                a.addTraineeProfile(TraineeID, cmbOffers, dtBegin, dtEnd, txtPrice, txtPaid, txtCarry, sessionNum, freezing, invitations, spa, massage, others, inbody,
                                    RGpaymentMethod, type, ref LogID, cmbTrainers, cmbEmployee);
                a.incrementSocialMedia(SocialID);
                if (Convert.ToDouble(txtPaid.Text) == 0)
                {
                    a.addCash(1, "إضافة إشتراك", 0.ToString(), txtPaid.Text, "", txtName.Text, cmbOffers.Text);
                }
                if (Convert.ToDouble(txtPaid.Text) > 0)
                {
                    a.addCash(1, "إضافة إشتراك", Properties.Settings.Default.RecieptID.ToString(), txtPaid.Text, RGpaymentMethod.Text, txtName.Text, cmbOffers.Text);
                    if (RGpaymentMethod.SelectedIndex == 0)
                    {
                        u.updateTraffic(Convert.ToDouble(txtPaid.Text), 0);
                    }
                    f.fillRpt(txtName.Text, txtPaid, offerName, Convert.ToDateTime(dtBegin.EditValue), Convert.ToDateTime(dtEnd.EditValue), txtCarry.Text, RGpaymentMethod.SelectedIndex);
                    Properties.Settings.Default.RecieptID = ++Properties.Settings.Default.RecieptID;
                    Properties.Settings.Default.Save();
                }
                XtraMessageBox.Show("تمت الإضافة بنجاح", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (XtraMessageBox.Show("هل تريد إضافة inbody report?", "سؤال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (inbody == 0)
                    {
                        XtraMessageBox.Show("هذا الإشتراك ليس له تقارير", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    frmInbodyReport frm = new frmInbodyReport();
                    frm.LogID = LogID;
                    frm.ShowDialog();
                }
                this.Close();
            }
            else if (txtCardNumber.Text == "")
            {
                if (XtraMessageBox.Show("لم يتم تمرير الكارت، هل تريد الإستمرار؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    a.addTrainee(txtCardNumber, txtName, dt, cmbGender, cmbStatus, txtNationality, txtDegree, txtNationalID, txtNotes, dtHiring, txtTel, txtPhone, txtAddress, txtMail,
                                img, radioGroup1, ref TraineeID);
                    a.addTraineeProfile(TraineeID, cmbOffers, dtBegin, dtEnd, txtPrice, txtPaid, txtCarry, sessionNum, freezing, invitations, spa, massage, others, inbody,
                                        RGpaymentMethod, type, ref LogID, cmbTrainers, cmbEmployee);
                    a.incrementSocialMedia(SocialID);
                    if (Convert.ToDouble(txtPaid.Text) == 0)
                    {
                        a.addCash(1, "إضافة إشتراك", 0.ToString(), txtPaid.Text, "", txtName.Text, cmbOffers.Text);
                    }
                    if (Convert.ToDouble(txtPaid.Text) > 0)
                    {
                        a.addCash(1, "إضافة إشتراك", Properties.Settings.Default.RecieptID.ToString(), txtPaid.Text, RGpaymentMethod.Text, txtName.Text, cmbOffers.Text);
                        if (RGpaymentMethod.SelectedIndex == 0)
                        {
                            u.updateTraffic(Convert.ToDouble(txtPaid.Text), 0);
                        }
                        f.fillRpt(txtName.Text, txtPaid, offerName, Convert.ToDateTime(dtBegin.EditValue), Convert.ToDateTime(dtEnd.EditValue), txtCarry.Text, RGpaymentMethod.SelectedIndex);
                        Properties.Settings.Default.RecieptID = ++Properties.Settings.Default.RecieptID;
                        Properties.Settings.Default.Save();
                    }
                    XtraMessageBox.Show("تمت الإضافة بنجاح", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (XtraMessageBox.Show("هل تريد إضافة inbody report?", "سؤال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (inbody == 0)
                        {
                            XtraMessageBox.Show("هذا الإشتراك ليس له تقارير", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                            return;
                        }
                        else
                        {
                            frmInbodyReport frm = new frmInbodyReport();
                            frm.LogID = LogID;
                            frm.ShowDialog();
                        }
                    }
                    this.Close();
                }
            }
        }

        private void frmAddTrainee_FormClosing(object sender, FormClosingEventArgs e)
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