using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Framework;
using System.Data;

namespace Framework
{
    public class DataAccess
    {
        string connectionString = "Data Source=AHSAN_ENVY\\SQLEXPRESS;Initial Catalog=InventoryManagement;Integrated Security=True;Pooling=False";

        public int ExecuteCommand(SqlCommand command)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            command.Connection = connection;
            connection.Open();
            int NumberOfRecords = command.ExecuteNonQuery();
            connection.Close();

            return NumberOfRecords;
        }

        public DataTable Query(SqlCommand query)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            query.Connection = connection;
            SqlDataAdapter da = new SqlDataAdapter(query);
            connection.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            connection.Close();

            return dt;
        }
    }
}