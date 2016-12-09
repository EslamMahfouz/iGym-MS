using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGYM_MS.BL
{
    class clsGet
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();

        public void getOffer(int OfferID, ref string offerName, ref int freezing, ref int invitations, ref int spa,
                                ref int massage, ref int others, ref int inbody, ref int sessionNum, ref string type, TextEdit txtPrice)
        {
            var offer = db.Offers.Find(OfferID);
            offerName = offer.OfferName;
            freezing = Convert.ToInt32(offer.Freezing);
            invitations = Convert.ToInt32(offer.Invitations);
            spa = Convert.ToInt32(offer.SPA);
            massage = Convert.ToInt32(offer.Massage);
            others = Convert.ToInt32(offer.Others);
            inbody = Convert.ToInt32(offer.Inbody);
            sessionNum = Convert.ToInt32(offer.SessionsNum);
            type = offer.Type;
            txtPrice.Text = offer.Price;
        }

        public void getBasics(int traineeID, TextEdit txtID, TextEdit txtCardNumber, TextEdit txtName, DateEdit dtBirthdate, RadioGroup cmbGender, RadioGroup cmbStatus,
                                TextEdit txtNationality, TextEdit txtDegree, TextEdit txtNationalID, TextEdit txtNotes, DateEdit dtHiring, TextEdit txtTel, TextEdit txtPhone,
                                    TextEdit AddressTextEdit, TextEdit txtMail, PictureEdit pBox)
        {
            try
            {
                var t = db.Trainees.Find(traineeID);
                txtID.Text = t.TraineeID.ToString();
                txtCardNumber.Text = t.CardNumber;
                txtName.Text = t.TraineeName;
                dtBirthdate.EditValue = t.Birtdate;
                cmbGender.EditValue = t.Gender;
                cmbStatus.EditValue = t.Status;
                txtNationality.Text = t.Nationality;
                txtDegree.Text = t.Degree;
                txtNationalID.Text = t.NationalID;
                txtNotes.Text = t.Notes;
                dtHiring.EditValue = t.JoiningDate;
                txtTel.Text = t.Telephone;
                txtPhone.Text = t.Phone;
                AddressTextEdit.Text = t.Address;
                txtMail.Text = t.Mail;
                byte[] img = t.Photo;
                MemoryStream ms = new MemoryStream(img);
                pBox.Image = Image.FromStream(ms);
            }
            catch
            { return; }

        }

        public void getCurrent(int traineeID, LookUpEdit cmbOffers, RadioGroup rdTYPE, DateEdit dtBegin, DateEdit dtEnd, TextEdit txtPrice, ref TextEdit txtPaid, ref TextEdit txtCarry,
                                SearchLookUpEdit cmbTrainers, SearchLookUpEdit cmbEmployees, TextEdit txtInvitations, TextEdit txtReports, TextEdit txtSpa, TextEdit txtMassage,
                                 TextEdit txtOthers, TextEdit txtFreeze, TextEdit txtSessionNum, ref bool frozen, SimpleButton btnFreeze, ref int logID, ref string offerName)
        {
            txtCarry.Text = "";
            txtPaid.Text = "";
            var tp = from x in db.TraineeProfiles
                     where x.TraineeID == traineeID && x.Active == true
                     select x;

            foreach (var item in tp)
            {
                if (item.Active == true)
                {
                    logID = item.LogID;
                    cmbOffers.EditValue = item.OfferID;
                    if (item.Type == "أيام")
                        rdTYPE.SelectedIndex = 0;
                    else
                        rdTYPE.SelectedIndex = 1;

                    dtBegin.EditValue = item.From;
                    dtEnd.EditValue = item.To;
                    txtPrice.Text = item.Price.ToString();
                    txtPaid.Text = item.Paid.ToString();
                    txtCarry.Text = item.Carry.ToString();
                    cmbTrainers.EditValue = item.TrainerID;
                    cmbEmployees.EditValue = item.EmployeeID;
                    txtInvitations.Text = item.Invitations.ToString();
                    txtReports.Text = item.Inbody.ToString();
                    txtSpa.Text = item.SPA.ToString();
                    txtMassage.Text = item.Massage.ToString();
                    txtOthers.Text = item.Others.ToString();
                    txtFreeze.Text = item.Freezing.ToString();
                    txtSessionNum.Text = item.SessionsNum.ToString();
                    frozen = Convert.ToBoolean(item.Frozen);
                    offerName = item.Offer.OfferName;
                    break;
                }
            }
            if (frozen)
                btnFreeze.Text = "إلغاء تجميد الإشتراك";
            if (!frozen)
                btnFreeze.Text = "تجميد الإشتراك"; 
        }

        public void getLog(GridControl x, int traineeID)
        {
            x.DataSource = null;
            var tp = from tp_ in db.TraineeProfiles
                     where tp_.TraineeID == traineeID
                     select new { العرض = tp_.Offer.OfferName, من = tp_.From, إلي = tp_.To, السعر = tp_.Price, دفع = tp_.Paid, متبقي = tp_.Carry, نشط = tp_.Active, ملغي = tp_.Canceled, freezed = tp_.Frozen, transfered = tp_.Transfered };
            x.DataSource = tp.ToList();
        }

        public void getInbody(int TraineeID, GridControl x, GridView y)
        {
            var ir = from r in db.InbodyReports
                     where r.TraineeProfile.TraineeID == TraineeID
                     select new { م = r.InodyID, التاريخ = r.Date };
            x.DataSource = ir.ToList();
            y.Columns["م"].Visible = false;
        }
        public void getInvitations(int traineeID, GridControl x)
        {
            var inv = from r in db.Invitations
                      where r.TraineeID == traineeID && r.Type == "دعوة"
                      select new { الإسم = r.Name, العنوان = r.Address, المحمول = r.Phone, النوع = r.Gender, التاريخ = r.Date };
            x.DataSource = inv.ToList();
        }
        
        public void getLoginLog(DateTime fromDate, DateTime toDate, GridControl y)
        {
            var logs = from x in db.Logins
                       let z = EntityFunctions.CreateTime(x.date.Hour, x.date.Minute, x.date.Second)
                       where ((EntityFunctions.TruncateTime(x.date)) >= fromDate && (EntityFunctions.TruncateTime(x.date)) <= toDate)
                       select new { المستخدم = x.userName, الوقت = z, العملية = x.action };
            y.DataSource = logs.ToList();
        }
        public void getJoining(DateTime fromDate, DateTime toDate, GridControl y)
        {
            var joins = from x in db.CashIns
                        let z = EntityFunctions.CreateTime(x.Date.Hour, x.Date.Minute, x.Date.Second)
                        where ((EntityFunctions.TruncateTime(x.Date)) >= fromDate && (EntityFunctions.TruncateTime(x.Date)) <= toDate) && (x.Category.CategoryName == "إشتراكات" || x.Category.CategoryName == "جلسات")
                        select new { المستخدم = x.userName, الوقت = z, العملية = x.Desc, المشترك = x.TraineeName, الإشتراك = x.OfferName, الإيصال = x.RecieptID, دفع = x.Price, طريقة_الدفع = x.Type };
            y.DataSource = joins.ToList();
        }
        public void getIncomes(DateTime fromDate, DateTime toDate, GridControl y)
        {
            var income = from x in db.CashIns
                         let z = EntityFunctions.CreateTime(x.Date.Hour, x.Date.Minute, x.Date.Second)
                         where ((EntityFunctions.TruncateTime(x.Date)) >= fromDate && (EntityFunctions.TruncateTime(x.Date)) <= toDate && x.Category.CategoryName != "إشتراكات" && x.Category.CategoryName != "جلسات" && x.Category.Type == "income") || x.Desc == "غلق اليوم"
                         select new { المستخدم = x.userName, الوقت = z, القسم = x.Category.CategoryName, الصنف = x.Desc, رقم_الإيصال = x.RecieptID, المبلغ = x.Price, الدفع = x.Type };
            y.DataSource = income.ToList();
        }
        public void getOutcoems(DateTime fromDate, DateTime toDate, GridControl y)
        {
            var outcome = from x in db.Outcomes
                         let z = EntityFunctions.CreateTime(x.Date.Value.Hour, x.Date.Value.Minute, x.Date.Value.Second)
                          where EntityFunctions.TruncateTime(x.Date) >= fromDate && EntityFunctions.TruncateTime(x.Date) <= toDate
                         select new { المستخدم = x.userName, الوقت = z, حساب_المصروف = x.Category.CategoryName, الوصف = x.Desc, رقم_الإيصال = x.RecieptID, المبلغ = x.Price};
            y.DataSource = outcome.ToList();
        }
    }
}
