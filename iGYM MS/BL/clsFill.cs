using DevExpress.XtraEditors;
using iGYM_MS.PL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using DevExpress.XtraReports.UI;

namespace iGYM_MS.BL
{
    class clsFill
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();

        public void fillOffers(LookUpEdit x)
        {
            var offer = from o in db.Offers
                        where o.frozen == false
                        select new { م = o.OfferID, العرض = o.OfferName, السعر = o.Price, النوع = o.Type, المدة = o.Duration.DurationName, الدعوات = o.Invitations, SPA = o.SPA, Massage = o.Massage, Otheres = o.Others, freezing = o.Freezing, Inbody = o.Inbody };
            x.Properties.DataSource = offer.ToList();
            x.Properties.PopulateColumns();
            x.Properties.DisplayMember = "العرض";
            x.Properties.ValueMember = "م";
        }
        public void fillEmployees(SearchLookUpEdit x)
        {
            var Employees = from t in db.Employees
                           select new { م = t.EmployeeID, الإسم = t.EmployeeName, المحمول = t.Phone, الوظيفة = t.Job.JobName };
            x.Properties.DataSource = Employees.ToList();
            x.Properties.PopulateViewColumns();
            x.Properties.DisplayMember = "الإسم";
            x.Properties.ValueMember = "م";
        }
        public void fillTrainees(SearchLookUpEdit x)
        {
            var trainees = from t in db.Trainees
                           select new { م = t.TraineeID, الإسم = t.TraineeName, المحمول = t.Phone, العنوان = t.Address, العضوية = t.CardNumber };
            x.Properties.DataSource = trainees.ToList();
            x.Properties.DisplayMember = "الإسم";
            x.Properties.ValueMember = "م";
            x.Properties.PopulateViewColumns();
            x.Properties.View.Columns["م"].Visible = false;
        }
        public void fillProducts(SearchLookUpEdit x)
        {
            var products = from p in db.Products
                           select new { م = p.ProductID, القسم = p.Category.CategoryName, الصنف = p.ProductName, تكلفة = p.Buy, بيع = p.Sell };
            x.Properties.DataSource = products.ToList();
            x.Properties.View.PopulateColumns();
            x.Properties.DisplayMember = "الصنف";
            x.Properties.ValueMember = "م";
        }
        public void fillCategories(LookUpEdit x)
        {
            var categories = from c in db.Categories
                             where c.Type == "outcome"
                             select new { م = c.CategoryID, القسم = c.CategoryName };

            x.Properties.DataSource = categories.ToList();
            x.Properties.DisplayMember = "القسم";
            x.Properties.ValueMember = "م";
            x.Properties.PopulateColumns();
            x.Properties.Columns["م"].Visible = false;
        }
        public void fillRpt(string name, TextEdit txtPaid, string offerName, DateTime dtBegin, DateTime dtEnd, string carry, int RGpaymentMethod)
        {
            var gymData = db.GymDatas.Find(1);

            ulong n = 0;
            ulong.TryParse(txtPaid.Text, out n);

            string msg = n > 0 ? NumberToText.ConvertToArabic(ulong.Parse(txtPaid.Text)) : txtPaid.Text;

            rptCashIn rpt = new rptCashIn();
            rpt.paramGymName.Value = gymData.Name;
            rpt.paramPhone.Value = gymData.Phone1;
            rpt.paramPhone2.Value = gymData.Phone2;
            rpt.paramName.Value = name;
            rpt.paramMoney.Value = txtPaid.Text;
            rpt.paramAmount.Value = msg;
            rpt.paramReceipt.Value = (Properties.Settings.Default.RecieptID);
            DateTime dt1 = DateTime.Now.Date;
            dt1 = dt1.Date;
            rpt.paramDate.Value = dt1;
            rpt.paramOffer.Value = offerName;
            DateTime dt = dtBegin;
            dt = dt.Date;
            rpt.paramFrom.Value = dt;
            dt = dtEnd;
            dt = dt.Date;
            rpt.paramTo.Value = dt;
            rpt.paramCarry.Value = carry;
            rpt.paramPhone.Value = gymData.Phone1;
            rpt.paramAddress.Value = gymData.Address;
            byte[] img = gymData.Logo;
            MemoryStream ms = new MemoryStream(img);
            Image _img = Image.FromStream(ms);
            if (RGpaymentMethod == 0)
                rpt.chk1.Checked = true;
            else
                rpt.chk2.Checked = true;
            rpt.xrPictureBox1.Image = _img;
            rpt.paramUser.Value = Program.Username;
            rpt.ShowPreview();
        }
        public void fillRptCashOut(string name, TextEdit txtPaid, string offerName, DateTime dtBegin, DateTime dtEnd, string carry, int RGpaymentMethod)
        {
            var gymData = db.GymDatas.Find(1);

            ulong n = 0;
            ulong.TryParse(txtPaid.Text, out n);

            string msg = n > 0 ? NumberToText.ConvertToArabic(ulong.Parse(txtPaid.Text)) : "اكتب رقماً";

            rptCashOut rpt = new rptCashOut();
            rpt.paramGymName.Value = gymData.Name;
            rpt.paramPhone.Value = gymData.Phone1;
            rpt.paramPhone2.Value = gymData.Phone2;
            rpt.paramName.Value = name;
            rpt.paramMoney.Value = txtPaid.Text;
            rpt.paramAmount.Value = msg;
            rpt.paramReceipt.Value = ("R" + Properties.Settings.Default.RecieptIDOut);
            DateTime dt1 = DateTime.Now.Date;
            dt1 = dt1.Date;
            rpt.paramDate.Value = dt1;
            rpt.paramOffer.Value = offerName;
            DateTime dt = dtBegin;
            dt = dt.Date;
            rpt.paramFrom.Value = dt;
            dt = dtEnd;
            dt = dt.Date;
            rpt.paramTo.Value = dt;
            rpt.paramCarry.Value = carry;
            rpt.paramPhone.Value = gymData.Phone1;
            rpt.paramAddress.Value = gymData.Address;
            byte[] img = gymData.Logo;
            MemoryStream ms = new MemoryStream(img);
            Image _img = Image.FromStream(ms);
            if (RGpaymentMethod == 0)
                rpt.chk1.Checked = true;
            rpt.xrPictureBox1.Image = _img;
            rpt.paramUser.Value = Program.Username;
            rpt.ShowPreview();
        }
        public void fillSessions(LookUpEdit x)
        {
            var sessions = from sess in db.Sessions
                           select new { م = sess.SessionID, الجلسة = sess.SessionName, السعر = sess.SessionPrice };
            x.Properties.DataSource = sessions.ToList();
            x.Properties.PopulateColumns();
            x.Properties.DisplayMember = "الجلسة";
            x.Properties.ValueMember = "م";
            x.Properties.Columns["م"].Visible = false;
        }

    }
}
