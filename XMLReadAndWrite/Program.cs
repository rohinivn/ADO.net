using System;
using System.Data.SqlClient;
using System.Data;


namespace XMLReadAndWrite
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
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet,"Flight");
                Console.WriteLine(dataSet.GetXml());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
