using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autorization
{
    public partial class Insert_email : Form
    {
        DB db = new DB();
        DataTable table = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter();
        public int ID;
        public string ind;
        public int Vybor=0;

        public Insert_email()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Vybor == 1)
                {
                    
                    SqlCommand cmd_insert = new SqlCommand("INSERT INTO Emails (IdUsers, Email, More) VALUES (@id, @email, @mor)", db.GetConnection());

                    db.openConnection();
                    cmd_insert.Parameters.AddWithValue("@id", ind);
                    db.closeConnection();

                    cmd_insert.Parameters.AddWithValue("@email", textBox1.Text);
                    cmd_insert.Parameters.AddWithValue("@mor", comboBox1.Text);

                    if (!isEmailExists())
                    {
                        db.openConnection();
                        if (cmd_insert.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Электронная почта добавлена успешно!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                            MessageBox.Show("Электронная почта не добавлена!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        db.closeConnection();
                    }
                    
                }
                else if (Vybor == 2)
                {
                    SqlCommand cmd_insert = new SqlCommand("INSERT INTO Phones (IdUsers, Phone, More) VALUES (@id, @phone, @mor)", db.GetConnection());

                    db.openConnection();
                    cmd_insert.Parameters.AddWithValue("@id", ind);
                    db.closeConnection();

                    cmd_insert.Parameters.AddWithValue("@phone", textBox1.Text);
                    cmd_insert.Parameters.AddWithValue("@mor", comboBox1.Text);

                    if (!isPhoneExists())
                    {
                        db.openConnection();
                        if (cmd_insert.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Номер телефона добавлен успешно!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                            MessageBox.Show("Номер телефона не добавлен!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        db.closeConnection();
                    }
                }
                else if (Vybor == 3)
                {
                    SqlCommand cmd_insert = new SqlCommand("INSERT INTO Address (IdUsers, Address, More) VALUES (@id, @adr, @mor)", db.GetConnection());

                    cmd_insert.Parameters.AddWithValue("@id", ind);
                    cmd_insert.Parameters.AddWithValue("@adr", textBox1.Text);
                    cmd_insert.Parameters.AddWithValue("@mor", comboBox1.Text);

                    if (!isPhoneExists())
                    {
                        db.openConnection();
                        if (cmd_insert.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Адрес сотрудника добавлен успешно!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                            MessageBox.Show("Адрес сотрудника не добавлен!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        db.closeConnection();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Boolean isEmailExists()
        {
            SqlCommand cmd_email = new SqlCommand("SELECT Email FROM Emails WHERE Email=@em", db.GetConnection());
            cmd_email.Parameters.Add("@em", SqlDbType.VarChar).Value = textBox1.Text;
            adapter.SelectCommand = cmd_email;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Извините, такая электронная почта уже существует!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox1.Focus();
                return true;
            }
            else
                return false;
        }

        public Boolean isPhoneExists()
        {
            SqlCommand cmd_phone = new SqlCommand("SELECT Phone FROM Phones WHERE Phone=@ph", db.GetConnection());
            cmd_phone.Parameters.Add("@ph", SqlDbType.VarChar).Value = textBox1.Text;
            adapter.SelectCommand = cmd_phone;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Извините, такой номер телефона уже существует!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox1.Focus();
                return true;
            }
            else
                return false;
        }
    }
}
