
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SvgFloorPlanner
{


    public partial class _Default : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            int iCount= System.Convert.ToInt32(SQL.ExecuteScalar("SELECT COUNT(*) FROM Table1 WHERE ID = 3"));

            if (iCount == 0)
            {
                // SQL.ExecuteNonQuery("DELETE FROM Table1 WHERE ID = 3");

                string strSQL = @"
INSERT INTO Table1
(
	 ID
	,FIRSTNAME
	,LASTNAME
)
VALUES
(
	 3-- ID, integer
	,'Test' -- FIRSTNAME, nvarchar(200)
	,'User' -- LASTNAME, nvarchar(128)
)
;
";
                SQL.ExecuteNonQuery(strSQL);
            } // End if

            System.Data.DataTable dt = SQL.GetDataTable("SELECT * FROM Table1");
            this.dgvData.DataSource = dt;
            this.dgvData.DataBind();
        } // End Sub Page_Load 


    } // End Class Default 


} // End Namespace 
