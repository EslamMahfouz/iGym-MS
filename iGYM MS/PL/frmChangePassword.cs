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
    public partial class frmChangePassword : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        public int userID;

        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!valPassword.Validate())
            { return; }
            if (!valConfirm.Validate())
            { return; }

            var user = db.Users.Find(userID);
            user.Password = txtNew.Text;
            db.SaveChanges();
            XtraMessageBox.Show("تم التعديل", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}