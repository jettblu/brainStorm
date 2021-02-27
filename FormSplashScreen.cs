using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrainStorm
// for threading method: https://stackoverflow.com/questions/15836027/c-sharp-winform-loading-screen/15836105#15836105
{
    public partial class FormSplashScreen : Form
    {
        private Timer tmr { get; set; }
        private int toWait = 4;
        //Delegate for cross thread call to close
        private delegate void CloseDelegate();

        //The type of form to be displayed as the splash screen.
        private static FormSplashScreen splashForm;


        public FormSplashScreen()
        {
            InitializeComponent();
            tboxTitle.Text = "Brain Storm";
        }


        private void FormSplashScreen_Shown(object sender, EventArgs e)
        {
            
            tmr = new Timer();

            //set time interval 3 sec

            tmr.Interval = 1000;

            //starts the timer

            tmr.Start();

            tmr.Tick += tmrTick;
        }

        void tmrTick(object sender, EventArgs e)

        {
            pbarSplash.Increment(1);
            pbarSplash.Maximum = toWait;
            if (pbarSplash.Value == toWait)
            {
                tmr.Stop();
                CloseForm();
            }
        }

        void CloseForm()
        {
            //display mainform
            BrainStorm0 mf = new BrainStorm0();
            mf.Show();
            this.Hide();
        }

    }
}
