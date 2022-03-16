using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

namespace DBLibrary.DBconnection
{
    public static class DB_sql
    {
        private const string CONNECTION_STRING = "Data Source={0};Initial Catalog={1};User ID={2};Password={3};";

        public static DataTable ExecuteQuery(string connection, string query)
        {
            DataTable dt = new DataTable();
            try
            {
                using (IDbConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = connection;
                    conn.Open();
                    using (IDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = query;
                        var reader = cmd.ExecuteReader();

                        dt.Load(reader);
                        conn.Close();
                    }
                }
            }
            catch (DbException exc)
            {
                Debug.WriteLine("Error Message: {0}", exc.Message);
            }
            return dt;
        }

        public static DataTable ExecuteSql(string connection, string file)
        {
            DataTable dt = new DataTable();
            try
            {
                string script = File.ReadAllText(file);
                dt = ExecuteQuery(connection, script);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error Message: {0}", e.Message);
            }
            return dt;
        }

        public static string ConnectionString(string serverName, string tableName, string userId, string password)
        {
            return string.Format(CONNECTION_STRING,
                serverName,
                tableName,
                userId,
                password);
        }
    }
}
