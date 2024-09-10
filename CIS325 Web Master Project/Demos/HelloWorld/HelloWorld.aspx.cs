using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CIS325_Web_Master_Project.Demos.HelloWorld
{
    public partial class HelloWorld : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {

            //Variables in C#, naming convention - camel case

            string firstName = "Jeremy";
            string lastName = "Wang";

            //simple calculations
            double totalPrice = 100;
            double taxRate = 0.07;

            //logic 
            double totalAmount = totalPrice* (1 + taxRate);



            Response.Write("hello world! My name is " + firstName + " " + lastName + "<br>");
            Response.Write("The total amount is: " + totalAmount.ToString("C"));
        }
    }
}