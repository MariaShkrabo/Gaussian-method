using System;
using System.Drawing;
using System.Windows.Forms;

namespace GaussMethod
{
    public partial class FormShowAnswer : Form
    {
        public FormShowAnswer()
        {   
            InitializeComponent();
        }

        public string labelText="";

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormShowAnswer_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
            labelX.BackColor = Color.Transparent;
            labelX.Text = labelText;
        }

        //функция для того, чтобы двигать форму курсором, так как FormBorderStyle = None
        private Point MouseHook;

        private void FormShowAnswer_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) MouseHook = e.Location;
            Location = new Point((Size)Location - (Size)MouseHook + (Size)e.Location);
        }
    }
}
