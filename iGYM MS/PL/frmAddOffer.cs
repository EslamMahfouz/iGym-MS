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
    public partial class frmAddOffer : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();

        public frmAddOffer()
        {
            InitializeComponent();
            txtFrom.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00);
            txtTo.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 00);
        }

        private void frmAddOffer_Load(object sender, EventArgs e)
        {
            var durations = from d in db.Durations
                            select new { م = d.DurationID, المدة = d.DurationName };
            cmbDuration.Properties.DataSource = durations.ToList();
            cmbDuration.Properties.DisplayMember = "المدة";
            cmbDuration.Properties.ValueMember = "م";
            cmbDuration.Properties.PopulateColumns();
            cmbDuration.Properties.Columns["م"].Visible = false;
            cmbType_SelectedIndexChanged(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int spa = int.Parse(txtSpa.Text);
            int massage = Convert.ToInt32(txtMassage.Text);
            int others = Convert.ToInt32(txtOthers.Text);
            int freezing = Convert.ToInt32(txtDays.Text);
            int invitations = Convert.ToInt32(txtInvitations.Text);
            int inbody = Convert.ToInt32(txtReports.Text);
            int sessionNum = Convert.ToInt32(txtNumSessions.Text);

            if (!valName.Validate())
            { return; }
            if (!valDuration.Validate())
            { return; }
            if (!valPrice.Validate())
            { return; }

            EDM.Offer o = new EDM.Offer()
            {
                OfferName = txtName.Text,
                DurationID = Convert.ToInt32(cmbDuration.EditValue),
                Price = txtPrice.Text,
                Freezing = freezing,
                Invitations = invitations,
                SPA = spa,
                Massage =massage,
                Others  = others,
                Inbody = inbody,
                Type = cmbType.Text,
                SessionsNum =sessionNum,
                From = txtFrom.Text,
                To = txtTo.Text,
                frozen = false
            };
            db.Offers.Add(o);
            db.SaveChanges();
            XtraMessageBox.Show("تم إضافة الإشتراك", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex == 0)
                txtNumSessions.Enabled = false;
            else
                txtNumSessions.Enabled = true;
        }
    }
}