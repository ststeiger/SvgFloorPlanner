
using FirebirdSql.Data.FirebirdClient;


namespace SvgFloorPlanner
{


    public class SQL
    {


        public static string GetConnectionString()
        {
            FirebirdSql.Data.FirebirdClient.FbConnectionStringBuilder csb = new FbConnectionStringBuilder();

            csb.ServerType = FbServerType.Embedded;
            csb.UserID = "sysdba";
            csb.Password = "masterkey";
            csb.Dialect = 3;
            csb.Database = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/MyDB.fdb");

            // string connectionString = "ServerType=1;User=SYSDBA;Password=masterkey;Dialect=3;Database="
            // + System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/MyDB.fdb");

            return csb.ConnectionString;
        } // End Function GetConnectionString


        public static bool CreateDatabase(string connectionString)
        {
            FirebirdSql.Data.FirebirdClient.FbConnectionStringBuilder csb = new FbConnectionStringBuilder(connectionString);
            if (!System.IO.File.Exists(csb.Database))
            {
                FbConnection.CreateDatabase(connectionString);
                // FbConnection.CreateDatabase(csb.ConnectionString, pageSize, forcedWrites, overwrite);
                return true;
            }

            return false;
        } // End Function CreateDatabase
        

        public static void ExecuteNonQuery(string strSQL)
        {

            using (System.Data.IDbConnection con = new FbConnection(GetConnectionString()))
            {

                try
                {
                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();

                    using (System.Data.IDbCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = strSQL;
                        cmd.ExecuteNonQuery();
                    } // End Using System.Data.IDbCommand cmd 

                } // End Try
                catch (System.Data.Common.DbException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    throw;
                } // End Catch
                finally
                {
                    if (con != null)
                    {
                        if (con.State != System.Data.ConnectionState.Closed)
                            con.Close();
                    } // End if (con != null)
                } // End Finally

            } // End Using System.Data.IDbConnection con 

        } // End Sub ExecuteNonQuery 


        public static object ExecuteScalar(string strSQL)
        {
            object obj = null;

            using (System.Data.IDbConnection con = new FbConnection(GetConnectionString()))
            {

                try
                {
                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();

                    using (System.Data.IDbCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = strSQL;
                        obj = cmd.ExecuteScalar();
                    } // End Using System.Data.IDbCommand cmd 

                } // End Try
                catch (System.Data.Common.DbException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    throw;
                } // End Catch
                finally
                {
                    if (con != null)
                    {
                        if (con.State != System.Data.ConnectionState.Closed)
                            con.Close();
                    } // End if (con != null)
                } // End Finally

            } // End Using System.Data.IDbConnection con 

            return obj;
        } // End Function ExecuteScalar 


        public static System.Data.DataTable GetDataTable(string strSQL)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            using (FbDataAdapter da = new FbDataAdapter(strSQL, GetConnectionString()))
            {
                da.Fill(dt);
            } // End Using da

            return dt;
        } // End Function GetDataTable


    } // End Class SQL


} // End Namespace SvgFloorPlanner
