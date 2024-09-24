using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CIS325_Web_Master_Project.Demos.MortgageCalculator
{
    public partial class MortgageCal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //Rule 1: At least 18, but not over 80

            int age = Convert.ToInt32(CustomerAge.Text);
            if (age >= 18 && age <= 80)
            {
                ResultMsg.Text = "Welcome to the mortgage app! :)";
            }
            else {
                ResultMsg.Text = "Sorry, not for you!";
                return;
            }
        }
    }
}