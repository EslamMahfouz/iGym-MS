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
    public partial class frmTraffic : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();

        public frmTraffic()
        {
            InitializeComponent();
            dtDate.EditValue = DateTime.Now.Date;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DateTime dt = Convert.ToDateTime(dtDate.EditValue);
            dt = dt.Date;
            try
            {
                var c = db.Traffic.Find(dt);
                txtCredit.Text = (c.TotalIncome - c.TotalOutcome).ToString();
                txtIncome.Text = c.TotalIncome.ToString();
                txtOutCome.Text = c.TotalOutcome.ToString();
            }
            catch
            {
                txtCredit.Text = "";
                txtIncome.Text = "";
                txtOutCome.Text = "";
            }
        }

        private void frmTraffic_Load(object sender, EventArgs e)
        {
            btnShow_Click(sender, e);
        }
    }
}