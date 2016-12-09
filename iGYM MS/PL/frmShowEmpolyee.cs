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
using System.IO.Ports;
using System.Threading;
using iGYM_MS.BL;

namespace iGYM_MS.PL
{
    public partial class frmShowEmpolyee : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        public SerialPort sp = new SerialPort(Properties.Settings.Default.FirstDevice);
        clsFill f = new clsFill();
        bool add = true;

        public int EmployeeID;
        public void getEmployee()
        {
            btnChangeID.Enabled = true;
            btnDelete.Enabled = true;
            btnLog.Enabled = true;
            btnSales.Enabled = true;
            btnDaily.Enabled = true;
            fill();
        }
        void fill()
        {
            var emp = db.Employees.Find(EmployeeID);
            txtName.Text = emp.EmployeeName;
            txtCardNumber.Text = emp.CardNumber;
            dtBirth.EditValue = emp.Birthdate;
            cmbGender.EditValue = emp.Gender;
            cmbStatus.EditValue = emp.Status;
            txtNationality.Text = emp.Nationality;
            txtDegree.Text = emp.Degree;
            txtNationalID.Text = emp.NationalID;
            txtNotes.Text = emp.Notes;
            dtHiring.EditValue = emp.HiringDate;
            txtTel.Text = emp.Telephone;
            txtPhone.Text = emp.Phone;
            txtAddress.Text = emp.Address;
            txtMail.Text = emp.Mail;
            cmbJobs.EditValue = emp.JobID;
            txtExperience.Text = emp.Experience;
            txtFrom.Text = emp.From;
            txtTo.Text = emp.To;

            rdType.EditValue = emp.Type;
            txtPrice.Text = emp.Salary;
            byte[] img = emp.Photo;
            MemoryStream ms = new MemoryStream(img);
            pBox.Image = Image.FromStream(ms);
        }
        void update()
        {
            var emp = db.Employees.Find(EmployeeID);

            MemoryStream ms = new MemoryStream();
            pBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] img = ms.ToArray();
            emp.EmployeeName = txtName.Text;
            emp.Birthdate = Convert.ToDateTime(dtBirth.EditValue);
            emp.Gender = cmbGender.EditValue.ToString();
            emp.Status = cmbStatus.EditValue.ToString();
            emp.Nationality = txtNationality.Text;
            emp.Degree = txtDegree.Text;
            emp.NationalID = txtNationalID.Text;
            emp.Notes = txtNotes.Text;
            emp.HiringDate = Convert.ToDateTime(dtHiring.EditValue);
            emp.Telephone = txtTel.Text;
            emp.Phone = txtPhone.Text;
            emp.Address = txtAddress.Text;
            emp.Mail = txtMail.Text;
            emp.JobID = Convert.ToInt32(cmbJobs.EditValue);
            emp.Experience = txtExperience.Text;
            emp.From = txtFrom.Text;
            emp.To = txtTo.Text;
            emp.Type = rdType.Text;
            emp.Salary = txtPrice.Text;
            emp.Photo = img;
            db.SaveChanges();
            XtraMessageBox.Show("تم حفظ التعديلات بنجاح", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }
        void fillCmbs()
        {
            f.fillEmployees(cmbEmployees);

            var job = from j in db.Jobs
                      select new { م = j.JobID, الإسم = j.JobName, المرتب = j.Salary, سعر_الساعة = j.HourPrice };

            cmbJobs.Properties.DataSource = job.ToList();
            cmbJobs.Properties.DisplayMember = "الإسم";
            cmbJobs.Properties.ValueMember = "م";
            cmbJobs.Properties.PopulateColumns();
            cmbJobs.Properties.Columns["م"].Visible = false;

        }
        string cardNumber;

        public frmShowEmpolyee()
        {
            InitializeComponent();
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
        void chkCardNumber()
        {
            var emp = (from yy in db.Employees
                      where yy.CardNumber == cardNumber
                      select yy).ToList();

            if (emp.Count > 0)
            {
                foreach (var item in emp)
                {
                    EmployeeID = item.EmployeeID;
                    break;
                }
                getEmployee();
            }
            else
                sp.Write("error");
        }

        private void frmShowEmpolyee_Load(object sender, EventArgs e)
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

            fillCmbs();
        }

        private void cmbEmployees_EditValueChanged(object sender, EventArgs e)
        {
            EmployeeID = Convert.ToInt32(cmbEmployees.EditValue);
            getEmployee();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            update();
        }

        private void btnChangeID_Click(object sender, EventArgs e)
        {
            sp.Dispose();
            sp.Close();
            frmChangeID frm = new frmChangeID();
            frm.type = "موظف";
            frm.TraineeID = EmployeeID;
            frm.ShowDialog();
            fill();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("تأكيد الحذف؟", "سؤال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var emp = from tr in db.TraineeProfiles
                          where tr.TrainerID == EmployeeID || tr.EmployeeID == EmployeeID
                          select tr;
                foreach (var item in emp)
                {
                    item.EmployeeID = 0;
                    item.TrainerID = 0;
                }
                db.SaveChanges();
                var em = db.Employees.Find(EmployeeID);
                db.Employees.Remove(em);
                db.SaveChanges();
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            frmEmployeeLog frm = new frmEmployeeLog();
            frm.EmployeeID = EmployeeID;
            frm.ShowDialog();
        }

        private void frmShowEmpolyee_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnDaily_Click(object sender, EventArgs e)
        {
            var _emp = (from em in db.EmployeesDailies
                        where em.EmployeeID == EmployeeID
                        select em).ToList();

            if (_emp.Count == 0)
            {
                EDM.EmployeesDaily ed = new EDM.EmployeesDaily()
                {
                    EmployeeID = EmployeeID,
                    DateComing = DateTime.Now,
                    Editable = true,
                };
                db.EmployeesDailies.Add(ed);
            }
            else
            {
                foreach (var item in _emp)
                {
                    if (item.Editable == true)
                    {
                        item.DateLeaving = Convert.ToDateTime(DateTime.Now);
                        item.Editable = false;
                        item.Hours = (item.DateLeaving - item.DateComing).ToString();
                        add = false;
                    }
                }
                if (add)
                {
                    EDM.EmployeesDaily ed = new EDM.EmployeesDaily()
                    {
                        EmployeeID = EmployeeID,
                        DateComing = DateTime.Now,
                        Editable = true,
                    };
                    db.EmployeesDailies.Add(ed);
                }
            }
            db.SaveChanges();
            XtraMessageBox.Show("تم بنجاح", "حضور / إنصرف", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            frmSales frm = new frmSales();
            frm.EmployeeID = EmployeeID;
            frm.ShowDialog();
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
        }
    }
}