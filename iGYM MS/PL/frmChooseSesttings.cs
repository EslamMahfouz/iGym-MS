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
    public partial class frmChooseSesttings : DevExpress.XtraEditors.XtraForm
    {
        public frmChooseSesttings()
        {
            InitializeComponent();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            frmAddCategory frm = new frmAddCategory();
            frm.type = "income";
            frm.ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frmAddProduct frm = new frmAddProduct();
            frm.ShowDialog();
        }

        private void frmShowCategory_Click(object sender, EventArgs e)
        {
            frmShowCategory frm = new frmShowCategory();
            frm.ShowDialog();
        }

        private void btnAddOutCome_Click(object sender, EventArgs e)
        {
            frmAddCategory frm = new frmAddCategory();
            frm.type = "outcome";
            frm.ShowDialog();
        }
    }
}