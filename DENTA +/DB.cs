using System.Data.SqlClient;

namespace Autorization
{
    class DB
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dinara\Desktop\Диплом\DENTA +\DATABASE.MDF;Integrated Security=True");

        public void openConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
        }
        public void closeConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
        }

        public SqlConnection GetConnection()
        {
            return con;
        }
    }
}
