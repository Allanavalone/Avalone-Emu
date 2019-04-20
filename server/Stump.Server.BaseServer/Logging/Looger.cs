using System;
using MongoDB.Bson;
using MongoDB.Driver;
using Stump.Core.Attributes;
using Stump.Core.Reflection;
using Stump.Core.Threading;
using Stump.ORM;
using Stump.Server.BaseServer.Initialization;
using MySql.Data.MySqlClient;

namespace Stump.Server.BaseServer.Logging
{
    public class Looger : Singleton<Looger>
    {
        [Variable(Priority = 10, DefinableRunning = true)] 
        public static bool IsLogEnable = true;

        private string databaseName = "calistya_logs";
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        [Initialization(InitializationPass.Fourth)]
        public void Initialize()
        {
            /*if (!IsLogEnable)
                return;

            if (String.IsNullOrEmpty(databaseName))
                return;

            string connstring = string.Format("Server=localhost; database={0}; UID=root; password=\"\"", databaseName);
            connection = new MySqlConnection(connstring);
            connection.Open();*/
        }

        public bool Insert(string query)
        {            
           /* if (!IsLogEnable)
            {
                if (connection == null)
                    return false;

                connection = null;

                return false;
            }

            if (connection == null)
                Initialize();

            if (connection != null)
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = query;
                command.ExecuteNonQuery();
            }

            else
                return false;
                */
            return true;
        }
    }
}