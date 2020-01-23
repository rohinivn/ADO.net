using System;
using System.Data.SqlClient;

namespace Connectivity
{
    class Program
    {
        static void Main()
        {
            FlightDetails flightDetails = new FlightDetails();
            SqlConnection sqlConnection = new SqlConnection("Data Source = LAPTOP-43E0PBDE\\SQLEXPRESS;Initial Catalog =ConnectionDataBase;Integrated security=true");
            SqlCommand sqlCommand = new SqlCommand("Select FlightId,FlightName,Source,Destination,AvailableSeats,Price from  Flight", sqlConnection);
            sqlConnection.Open();
            string status;
            do
            {
                Console.WriteLine("Enter your choice: \n1.Add Flight\n2.update Flight\n3.delete Flight\n4.display Flight");
                byte choice = Byte.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        flightDetails.AddFlightDetails(sqlConnection);
                        break;
                    case 2:
                        flightDetails.UpdateUserDetail(sqlConnection);
                        break;
                    case 3:
                        flightDetails.DeleteUserDetail(sqlConnection);
                        break;
                    case 4:
                        flightDetails.DisplayUserDetail(sqlConnection);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice");
                        break;
                }
                Console.WriteLine("Do you want to continue[yes/no]: ");
                status = Console.ReadLine().ToLower();
            } while (status == "yes");
            sqlConnection.Close();
        }
    }
}
