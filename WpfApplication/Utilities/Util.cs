using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfApplication.Utilities
{
    public static class Util
    {

        /// <summary>
        /// Builds the partial connection string to a full one holding username and password in runtime and returns it.
        /// </summary>
        /// <param name="connStringKey"></param>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns>The full connectionString</returns>
        /// <exception cref="KeyNotFoundException"></exception>
        static string BuildConnectionString(string connStringKey, string userName, string userPassword)
        {
            // Retrieve the partial connection string named databaseConnection
            // from the application's app.config or web.config file.
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[connStringKey];

            if (null != settings)
            {
                // Retrieve the partial connection string.
                string connectString = settings.ConnectionString;
                Console.WriteLine("Original: {0}", connectString);

                // Create a new SqlConnectionStringBuilder based on the
                // partial connection string retrieved from the config file.
                SqlConnectionStringBuilder builder =
                    new SqlConnectionStringBuilder(connectString);

                // Supply the additional values.
                builder.UserID = userName;
                builder.Password = userPassword;
                Console.WriteLine("Modified: {0}", builder.ConnectionString);
                return builder.ConnectionString;
            }
            throw new KeyNotFoundException("Key \"" + connStringKey + "\" not found.");
        }

    }
}
