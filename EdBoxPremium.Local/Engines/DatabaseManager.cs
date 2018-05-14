using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using EdBoxPremium.Data;
using EdBoxPremium.Data.InterchangeModels;

namespace EdBoxPremium.Local.Engines
{
    public class DatabaseManager
    {
        private static UpdateSpec _updateSpec;
        private static AuthModel _authModel;

        public static void IntializeDataStoreEngine()
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "cmd.exe",
                    Arguments = "/c sqllocaldb start mssqllocaldb",
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };
            process.Start();

            while (!process.HasExited)
            {
                //
            }
        }

        public static void InitializeDataStore()
        {
            try
            {
                GetLocalDb("EdboxDb");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool ExecuteScripts(string commandText)
        {
            try
            {
                var conn = GetConnection();

                if (conn.State != ConnectionState.Open)
                    return false;

                var cmd = conn.CreateCommand();
                cmd.CommandText = commandText;
                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static UpdateSpec UpdateSpec
        {
            get => _updateSpec;
            set
            {
                try
                {
                    var outputFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    var updateSpecFileLocation = Path.Combine(outputFolder, "LocalData\\UpdateSpec.json");
                    File.WriteAllText(updateSpecFileLocation, Newtonsoft.Json.JsonConvert.SerializeObject(value));
                    _updateSpec = value;
                }
                catch (Exception e)
                {
                    ErrorHandler.TreatError(e);
                }
            }
        }

        public static List<School_Course> SchoolCourse
        {
            get
            {
                var updateSpecFileLocation = Path.Combine(OutputFolder, "LocalData\\SchoolCourse.json");
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<School_Course>>(File.ReadAllText(updateSpecFileLocation));
            }
            set
            {
                var updateSpecFileLocation = Path.Combine(OutputFolder, "LocalData\\SchoolCourse.json");
                File.WriteAllText(updateSpecFileLocation, Newtonsoft.Json.JsonConvert.SerializeObject(value));
            }
        }

        public static AcademicSetUpData AcademicSetUpData
        {
            get
            {
                var updateSpecFileLocation = Path.Combine(OutputFolder, "LocalData\\AcademicSetUpData.json");
                return Newtonsoft.Json.JsonConvert.DeserializeObject<AcademicSetUpData>(File.ReadAllText(updateSpecFileLocation));
            }
            set
            {
                var updateSpecFileLocation = Path.Combine(OutputFolder, "LocalData\\AcademicSetUpData.json");
                File.WriteAllText(updateSpecFileLocation, Newtonsoft.Json.JsonConvert.SerializeObject(value));
            }
        }

        public static List<AuthModel> LocalAuthData
        {
            get
            {
                var updateSpecFileLocation = Path.Combine(OutputFolder, "LocalData\\DefaultCredentials.json");
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuthModel>>(File.ReadAllText(updateSpecFileLocation));
            }
            set
            {
                var updateSpecFileLocation = Path.Combine(OutputFolder, "LocalData\\DefaultCredentials.json");
                File.WriteAllText(updateSpecFileLocation, Newtonsoft.Json.JsonConvert.SerializeObject(value));
            }
        }

        public static AuthModel CurrentAuthModel
        {
            get => _authModel;
            set => _authModel = value;
        }

        private static string OutputFolder => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        #region Database Engine

        private static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\EdboxDb.mdf;integrated security=True;MultipleActiveResultSets=True");
            try
            {
                connection.Open();
            }
            catch //
            {
                // ignored
            }

            return connection;
        }

        private static SqlConnection GetLocalDb(string dbName)
        {
            var outputFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var mdfFilename = dbName + ".mdf";
            var dbDataFileName = Path.Combine(outputFolder, mdfFilename);
            var dbLogFileName = Path.Combine(outputFolder, $"{dbName}.ldf");

            var updateSpecFileLocation = Path.Combine(outputFolder, "LocalData\\UpdateSpec.json");
            _updateSpec =
                Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateSpec>(File.ReadAllText(updateSpecFileLocation));

            var connection = new SqlConnection(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\EdboxDb.mdf;integrated security=True;MultipleActiveResultSets=True");
            
            // Delete Database if required.
            if (UpdateSpec.DatabaseFiles)
            {
                SqlConnection.ClearPool(connection);

                DetachDatabase(dbName);
                DropDatabase(dbName);

                File.Delete(dbLogFileName);
                File.Delete(dbDataFileName);
            }

            // If the database does not already exist, create it.
            if (!File.Exists(dbDataFileName))
            {
                DropDatabase(dbDataFileName);
                CreateDatabase(dbName, dbDataFileName);
            }

            // Open newly created, or old database.
            connection.Open();

            _updateSpec.DatabaseFiles = false;
            _updateSpec.DatabaseSchema = false;

            File.WriteAllText(updateSpecFileLocation, Newtonsoft.Json.JsonConvert.SerializeObject(_updateSpec));
            return connection;
        }

        private static void CreateDatabase(string dbName, string dbFileName)
        {
            const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var installCmd = connection.CreateCommand();
                installCmd.CommandText = ScriptClean(Properties.Resources.DatabaseScript_1);
                installCmd.ExecuteNonQuery();

                DetachDatabase(dbName);

                var migrateCmd = connection.CreateCommand();
                migrateCmd.CommandText = ScriptClean(Properties.Resources.DatabaseScript_2);
                migrateCmd.ExecuteNonQuery();
            }
        }

        private static string ScriptClean(string sqlScript)
        {
            sqlScript = sqlScript.Replace("GO", "");
            sqlScript = Regex.Replace(sqlScript, "([/*][*]).*([*][/])", "");
            sqlScript = Regex.Replace(sqlScript, "\\s{2,}", " ");
            sqlScript = sqlScript.Replace("{dbLocation}",
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));

            return sqlScript;
        }

        private static void DetachDatabase(string dbName)
        {
            try
            {
                const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = $"exec sp_detach_db '{dbName}'";
                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch
            {
                // ignored
            }
        }

        private static void DropDatabase(string dbName)
        {
            try
            {
                const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = $"drop database [{dbName}]";
                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch
            {
                // ignored
            }
        }

        #endregion
    }
}
