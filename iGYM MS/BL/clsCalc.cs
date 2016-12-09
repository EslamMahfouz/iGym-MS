using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGYM_MS.BL
{
    class clsCalc
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();

        public void calcDuration(int OfferID, DateEdit dtBegin, DateEdit dtEnd)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(dtBegin.EditValue);
                var offer = db.Offers.Find(OfferID);

                if (offer.DurationID == 1)
                {
                    dt = dt.AddDays(7);
                    dtEnd.EditValue = dt;
                }
                else if (offer.DurationID == 2)
                {
                    dt = dt.AddDays(14);
                    dtEnd.EditValue = dt;
                }
                else if (offer.DurationID == 3)
                {
                    dt = dt.AddMonths(1);
                    dtEnd.EditValue = dt;
                }
                else if (offer.DurationID == 4)
                {
                    dt = dt.AddMonths(2);
                    dtEnd.EditValue = dt;
                }
                else if (offer.DurationID == 5)
                {
                    dt = dt.AddMonths(3);
                    dtEnd.EditValue = dt;
                }
                else if (offer.DurationID == 6)
                {
                    dt = dt.AddMonths(4);
                    dtEnd.EditValue = dt;
                }
                else if (offer.DurationID == 7)
                {
                    dt = dt.AddMonths(5);
                    dtEnd.EditValue = dt;
                }
                else if (offer.DurationID == 8)
                {
                    dt = dt.AddMonths(6);
                    dtEnd.EditValue = dt;
                }
                else if (offer.DurationID == 9)
                {
                    dt = dt.AddMonths(7);
                    dtEnd.EditValue = dt;
                }
                else if (offer.DurationID == 10)
                {
                    dt = dt.AddMonths(8);
                    dtEnd.EditValue = dt;
                }
                else if (offer.DurationID == 11)
                {
                    dt = dt.AddMonths(9);
                    dtEnd.EditValue = dt;
                }
                else if (offer.DurationID == 12)
                {
                    dt = dt.AddMonths(10);
                    dtEnd.EditValue = dt;
                }
                else if (offer.DurationID == 13)
                {
                    dt = dt.AddMonths(11);
                    dtEnd.EditValue = dt;
                }
                else if (offer.DurationID == 14)
                {
                    dt = dt.AddYears(1);
                    dtEnd.EditValue = dt;
                }
                else if (offer.DurationID == 15)
                {
                    dt = dt.AddYears(2);
                    dtEnd.EditValue = dt;
                }
                else if (offer.DurationID == 16)
                {
                    dt = dt.AddYears(3);
                    dtEnd.EditValue = dt;
                }
                else if (offer.DurationID == 17)
                {
                    dt = dt.AddYears(4);
                    dtEnd.EditValue = dt;
                }
                else if (offer.DurationID == 18)
                {
                    dt = dt.AddYears(5);
                    dtEnd.EditValue = dt;
                }
            }
            catch
            {
                return;
            }
        }

        public void calcCarry(TextEdit txtPaid, TextEdit txtCarry, TextEdit txtPrice)
        {
            try
            {
                if (txtPaid.Text == "")
                {
                    txtCarry.Text = txtPrice.Text;
                    txtPaid.Text = "0";
                }
                else
                    txtCarry.Text = (Convert.ToDouble(txtPrice.Text) - Convert.ToDouble(txtPaid.Text)).ToString();
            }
            catch
            {
                return;
            }
        }

        public void calcPrice(TextEdit txtPrice, TextEdit txtNumber, TextEdit txtSell)
        {
            try
            {
                txtPrice.Text = (Convert.ToDouble(txtNumber.Text) * Convert.ToDouble(txtSell.Text)).ToString();
            }
            catch
            {
                return;
            }

        }

    }
}
