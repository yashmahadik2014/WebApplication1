using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Comman
{
    public class DBConnection
    {
        private static string connectionstring;

        static DBConnection()
        {
            connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public static string DbConnectionString
        {
            get
            {
                return connectionstring;
            }
        }

        public static DataTable ExecuteSelectCommand(SqlCommand command)
        {
            // The DataTable to be returned 
            DataTable table;
            // Execute the command making sure the connection gets closed in the end
            try
            {
                // Open the data connection 
                command.Connection.Open();
                // Execute the command and save the results in a DataTable
                SqlDataReader reader = command.ExecuteReader();
                table = new DataTable();
                table.Load(reader);

                // Close the reader 
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // Close the connection
                command.Connection.Close();
            }
            return table;
        }

        public static DataSet ExecuteSelectCommandWithDataSet(SqlCommand command)
        {
            // The DataTable to be returned 
            DataSet ds;
            // Execute the command making sure the connection gets closed in the end
            try
            {
                ds = new DataSet();
                // Open the data connection 
                command.Connection.Open();
                // Execute the command and save the results in a DataTable
                //SqlDataReader reader = command.ExecuteReader();
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(ds);
                //ds.Tables[0].Load(reader);
                // Close the reader 
                adapter.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // Close the connection
                command.Connection.Close();
            }
            return ds;
        }

        // creates and prepares a new SqlCommand object on a new connection
        public static SqlCommand CreateCommand()
        {
            // Obtain the database connection string
            string connectionString = DbConnectionString;
            // Obtain a database specific connection object
            SqlConnection conn = new SqlConnection(connectionString);
            // Create a database specific command object
            SqlCommand comm = conn.CreateCommand();
            // Set the command type to stored procedure
            comm.CommandType = CommandType.StoredProcedure;
            // Return the initialized command object
            return comm;
        }

        public static int ExecuteCommand(SqlCommand command)
        {
            try
            {
                command.Connection.Open();

                return command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public static int InsertCommand(SqlCommand command)
        {
            try
            {
                int iIdentity = 0;

                command.Connection.Open();
                command.ExecuteNonQuery();
                iIdentity = Convert.ToInt32(command.Parameters["@iIdentity"].Value.ToString());
                return iIdentity;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public static object ExecuteScalar(SqlCommand command)
        {
            try
            {
                command.Connection.Open();

                return command.ExecuteScalar();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public static void ConnectionOpen(SqlCommand command)
        {
            command.Connection.Open();
        }

        public static void ConnectionClose(SqlCommand command)
        {
            command.Connection.Close();
        }


    }
}
