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
using System.Net.NetworkInformation;

namespace iGYM_MS.PL
{
    public partial class frmActivate : DevExpress.XtraEditors.XtraForm
    {
        public static string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            } return sMacAddress;
        }

        static int CalculateHashForMonth(string serial)
        {
            int hashedValue = 0;
            for (int i = 0; i < serial.Length; i++)
            {
                hashedValue += (int)Convert.ToChar(serial[i]);
                hashedValue *= 4;
            }
            return hashedValue;
        }
        static int CalculateHashForYear(string serial)
        {
            int hashedValue = 0;
            for (int i = 0; i < serial.Length; i++)
            {
                hashedValue += (int)Convert.ToChar(serial[i]);
                hashedValue *= 3;
            }
            return hashedValue;
        }
        static int CalculateHashForEver(string serial)
        {
            int hashedValue = 0;
            for (int i = 0; i < serial.Length; i++)
            {
                hashedValue += (int)Convert.ToChar(serial[i]);
                hashedValue *= 2;
            }
            return hashedValue;
        }

        string calcForMonth()
        {
            return CalculateHashForMonth(txtSerial.Text).ToString();
        }
        string calcForYear()
        {
            return CalculateHashForYear(txtSerial.Text).ToString();
        }
        string calcForEver()
        {
            return CalculateHashForEver(txtSerial.Text).ToString();
        }

        public frmActivate()
        {
            InitializeComponent();
            txtSerial.Text = GetMACAddress();
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            try
            {
                string checkMonth = calcForMonth();
                string checkYear = calcForYear();
                string checkEver = calcForEver();

                if (Convert.ToInt32(txtCode.Text) == Convert.ToInt32(checkMonth))
                {
                    Properties.Settings.Default.PaidMonth = true;
                    Properties.Settings.Default.PaidYear = false;
                    Properties.Settings.Default.PaidEver = false;
                    Properties.Settings.Default.Save();
                    XtraMessageBox.Show("تم التفعيل لمدة شهر", "التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else if (Convert.ToInt32(txtCode.Text) == Convert.ToInt32(checkYear))
                {
                    Properties.Settings.Default.PaidMonth = true;
                    Properties.Settings.Default.PaidYear = true;
                    Properties.Settings.Default.PaidEver = false;
                    Properties.Settings.Default.Save();
                    XtraMessageBox.Show("تم التفعيل لمدة سنة", "التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else if (Convert.ToInt32(txtCode.Text) == Convert.ToInt32(checkEver))
                {
                    Properties.Settings.Default.PaidMonth = true;
                    Properties.Settings.Default.PaidYear = true;
                    Properties.Settings.Default.PaidEver = true;
                    Properties.Settings.Default.Save();
                    XtraMessageBox.Show("تم التفعيل مدي الحياة", "التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    XtraMessageBox.Show("من فضلك أدخل رقم سيريال صحيح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                XtraMessageBox.Show("من فضلك أدخل رقم سيريال صحيح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
 
    }
}

        
    
