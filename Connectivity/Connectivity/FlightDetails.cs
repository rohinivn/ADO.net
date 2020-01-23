using System.Data.SqlClient;
using System;
namespace Connectivity
{
    class FlightDetails
    {

        public void AddFlightDetails(SqlConnection connection)
        {

            Console.Write("Enter flightname: ");
            string flightName = Console.ReadLine();
            Console.Write("Enter flightid: ");
            int flightId = int.Parse(Console.ReadLine());
            Console.Write("Enter source: ");
            string source = Console.ReadLine();
            Console.Write("Enter destination: ");
            string destination = Console.ReadLine();
            Console.Write("Enter no of seats: ");
            int availableSeats = int.Parse(Console.ReadLine());
            Console.Write("Enter price: ");
            int price = int.Parse(Console.ReadLine());
            string insertValue = "INSERT INTO Flight (flightId,flightName,source,destination,availableSeats,price) VALUES(@flightId,@flightName,@source,@destination,@availableSeats,@price)";
            SqlCommand sqlCommand = new SqlCommand(insertValue, connection);
            sqlCommand.Parameters.AddWithValue("@flightId", flightId);
            sqlCommand.Parameters.AddWithValue("@flightName", flightName);
            sqlCommand.Parameters.AddWithValue("@source", source);
            sqlCommand.Parameters.AddWithValue("@destination", destination);
            sqlCommand.Parameters.AddWithValue("@availableSeats", availableSeats);
            sqlCommand.Parameters.AddWithValue("@price", price);
            sqlCommand.ExecuteNonQuery();
        }
        public void DisplayUserDetail(SqlConnection connection)
        {
            string display = "SELECT flightId,flightName,source,destination,availableSeats,price FROM Flight";
            SqlCommand sqlCommand = new SqlCommand(display, connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("flightId : {0},flightName : {1},source : {2},destination : {3},availableSeats : {4},price : {5}", reader.GetDecimal(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDecimal(4), reader.GetDecimal(5));
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
        }
        public void UpdateUserDetail(SqlConnection connection)
        {
            string status;
            do
            {
                Console.WriteLine("Enter the field to be updated: \n1.flightName\n2.source\n3.destination\n");
                byte choice = Byte.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        UpdateFlightName(connection);
                        break;
                    case 2:
                        UpdateSource(connection);
                        break;
                    case 3:
                        UpdateDestination(connection);
                        break;
                    default:
                        Console.WriteLine("Enter valid choice");
                        break;
                }
                Console.WriteLine("Do you want to continue[yes/no]: ");
                status = Console.ReadLine().ToLower();
            } while (status == "yes");
        }
        public void UpdateFlightName(SqlConnection connection)
        {
            Console.WriteLine("Enter flight id");
            int flightId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the updated name: ");
            String flightName = Console.ReadLine();
            string updateUser = "UPDATE Flight SET flightName = @flightName WHERE flightId = @flightId;";
            SqlCommand command = new SqlCommand(updateUser, connection);
            command.Parameters.Add("@flightId", System.Data.SqlDbType.VarChar);
            command.Parameters.Add("@flightName", System.Data.SqlDbType.VarChar);
            command.Parameters["@flightId"].Value = flightId;
            command.Parameters["@flightName"].Value = flightName;
            command.ExecuteNonQuery();

        }
        public void UpdateSource(SqlConnection connection)
        {
            Console.WriteLine("Enter flight id");
            int flightId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Updated source: ");
            String source = Console.ReadLine();
            string updateUser = "UPDATE Flight SET source = @source WHERE flightId = @flightId;";
            SqlCommand command = new SqlCommand(updateUser, connection);
            command.Parameters.Add("@flightId", System.Data.SqlDbType.VarChar);
            command.Parameters.Add("@source", System.Data.SqlDbType.VarChar);
            command.Parameters["@flightId"].Value = flightId;
            command.Parameters["@source"].Value = source;
            command.ExecuteNonQuery();
        }
        public void UpdateDestination(SqlConnection connection)
        {
            Console.WriteLine("Enter flight id");
            int flightId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the updated destination: ");
            String destination = Console.ReadLine();
            string updateUser = "UPDATE ConnectionDataBase SET destination = @destination WHERE flightId = @flightId";
            SqlCommand command = new SqlCommand(updateUser, connection);
            command.Parameters.Add("@flightId", System.Data.SqlDbType.VarChar);
            command.Parameters.Add("@source", System.Data.SqlDbType.VarChar);
            command.Parameters["@flightId"].Value = flightId;
            command.Parameters["@destination"].Value = destination;
            command.ExecuteNonQuery();
        }
        public void DeleteUserDetail(SqlConnection connection)
        {
            Console.WriteLine("Enter flight id to delete");
            int flightId = int.Parse(Console.ReadLine());
            string deleteUser = "DELETE FROM Flight where flightId = @flightId";
            SqlCommand command = new SqlCommand(deleteUser, connection);
            command.Parameters.Add("@flightId", System.Data.SqlDbType.VarChar);
            command.Parameters["@flightId"].Value = flightId;
            command.ExecuteNonQuery();
        }
    }
}
