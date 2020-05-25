using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Autorization
{
    public partial class Autorization : Form
    {
        public Autorization()
        {
            InitializeComponent();
            textBox1.Text = "Введите логин";
            textBox1.ForeColor = Color.Gray;
            textBox2.Text = "Введите пароль";
            textBox2.ForeColor = Color.Gray;
            textBox2.UseSystemPasswordChar = false; 
        }

        DB db = new DB();
        DataTable table = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter();

        String name, surname, pass, admin, login;
        
        public Boolean isUsersExists()
        {
            SqlCommand cmd_login = new SqlCommand("SELECT Login FROM Users WHERE Login = @ul", db.GetConnection());
            cmd_login.Parameters.Add("@ul", SqlDbType.VarChar).Value = textBox1.Text;
            adapter.SelectCommand = cmd_login;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                db.openConnection();
                login = cmd_login.ExecuteScalar().ToString();
                db.closeConnection();
                return true;
            }
            else
            {
                MessageBox.Show("Такой пользователь не существует!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
                textBox2.Text = "Введите пароль";
                textBox2.ForeColor = Color.Gray;
                textBox2.UseSystemPasswordChar = false;
                textBox1.Focus();
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox1.Text == "Введите логин")
                {
                    MessageBox.Show("Введите логин", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Focus();
                    return;
                }
                
                if (textBox2.Text == "" || textBox2.Text == "Введите пароль")
                {
                    MessageBox.Show("Введите пароль", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox2.Focus();
                    return;
                }

                db.openConnection();

                SqlCommand cmd_name = new SqlCommand("Select Name From Users WHERE Login = @ul", db.GetConnection());
                cmd_name.Parameters.Add("@ul", SqlDbType.VarChar).Value = textBox1.Text;
                adapter.SelectCommand = cmd_name;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                    name = cmd_name.ExecuteScalar().ToString();

                SqlCommand cmd_surname = new SqlCommand("Select Surname From Users WHERE Login = @ul", db.GetConnection());
                cmd_surname.Parameters.Add("@ul", SqlDbType.VarChar).Value = textBox1.Text;
                adapter.SelectCommand = cmd_surname;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                    surname = cmd_surname.ExecuteScalar().ToString();

                SqlCommand cmd_pass = new SqlCommand("Select Password From Users WHERE Login = @ul", db.GetConnection());
                cmd_pass.Parameters.Add("@ul", SqlDbType.VarChar).Value = textBox1.Text;
                adapter.SelectCommand = cmd_pass;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                    pass = cmd_pass.ExecuteScalar().ToString();

                SqlCommand cmd_adm = new SqlCommand("Select Admin From Users WHERE Login = @ul", db.GetConnection());
                cmd_adm.Parameters.Add("@ul", SqlDbType.VarChar).Value = textBox1.Text;
                adapter.SelectCommand = cmd_adm;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                    admin = cmd_adm.ExecuteScalar().ToString();

                db.closeConnection();

                if (isUsersExists())
                   {
                    if (pass.Equals(textBox2.Text))
                    {
                        Menu m = new Menu();
                        m.Show();
                        m.label4.Text = "Добро пожаловать, " + name + " " + surname + "!";
                        m.label5.Text = admin;
                        m.label6.Text = login;
                        if (!admin.Equals("Yes"))
                        {
                            m.label1.Visible = false;
                            m.label2.Text = "Сведения о себе";
                            m.label2.Location = new Point(60, 344);
                            m.panel5.Location = new Point(96, 368);
                        }
                        else
                            m.label2.Text = "Сторудники";
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Пароль введён неверно!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox2.Text = "";
                        textBox2.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text="";
            textBox1.Text = "Введите логин";
            textBox1.ForeColor = Color.Gray;
            textBox2.Text="";
            textBox2.Text = "Введите пароль";
            textBox2.UseSystemPasswordChar = false;
            textBox2.ForeColor = Color.Gray;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.Blue;
            button1.ForeColor = Color.White;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.Blue;
            button2.ForeColor = Color.White;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.ForeColor = Color.Blue;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = SystemColors.Control;
            button1.ForeColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = SystemColors.Control;
            button2.ForeColor = Color.Black;
        }
 
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите логин")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Введите логин";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Введите пароль")
            {
                textBox2.Text = "";
                textBox2.UseSystemPasswordChar = true;
                textBox2.ForeColor = Color.Black;
            }

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Введите пароль";
                textBox2.UseSystemPasswordChar = false;
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Point lastPoint;
        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

    }
}
