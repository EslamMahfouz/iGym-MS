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
    public partial class frmFreezing : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        clsAdd a = new clsAdd();
        clsUpdate u = new clsUpdate();

        public int logID, number;
        public string traineeName;
        public string offerName;

        public frmFreezing()
        {
            InitializeComponent();
            from.EditValue = DateTime.Now.Date;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            u.freezing(Convert.ToDateTime(dtBegin.EditValue), Convert.ToDateTime(dtEnd.EditValue), Convert.ToDateTime(from.EditValue),
                        Convert.ToDateTime(to.EditValue), number, logID, traineeName, offerName);
            DialogResult = DialogResult.OK;
        }
    }
}