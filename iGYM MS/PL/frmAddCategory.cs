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
    public partial class frmAddCategory : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        public string type;
        bool edit = false;
        int catID;

        public frmAddCategory()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!valName.Validate())
            { return; }

            if (!edit)
            {
                string name = txtName.Text;
                var category = (from c in db.Categories
                                where c.CategoryName == name
                                select c).ToList();
                if (category.Count > 0)
                {
                    XtraMessageBox.Show("يوجد قسم بهذا الإسم", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                EDM.Category Category = new EDM.Category()
                {
                    CategoryName = name,
                    Type = type,
                };
                db.Categories.Add(Category);
                db.SaveChanges();
                XtraMessageBox.Show("تم إضافة القسم", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var cat = db.Categories.Find(catID);
                cat.CategoryName = txtName.Text;
                db.SaveChanges();
                XtraMessageBox.Show("تم التعديل بنجاح", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Text = "";
            }

            edit = false;
            frmAddCategory_Load(sender, e);
            cmbJobs.EditValue = -1;
            txtName.Text = "";
        }

        private void frmAddCategory_Load(object sender, EventArgs e)
        {
            if (type == "outcome")
            {
                this.Text = "إضافة حساب مصروف";
                labelControl1.Text = "إسم الحساب";

                var cat = from x in db.Categories
                          where x.Type == "outcome"
                          select new { م = x.CategoryID, الإسم = x.CategoryName };
                cmbJobs.Properties.DataSource = cat.ToList();
                cmbJobs.Properties.DisplayMember = "الإسم";
                cmbJobs.Properties.ValueMember = "م";
                cmbJobs.Properties.PopulateColumns();
                cmbJobs.Properties.Columns["م"].Visible = false;
            }
            else
            {
                var cat = from x in db.Categories
                          where x.Type == "income" && x.CategoryName != "إشتراكات" && x.CategoryName != "جلسات"
                          select new { م = x.CategoryID, الإسم = x.CategoryName };
                cmbJobs.Properties.DataSource = cat.ToList();
                cmbJobs.Properties.DisplayMember = "الإسم";
                cmbJobs.Properties.ValueMember = "م";
                cmbJobs.Properties.PopulateColumns();
                cmbJobs.Properties.Columns["م"].Visible = false;
            }
        }

        private void cmbJobs_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                edit = false;
                txtName.Text = "";
                cmbJobs.EditValue = -1;
            }
        }

        private void cmbJobs_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                catID = Convert.ToInt32(cmbJobs.EditValue);
                var cat = db.Categories.Find(catID);
                txtName.Text = cat.CategoryName;
                edit = true;
            }
            catch
            {
                return;
            }

        }
    }
}