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
using iGYM_MS.EDM;
using System.IO.Ports;
using System.Threading;

namespace iGYM_MS.PL
{
    public partial class frmAddEmplyee : DevExpress.XtraEditors.XtraForm
    {
        GymEntities1 db = new GymEntities1();
        SerialPort sp = new SerialPort(Properties.Settings.Default.FirstDevice);

        string cardNumber;

        void chkCardNumber()
        {
            var x = (from y in db.Employees
                     where y.CardNumber == cardNumber
                     select y).ToList();

            var xx = (from yy in db.Trainees
                      where yy.CardNumber == cardNumber
                      select yy).ToList();

            if (x.Count > 0 || xx.Count > 0)
            {
                XtraMessageBox.Show("هذا الكارت مستخدم بالفعل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                txtCardNumber.Text = cardNumber;
            }

        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            cardNumber = sp.ReadLine();
            Thread.Sleep(100);
            if (this.InvokeRequired)
            {
                this.Invoke((Action)chkCardNumber);
            }
        }

        public frmAddEmplyee()
        {
            InitializeComponent();
            dtHiring.EditValue = DateTime.Now.Date;
            txtFrom.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 00, 00);
            txtTo.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 00, 00);
        }
        private void frmAddEmplyee_Load(object sender, EventArgs e)
        {
            string[] comPorts = SerialPort.GetPortNames();
            foreach (string com in comPorts)
            {
                if (Properties.Settings.Default.FirstDevice == com)
                {
                    frmMain.sp1.Dispose();
                    frmMain.sp1.Close();
                    sp.BaudRate = 9600;
                    sp.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    sp.Open();
                    sp.Write("connected");
                }
            }

            var jobs = from j in db.Jobs
                       select new { م = j.JobID, الوظيفة = j.JobName, المرتب = j.Salary, سعر_الساعة = j.HourPrice };

            cmbJobs.Properties.DataSource = jobs.ToList();
            cmbJobs.Properties.DisplayMember = "الوظيفة";
            cmbJobs.Properties.ValueMember = "م";
            cmbJobs.Properties.PopulateColumns();
            cmbJobs.Properties.Columns["م"].Visible = false;
            rdType_SelectedIndexChanged(sender, e);
        }

        private void rdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdType.SelectedIndex == 0)
            {
                lblPrice.Text = "المرتب الشهري";
            }
            else
            {
                lblPrice.Text = "الأجر بالساعة";
            }
            cmbJobs_EditValueChanged(sender, e);
        }
        private void cmbJobs_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(cmbJobs.EditValue);
                var job = db.Jobs.Find(id);
                if (rdType.SelectedIndex == 0)
                {
                    txtPrice.Text = job.Salary;
                }
                else
                {
                    txtPrice.Text = job.HourPrice;
                }
            }
            catch
            {
                return;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!valGender.Validate())
            { return; }
            if (!valJob.Validate())
            { return; }
            MemoryStream ms = new MemoryStream();
            pBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] img = ms.ToArray();

            Employee o = new Employee()
            {
                EmployeeName = txtName.Text,
                Birthdate = Convert.ToDateTime(dtBirth.EditValue),
                Gender = cmbGender.EditValue.ToString(),
                Status = cmbStatus.EditValue.ToString(),
                Nationality = txtNationality.Text,
                Degree = txtDegree.Text,
                NationalID = txtNationalID.Text,
                Notes = txtNotes.Text,
                HiringDate = Convert.ToDateTime(dtHiring.EditValue),
                Telephone = txtTel.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text,
                Mail = txtMail.Text,
                JobID = Convert.ToInt32(cmbJobs.EditValue),
                Experience = txtExperience.Text,
                From = txtFrom.Text,
                To = txtTo.Text,
                Type = rdType.EditValue.ToString(),
                Salary = txtPrice.Text,
                Photo = img,
                CardNumber = txtCardNumber.Text,
            };
            db.Employees.Add(o);
            db.SaveChanges();
            XtraMessageBox.Show("تمت الإضافة بنجاح", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void frmAddEmplyee_FormClosing(object sender, FormClosingEventArgs e)
        {
            string[] comPorts = SerialPort.GetPortNames();
            foreach (string com in comPorts)
            {
                if (Properties.Settings.Default.FirstDevice == com)
                {
                    sp.Dispose();
                    sp.Close();
                    frmMain.sp1.Open();
                }
            }
        }
    }
}