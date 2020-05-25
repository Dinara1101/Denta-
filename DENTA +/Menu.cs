using System;
using System.Drawing;
using System.Windows.Forms;

namespace Autorization
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        Autorization autor = new Autorization();
        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.ForeColor = Color.Red;
            panel5.BackColor = Color.Red;
            this.panel5.Location = new Point(108, 321);
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            label2.ForeColor = Color.Red;
            panel5.BackColor = Color.Red;
            this.panel5.Location = new Point(103, 368);
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            label3.ForeColor = Color.Red;
            panel5.BackColor = Color.Red;
            this.panel5.Location = new Point(103, 413);
        }

        private void label7_MouseMove(object sender, MouseEventArgs e)
        {
            label7.ForeColor = Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
            panel5.BackColor = Color.White;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
            panel5.BackColor = Color.White;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.White;
            panel5.BackColor = Color.White;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.ForeColor = Color.White ;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
        }

        Point lastPoint;

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Users_Admin adm = new Users_Admin();
            Users us = new Users();
            if (label5.Text.Equals("Yes"))
            {
                adm.login = label6.Text;
                adm.Show();
            }
            else
            {
                us.login = label6.Text;
                us.Show();
            }
            this.panel5.Location = new Point(103, 368);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Registratura reg = new Registratura();
            reg.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
