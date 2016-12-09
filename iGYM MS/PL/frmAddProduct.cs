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
    public partial class frmAddProduct : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        public bool add = true;
        public int ProductID;

        public frmAddProduct()
        {
            InitializeComponent();
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            var categories = from c in db.Categories
                             where c.Type == "income" && c.CategoryName != "إشتراكات" && c.CategoryName != "جلسات"
                             select new { م = c.CategoryID, القسم = c.CategoryName };

            cmbCategories.Properties.DataSource = categories.ToList();
            cmbCategories.Properties.DisplayMember = "القسم";
            cmbCategories.Properties.ValueMember = "م";
            cmbCategories.Properties.PopulateColumns();
            cmbCategories.Properties.Columns["م"].Visible=false;
            if (!add)
            {
                var product = db.Products.Find(ProductID);
                cmbCategories.EditValue = product.CategoryID;
                txtName.Text = product.ProductName;
                txtBuy.Text = product.Buy;
                txtSell.Text = product.Sell;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!valCategory.Validate())
            { return; }

            if (!valName.Validate())
            { return; }

            if (!valBuy.Validate())
            { return; }
            
            if (!valSell.Validate())
            { return; }
            if (Convert.ToDouble(txtSell.Text) < Convert.ToDouble(txtBuy.Text))
            {
                XtraMessageBox.Show("سعر البيع أقل من سعر الشراء", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSell.Focus();
                return;
            }

            if (add)
            {
                string name = txtName.Text;
                var product = (from c in db.Products
                               where c.ProductName == name
                               select c).ToList();
                if (product.Count > 0)
                {
                    XtraMessageBox.Show("يوجد صنف بهذا الإسم", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                EDM.Product prd = new EDM.Product()
                {
                    CategoryID = Convert.ToInt32(cmbCategories.EditValue),
                    ProductName = txtName.Text,
                    Buy = txtBuy.Text,
                    Sell = txtSell.Text
                };
                db.Products.Add(prd);
                db.SaveChanges();
                XtraMessageBox.Show("تم إضافة الصنف", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            else
            {
                var product = db.Products.Find(ProductID);
                product.CategoryID = Convert.ToInt32(cmbCategories.EditValue);
                product.ProductName = txtName.Text;
                product.Buy = txtBuy.Text;
                product.Sell = txtSell.Text;
                db.SaveChanges();
                XtraMessageBox.Show("تم تعديل الصنف", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
        }




    }
}