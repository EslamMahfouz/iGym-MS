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
using System.Data.Objects;

namespace iGYM_MS.PL
{
    public partial class frmShowInvitations : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        DateTime fromDate, toDate;

        public string type;

        public frmShowInvitations()
        {
            InitializeComponent();
            dtFrom.EditValue = DateTime.Now.Date;
            dtTo.EditValue = DateTime.Now.Date;
        }

        private void frmShowInvitations_Load(object sender, EventArgs e)
        {
            btnShow_Click(sender, e);
        }

        private void dtFrom_EditValueChanged(object sender, EventArgs e)
        {
            fromDate = Convert.ToDateTime(dtFrom.EditValue);
        }

        private void dtTo_EditValueChanged(object sender, EventArgs e)
        {
            toDate = Convert.ToDateTime(dtTo.EditValue);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            var invitations = from c in db.Invitations
                              where ((EntityFunctions.TruncateTime(c.Date)) >= fromDate && (EntityFunctions.TruncateTime(c.Date)) <= toDate)
                              select new { م = c.InvitationID, الإسم = c.Name, الهاتف = c.Phone, الجنس = c.Gender, النوع = c.Type, التاريخ = c.Date };
            gridControl1.DataSource = invitations.ToList();
            gridView1.Columns["م"].Visible = false;
        }


    }
}