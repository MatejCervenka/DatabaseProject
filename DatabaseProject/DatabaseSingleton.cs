using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DatabaseProject
{
    /// <summary>
    /// Represents a singleton class for managing a database connection using SqlConnection.
    /// </summary>
    public class DatabaseSingleton
    {
        private static SqlConnection connection = null;

        /// <summary>
        /// Private constructor to prevent direct instantiation of the class.
        /// </summary>
        private DatabaseSingleton()
        {
        }

        /// <summary>
        /// Gets an instance of the SqlConnection, creating a new connection if one does not exist.
        /// </summary>
        /// <returns>An instance of SqlConnection.</returns>
        public static SqlConnection GetInstance()
        {
            if (connection == null)
            {
                SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
                consStringBuilder.UserID = ReadSetting("Name");
                consStringBuilder.Password = ReadSetting("Password");
                consStringBuilder.InitialCatalog = ReadSetting("Database");
                consStringBuilder.DataSource = ReadSetting("DataSource");
                consStringBuilder.ConnectTimeout = 30;
                connection = new SqlConnection(consStringBuilder.ConnectionString);
                connection.Open();
            }
            return connection;
        }

        /// <summary>
        /// Closes and disposes of the database connection.
        /// </summary>
        public static void CloseConnection()
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }

        /// <summary>
        /// Reads a configuration setting from the appSettings section in the configuration file.
        /// </summary>
        /// <param name="key">The key of the configuration setting to read.</param>
        /// <returns>The value of the configuration setting or "Not Found" if the key is not present.</returns>
        private static string ReadSetting(string key)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[key] ?? "Not Found";
            return result;
        }
    }
}
