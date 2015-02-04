using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FirebirdSql.Data.FirebirdClient;


namespace SvgFloorPlanner
{


    public partial class _Default : System.Web.UI.Page
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
            }


        }



        protected void Page_Load(object sender, EventArgs e)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            FbDataAdapter da = new FbDataAdapter("SELECT * FROM Table1", connectionString);
            da.Fill(dt);

            // ID
            // FIRSTNAME
            // LASTNAME

            

            this.dgvData.DataSource = dt;
            this.dgvData.DataBind();
        }
    }
}