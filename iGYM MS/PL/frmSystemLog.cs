using System;
using System.Collections.Generic;
using System.Linq;
using iGYM_MS.BL;

namespace iGYM_MS.PL
{
    public partial class frmSystemLog : DevExpress.XtraEditors.XtraForm
    {
        clsGet g = new clsGet();

        DateTime dtFrom, dtTo;
        void fill()
        {
            g.getLoginLog(dtFrom, dtTo, gridControl1);
            g.getJoining(dtFrom, dtTo, gridControl2);
            g.getIncomes(dtFrom, dtTo, gridControl3);
            g.getOutcoems(dtFrom, dtTo, gridControl4);
        }

        public frmSystemLog()
        {
            InitializeComponent();
            dtDateFrom.EditValue = DateTime.Now.Date;
            dtDateTo.EditValue = DateTime.Now.Date;
        }

        private void dtDateTo_EditValueChanged(object sender, EventArgs e)
        {
            dtFrom = Convert.ToDateTime(dtDateFrom.EditValue);
            dtFrom = dtFrom.Date;
            dtTo = Convert.ToDateTime(dtDateTo.EditValue);
            dtTo = dtTo.Date;
            fill();
        }

        private void dtDateFrom_EditValueChanged(object sender, EventArgs e)
        {
            dtFrom = Convert.ToDateTime(dtDateFrom.EditValue);
            dtFrom = dtFrom.Date;
            dtTo = Convert.ToDateTime(dtDateTo.EditValue);
            dtTo = dtTo.Date;
            fill();
        }
    }
}