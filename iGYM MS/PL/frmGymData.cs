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
using System.Security.AccessControl;

namespace iGYM_MS.PL
{
    public partial class frmGymData : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();

        public frmGymData()
        {
            InitializeComponent();
        }

        private void frmGymData_Load(object sender, EventArgs e)
        {
            try
            {
                var gymData = db.GymDatas.Find(1);
                txtName.Text = gymData.Name;
                txtAddress.Text = gymData.Address;
                txtPhone1.Text = gymData.Phone1;
                txtPhone2.Text = gymData.Phone2;
                txtMail.Text = gymData.Mail;
                byte[] img = gymData.Logo;
                MemoryStream ms = new MemoryStream(img);
                pBox.Image = Image.FromStream(ms);
                txtBackup.Text = Properties.Settings.Default.BackupFolder;
            }
            catch
            {
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] img = ms.ToArray();

            var gd = db.GymDatas.Find(1);
            gd.Name = txtName.Text;
            gd.Address = txtAddress.Text;
            gd.Phone1 = txtPhone1.Text;
            gd.Phone2 = txtPhone2.Text;
            gd.Mail = txtMail.Text;
            gd.Logo = img;
            db.SaveChanges();
            XtraMessageBox.Show("تم حفظ التعديلات بنجاح", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        
        
            
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtBackup.Text = folderBrowserDialog1.SelectedPath;
                    Properties.Settings.Default.BackupFolder = txtBackup.Text;
                    Properties.Settings.Default.Save();
                    File.SetAttributes(Properties.Settings.Default.BackupFolder, File.GetAttributes(Properties.Settings.Default.BackupFolder) & ~FileAttributes.ReadOnly);
                    DirectoryInfo dInfo = new DirectoryInfo(Properties.Settings.Default.BackupFolder);
                    DirectorySecurity dSecurity = dInfo.GetAccessControl();
                    dSecurity.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
                    dInfo.SetAccessControl(dSecurity);
                }
            }
            catch
            {
                XtraMessageBox.Show("برجاء إختيار فولدر أخر", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}