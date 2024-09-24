using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CIS325_Web_Master_Project.Tests.MortgageCal
{
    public partial class WageCalculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //Declare constants
            int age = int.Parse(CustomerAge.Text);

            if (age >= 18 && age <= 80)
            {
                ResultMsg.Text = "Welcome to the mortgage cal app!:)";
                return;
            }
            else
            {
                ResultMsg.Text = "Sorry, this app is not for you";
                return;
            }
        }
    }
}