using System;
using System.Data.SqlClient;
using System.Data;


namespace DataAdapter
{
    class Program
    {
        static void Main(string[] args)
        {

            SqlConnection connection = new SqlConnection("Data Source = LAPTOP-43E0PBDE\\SQLEXPRESS;Initial Catalog =ConnectionDataBase;Integrated security=true");
            try
            {
                string query = "select * from Flight";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        Console.WriteLine(row[column] + "\n");
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
