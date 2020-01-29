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


        public int LoginAllowed(LoginViewModel loginViewModel)
        {
            using (SqlConnection tConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand tCommand = new SqlCommand("SELECT id FROM dbo.Users WHERE Username = '" + loginViewModel.Username + "' AND Password = '" + loginViewModel.Password + "'", tConnection);

                tConnection.Open();

                using (SqlDataReader reader = tCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            return (int)reader["id"];
                        }
                    }

                    return -1;
                }
            }
        }
    }
}
