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
using System.IO.Ports;
using System.Threading;

namespace iGYM_MS.PL
{
    public partial class frmChangeID : DevExpress.XtraEditors.XtraForm
    {
        EDM.GymEntities1 db = new EDM.GymEntities1();
        SerialPort sp = new SerialPort(Properties.Settings.Default.FirstDevice);
        public string cardNumber;
        public int TraineeID;
        public string type;

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            cardNumber = sp.ReadLine();
            Thread.Sleep(100);
            if (this.InvokeRequired)
            {
                this.Invoke((Action)chkCardNumber);
            }
        }
        void chkCardNumber()
        {
            var x = (from y in db.Employees
                     where y.CardNumber == cardNumber
                     select y).ToList();

            var xx = (from yy in db.Trainees
                      where yy.CardNumber == cardNumber
                      select yy).ToList();

            var xxx = (from yyy in db.Users
                       where yyy.CardNumber == cardNumber
                       select yyy).ToList();

            if (x.Count > 0 || xx.Count > 0 || xxx.Count > 0)
            {
                sp.Write("error");
                XtraMessageBox.Show("هذا الكارت مستخدم بالفعل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                txtNew.Text = cardNumber;
            }
        }

        public frmChangeID()
        {
            InitializeComponent();
        }

        private void frmChangeID_Load(object sender, EventArgs e)
        {
            string[] comPorts = SerialPort.GetPortNames();
            foreach (string com in comPorts)
            {
                if (Properties.Settings.Default.FirstDevice == com)
                {
                    frmMain.sp1.Dispose();
                    frmMain.sp1.Close();
                    sp.BaudRate = 9600;
                    sp.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    sp.Open();
                    sp.Write("connected");
                }
            } 
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNew.Text == "")
            {
            XtraMessageBox.Show("من فضلك مرر الكارت الجديد", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (type == "مشترك")
            {
                var trainee = db.Trainees.Find(TraineeID);
                trainee.CardNumber = cardNumber;
            }
            else if (type == "موظف")
            {
                var emp = db.Employees.Find(TraineeID);
                emp.CardNumber = cardNumber;
            }
            db.SaveChanges();
            this.DialogResult = DialogResult.OK;
        }

        private void frmChangeID_FormClosing(object sender, FormClosingEventArgs e)
        {
            string[] comPorts = SerialPort.GetPortNames();
            foreach (string com in comPorts)
            {
                if (Properties.Settings.Default.FirstDevice == com)
                {
                    sp.Dispose();
                    sp.Close();
                }
            }
        }
    }
}