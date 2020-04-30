using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace POS_APP.DAL
{
    class DBAccess
    {
        private static SqlConnection objConnection;
        private static SqlDataAdapter objDataAdapter;

        public static string ConnectionString = @"Data Source=NITINDABI954\NITINDATABASE; Initial Catalog=master; User Id=Nitindabi954; Password=Nitindabi954@";

        private static void OpenConnection()
        {
            try
            {

                if (objConnection == null)
                {
                    objConnection = new SqlConnection(@"Data Source=NITINDABI954\NITINDATABASE; Initial Catalog=master; User Id=Nitindabi954; Password=Nitindabi954@");
                    objConnection.Open();
                }
                else
                {
                    if (objConnection.State != System.Data.ConnectionState.Open)
                    {
                        objConnection = new SqlConnection(@"Data Source=NITINDABI954\NITINDATABASE; Initial Catalog=master; User Id=Nitindabi954; Password=Nitindabi954@");
                        objConnection.Open();
                    }
                }
            }
            catch {
            }


        }

        private static void CloseConnection()
        {

            try
            {
                if (objConnection == null)
                {
                    if (objConnection.State == System.Data.ConnectionState.Open)
                    {
                        objConnection.Close();
                        objConnection.Dispose();
                    }
                }

            }
            catch (Exception)
            {

            }

        }

        public static DataTable FilDataTable(String quary, DataTable Table)
        {
            try
            {
                OpenConnection();
                objDataAdapter = new SqlDataAdapter(quary, objConnection);
                objDataAdapter.Fill(Table);
                objDataAdapter.Dispose();
                CloseConnection();
                return Table;
            }
            catch
            {
                return null;
            }

        }

        public static bool ExecuteInsertQuery(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }


}