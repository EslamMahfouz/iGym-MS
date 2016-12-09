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
using iGYM_MS.BL;

namespace iGYM_MS.PL
{
    public partial class frmAddOutcome : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        clsFill f = new clsFill(); clsUpdate u = new clsUpdate(); clsAdd a = new clsAdd();

        public frmAddOutcome()
        {
            InitializeComponent();
            dtDate.EditValue = DateTime.Now;
        }

        private void frmAddOutcome_Load(object sender, EventArgs e)
        {
            f.fillCategories(cmbCategories);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!valCategory.Validate())  { return; }
            if (!valPrice.Validate())     { return; }
            
            int categoryID = Convert.ToInt32(cmbCategories.EditValue);

            a.addOutcome(categoryID, txtDesc.Text, txtReceiptID.Text, txtPrice.Text, Convert.ToDateTime(dtDate.EditValue));
            u.updateTraffic(0, Convert.ToDouble(txtPrice.Text));

            XtraMessageBox.Show("تم إضافة المصروف بنجاح", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}