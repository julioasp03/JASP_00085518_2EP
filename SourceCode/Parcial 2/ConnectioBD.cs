using System;
using System.Data;
using Npgsql;

namespace Parcial_2
{
    public class ConnectioBD
    {
        private static String host = "127.0.0.1",
            database = "Parcial2",
            userid = "postgres",
            password = "090799";

        private static string sConnection =
            $"Server={host};Port=5432;User Id={userid};Password={password};Database={database}";

        public static DataTable ExecuteQuery(string query)
        {
            NpgsqlConnection connection=new NpgsqlConnection(sConnection);
            DataSet ds=new DataSet();
            connection.Open();
             
            NpgsqlDataAdapter da=new NpgsqlDataAdapter(query,connection);
            da.Fill(ds);
            connection.Close();
            return ds.Tables[0];
        }

        public static void ExecuteNonQuery(string act)
        {
            Console.WriteLine(sConnection);
            NpgsqlConnection connection=new NpgsqlConnection(sConnection);
            connection.Open();
            NpgsqlCommand command=new NpgsqlCommand(act,connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}