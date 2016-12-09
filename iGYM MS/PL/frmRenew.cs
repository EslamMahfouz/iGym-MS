using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using iGYM_MS.BL;

namespace iGYM_MS.PL
{
    public partial class frmRenew : XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        clsAdd a = new clsAdd();   clsFill f = new clsFill();  clsCalc c = new clsCalc();   clsGet g = new clsGet();  clsUpdate u = new clsUpdate();

        public int traineeID, logID, OfferID, freezing, invitations, inbody, spa, massage, others, sessionNum, employeeID, trainerID;
        public string traineeName, type, offerName;
        public bool changeOffer = false, status = true;
        double paid = 0;

        public frmRenew()
        {
            InitializeComponent();
            dtBegin.EditValue = DateTime.Now;
        }

        private void frmRenew_Load(object sender, EventArgs e)
        {
            f.fillEmployees(cmbEmployees);
            f.fillEmployees(cmbTrainers);
            paid = Convert.ToDouble(txtPaid.Text);
            f.fillOffers(cmbOffers);
            if (!changeOffer)
            {
                var trainee = from tr in db.TraineeProfiles
                              where tr.TraineeID == traineeID
                              select tr;

                foreach (var item in trainee)
                {
                    if (item.Active == true)
                    {
                        status = false;
                        DateTime dt = Convert.ToDateTime(item.To);
                        dt = dt.AddDays(1);
                        dtBegin.EditValue = dt;
                        dtBegin_Leave(sender, e);
                        break;
                    }
                }
            }
        }
        
        private void cmbOffers_EditValueChanged(object sender, EventArgs e)
        {
            OfferID = Convert.ToInt32(cmbOffers.EditValue);
            g.getOffer(OfferID, ref offerName, ref freezing, ref invitations, ref spa, ref massage, ref others, ref inbody, ref sessionNum, ref type, txtPrice);
            c.calcDuration(OfferID, dtBegin, dtEnd);
            c.calcCarry(txtPaid, txtCarry, txtPrice);
        }
        private void txtPaid_EditValueChanged(object sender, EventArgs e)
        {
            c.calcCarry(txtPaid, txtCarry, txtPrice);
        }
        private void dtBegin_Leave(object sender, EventArgs e)
        {
            c.calcDuration(OfferID, dtBegin, dtEnd);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!valOffer.Validate())
            { return; }

            if (!changeOffer)
            {
                a.addTraineeProfile(traineeID, cmbOffers, dtBegin, dtEnd, txtPrice, txtPaid, txtCarry, sessionNum, freezing, invitations, spa, massage, others, inbody,
                    radioGroup1, type, ref logID, cmbTrainers, cmbEmployees);

                if (Convert.ToDouble(txtPaid.Text) == 0)
                {
                    a.addCash(1, "تجديد إشتراك", "", txtPaid.Text, "", traineeName, cmbOffers.Text);
                }
                else if (Convert.ToDouble(txtPaid.Text) > 0)
                {
                    a.addCash(1, "تجديد إشتراك", Properties.Settings.Default.RecieptID.ToString(), txtPaid.Text, radioGroup1.Text, traineeName, cmbOffers.Text);
                    if (radioGroup1.SelectedIndex == 0)
                    {
                        u.updateTraffic(Convert.ToDouble(txtPaid.Text), 0);
                    }
                    f.fillRpt(traineeName, txtPaid, offerName, Convert.ToDateTime(dtBegin.EditValue), Convert.ToDateTime(dtEnd.EditValue), txtCarry.Text, radioGroup1.SelectedIndex);
                    Properties.Settings.Default.RecieptID = ++Properties.Settings.Default.RecieptID;
                    Properties.Settings.Default.Save();
                }
                XtraMessageBox.Show("تمت الإضافة بنجاح", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            if (changeOffer)
            {
                var tp = db.TraineeProfiles.Find(logID);
                tp.OfferID = Convert.ToInt32(cmbOffers.EditValue);
                tp.From = Convert.ToDateTime(dtBegin.EditValue);
                tp.To = Convert.ToDateTime(dtEnd.EditValue);
                tp.Price = Convert.ToDouble(txtPrice.Text);
                tp.Paid = Convert.ToDouble(txtPaid.Text);
                tp.Carry = Convert.ToDouble(txtCarry.Text);
                tp.SessionsNum = sessionNum - tp.SessionsNum;
                tp.Invitations = invitations - tp.Invitations;
                tp.Massage = massage - tp.Massage;
                tp.SPA = spa - tp.SPA;
                tp.Others = others - tp.Others;
                tp.Freezing = freezing - tp.Freezing;
                db.SaveChanges();

                if(Convert.ToInt32(txtPaid.Text) == 0)
                    a.addCash(1, "تغيير إشتراك", "", txtPaid.Text, "", traineeName, cmbOffers.Text);
                if (Convert.ToInt32(txtPaid.Text) > 0)
                {
                    if (Convert.ToDouble(txtCarry.Text) > 0)
                    {
                        a.addCash(1, "تغيير إشتراك", Properties.Settings.Default.RecieptID.ToString(), txtPaid.Text, radioGroup1.Text, traineeName, cmbOffers.Text);
                        Properties.Settings.Default.RecieptID = ++Properties.Settings.Default.RecieptID;
                        Properties.Settings.Default.Save();

                    }
                    else if (Convert.ToDouble(txtCarry.Text) < 0)
                    {
                        a.addOutcome(1, "تغيير إشتراك",  "R" + Properties.Settings.Default.RecieptIDOut, txtPaid.Text, DateTime.Now);
                        Properties.Settings.Default.RecieptIDOut = ++Properties.Settings.Default.RecieptIDOut;
                        Properties.Settings.Default.Save();
                    }

                    f.fillRpt(traineeName, txtPaid, offerName, Convert.ToDateTime(dtBegin.EditValue), Convert.ToDateTime(dtEnd.EditValue), txtCarry.Text, radioGroup1.SelectedIndex);
                }
                XtraMessageBox.Show("تم التعديل بنجاح", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }

            frmMain frm = new frmMain();
            frm.checkTraineesProfile();
        }
    }
}