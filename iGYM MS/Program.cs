using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using iGYM_MS.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iGYM_MS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static bool addNewTrainee = false;
        public static bool editTraineeProfile = false;
        public static bool cancelTraineeProfile = false;
        public static bool showTrainees = false;

        public static bool searchMen = false;
        public static bool searchWomen = false;

        public static bool addOffer = false;
        public static bool editOffer = false;

        public static bool addIncomeOutcome = false;
        public static bool newIncomeOutcome = false;

        public static bool settings = false;
        public static bool reports = false;

        public static bool addNewUser = false;
        public static bool editUsers = false;

        public static int UserID;
        public static string Username;

        public static bool firstConnected = false;
        public static bool secondConnected = false;

        public static bool deleteTrainee = false;
        public static bool freezeTrainee = false;
        [STAThread]

        static void Main()
        {
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            SkinManager.EnableMdiFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("VS2010");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
