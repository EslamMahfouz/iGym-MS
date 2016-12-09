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
    public partial class frmUserPassword : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();

        public frmUserPassword()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!valConfirm.Validate())
            { return; }

            var u = db.Users.Find(Program.UserID);
            if (txtOld.Text != u.Password)
            {
                XtraMessageBox.Show("الباسورد غير صحيح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            u.Password = txtNew.Text;
            db.SaveChanges();
            XtraMessageBox.Show("تم تعديل الباسورد", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}