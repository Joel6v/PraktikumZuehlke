using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace CharacterConfigurator.Repository
{
    class DBConnection
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;

        public MySqlConnection Connection { get; private set; }

        public DBConnection()
        {
            Connect();
        }

        public void Connect()
        {
            if (Connection == null)
            {
                Connection = new MySqlConnection(ConnectionString);
            }
            Connection.Open();
        }

        public void Close()
        {
            Connection.Close();
        }
    }
}
