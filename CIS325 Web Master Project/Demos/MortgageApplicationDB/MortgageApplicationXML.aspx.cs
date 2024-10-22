using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CIS325_Web_Master_Project.Demos.MortgageApplicationDB
{
    public partial class MortgageApplicationXML : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //Force validation
            Page.Validate();
            if (Page.IsValid)
            {
                //Get the user inputs
                string customerName = CustomerName.Text;
                string customerEmail = CustomerEmail.Text;
                string customerSSN = CustomerSSN.Text;
                double customerLoanAmount = double.Parse(CustomerLoanAmount.Text);

                //Construct XMLFormData
                XDocument xmlForm = new XDocument(
                 new XComment("Application Form for " + customerName),
                 new XElement("DataForm",
                 new XAttribute("CustomerSSN", customerSSN))
                 );

                foreach (Control myContol in DataFormPanel.Controls)
                {
                    if (myContol.GetType().Name == "TextBox")
                    {
                        TextBox textbox = (TextBox)myContol;
                        xmlForm.Element("DataForm").Add(new XElement("Field", textbox.Text, new XAttribute("ID", myContol.ID), new XAttribute("Type", "TextBox")));
                    }
                    else if (myContol.GetType().Name == "RadioButtonList")
                    {
                        RadioButtonList radiolst = (RadioButtonList)myContol;
                        xmlForm.Element("DataForm").Add(new XElement("Field", radiolst.Text, new XAttribute("ID", myContol.ID), new XAttribute("Type", "RadioButtonList")));
                    }
                    else if (myContol.GetType().Name == "DropDownList")
                    {
                        DropDownList droplst = (DropDownList)myContol;
                        xmlForm.Element("DataForm").Add(new XElement("Field", droplst.Text, new XAttribute("ID", myContol.ID), new XAttribute("Type", "DropDownList")));
                    }
                    else if (myContol.GetType().Name == "CheckBox")
                    {
                        CheckBox chk = (CheckBox)myContol;
                        if (chk.Checked)
                        {
                            xmlForm.Element("DataForm").Add(new XElement("Field", chk.Text, new XAttribute("ID", myContol.ID), new XAttribute("Type", "CheckBox")));
                        }
                    }
                    else if (myContol.GetType().Name == "CheckBoxList")
                    {
                        CheckBoxList chklst = (CheckBoxList)myContol;

                        // try this one by yourself - hint: use a loop to concatenate the selected values

                    }
                }
                string xmlData = xmlForm.ToString();
                //End of XML processing


                //Get AppID from QueryString
                string queryAppID = Request.QueryString["AppID"];
                string queryAction = Request.QueryString["Action"];
                //========DB Operations==========

                //Establish a SQL connect to my Database                
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MortgageAppDB"].ConnectionString);

                try
                {
                    conn.Open(); //it's not for sure. 
                    conn.ChangeDatabase("jwang");

                    if (queryAction != "Edit")
                    {
                        string sqlQuery = "INSERT INTO MortgageApplicationXML VAlUES (";
                        sqlQuery += "'" + customerName + "',";
                        sqlQuery += "'" + customerEmail + "',";
                        sqlQuery += "'" + customerSSN + "',";
                        sqlQuery += "'" + customerLoanAmount + "',";
                        sqlQuery += "'" + xmlData + "'";
                        sqlQuery += "); SELECT CAST(scope_identity() AS INT);";

                        SqlCommand cmdMortgageApp = new SqlCommand(sqlQuery, conn);
                        int newMortgageAppID = (int)cmdMortgageApp.ExecuteScalar();
                        ResultMsg.Text = "Your application has been succesfully submitted!" + "<a href=\"MortgageApplicationXMLMain.aspx \"> Click here</a> to view the results! ";
                    }
                    else
                    {
                        string sqlQuery = "UPDATE MortgageApplicationXML SET ";
                        sqlQuery += "CustomerName='" + customerName + "',";
                        sqlQuery += "CustomerEmail='" + customerEmail + "',";
                        sqlQuery += "CustomerSSN='" + customerSSN + "',";
                        sqlQuery += "CustomerLoanAmount=" + customerLoanAmount + ",";
                        sqlQuery += "DataFormXML='" + xmlData + "'";
                        sqlQuery += "WHERE AppID=" + int.Parse(queryAppID);

                        SqlCommand cmdMortgageApp = new SqlCommand(sqlQuery, conn);
                        cmdMortgageApp.ExecuteNonQuery();
                        ResultMsg.Text = "Your application has been succesfully updated!" + "<a href=\"MortgageApplicationXMLMain.aspx \"> Click here</a> to view the results! ";
                    }

                    DataFormPanel.Visible = false;
                    Submit.Visible = false;
                    //You can choose to use a separate Update button.
                    //Update.Visible = false;

                    //Add a Cancel button by yourself. :)
                    //Cancel.Visible = false; 


                    //Email Notification for eRouting.
                    // How to grab that AppID for the new form?

                    //Don't forget to close the DB connection!
                    conn.Close();
                }
                catch (SqlException exception)
                {
                    ErrorMsg.Text = "Sorry an error has occurred!" + "Error Message: " + exception.Message + " Error NO: " + exception.Number;
                    throw;
                }
            }
        }

    }
}