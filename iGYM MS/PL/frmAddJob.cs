using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace iGYM_MS.PL
{
    public partial class frmAddJob : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        bool edit = false;
        int jobID;

        public frmAddJob()
        {
            InitializeComponent();
        }

        void ClrBoxs()
        {
            txtName.Text = "";
            txtSalary.Text = "";
            txtHourPrice.Text = "";
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!valName.Validate())
            { return; }

            if (!edit)
            {
                EDM.Job j = new EDM.Job()
                {
                    JobName = txtName.Text,
                    Salary = txtSalary.Text,
                    HourPrice = txtHourPrice.Text
                };
                db.Jobs.Add(j);
                db.SaveChanges();
                XtraMessageBox.Show("تم إضافة الوظيفة بنجاح", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClrBoxs();
            }
            else
            {
                var job = db.Jobs.Find(jobID);
                job.JobName = txtName.Text;
                job.Salary = txtSalary.Text;
                job.HourPrice = txtHourPrice.Text;
                db.SaveChanges();
                XtraMessageBox.Show("تم تعديل الوظيفة بنجاح", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClrBoxs();
            }

            edit = false;
            frmAddJob_Load(sender, e);
            cmbJobs.EditValue = -1;
        }

        private void frmAddJob_Load(object sender, EventArgs e)
        {
            var jobs = from x in db.Jobs
                       select new { م = x.JobID, الوظيفة = x.JobName };
            cmbJobs.Properties.DataSource = jobs.ToList();
            cmbJobs.Properties.DisplayMember = "الوظيفة";
            cmbJobs.Properties.ValueMember = "م";
            cmbJobs.Properties.PopulateColumns();
            cmbJobs.Properties.Columns["م"].Visible = false;
        }

        private void cmbJobs_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                edit = false;
                ClrBoxs();
                cmbJobs.EditValue = -1;
            }
        }

        private void cmbJobs_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                jobID = Convert.ToInt32(cmbJobs.EditValue);
                var job = db.Jobs.Find(jobID);
                txtName.Text = job.JobName;
                txtSalary.Text = job.Salary;
                txtHourPrice.Text = job.HourPrice;
                edit = true;
            }
            catch
            {
                return;
            }
        }
    }
}