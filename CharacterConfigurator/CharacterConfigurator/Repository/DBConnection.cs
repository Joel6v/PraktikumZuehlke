using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace CharacterConfigurator.Repository
{
    class DBConnection
    {
        public DBConnection()
        {
            Connect();
        }

        public static string Server { get; set; }
        public static string DatabaseName { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }

        public MySqlConnection Connection { get; private set; }

        public void Connect()
        {
            if (Connection == null)
            {
                string connstring = $"Server={Server}; database={DatabaseName}; UID={UserName}; password={Password}";
                Connection = new MySqlConnection(connstring);
                Connection.Open();
            }
        }

        public void Close()
        {
            Connection.Close();
        }
    }
}
