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
using System.IO;

namespace iGYM_MS.PL
{
    public partial class frmDaily : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        public int traineeID, logID = 0;
        TimeSpan now, timeFrom, timeTo;
        DateTime dt;
        public bool close = false, frozen = false, ended = false;

        public frmDaily()
        {
            InitializeComponent();
            now = DateTime.Now.TimeOfDay;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }

        public void function()
        {
            var log = db.TraineeProfiles.Find(logID);

            dt = Convert.ToDateTime(log.Offer.From);
            timeFrom = dt.TimeOfDay;
            dt = Convert.ToDateTime(log.Offer.To);
            timeTo = dt.TimeOfDay;

            if (log.Frozen == true)
            {
                frozen = true;
                return;
            }

            if (log.Type == "جلسات")
            {
                if (log.SessionsNum > 0)
                {
                    log.SessionsNum = --log.SessionsNum;
                    logID = log.LogID;
                    txtID.Text = log.Trainee.CardNumber;
                    txtName.Text = log.Trainee.TraineeName;
                    txtOffer.Text = log.Offer.OfferName;
                    dtBegin.EditValue = log.From;
                    dtEnd.EditValue = log.To;
                    txtSessions.Text = log.SessionsNum.ToString();
                    txtInvitations.Text = log.Invitations.ToString();
                    txtFreezing.Text = log.Freezing.ToString();
                    txtInbody.Text = log.Inbody.ToString();
                    txtCarry.Text = log.Carry.ToString();
                    byte[] img = log.Trainee.Photo;
                    MemoryStream ms = new MemoryStream(img);
                    pBox.Image = Image.FromStream(ms);
                }
                else
                {
                    ended = true;
                    return;
                }
            }
            if(log.Type == "أيام")
            {
                logID = log.LogID;
                txtID.Text = log.Trainee.CardNumber;
                txtName.Text = log.Trainee.TraineeName;
                txtOffer.Text = log.Offer.OfferName;
                dtBegin.EditValue = log.From;
                dtEnd.EditValue = log.To;
                txtSessions.Text = log.SessionsNum.ToString();
                txtInvitations.Text = log.Invitations.ToString();
                txtFreezing.Text = log.Freezing.ToString();
                txtInbody.Text = log.Inbody.ToString();
                txtCarry.Text = log.Carry.ToString();
                byte[] img = log.Trainee.Photo;
                MemoryStream ms = new MemoryStream(img);
                pBox.Image = Image.FromStream(ms);
            }

            if ((now < timeFrom) || (now > timeTo))
            {
                close = true;
                return;
            }

            db.SaveChanges();

            if (close == false)
            {
                EDM.TraineesDaily td = new EDM.TraineesDaily()
                {
                    TraineeID = traineeID,
                    Date = DateTime.Now,
                    LogID = logID,
                };
                db.TraineesDailies.Add(td);
                db.SaveChanges();
                timer1.Enabled = true;
            }
        }
    }
}