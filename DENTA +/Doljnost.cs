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
    public partial class Doljnost : Form
    {
        DB db = new DB();
        public string ind;

        public Doljnost()
        {
            InitializeComponent();
        }

        private void Doljnost_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd_insert = new SqlCommand("INSERT INTO Doljnost (IdUsers, Name, More) VALUES (@id, @name, @mor)", db.GetConnection());
                cmd_insert.Parameters.AddWithValue("@id", ind);
                cmd_insert.Parameters.AddWithValue("@name", comboBox1.Text);
                cmd_insert.Parameters.AddWithValue("@mor", textBox1.Text);
                db.openConnection();
                if (cmd_insert.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Должность добавлена успешно!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Должность не добавлена!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
