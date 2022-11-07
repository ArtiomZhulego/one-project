using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TRPOY
{
    internal class workBD
    {
        static readonly string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Artem\Desktop\TRPOY\TRPOY\clients.mdf;Integrated Security=True";
        static readonly SqlConnection sqlConnection = new SqlConnection(connection);
        public static void Connection()
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            else
            {
                sqlConnection.Close();
            }
        }
        public static void Query(string query)
        {
            Connection();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            Connection();
        }
        public static int Search(string query)
        {
            Connection();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            int s1 = 0;
            if (sqlCommand.ExecuteScalar() != null)
            {
                s1 = int.Parse((sqlCommand.ExecuteScalar()).ToString());
            }
            Connection();
            return s1;
        }
        public static void Select(DataGrid Grid, string query)
        {
            Connection();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            Grid.ItemsSource = dataTable.DefaultView;
            Connection();
        }

        public static DataTable Select( string query)
        {
            Connection();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            Connection();
            return dataTable;
        }
        public static string Change(string query)
        {
            Connection();
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            string d = " ";
            if (sqlCommand.ExecuteScalar() != null)
            {
                d = sqlCommand.ExecuteNonQuery().ToString();
            }
            Connection();
            return d;
        }
    }
}
