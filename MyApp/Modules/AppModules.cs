using System;
using System.Data.SqlClient;
using System.Data;

namespace MyApp.Modules
{
    public class AppModules
    {
        public string getConString()
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["DB_AbsoluteURLString"].ConnectionString;
            return conString;
        }

        public void execQuery(string sql)
        {
            SqlConnectionStringBuilder build = new SqlConnectionStringBuilder(this.getConString());
            build.AsynchronousProcessing = true;
            try
            {
                using (SqlConnection con = new SqlConnection(build.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        if (con.State == System.Data.ConnectionState.Closed || con.State == System.Data.ConnectionState.Broken)
                        {
                            con.Open();
                        }
                        var result = cmd.BeginExecuteNonQuery();
                        cmd.EndExecuteNonQuery(result);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string execGetVal(string sql)
        {
            SqlConnectionStringBuilder build = new SqlConnectionStringBuilder(this.getConString());
            build.AsynchronousProcessing = true;
            string result = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(build.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        if (con.State == System.Data.ConnectionState.Closed || con.State == System.Data.ConnectionState.Broken)
                        {
                            con.Open();
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            using(DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                if(dt.Rows.Count > 0)
                                {
                                    result = dt.Rows[0][0].ToString();
                                }
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable execQueryDT(string sql, DataTable dt)
        {
            SqlConnectionStringBuilder build = new SqlConnectionStringBuilder(this.getConString());
            build.AsynchronousProcessing = true;
            try
            {
                using (SqlConnection con = new SqlConnection(build.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        if (con.State == System.Data.ConnectionState.Closed || con.State == System.Data.ConnectionState.Broken)
                        {
                            con.Open();
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}