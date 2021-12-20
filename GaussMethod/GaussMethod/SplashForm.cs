using System;
using System.Drawing;
using System.Windows.Forms;

namespace GaussMethod
{
    public partial class SplashForm : Form
    {
        private Timer timer1;
        public SplashForm()
        {
            InitializeComponent();
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            bar.PerformStep();
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            // bar.ForeColor = Color.FromArgb(102, 252, 241);
            bar.ForeColor = Color.FromArgb(69, 162, 158);
            bar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            bar.Maximum = 150;
            bar.Step = 1;
            timer1 = new Timer();
            timer1.Interval = 25;
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
        }
    }
}
