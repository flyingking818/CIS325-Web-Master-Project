using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CIS325_Web_Master_Project.Demos.MATDepartment
{
    public partial class ProspectiveStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string htmlOutput;
            FormPanel.Visible = false;

            htmlOutput = "<h2>Thank you for submitting you form, " + Name.Text + "</h2>";
            htmlOutput += "<br> Hope to see you at Flagler soon! :)";

            //String interplolation by using the $ {}
            htmlOutput += $"<br>Your intended major is {IntendedMajor.SelectedValue} - {IntendedMajor.SelectedItem.Text}.";

            //.text returns the value.

            
            //keep adding whatever you need for output here.
            ResultMsg.Text = htmlOutput;
        }
    }
}