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
    public partial class frmAddVisit : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();

        public frmAddVisit()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EDM.Invitation inv = new EDM.Invitation()
            {
                Name = txtName.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                Nationality = txtNationality.Text,
                EmployeeID = Convert.ToInt32(cmbEmployee.EditValue),
                Date = DateTime.Now,
                Gender = cmbGender.EditValue.ToString(),
                Type = "visit"
            };
            db.Invitations.Add(inv);

            EDM.Interest inter = new EDM.Interest()
            {
                InvitationID = inv.InvitationID,
                Aerobics = Convert.ToBoolean(chkAerobics.EditValue),
                Running = Convert.ToBoolean(chkRunning.EditValue),
                Swimming = Convert.ToBoolean(chkSwimming.EditValue),
                PersonalTraining = Convert.ToBoolean(chkPersonal.EditValue),
                Rohabilitation = Convert.ToBoolean(chkRohab.EditValue),
                Fitness = Convert.ToBoolean(chkFitness.EditValue),
                WeightGaining = Convert.ToBoolean(ChkGain.EditValue),
                WeightLoss = Convert.ToBoolean(chkLoss.EditValue),
                Mas = Convert.ToBoolean(chkMas.EditValue),
                BodyBuilding = Convert.ToBoolean(chkBody.EditValue),
                Spa = Convert.ToBoolean(chkSpa.EditValue),
                Other = Convert.ToBoolean(chkOther.EditValue),

            };
            db.Interests.Add(inter);

            int SocialID = Convert.ToInt32(radioGroup1.EditValue);
            var sm = db.SocialMedias.Find(SocialID);
            sm.number = ++sm.number;
            db.SaveChanges();

            XtraMessageBox.Show("تمت الإضافة بنجاح", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;

        }

        private void frmAddVisit_Load(object sender, EventArgs e)
        {
            var Employees = from t in db.Employees
                            select new { م = t.EmployeeID, الإسم = t.EmployeeName, الهاتف = t.Phone };
            cmbEmployee.Properties.DataSource = Employees.ToList();
            cmbEmployee.Properties.PopulateViewColumns();
            cmbEmployee.Properties.DisplayMember = "الإسم";
            cmbEmployee.Properties.ValueMember = "م";
        }
    }
}