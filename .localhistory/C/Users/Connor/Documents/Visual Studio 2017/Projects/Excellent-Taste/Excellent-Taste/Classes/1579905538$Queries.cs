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
        private string ConnectionString = "Server=localhost\\SQLEXPRESS;Database=ExellentTasteDB;Integrated Security=False;User Id='ExcellentTasteMaster'; Password='1234'";


        public bool LoginAllowed(LoginViewModel loginViewModel)
        {
            using (SqlConnection tConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand tCommand = new SqlCommand("SELECT Username, Password FROM dbo.Users WHERE Username = '"+loginViewModel.Username+"' AND Password = '"+loginViewModel.Password+"'",tConnection);

                tConnection.Open();

                int tRows = tCommand.ExecuteNonQuery();

                if (tRows == 1)

                {
                    return true;
                }   
            }
                return false;
        }
    }
}
