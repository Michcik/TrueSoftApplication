using System.Configuration;
using System.Data.SqlClient;

namespace ContactManager.Data
{
    public static class DatabaseHelper
    {
        // Connection string pointing at ContactManagerDB
        private static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["ContactsDb"].ConnectionString;

        // Connection string to (localdb) master — used to CREATE the database
        private const string MasterConnectionString =
            @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30";

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Creates the LocalDB database (if missing) and ensures the Contacts table exists.
        /// Called once at application startup.
        /// </summary>
        public static void InitializeDatabase()
        {
            EnsureDatabaseExists();
            EnsureTableExists();
        }

        private static void EnsureDatabaseExists()
        {
            using (var conn = new SqlConnection(MasterConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    // Idempotent: only creates the DB when it does not yet exist
                    cmd.CommandText = @"
                        IF DB_ID('ContactManagerDB') IS NULL
                            CREATE DATABASE [ContactManagerDB];";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void EnsureTableExists()
        {
            using (var conn = CreateConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        IF NOT EXISTS (
                            SELECT 1 FROM sys.tables WHERE name = 'Contacts'
                        )
                        CREATE TABLE Contacts (
                            Id          INT           IDENTITY(1,1) PRIMARY KEY,
                            FirstName   NVARCHAR(100) NOT NULL,
                            LastName    NVARCHAR(100) NOT NULL,
                            Email       NVARCHAR(200) NOT NULL,
                            Phone       NVARCHAR(50)  NOT NULL,
                            Category    NVARCHAR(20)  NOT NULL,
                            AvatarPath  NVARCHAR(500) NULL
                        );";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
