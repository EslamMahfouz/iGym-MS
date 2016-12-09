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
    public partial class frmEditOffer : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        int OfferID;
        void fill()
        {
            var offer = db.Offers.Find(OfferID);
            txtName.Text = offer.OfferName;
            cmbDuration.EditValue = offer.DurationID;
            txtFrom.EditValue = offer.From;
            txtTo.EditValue = offer.To;
            txtPrice.Text = offer.Price;
            if (offer.Type == "أيام")
                cmbType.SelectedIndex = 0;
            else
                cmbType.SelectedIndex = 1;
            txtNumSessions.Text = offer.SessionsNum.ToString();
            txtDays.Text = offer.Freezing.ToString();
            txtInvitations.Text = offer.Invitations.ToString();
            txtReports.Text = offer.Inbody.ToString();
            txtSpa.Text = offer.SPA.ToString();
            txtMassage.Text = offer.Massage.ToString();
            txtOthers.Text = offer.Others.ToString();
            if (offer.frozen == true)
                chkFrozen.Checked = true;
            else
                chkFrozen.Checked = false;
        }
        void update()
        {
            var o = db.Offers.Find(OfferID);
            o.OfferName = txtName.Text;
            o.DurationID = Convert.ToInt32(cmbDuration.EditValue);
            o.Price = txtPrice.Text;
            o.Freezing = Convert.ToInt32(txtDays.Text);
            o.Invitations = Convert.ToInt32(txtInvitations.Text);
            o.SPA = Convert.ToInt32(txtSpa.Text);
            o.Massage = Convert.ToInt32(txtMassage.Text);
            o.Others = Convert.ToInt32(txtOthers.Text);
            o.Inbody = Convert.ToInt32(txtReports.Text);
            o.Type = cmbType.Text;
            o.SessionsNum = Convert.ToInt32(txtNumSessions.Text);
            o.From = txtFrom.Text;
            o.To = txtTo.Text;
            if (chkFrozen.Checked)
            {
                var offer = db.Offers.Find(OfferID);
                offer.frozen = true;
            }
            else
            {
                var offer = db.Offers.Find(OfferID);
                offer.frozen = false;
            } 
            db.SaveChanges();
        }
        public frmEditOffer()
        {
            InitializeComponent();
        }

        private void frmEditOffer_Load(object sender, EventArgs e)
        {
            var offer = from o in db.Offers
                        select new { م = o.OfferID, العرض = o.OfferName };
            cmbOffers.Properties.DataSource = offer.ToList();
            cmbOffers.Properties.PopulateColumns();
            cmbOffers.Properties.DisplayMember = "العرض";
            cmbOffers.Properties.ValueMember = "م";

            var durations = from d in db.Durations
                            select new { م = d.DurationID, المدة = d.DurationName };
            cmbDuration.Properties.DataSource = durations.ToList();
            cmbDuration.Properties.DisplayMember = "المدة";
            cmbDuration.Properties.ValueMember = "م";
            cmbDuration.Properties.PopulateColumns();
            cmbDuration.Properties.Columns["م"].Visible = false; 
        }

        private void cmbOffers_EditValueChanged(object sender, EventArgs e)
        {
            OfferID = Convert.ToInt32(cmbOffers.EditValue);
            btnAdd.Enabled = true;
            fill();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            update();
            XtraMessageBox.Show("تم التعديل بنجاح", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}