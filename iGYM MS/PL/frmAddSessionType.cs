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
    public partial class frmAddSessionType : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        bool edit = false;
        int sessionID;

        public frmAddSessionType()
        {
            InitializeComponent();
        }

        void clrBoxs()
        {
            txtName.Text = "";
            txtPrice.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!valName.Validate())
            { return; }

            if (!edit)
            {
                EDM.Session session = new EDM.Session()
                {
                    SessionName = txtName.Text,
                    SessionPrice = txtPrice.Text
                };
                db.Sessions.Add(session);
                db.SaveChanges();
                XtraMessageBox.Show("تمت الإضافة بنجاح", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clrBoxs();
            }
            else
            {
                var session = db.Sessions.Find(sessionID);
                session.SessionName = txtName.Text;
                session.SessionPrice = txtPrice.Text;
                db.SaveChanges();
                XtraMessageBox.Show("تم تعديل الجلسة بنجاح", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clrBoxs();
            }

            edit = false;
            frmAddSessionType_Load(sender, e);
            cmbJobs.EditValue = -1;
        }

        private void frmAddSessionType_Load(object sender, EventArgs e)
        {
            var sessions = from x in db.Sessions
                           select new { م = x.SessionID, الجلسة = x.SessionName };
            
            cmbJobs.Properties.DataSource = sessions.ToList();
            cmbJobs.Properties.DisplayMember = "الجلسة";
            cmbJobs.Properties.ValueMember = "م";
            cmbJobs.Properties.PopulateColumns();
            cmbJobs.Properties.Columns["م"].Visible = false;
        }

        private void cmbJobs_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                edit = false;
                clrBoxs();
                cmbJobs.EditValue = -1;
            }
        }

        private void cmbJobs_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                sessionID = Convert.ToInt32(cmbJobs.EditValue);
                var session = db.Sessions.Find(sessionID);
                txtName.Text = session.SessionName;
                txtPrice.Text = session.SessionPrice;
                edit = true;
            }
            catch
            {
                return;
            }
        }
    }
}