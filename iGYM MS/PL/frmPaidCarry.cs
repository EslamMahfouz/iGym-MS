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
    public partial class frmPaidCarry : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        clsAdd a = new clsAdd(); clsUpdate u = new clsUpdate(); clsFill f = new clsFill();


        public int logID, TraineeID;
        public DateEdit dtBegin, dtEnd;
        public string name, offerName;

        public frmPaidCarry()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var tp = db.TraineeProfiles.Find(logID);
            tp.Paid = tp.Paid + Convert.ToDouble(txtPaid.Text);
            db.SaveChanges();
            tp.Carry = tp.Price - Convert.ToDouble(tp.Paid);
            db.SaveChanges();

            if (Convert.ToDouble(txtPaid.Text) > 0)
            {
                a.addCash(1, "دفع متبقي", Properties.Settings.Default.RecieptID.ToString(), txtPaid.Text, radioGroup1.Text, name, offerName);

                if (radioGroup1.SelectedIndex == 0)
                {
                    u.updateTraffic(Convert.ToDouble(txtPaid.Text), 0);
                }

                f.fillRpt(name, txtPaid, offerName, Convert.ToDateTime(dtBegin.EditValue), Convert.ToDateTime(dtEnd.EditValue), txtCarry.Text, radioGroup1.SelectedIndex);
                Properties.Settings.Default.RecieptID = ++Properties.Settings.Default.RecieptID;
                Properties.Settings.Default.Save();
            }

            XtraMessageBox.Show("تم الحفظ", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }
    }
}