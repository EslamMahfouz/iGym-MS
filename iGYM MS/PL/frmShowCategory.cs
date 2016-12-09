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
    public partial class frmShowCategory : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();

        public frmShowCategory()
        {
            InitializeComponent();
        }

        private void frmShowCategory_Load(object sender, EventArgs e)
        {
            var categories = from c in db.Categories
                             where c.Type == "income" && c.CategoryName != "إشتراكات" && c.CategoryName != "جلسات"
                             select new { م = c.CategoryID, القسم = c.CategoryName };

            cmbCategories.Properties.DataSource = categories.ToList();
            cmbCategories.Properties.DisplayMember = "القسم";
            cmbCategories.Properties.ValueMember = "م";
            cmbCategories.Properties.PopulateColumns();
            cmbCategories.Properties.Columns["م"].Visible = false;
        }

        private void cmbCategories_EditValueChanged(object sender, EventArgs e)
        {
            int CategoryID = Convert.ToInt32(cmbCategories.EditValue);
            var products = from p in db.Products
                           where p.CategoryID == CategoryID
                           select new { م = p.ProductID, الإسم = p.ProductName, تكلفة_الوحدة = p.Buy, سعر_بيع_الوحدة = p.Sell };

            gridControl1.DataSource = products.ToList();
            gridView1.Columns["م"].Visible = false;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            int ProductID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("م"));
            frmAddProduct frm = new frmAddProduct();
            frm.add = false;
            frm.ProductID = ProductID;
            frm.ShowDialog();
            frmShowCategory_Load(sender, e);
        }
    }
}