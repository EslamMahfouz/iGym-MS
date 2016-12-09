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
    public partial class frmAddInvitation : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        int TraineeID;

        public frmAddInvitation()
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
                TraineeID = Convert.ToInt32(cmbTrainees.EditValue),
                Date = DateTime.Now,
                Gender = cmbGender.EditValue.ToString(),
                Type = "invitation"
            };
            TraineeID = Convert.ToInt32(cmbTrainees.EditValue);
            var trainee = from t in db.TraineeProfiles
                          where t.TraineeID == TraineeID && t.Active == true
                          select t;

            foreach (var item in trainee)
            {
                //if (item.Active == true)
                //{
                //    int num = Convert.ToInt32(item.SessionsNum);
                //    num -= 1;
                //    item.Sessions = num.ToString();
                //    break;
                //}
            }

            var sm = db.SocialMedias.Find(5);
            sm.number = ++sm.number;
            db.SaveChanges();

            db.Invitations.Add(inv);
            db.SaveChanges();

            EDM.Interest inter = new EDM.Interest()
            {
                InvitationID = inv.InvitationID,
                Aerobics = Convert.ToBoolean(chkAerobics.EditValue),
                Running = Convert.ToBoolean(chkRunning.EditValue),
                Swimming = Convert.ToBoolean(chkSwimming.EditValue),
                PersonalTraining = Convert.ToBoolean(chkPersonal.EditValue),
                Rohabilitation= Convert.ToBoolean(chkRohab.EditValue),
                Fitness=Convert.ToBoolean(chkFitness.EditValue),
                WeightGaining = Convert.ToBoolean(ChkGain.EditValue),
                WeightLoss = Convert.ToBoolean(chkLoss.EditValue),
                Mas = Convert.ToBoolean(chkMas.EditValue),
                BodyBuilding = Convert.ToBoolean(chkBody.EditValue),
                Spa = Convert.ToBoolean(chkSpa.EditValue),
                Other = Convert.ToBoolean(chkOther.EditValue),
                
            };
            db.Interests.Add(inter);
            db.SaveChanges();
            XtraMessageBox.Show("تمت الإضافة بنجاح", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void frmAddInvitation_Load(object sender, EventArgs e)
        {
            var Employees = from t in db.Employees
                           select new { م = t.EmployeeID, الإسم = t.EmployeeName, الهاتف = t.Phone };
            cmbEmployee.Properties.DataSource = Employees.ToList();
            cmbEmployee.Properties.PopulateViewColumns();
            cmbEmployee.Properties.DisplayMember = "الإسم";
            cmbEmployee.Properties.ValueMember = "م";

            var trainees = from t in db.TraineeProfiles
                           where t.Active == true && t.Frozen == false
                           select new { م = t.TraineeID, الإسم = t.Trainee.TraineeName, الهاتف = t.Trainee.Phone, العنوان = t.Trainee.Address, العضوية = t.Trainee.CardNumber };
            cmbTrainees.Properties.DataSource = trainees.ToList();
            cmbTrainees.Properties.DisplayMember = "الإسم";
            cmbTrainees.Properties.ValueMember = "م";
            cmbTrainees.Properties.PopulateViewColumns();
            cmbTrainees.Properties.View.Columns["م"].Visible = false;
        }

        private void cmbTrainees_EditValueChanged(object sender, EventArgs e)
        {
            int TraineeID = Convert.ToInt32(cmbTrainees.EditValue);
            var trainee = from tr in db.TraineeProfiles
                          where tr.TraineeID == TraineeID && tr.Active == true
                          select tr;

            foreach(var item in trainee)
            {
                try
                {
                    int num = Convert.ToInt32(item.Invitations);
                    if (num == 0)
                    {
                        XtraMessageBox.Show("لقد إنتهت دعوات هذا المشترك", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        DialogResult = DialogResult.OK;
                    }
                }
                catch
                {
                    XtraMessageBox.Show("هذا المشترك ليس له دعوات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}