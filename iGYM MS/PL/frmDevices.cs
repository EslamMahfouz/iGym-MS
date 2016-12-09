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
using System.IO.Ports;
using System.Threading;

namespace iGYM_MS.PL
{
    public partial class frmDevices : DevExpress.XtraEditors.XtraForm
    {
        public string cardNumber1, cardNumber2;

        public static SerialPort sp1 = new SerialPort(Properties.Settings.Default.FirstDevice);
        public static SerialPort sp2 = new SerialPort(Properties.Settings.Default.SecondDevice);

        public frmDevices()
        {
            InitializeComponent();
            frmMain.sp1.Dispose();
            frmMain.sp1.Close();
            frmMain.sp2.Dispose();
            frmMain.sp2.Close();

            string[] comPorts = SerialPort.GetPortNames();
            foreach (string com in comPorts)
            {
                cmbFirst.Properties.Items.Add(com);
                cmbSecond.Properties.Items.Add(com);
            }
        }

        private void frmDevices_Load(object sender, EventArgs e)
        {
            cmbFirst.Text = Properties.Settings.Default.FirstDevice;
            cmbSecond.Text = Properties.Settings.Default.SecondDevice;
            frmMain.sp1.Dispose();
            frmMain.sp1.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FirstDevice = cmbFirst.Text;
            Properties.Settings.Default.SecondDevice = cmbSecond.Text;
            Properties.Settings.Default.Save();
            XtraMessageBox.Show("تم حفظ الإعدادات", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                sp1 = new SerialPort(Properties.Settings.Default.FirstDevice);
                sp2 = new SerialPort(Properties.Settings.Default.SecondDevice);
                this.Close();
            }
            catch
            {
                this.Close();
            }
        }

        private void btnConnect1_Click(object sender, EventArgs e)
        {
            if (sp1.IsOpen)
            {
                sp1.Write("connected");
            }
        }

        private void btnConnect2_Click(object sender, EventArgs e)
        {
            if (sp2.IsOpen)
            {
                sp2.Write("connected");
            }
        }

        private void frmDevices_FormClosing(object sender, FormClosingEventArgs e)
        {
            string[] comPorts = SerialPort.GetPortNames();
            foreach (string com in comPorts)
            {
                sp1.Dispose();
                sp1.Close();
                try
                {
                    frmMain.sp1.Open();
                }
                catch
                {
                    return;
                }
            }
        }
    }
}