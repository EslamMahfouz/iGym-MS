using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using iGYM_MS.BL;

namespace iGYM_MS.PL
{
    public partial class frmShowTrainee : XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        public SerialPort sp = new SerialPort(Properties.Settings.Default.FirstDevice);
        clsFill f = new clsFill(); clsUpdate u = new clsUpdate(); clsAdd a = new clsAdd();
        public string cardNumber, offerName; public int TraineeID = 0, OfferID, logID = 0;  bool frozen;

        void getBasics()
        {
            var t = db.Trainees.Find(TraineeID);
            txtID.Text = t.TraineeID.ToString();
            txtCardNumber.Text = t.CardNumber;
            txtName.Text = t.TraineeName;
            dtBirthdate.EditValue = t.Birtdate;
            cmbGender.EditValue = t.Gender;
            cmbStatus.EditValue = t.Status;
            txtNationality.Text = t.Nationality;
            txtDegree.Text = t.Degree;
            txtNationalID.Text = t.NationalID;
            txtNotes.Text = t.Notes;
            dtHiring.EditValue = t.JoiningDate;
            txtTel.Text = t.Telephone;
            txtPhone.Text = t.Phone;
            AddressTextEdit.Text = t.Address;
            txtMail.Text = t.Mail;
            byte[] img = t.Photo;
            MemoryStream ms = new MemoryStream(img);
            pBox.Image = Image.FromStream(ms);
        }
        void getCurrent()
        {
            var tp = from x in db.TraineeProfiles
                     where x.TraineeID == TraineeID && x.Active == true
                     select x;

            foreach (var item in tp)
            {
                logID = item.LogID;
                cmbOffers.EditValue = item.OfferID;
                if (item.Type == "أيام") rdTYPE.SelectedIndex = 0;
                else rdTYPE.SelectedIndex = 1;

                dtBegin.EditValue = item.From;
                dtEnd.EditValue = item.To;
                txtPrice.Text = item.Price.ToString();
                txtPaid.Text = item.Paid.ToString();
                txtCarry.Text = item.Carry.ToString();
                cmbTrainers.EditValue = item.TrainerID;
                cmbEmployees.EditValue = item.EmployeeID;
                txtInvitations.Text = item.Invitations.ToString();
                txtReports.Text = item.Inbody.ToString();
                txtSpa.Text = item.SPA.ToString();
                txtMassage.Text = item.Massage.ToString();
                txtOthers.Text = item.Others.ToString();
                txtFreeze.Text = item.Freezing.ToString();
                txtSessionNum.Text = item.SessionsNum.ToString();
                frozen = Convert.ToBoolean(item.Frozen);
                offerName = item.Offer.OfferName;
                break;
            }
            
            if (frozen)
                btnFreeze.Text = "إلغاء تجميد الإشتراك";
            if (!frozen)
                btnFreeze.Text = "تجميد الإشتراك"; 
        }
        void getInvitations()
        {
            var inv = from r in db.Invitations
                      where r.TraineeID == TraineeID && r.Type == "دعوة"
                      select new { الإسم = r.Name, العنوان = r.Address, المحمول = r.Phone, النوع = r.Gender, التاريخ = r.Date };
            gridControl3.DataSource = inv.ToList();
        }
        void getLog()
        {
            gridControl1.DataSource = null;
            var tp = from tp_ in db.TraineeProfiles
                     where tp_.TraineeID == TraineeID
                     select new { العرض = tp_.Offer.OfferName, من = tp_.From, إلي = tp_.To, السعر = tp_.Price, دفع = tp_.Paid, متبقي = tp_.Carry, نشط = tp_.Active, ملغي = tp_.Canceled, freezed = tp_.Frozen, transfered = tp_.Transfered };
            gridControl1.DataSource = tp.ToList();
        }
        void getInbody()
        {
            var ir = from r in db.InbodyReports
                     where r.TraineeProfile.TraineeID == TraineeID
                     select new { م = r.InodyID, التاريخ = r.Date };
            gridControl2.DataSource = ir.ToList();
            gridView4.Columns["م"].Visible = false;
        }

        void updateBasics()
        {
            MemoryStream ms = new MemoryStream();
            pBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] img = ms.ToArray();

            var t = db.Trainees.Find(TraineeID);
            t.TraineeName = txtName.Text;
            t.Birtdate = Convert.ToDateTime(dtBirthdate.EditValue);
            t.Gender = cmbGender.EditValue.ToString();
            t.Status = cmbStatus.EditValue.ToString();
            t.Nationality = txtNationality.Text;
            t.Degree = txtDegree.Text;
            t.NationalID = txtNationalID.Text;
            t.Notes = txtNotes.Text;
            t.JoiningDate = Convert.ToDateTime(dtHiring.EditValue);
            t.Telephone = txtTel.Text;
            t.Phone = txtPhone.Text;
            t.Address = AddressTextEdit.Text;
            t.Mail = txtMail.Text;
            t.Photo = img;
            t.CardNumber = txtCardNumber.Text;
            db.SaveChanges();
        }
        void updateCurrent()
        {
            var item = db.TraineeProfiles.Find(logID);
            item.TrainerID = Convert.ToInt32(cmbTrainers.EditValue);
            item.Invitations = Convert.ToInt32(txtInvitations.Text);
            item.Inbody = Convert.ToInt32(txtReports.Text);
            item.SPA = Convert.ToInt32(txtSpa.Text);
            item.Massage = Convert.ToInt32(txtMassage.Text);
            item.Others = Convert.ToInt32(txtOthers.Text);
            item.Freezing = Convert.ToInt32(txtFreeze.Text);
            item.SessionsNum = Convert.ToInt32(txtSessionNum.Text);
            frozen = Convert.ToBoolean(item.Frozen);
            item.EmployeeID = Convert.ToInt32(cmbEmployees.EditValue);
            item.TrainerID = Convert.ToInt32(cmbTrainers.EditValue);
            db.SaveChanges();
        }
        
        public void getTrainee()
        {
            if(Program.deleteTrainee)
                btnDelete.Enabled = true;
            btnRenew.Enabled = true;
            btnLog.Enabled = true;
            btnSave.Enabled = true;

            getBasics();
            getCurrent();
            getInvitations();
            getLog();
            getInbody();

            chkDaily();
            if (txtCardNumber.Text == "")
                btnChangeID.Text = "إضافة كارت";
            else
                btnChangeID.Text = "تغيير الكارت";
        }
        void chkDaily()
        {
            if (logID > 0)
            {
                btnDaily.Enabled = true;
                btnChangeOffer.Enabled = true;
                if(Program.freezeTrainee)
                    btnFreeze.Enabled = true;
                if(Program.cancelTraineeProfile)
                    btnDeleteCurrent.Enabled = true;
                btnChangeID.Enabled = true;
                btnTransfer.Enabled = true;
                var x = db.TraineeProfiles.Find(logID);
                if (x.Inbody > 0)
                    btnAddInbody.Enabled = true;
                if (x.Carry > 0)
                    btnPaidCarry.Enabled = true;
            }
            else
            {
                btnDaily.Enabled = false;
                btnChangeOffer.Enabled = false;
                btnFreeze.Enabled = false;
                btnDeleteCurrent.Enabled = false;
                btnChangeID.Enabled = false;
                btnAddInbody.Enabled = false;
                btnTransfer.Enabled = false;
                btnPaidCarry.Enabled = true;
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
                getTrainee();
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

        public frmShowTrainee()
        {
            InitializeComponent();
        }

        private void frmShowTrainee_Load(object sender, EventArgs e)
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

            f.fillOffers(cmbOffers);
            f.fillEmployees(cmbEmployees);
            f.fillEmployees(cmbTrainers);
            f.fillTrainees(cmbTrainees);
        }

        private void cmbTrainees_EditValueChanged(object sender, EventArgs e)
        {
            logID = 0;
            TraineeID = Convert.ToInt32(cmbTrainees.EditValue);
            getTrainee();
            chkDaily();
        }

        private void btnChangeID_Click(object sender, EventArgs e)
        {
            string[] comPorts = SerialPort.GetPortNames();
            foreach (string com in comPorts)
            {
                if (Properties.Settings.Default.FirstDevice == com)
                {
                    sp.Dispose();
                    sp.Close();
                }
            } 

            frmChangeID frm = new frmChangeID();
            frm.TraineeID = TraineeID;
            frm.type = "مشترك";
            frm.ShowDialog();

            string[] comPorts_ = SerialPort.GetPortNames();
            foreach (string com in comPorts_)
            {
                if (Properties.Settings.Default.FirstDevice == com)
                {
                    sp.Open();
                }
            }

            getTrainee();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("تأكيد الحذف؟", "سؤال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                u.deleteTrainee(TraineeID);
                a.addCash(1, "حذف مشترك", "", 0.ToString(), "", txtName.Text, "");
                XtraMessageBox.Show("تم الحذف", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnChangeOffer_Click(object sender, EventArgs e)
        {
            frmRenew frm = new frmRenew();
            frm.Text = "تغيير العرض الحالي";
            frm.txtPaid.Text = txtPaid.Text;
            frm.txtCarry.Text = txtCarry.Text;
            frm.logID = logID;
            frm.traineeID = TraineeID;
            frm.traineeName = txtName.Text;
            frm.dtBegin.EditValue = dtBegin.EditValue;
            frm.changeOffer = true;
            frm.ShowDialog();
        }
        private void btnDaily_Click(object sender, EventArgs e)
        {
            if (frozen == true)
            {
                MessageBox.Show("هذا الإشتراك مجمد", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var item = db.TraineeProfiles.Find(logID);
            if (item.Type == "جلسات")
            {
                if (item.SessionsNum > 0)
                {
                    item.SessionsNum = --item.SessionsNum;
                }
                else
                {
                    XtraMessageBox.Show("لقد إنتهي عدد الجلسات لهذا المشترك", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            EDM.TraineesDaily td = new EDM.TraineesDaily()
            {
                TraineeID = TraineeID,
                Date = DateTime.Now,
                LogID = logID,
            };
            db.TraineesDailies.Add(td);
            db.SaveChanges();
            XtraMessageBox.Show("تم التحضير", "تحضير", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmMain frm = new frmMain();
            frm.checkTraineesProfile();
        }
        private void btnLog_Click(object sender, EventArgs e)
        {
            FrmTraineeLog frm = new FrmTraineeLog();
            frm.TraineeID = TraineeID;
            frm.ShowDialog();
        }
        private void btnAddInbody_Click(object sender, EventArgs e)
        {
            frmInbodyReport frm = new frmInbodyReport();
            frm.LogID = logID;
            frm.ShowDialog();
            getTrainee();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            frmRenew frm = new frmRenew();
            frm.traineeID = TraineeID;
            frm.logID = logID;
            frm.traineeName = txtName.Text;
            frm.offerName = offerName;
            frm.ShowDialog();
            getTrainee();
        }
        private void btnFreeze_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtFreeze.Text) == 0)
            {
                XtraMessageBox.Show("لقد تجاوز هذا الإشتراك الحد المسموح به", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!frozen)
            {
                frmFreezing frm = new frmFreezing();
                frm.dtBegin.EditValue = dtBegin.EditValue;
                frm.dtEnd.EditValue = dtEnd.EditValue;
                frm.logID = logID;
                frm.traineeName = txtName.Text;
                frm.offerName = offerName;
                frm.number = Convert.ToInt32(txtFreeze.Text);
                frm.ShowDialog();

                getTrainee();
                return;
            }
            var tp = from tp_ in db.TraineeProfiles
                     where tp_.TraineeID == TraineeID && tp_.Active == true
                     select tp_;

            foreach (var item in tp)
            {
                if (item.Active == true)
                {
                    item.Frozen = false;
                    XtraMessageBox.Show("تم إلغاء تجميد الإشتراك", "تجميد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnFreeze.Text = "تجميد الإشتراك";
                    frozen = false;
                    break;
                }
            }
            a.addCash(1, "إلغاء تجميد إشتراك", "", 0.ToString(), "", txtName.Text, cmbOffers.Text);
            db.SaveChanges();
        }
        private void btnDeleteCurrent_Click(object sender, EventArgs e)
        {
            if (Program.cancelTraineeProfile)
            {
                var tp = db.TraineeProfiles.Find(logID);
                if (tp.Active == true)
                {
                    if (XtraMessageBox.Show("تأكيد إلغاء الإشتراك الحالي؟", "سؤال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        tp.Active = false;
                        tp.Canceled = true;
                        db.SaveChanges();
                        XtraMessageBox.Show("تم إلغاء الإشتراك بنجاح", "إلغاء", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getTrainee();

                        frmCancellation frm = new frmCancellation();
                        frm.traineeID = TraineeID;
                        frm.name = txtName.Text;
                        frm.offerName = offerName;
                        frm.dtBegin = Convert.ToDateTime(dtBegin.EditValue);
                        frm.dtEnd = Convert.ToDateTime(dtEnd.EditValue);

                        frm.txtPaid.Text = txtPaid.Text;
                        var number = (from n in db.TraineesDailies
                                      where n.TraineeID == TraineeID && n.LogID == logID
                                      select n).ToList();
                        frm.txtNumber.Text = number.Count.ToString();
                        frm.ShowDialog();
                    }
                }
            }
        }
        private void btnPaidCarry_Click(object sender, EventArgs e)
        {
            frmPaidCarry frm = new frmPaidCarry();
            frm.logID = logID;
            frm.TraineeID = TraineeID;
            frm.name = txtName.Text;
            frm.offerName = offerName;
            frm.dtBegin = dtBegin;
            frm.dtEnd = dtEnd;
            frm.txtCarry.Text = txtCarry.Text;
            frm.ShowDialog();
            txtCarry.Text = "";
            txtPaid.Text = "";
            getTrainee();
        }
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            var tr = db.Trainees.Find(TraineeID);
            cardNumber = tr.CardNumber;
            tr.CardNumber = "";
            db.SaveChanges();

            frmAddForTransfer frm = new frmAddForTransfer();
            frm.logID = logID;
            frm.txtCardNumber.Text = cardNumber;
            frm.ShowDialog();
        }


        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            int InbodyID = Convert.ToInt32(gridView4.GetFocusedRowCellValue("م"));
            frmInbodyReport frm = new frmInbodyReport();
            frm.inBodyID = InbodyID;
            frm.newOne = false;
            frm.ShowDialog();
        }
 
        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime dt = Convert.ToDateTime(dtBirthdate.EditValue);
            dt = dt.Date;

            updateBasics();
            updateCurrent();
            XtraMessageBox.Show("تم حفظ التعديلات بنجاح", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmShowTrainee_FormClosing(object sender, FormClosingEventArgs e)
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