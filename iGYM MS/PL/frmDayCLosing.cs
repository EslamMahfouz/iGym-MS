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
    public partial class frmDayCLosing : DevExpress.XtraEditors.XtraForm
    {
        public frmDayCLosing()
        {
            InitializeComponent();
        }

        private void rgMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rgMode.SelectedIndex == 0)
                timeEdit.Enabled = false;
            else
                timeEdit.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rgMode.SelectedIndex == 0)
                Properties.Settings.Default.Mode = "Manual";
            else
            {
                Properties.Settings.Default.Mode = "Automatic";
                Properties.Settings.Default.Time = timeEdit.Time.TimeOfDay;
            }
            Properties.Settings.Default.Save();
            XtraMessageBox.Show("تم حفظ الإعدادات", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void frmDayCLosing_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Mode == "Manual")
            {
                rgMode.SelectedIndex = 0;
                timeEdit.EditValue = Properties.Settings.Default.Time;
            }
            else
            {
                rgMode.SelectedIndex = 1;
                timeEdit.EditValue = Properties.Settings.Default.Time;
            }

        }
    }
}