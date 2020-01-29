using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Excellent_Taste.Models;

namespace Excellent_Taste.Classes
{
    public class Queries
    {
        // Construct connection string
        private string ConnectionString = "Server=localhost\\SQLEXPRESS;Database=ExcellentTasteDB;Integrated Security=False;User Id='ExcellentTasteMaster'; Password='1234'";


        public int LoginAllowed(LoginViewModel LoginViewModel)
        {
            using (SqlConnection tConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand tCommand = new SqlCommand("SELECT Id FROM dbo.Users WHERE Username = '" + LoginViewModel.Username + "' AND Password = '" + LoginViewModel.Password + "'", tConnection);

                tConnection.Open();

                using (SqlDataReader reader = tCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return (int)reader["Id"];
                        }
                    }
                    return -1;
                }
            }
        }

        public bool UserCreation(CreateUserViewModel CreateUserViewModel)
        {
            using (SqlConnection tConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand tCommand = new SqlCommand("INSERT INTO [dbo].[Users] SELECT '"+CreateUserViewModel.Username+"', '"+CreateUserViewModel.Password+"', "+CreateUserViewModel.Admin+";", tConnection);

                tConnection.Open();

                int _rows = tCommand.ExecuteNonQuery();

                if (_rows > 0)
                {
                    return true;
                }
            }
            return false;
        }

              
        



    }
}
