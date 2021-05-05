using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace HRMS.Connect
{
    public class ConnectDB
    {
        public MySqlConnection connection;
        public ConnectDB()
        {
            string connect_string = "Server=127.0.0.1;Database=HRMS;Uid=root;Pwd=12345678;";
            connection = new MySqlConnection(connect_string);
            connection.Open();
        }


        public DataTable Getdata(string _sqlCommand) {
            MySqlCommand command = new MySqlCommand(_sqlCommand,connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

        public void ExecuteQuery(String _sqlCommand) {
            MySqlCommand command = new MySqlCommand("", connection);
            command.CommandText = _sqlCommand;
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.ExecuteNonQuery();



        }
    }
}
