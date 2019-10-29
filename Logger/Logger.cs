using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace Logger
{
    public class Logger
    {
        static string connectionstring;
        static Logger()
        {
            try
            {
                connectionstring = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            }
            catch(Exception ex)
            {
                throw new Exception("Something went wrong while getting the Default Conn String for Logger");
            }
        }
        public static void Log(Exception ex)
        {
            try
            {
                using (SqlConnection sec = new SqlConnection(connectionstring))
                {
                    sec.Open();
                    using (SqlCommand com = sec.CreateCommand())
                    {
                        com.CommandText = "InsertLogItem";
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@Message", ex.Message);
                        com.Parameters.AddWithValue("@Trace", ex.StackTrace.ToString());
                        com.ExecuteNonQuery();
                    }
                }
            }
            //Here's a failsafe JIC.
            catch(Exception exc)
            {
                var p = HttpContext.Current.Server.MapPath("~");
                p += @"ErrorLog.Log";
                System.IO.File.AppendAllText(p, "While attempting to record the original exception to the database, this exception occurred\r\n");
                System.IO.File.AppendAllText(p, exc.ToString());
                System.IO.File.AppendAllText(p, "This is the Original Exception that was attemting to be written to the database\r\n");
                System.IO.File.AppendAllText(p, ex.ToString());
            }
        }
    }
}
