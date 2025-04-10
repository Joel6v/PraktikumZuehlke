using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows;

namespace CharacterConfigurator.Repository
{
    class DbConnection : System.IDisposable
    {
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;

        public MySqlConnection Connection { get; private set; }

        public DbConnection()
        {
            Connect();
        }

        public void Connect()
        {
            try
            {
                if (Connection == null)
                {
                    Connection = new MySqlConnection(ConnectionString);
                }
                Connection.Open();
            }            
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error while connecting to the MySqlDB", MessageBoxButton.OK, MessageBoxImage.Error);
                //throw;
            }
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
