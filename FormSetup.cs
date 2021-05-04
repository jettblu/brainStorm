using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrainStorm
{
    public partial class FormSetup : Form
    {
        public string emotivID = "";
        public string emotivSecret = "";
        public string emailAddress = "";
        public string emailPassword = "";
        public FormSetup()
        {
            InitializeComponent();
        }


        private void btnLaunch_Click(object sender, EventArgs e)
        {
            if (! cBoxPrefilled.Checked)
            {
                emotivSecret = Properties.Settings.Default.EmotivSecret;
                emotivID = Properties.Settings.Default.EmailPassword;
                emailPassword = Properties.Settings.Default.EmailPassword;
                emailAddress = Properties.Settings.Default.EmailAddress;

                Properties.Settings.Default.EmotivSecret = emotivSecret;
                Properties.Settings.Default.EmailPassword = emotivID;
                Properties.Settings.Default.EmailPassword = emailPassword;
                Properties.Settings.Default.EmailAddress = emailAddress;
            }
            
            CloseForm();
        }


        void CloseForm()
        {
            //display mainform
            FormSplashScreen sC = new FormSplashScreen();
            sC.Show();
            this.Hide();
        }

        private void cBoxPrefilled_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
