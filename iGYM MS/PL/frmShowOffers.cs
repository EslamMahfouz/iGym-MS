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
    public partial class frmShowOffers : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();

        public frmShowOffers()
        {
            InitializeComponent();
        }

        private void frmShowOffers_Load(object sender, EventArgs e)
        {
            var offers = from o in db.Offers
                         select new { الإسم = o.OfferName, المدة = o.Duration.DurationName, السعر = o.Price, النوع = o.Type, الجلسات = o.SessionsNum, freezing = o.Freezing, دعوات = o.Invitations, SPA = o.SPA, Massage = o.Massage, Other = o.Others, Inbody = o.Inbody, من = o.From, إلي = o.To };
            gridControl1.DataSource = offers.ToList();
        }
    }
}