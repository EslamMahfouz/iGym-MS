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
using DevExpress.XtraReports.UI;
using iGYM_MS.BL;

namespace iGYM_MS.PL
{
    public partial class frmAddForTransfer : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        clsAdd a = new clsAdd(); clsUpdate u = new clsUpdate(); clsFill f = new clsFill();

        public int logID;
        public frmAddForTransfer()
        {
            InitializeComponent();
            dtHiring.EditValue = DateTime.Now.Date;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!valName.Validate())
            { return; }
            if (!valBirth.Validate())
            { return; }
            if (!valPhone.Validate())
            { return; }

            MemoryStream ms = new MemoryStream();
            pBox.Image.Save(ms, pBox.Image.RawFormat);
            byte[] img = ms.ToArray();
            DateTime dt = Convert.ToDateTime(dtBirthdate.EditValue);
            dt = dt.Date;
            EDM.Trainee t = new EDM.Trainee()
            {
                CardNumber = txtCardNumber.Text,
                TraineeName = txtName.Text,
                Birtdate = dt,
                Gender = cmbGender.EditValue.ToString(),
                Status = cmbStatus.EditValue.ToString(),
                Nationality = txtNationality.Text,
                Degree = txtDegree.Text,
                NationalID = txtNationalID.Text,
                Notes = txtNotes.Text,
                JoiningDate = Convert.ToDateTime(dtHiring.EditValue),
                Telephone = txtTel.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text,
                Mail = txtMail.Text,
                Photo = img,
                SocialID = Convert.ToInt32(radioGroup1.EditValue),
            };
            db.Trainees.Add(t);
            db.SaveChanges();
            var tp = db.TraineeProfiles.Find(logID);
            tp.TraineeID = t.TraineeID;
            tp.Transfered = true;

            if (Convert.ToInt32(txtPaid.Text) == 0)
            {
                a.addCash(1, "نقل إشتراك", 0.ToString(), 0.ToString(), "", txtName.Text, tp.Offer.OfferName);
            }
            if (Convert.ToInt32(txtPaid.Text) > 0)
            {
                a.addCash(1, "نقل إشتراك", Properties.Settings.Default.RecieptID.ToString(), txtPaid.Text, RGpaymentMethod.Text, txtName.Text, tp.Offer.OfferName);
                if (RGpaymentMethod.SelectedIndex == 0)
                {
                    u.updateTraffic(Convert.ToDouble(txtPaid.Text), 0);
                }
                db.SaveChanges();
                f.fillRpt(txtName.Text, txtPaid, tp.Offer.OfferName, Convert.ToDateTime(tp.From), Convert.ToDateTime(tp.To), tp.Carry.ToString(), RGpaymentMethod.SelectedIndex);
                Properties.Settings.Default.RecieptID = ++Properties.Settings.Default.RecieptID;
                Properties.Settings.Default.Save();
            }

            db.SaveChanges();
            XtraMessageBox.Show("تم نقل العضوية بنجاح", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }
    }
}