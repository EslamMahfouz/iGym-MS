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
    public partial class frmInbodyReport : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        public int LogID, inBodyID;
        public bool newOne = true;

        public frmInbodyReport()
        {
            InitializeComponent();
            DateDateEdit.EditValue = DateTime.Now.Date;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (newOne)
            {
                EDM.InbodyReport rep = new EDM.InbodyReport()
                {
                    LogID = LogID,
                    Date = Convert.ToDateTime(DateDateEdit.EditValue),
                    Height = HeightTextEdit.Text,
                    Weight = WeightTextEdit.Text,
                    BMI = BMITextEdit.Text,
                    BMR = BMRTextEdit.Text,
                    Fat_ = Fat_.Text,
                    FatMass = FatMassTextEdit.Text,
                    FFM = FFMTextEdit.Text,
                    TBW = TBWTextEdit.Text,
                    VFHDR = VFHDRTextEdit.Text,
                    FAT__ = fat__.Text,
                    FatMass_ = FatMass_TextEdit.Text,
                    WholeBody = WholeBodyTextEdit.Text,
                    RightLeg = RightLegTextEdit.Text,
                    LeftLeg = LeftLegTextEdit.Text,
                    RightArm = RightArmTextEdit.Text,
                    LeftArm = LeftArmTextEdit.Text,
                    RightLegFat_ = rightLegFatPercent.Text,
                    RightLegFatMass = RightLegFatMassTextEdit.Text,
                    RightLegFFM = RightLegFFMTextEdit.Text,
                    RightLegMuscle = RightLegMuscleTextEdit.Text,
                    LeftLegFat_ = leftLegFatPercent.Text,
                    LeftLegFatMass = LeftLegTextEdit.Text,
                    LeftLegFFM = LeftLegFFMTextEdit.Text,
                    LeftLegMuscle = LeftLegMuscleTextEdit.Text,
                    RightArmFat_ = rightArmFatPercent.Text,
                    RightArmFatMass = RightArmFatMassTextEdit.Text,
                    RightArmFFM = RightArmFFMTextEdit.Text,
                    RightArmMuscle = RightArmMuscleTextEdit.Text,
                    LeftArmFat_ = leftArmFatPercent.Text,
                    LeftArmFatMass = LeftArmFatMassTextEdit.Text,
                    LeftArmFFM = LeftArmFFMTextEdit.Text,
                    LeftArmMuscle = LeftArmMuscleTextEdit.Text,
                    TrunkFat_ = TrunkFatPercent.Text,
                    TrunkFatMass = TrunkFatMassTextEdit.Text,
                    TrunkFFM = TrunkFFMTextEdit.Text,
                    TrunkMuscle = TrunkMuscleTextEdit.Text,
                };
                db.InbodyReports.Add(rep);
                db.SaveChanges();
                XtraMessageBox.Show("تم إضافة التقرير", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;

                var tp = db.TraineeProfiles.Find(LogID);
                tp.Inbody = --tp.Inbody;
                db.SaveChanges();
            }
            else
            {
                var x = db.InbodyReports.Find(inBodyID);
                x.Height = HeightTextEdit.Text;
                x.Weight = WeightTextEdit.Text;
                x.BMI = BMITextEdit.Text;
                x.BMR = BMRTextEdit.Text;
                x.Fat_ = Fat_.Text;
                x.FatMass = FatMassTextEdit.Text;
                x.FFM = FFMTextEdit.Text;
                x.TBW = TBWTextEdit.Text;
                x.VFHDR = VFHDRTextEdit.Text;
                x.FAT__ = fat__.Text;
                x.FatMass_ = FatMass_TextEdit.Text;
                x.WholeBody = WholeBodyTextEdit.Text;
                x.RightLeg = RightLegTextEdit.Text;
                x.LeftLeg = LeftLegTextEdit.Text;
                x.RightArm = RightArmTextEdit.Text;
                x.LeftArm = LeftArmTextEdit.Text;
                x.RightLegFat_ = rightLegFatPercent.Text;
                x.RightLegFatMass = RightLegFatMassTextEdit.Text;
                x.RightLegFFM = RightLegFFMTextEdit.Text;
                x.RightLegMuscle = RightLegMuscleTextEdit.Text;
                x.LeftLegFat_ = leftLegFatPercent.Text;
                x.LeftLegFatMass = LeftLegTextEdit.Text;
                x.LeftLegFFM = LeftLegFFMTextEdit.Text;
                x.LeftLegMuscle = LeftLegMuscleTextEdit.Text;
                x.RightArmFat_ = rightArmFatPercent.Text;
                x.RightArmFatMass = RightArmFatMassTextEdit.Text;
                x.RightArmFFM = RightArmFFMTextEdit.Text;
                x.RightArmMuscle = RightArmMuscleTextEdit.Text;
                x.LeftArmFat_ = leftArmFatPercent.Text;
                x.LeftArmFatMass = LeftArmFatMassTextEdit.Text;
                x.LeftArmFFM = LeftArmFFMTextEdit.Text;
                x.LeftArmMuscle = LeftArmMuscleTextEdit.Text;
                x.TrunkFat_ = TrunkFatPercent.Text;
                x.TrunkFatMass = TrunkFatMassTextEdit.Text;
                x.TrunkFFM = TrunkFFMTextEdit.Text;
                x.TrunkMuscle = TrunkMuscleTextEdit.Text;
                db.SaveChanges();
                XtraMessageBox.Show("تم تعديل التقرير", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmInbodyReport_Load(object sender, EventArgs e)
        {
            try
            {
                var x = db.InbodyReports.Find(inBodyID);
                DateDateEdit.EditValue = x.Date;
                HeightTextEdit.Text = x.Height;
                WeightTextEdit.Text = x.Weight;
                BMITextEdit.Text = x.BMI;
                BMRTextEdit.Text = x.BMR;
                Fat_.Text = x.Fat_;
                FatMassTextEdit.Text = x.FatMass;
                FFMTextEdit.Text = x.FFM;
                TBWTextEdit.Text = x.TBW;
                VFHDRTextEdit.Text = x.VFHDR;
                fat__.Text = x.FAT__;
                FatMass_TextEdit.Text = x.FatMass_;
                WholeBodyTextEdit.Text = x.WholeBody;
                RightLegTextEdit.Text = x.RightLeg;
                LeftLegTextEdit.Text = x.LeftLeg;
                RightArmTextEdit.Text = x.RightArm;
                LeftArmTextEdit.Text = x.LeftArm;
                rightLegFatPercent.Text = x.RightLegFat_;
                RightLegFatMassTextEdit.Text = x.RightLegFatMass;
                RightLegFFMTextEdit.Text = x.RightLegFFM;
                RightLegMuscleTextEdit.Text = x.RightLegMuscle;
                leftLegFatPercent.Text = x.LeftLegFat_;
                LeftLegTextEdit.Text = x.LeftLegFatMass;
                LeftLegFFMTextEdit.Text = x.LeftLegFFM;
                LeftLegMuscleTextEdit.Text = x.LeftLegMuscle;
                rightArmFatPercent.Text = x.RightArmFat_;
                RightArmFatMassTextEdit.Text = x.RightArmFatMass;
                RightArmFFMTextEdit.Text = x.RightArmFFM;
                RightArmMuscleTextEdit.Text = x.RightArmMuscle;
                leftArmFatPercent.Text = x.LeftArmFat_;
                LeftArmFatMassTextEdit.Text = x.LeftArmFatMass;
                LeftArmFFMTextEdit.Text = x.LeftArmFFM;
                LeftArmMuscleTextEdit.Text = x.LeftArmMuscle;
                TrunkFatPercent.Text = x.TrunkFat_;
                TrunkFatMassTextEdit.Text =x.TrunkFatMass;
                TrunkFFMTextEdit.Text = x.TrunkFFM;
                TrunkMuscleTextEdit.Text = x.TrunkMuscle;
            }
            catch
            {
                return;
            }
        }
      
    }
}