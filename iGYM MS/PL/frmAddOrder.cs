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
using iGYM_MS.BL;
using iGYM_MS.EDM;

namespace iGYM_MS.PL
{
    public partial class frmAddOrder : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        clsFill f = new clsFill(); clsCalc c = new clsCalc(); clsAdd a = new clsAdd(); clsUpdate u = new clsUpdate();

        DataTable dt = new DataTable();
        int orderID;

        public frmAddOrder()
        {
            InitializeComponent();
            dtDate.EditValue = DateTime.Now;
            dt.Columns.Add("م");
            dt.Columns.Add("الصنف");
            dt.Columns.Add("سعر الوحدة");
            dt.Columns.Add("العدد");
            dt.Columns.Add("الثمن");
        }

        private void frmAddOrder_Load(object sender, EventArgs e)
        {
            f.fillProducts(cmbProducts);
        }

        private void cmbProducts_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int prdID = Convert.ToInt32(cmbProducts.EditValue);
                var product = db.Products.Find(prdID);
                txtSell.Text = product.Sell;
                c.calcPrice(txtPrice, txtNumber, txtSell);
            }
            catch
            {
                return; 
            }
        }

        private void txtSell_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSell.Text == "")
            {
                txtPrice.Text = "";
                return;
            }
            c.calcPrice(txtPrice, txtNumber, txtSell);
        }

        private void txtNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (txtNumber.Text == "")
            {
                txtPrice.Text = "";
                return;
            }
            c.calcPrice(txtPrice, txtNumber, txtSell);
        }

        private void btnAddTo_Click(object sender, EventArgs e)
        {
            double total = 0;
            if (Convert.ToInt32(cmbProducts.EditValue) == 0 || txtPrice.Text == "")
            {
                return;
            }
            foreach (DataRow dr1 in dt.Rows)
            {
                if (Convert.ToInt32(cmbProducts.EditValue) == Convert.ToInt32(dr1["م"]))
                {
                    XtraMessageBox.Show("هذا المنتج موجود بالفعل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            DataRow dr = dt.NewRow();
            int prdID = Convert.ToInt32(cmbProducts.EditValue);
            string prdName = cmbProducts.Text;
            string sell = txtSell.Text;
            string number = txtNumber.Text;
            string price = txtPrice.Text;
            dr["م"] = prdID;
            dr["الصنف"] = prdName;
            dr["سعر الوحدة"] = sell;
            dr["العدد"] = number;
            dr["الثمن"] = price;
            dt.Rows.Add(dr);
            gridControl1.DataSource = dt;

            foreach (DataRow dr_ in dt.Rows)
            {
                total += Convert.ToDouble (dr_["الثمن"]);
            }
            txtTotal.Text = total.ToString();
            btnClear_Click(sender, e);
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            int prdID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("م"));
            string name = gridView1.GetFocusedRowCellValue("الصنف").ToString();
            string sell = gridView1.GetFocusedRowCellValue("سعر الوحدة").ToString();
            string number = gridView1.GetFocusedRowCellValue("العدد").ToString();
            string price = gridView1.GetFocusedRowCellValue("الثمن").ToString();

            cmbProducts.EditValue = prdID;
            txtNumber.Text = name;
            txtSell.Text = sell;
            txtNumber.Text = number;
            txtPrice.Text = price;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (Convert.ToInt32(dr["م"]) == prdID)
                {
                    dr.Delete();
                    break;
                }
            }
            gridControl1.DataSource = dt;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbProducts.EditValue = 0;
            txtSell.Text = "";
            txtNumber.Text = "";
            txtPrice.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            a.addOrder(dtDate, txtDescription.Text, txtTotal.Text, ref orderID);
            foreach (DataRow dr in dt.Rows)
            {
                int productID = Convert.ToInt32(dr["م"]);
                string sell = dr["سعر الوحدة"].ToString();
                string number = dr["العدد"].ToString();
                string price = dr["الثمن"].ToString();
                string productName = dr["الصنف"].ToString();
                a.addOrderDetails(orderID, productID, sell, number, price);
                var p = db.Products.Find(productID);
                int categoryID = Convert.ToInt32(p.CategoryID);

                CashIn cash = new CashIn()
                {
                    Date = Convert.ToDateTime(dtDate.EditValue),
                    CategoryID = categoryID,
                    Desc = productName,
                    RecieptID = "",
                    Price = price,
                    Type = RGpaymentMethod.Text,
                    TraineeName = "",
                    userName = Program.Username,
                    OfferName = "",
                };
                db.CashIns.Add(cash);
                db.SaveChanges();
            }
            db.SaveChanges();
            if (RGpaymentMethod.SelectedIndex == 0)
            {
                u.updateTraffic(Convert.ToDouble(txtTotal.Text), 0);
            }
            XtraMessageBox.Show("تم إضافة الفاتورة بنجاح", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}