using System;
using System.Collections.Generic;
using System.Linq;
using iGYM_MS.EDM;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace iGYM_MS.BL
{
    class clsUpdate
    {
        GymEntities1 db = new GymEntities1();
        clsAdd a = new clsAdd();

        public void updateBasics(int TraineeID, TextEdit txtName, RadioGroup cmbGender, RadioGroup cmbStatus, TextEdit txtNationality, TextEdit txtDegree, TextEdit txtNationalID,
                                    TextEdit txtNotes, DateEdit dtHiring, TextEdit txtTel, TextEdit txtPhone, TextEdit AddressTextEdit, TextEdit txtMail, TextEdit txtCardNumber,
                                        DateTime dt, byte[] img)
        {
            var t = db.Trainees.Find(TraineeID);
            t.TraineeName = txtName.Text;
            t.Birtdate = dt;
            t.Gender = cmbGender.EditValue.ToString();
            t.Status = cmbStatus.EditValue.ToString();
            t.Nationality = txtNationality.Text;
            t.Degree = txtDegree.Text;
            t.NationalID = txtNationalID.Text;
            t.Notes = txtNotes.Text;
            t.JoiningDate = Convert.ToDateTime(dtHiring.EditValue);
            t.Telephone = txtTel.Text;
            t.Phone = txtPhone.Text;
            t.Address = AddressTextEdit.Text;
            t.Mail = txtMail.Text;
            t.Photo = img;
            t.CardNumber = txtCardNumber.Text;
            db.SaveChanges();
        }

        public void updateCurrent(int logID, SearchLookUpEdit cmbTrainers, TextEdit txtInvitations, TextEdit txtReports, TextEdit txtSpa, TextEdit txtMassage, TextEdit txtOthers,
                                    TextEdit txtFreeze, TextEdit txtSessionNum, ref bool frozen)
        {
            var item = db.TraineeProfiles.Find(logID);
            if (item.Active == true)
            {
                item.TrainerID = Convert.ToInt32(cmbTrainers.EditValue);
                item.Invitations = Convert.ToInt32(txtInvitations.Text);
                item.Inbody = Convert.ToInt32(txtReports.Text);
                item.SPA = Convert.ToInt32(txtSpa.Text);
                item.Massage = Convert.ToInt32(txtMassage.Text);
                item.Others = Convert.ToInt32(txtOthers.Text);
                item.Freezing = Convert.ToInt32(txtFreeze.Text);
                item.SessionsNum = Convert.ToInt32(txtSessionNum.Text);
                frozen = Convert.ToBoolean(item.Frozen);
            }
            db.SaveChanges();
        }

        public void updateTraffic(double income, double outcome)
        {
            var traffic = (from x in db.Traffic
                           where x.Status == false
                           select x).ToList();

            if (traffic.Count == 0)
            {
                Traffic f = new Traffic()
                {
                    DayDate = DateTime.Now,
                    TotalIncome = income,
                    TotalOutcome = outcome,
                    Status = false,
                };
                db.Traffic.Add(f);
                db.SaveChanges();
            }
            else
            {
                foreach (var item in traffic)
                {
                    if (item.Status == false)
                    {
                        item.TotalIncome = item.TotalIncome + income;
                        item.TotalOutcome = item.TotalOutcome + outcome;
                        break;
                    }
                }
                db.SaveChanges();
            }
        }

        public void freezing(DateTime dtBegin, DateTime dtEnd, DateTime from, DateTime to, int days, int logID, string traineeName, string offerName)
        {
            TimeSpan ts = to - from;
            if (from > dtEnd || from < dtBegin || to > dtEnd || to < dtBegin)
            {
                XtraMessageBox.Show("برجاء إختيار تاريخ صحيح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (ts.Days > days)
                {
                    XtraMessageBox.Show("المدة أكبر من المدة المسموح بها", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    var tp = db.TraineeProfiles.Find(logID);
                    if (tp.Active == true)
                    {
                        DateTime dt = DateTime.Parse(tp.To.ToString());
                        dt = dt.AddDays(ts.Days);
                        tp.To = dt;
                        tp.Freezing = Convert.ToInt32(tp.Freezing) - ts.Days;
                        tp.Frozen = true;
                        XtraMessageBox.Show("تم تجميد الإشتراك", "تجميد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        db.SaveChanges();
                        a.addCash(1, "تجميد إشتراك", 0.ToString(), 0.ToString(), "", traineeName, offerName);
                    }
                }
            }

        }

        public void deleteTrainee(int TraineeID)
        {
            var d = from x in db.TraineesDailies
                    where x.TraineeID == TraineeID
                    select x;
            foreach (var item in d)
            {
                db.TraineesDailies.Remove(item);
            }
            db.SaveChanges();
            var trainee = db.Trainees.Find(TraineeID);
            var tp = from x in db.TraineeProfiles
                     where x.TraineeID == TraineeID
                     select x;
            foreach (var item in tp)
            {
                db.TraineeProfiles.Remove(item);
            }
            db.SaveChanges();
            db.Trainees.Remove(trainee);
            db.SaveChanges();
        }
    }
}
