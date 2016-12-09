using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iGYM_MS.EDM;
using DevExpress.XtraEditors;

namespace iGYM_MS.BL
{
    class clsAdd
    {
        GymEntities1 db = new GymEntities1();

        public void addTrainee(TextEdit txtCardNumber, TextEdit txtName, DateTime dt, RadioGroup cmbGender, RadioGroup cmbStatus, TextEdit txtNationality, 
                                TextEdit txtDegree, TextEdit txtNationalID, TextEdit txtNotes, DateEdit dtHiring, TextEdit txtTel, TextEdit txtPhone, TextEdit txtAddress, TextEdit txtMail, 
                                byte[] img, RadioGroup radioGroup1, ref int traineeID)
        {
            Trainee t = new Trainee()
            {
                CardNumber = txtCardNumber.Text,
                TraineeName = txtName.Text,
                Birtdate = dt,
                Gender = cmbGender.EditValue.ToString(),
                Status = cmbStatus.EditValue.ToString(),
                Nationality = txtNationality.Text,
                Degree = txtDegree.Text,
                NationalID = txtNationalID.Text,
                Notes = txtNotes.Text,
                JoiningDate = Convert.ToDateTime(dtHiring.EditValue),
                Telephone = txtTel.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text,
                Mail = txtMail.Text,
                Photo = img,
                SocialID = Convert.ToInt32(radioGroup1.EditValue),
            };
            db.Trainees.Add(t);
            db.SaveChanges();
            traineeID = t.TraineeID;
        }

        public void addTraineeProfile(int TraineeID, LookUpEdit cmbOffers, DateEdit dtBegin, DateEdit dtEnd, TextEdit txtPrice, TextEdit txtPaid, TextEdit txtCarry, int sessionNum,
                                       int freezing, int invitations, int spa, int massage, int others, int inbody, RadioGroup RGpaymentMethod, string type, ref int LogID, SearchLookUpEdit cmbTrainers, SearchLookUpEdit cmbEmployee)
        {
            TraineeProfile tp = new TraineeProfile()
            {
                TraineeID = TraineeID,
                OfferID = Convert.ToInt32(cmbOffers.EditValue),
                From = Convert.ToDateTime(dtBegin.EditValue),
                To = Convert.ToDateTime(dtEnd.EditValue),
                Price = Convert.ToDouble(txtPrice.Text),
                Paid = Convert.ToDouble(txtPaid.Text),
                Carry = Convert.ToDouble(txtCarry.Text),
                SessionsNum = sessionNum,
                Freezing = freezing,
                Invitations = invitations,
                SPA = spa,
                Massage = massage,
                Others = others,
                Inbody = inbody,
                Active = true,
                Frozen = false,
                Canceled = false,
                Transfered = false,
                PaymentMethod = RGpaymentMethod.Text,
                Type = type,
                TrainerID = Convert.ToInt32(cmbTrainers.EditValue),
                EmployeeID = Convert.ToInt32(cmbEmployee.EditValue),
            };
            db.TraineeProfiles.Add(tp);
            db.SaveChanges();
            LogID = tp.LogID;
        }

        public void incrementSocialMedia(int SocialID) 
        {
            var sm = db.SocialMedias.Find(SocialID);
            sm.number = ++sm.number;
            db.SaveChanges();
        }

        public void addLoginLog(string action)
        {
            Login l = new Login()
            {
                date = DateTime.Now,
                userName = Program.Username,
                action = action,
            };
            db.Logins.Add(l);
            db.SaveChanges();
        }

        public void addCash(int categoryID, string desc, string receiptID, string price, string type, string TraineeName, string offerName)
        {
            CashIn cash = new CashIn()
            {
                Date = DateTime.Now,
                CategoryID = categoryID,
                Desc = desc,
                RecieptID = receiptID,
                Price = price,
                Type = type,
                TraineeName = TraineeName,
                userName = Program.Username,
                OfferName = offerName,
            };
            db.CashIns.Add(cash);
            db.SaveChanges();
        }

        public void addCash(int categoryID, string desc, string receiptID, string price, string type, string TraineeName, string offerName, DateTime date)
        {
            CashIn cash = new CashIn()
            {
                Date = date,
                CategoryID = categoryID,
                Desc = desc,
                RecieptID = receiptID,
                Price = price,
                Type = type,
                TraineeName = TraineeName,
                userName = Program.Username,
                OfferName = offerName,
            };
            db.CashIns.Add(cash);
            db.SaveChanges();
        }

        public void addCash(string desc, DateTime date)
        {
            CashIn cash = new CashIn()
            {
                Date = date,
                Desc = desc,
                userName = Program.Username,
            };
            db.CashIns.Add(cash);
            db.SaveChanges();
        }

        public void addOrder(DateEdit dtDate, string desc, string total, ref int orderID)
        {
            Order order = new Order()
            {
                Date = Convert.ToDateTime(dtDate.EditValue),
                Desc = desc,
                Total = total,
                ReceiptID = ""
            };
            db.Orders.Add(order);
            db.SaveChanges();
            orderID = order.OrderID;
        }
        public void addOrderDetails(int orderID, int productID, string sell, string number, string price)
        {
            OrderDetail od = new OrderDetail()
            {
                OrderID = orderID,
                ProductID = productID,
                Sell = sell,
                Number = number,
                Price = price
            };
            db.OrderDetails.Add(od);
            db.SaveChanges();
        }

        public void addOutcome(int categoryID, string desc, string receipt, string price, DateTime dtDate)
        {
            double outcome = Convert.ToDouble(price);
            Outcome oc = new Outcome()
            {
                CategoryID = categoryID,
                Desc = desc,
                RecieptID = receipt,
                Price = price,
                Date = dtDate,
                userName = Program.Username,
            };
            db.Outcomes.Add(oc);
            db.SaveChanges();
        }

    }
}
