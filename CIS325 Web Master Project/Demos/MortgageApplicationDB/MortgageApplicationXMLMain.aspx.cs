using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace CIS325_Web_Master_Project.Demos.MortgageApplicationDB
{
    public partial class MortgageApplicationXMLMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }


        protected void BindData()
        {

            string constr = ConfigurationManager.ConnectionStrings["MortgageAppDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM MortgageApplicationXML";
                    cmd.Connection = con;
                    // cmd.Parameters hint: use this to perform a search!

                    DataTable dt = new DataTable();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            //Add this.
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Handle the page index changing event here.
            // Typically, you would update the GridView's PageIndex property.
            GridView1.PageIndex = e.NewPageIndex;
            BindData();
        }
    }
}