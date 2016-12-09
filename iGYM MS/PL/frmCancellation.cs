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
    public partial class frmCancellation : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        clsUpdate u = new clsUpdate(); clsFill f = new clsFill();

        public int traineeID;
        public double carry;
        public string name, offerName;
        public DateTime dtBegin, dtEnd;
        public frmCancellation()
        {
            InitializeComponent();
        }

        private void txtPrice_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPrice.Text == "")
            {
                txtCarry.Text = carry.ToString();
                return;
            }
            txtCarry.Text = (Convert.ToDouble(txtPaid.Text) - (Convert.ToDouble(txtNumber.Text) * Convert.ToDouble(txtPrice.Text))).ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(txtCarry.Text) > 0)
            {
                EDM.Outcome oc = new EDM.Outcome()
                {
                    CategoryID = 1,
                    Desc = "إلغاء إشتراك",
                    Date = DateTime.Now,
                    RecieptID = ("R" + Properties.Settings.Default.RecieptIDOut),
                    Price = txtCarry.Text,
                    TraineeID = traineeID,
                    userName = Program.Username
                };
                db.Outcomes.Add(oc);
                db.SaveChanges();
                f.fillRptCashOut(name, txtCarry, offerName, dtBegin, dtEnd, 0.ToString(), 0);
                u.updateTraffic(0, Convert.ToDouble(txtCarry.Text));
                Properties.Settings.Default.RecieptID = ++Properties.Settings.Default.RecieptIDOut;
                Properties.Settings.Default.Save();
                DialogResult = DialogResult.OK;
            }
            else
            { DialogResult = DialogResult.OK; }
        }

        private void frmCancellation_Load(object sender, EventArgs e)
        {
            txtPrice_EditValueChanged(sender, e);
        }
    }
}