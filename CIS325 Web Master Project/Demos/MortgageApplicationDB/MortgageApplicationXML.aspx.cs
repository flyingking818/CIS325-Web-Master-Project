﻿using System;
using System.Collections.Generic;
using System.Configuration;
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
            //Get AppID from QueryString
            string queryAppID = Request.QueryString["AppID"];
            string queryAction = Request.QueryString["Action"];

            if (queryAction == "Edit" || queryAction == "View")
            {
                //Passed validation, now do the DB operation.

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MortgageAppDB"].ConnectionString);

                try
                {
                    conn.Open();
                    conn.ChangeDatabase("jwang");

                    //construct SQLquery (R)
                    string sqlQuery = "SELECT * FROM MortgageApplicationXML WHERE AppID = " + queryAppID + ";";

                    SqlCommand cmdMortgageApp = new SqlCommand(sqlQuery, conn);
                    SqlDataReader rsCustomers = cmdMortgageApp.ExecuteReader();

                    if (rsCustomers.Read())
                    {
                        XDocument doc = XDocument.Parse(rsCustomers["DataFormXML"].ToString());
                        //Loop through all elements

                        foreach (XElement xe in doc.Root.Descendants())
                        {
                            string fieldID = xe.Attribute("ID").Value;
                            string fieldType = xe.Attribute("Type").Value;
                            string fieldValue = xe.Value;

                            //Find controls by using the MainContent place holder which is defined in the HTML document
                            ContentPlaceHolder cph = (ContentPlaceHolder)this.Master.FindControl("MainContent");
                            
                            //You may use the switch...case block here as well. :)
                            if (fieldType == "TextBox")
                            {
                                TextBox tb = (TextBox)cph.FindControl(fieldID);
                                tb.Text = fieldValue;
                                if (queryAction == "View")
                                {
                                    tb.ReadOnly = true;
                                    tb.BorderStyle = BorderStyle.None;
                                }
                            }
                            else if (fieldType == "CheckBoxList")
                            {
                                CheckBoxList chklst = (CheckBoxList)cph.FindControl(fieldID);
                                string[] items = fieldValue.Split(',');
                                for (int i = 0; i <= items.GetUpperBound(0); i++)
                                {
                                    ListItem currentCheckBox = chklst.Items.FindByText(items[i].ToString().Trim());
                                    if (currentCheckBox != null)
                                    {
                                        currentCheckBox.Selected = true;
                                        //currentCheckBox.Enabled = false;
                                    }
                                    if (queryAction == "View")
                                        chklst.Items[i].Enabled = false;
                                }
                            }
                            else if (fieldType == "RadioButtonList")
                            {
                                RadioButtonList radiolst = (RadioButtonList)cph.FindControl(fieldID);
                                ListItem currentRadioBox = radiolst.Items.FindByText(fieldValue);
                                if (currentRadioBox != null)
                                {
                                    currentRadioBox.Selected = true;
                                }
                                if (queryAction == "View")
                                {
                                    //disable radiobutton
                                    for (int i = 0; i < radiolst.Items.Count; i++)
                                    {
                                        radiolst.Items[i].Enabled = false;
                                    }
                                }
                            }
                            //Do the drop down list by yourself! :)

                        }
                    }
                    else
                    {
                        ErrorMsg.Text = "No customer found! ";
                    }

                }
                catch (SqlException exception)
                {

                    ErrorMsg.Text = "Sorry an error has occurred! " + "Error Message: " + exception.Message + "Error No: " + exception.Number;
                }

                conn.Close();
            }
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
                    /*
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
                    */

                    switch (myContol.GetType().Name)
                    {
                        case "TextBox":
                            TextBox textbox = (TextBox)myContol;
                            xmlForm.Element("DataForm").Add(new XElement("Field", textbox.Text, new XAttribute("ID", myContol.ID), new XAttribute("Type", "TextBox")));
                            break;
                        case "RadioButtonList":
                            RadioButtonList radiolst = (RadioButtonList)myContol;
                            xmlForm.Element("DataForm").Add(new XElement("Field", radiolst.Text, new XAttribute("ID", myContol.ID), new XAttribute("Type", "RadioButtonList")));
                            break;
                        case "DropDownList":
                            DropDownList droplst = (DropDownList)myContol;
                            xmlForm.Element("DataForm").Add(new XElement("Field", droplst.Text, new XAttribute("ID", myContol.ID), new XAttribute("Type", "DropDownList")));
                            break;
                        case "CheckBox":
                            CheckBox chk = (CheckBox)myContol;
                            if (chk.Checked)
                            {
                                xmlForm.Element("DataForm").Add(new XElement("Field", chk.Text, new XAttribute("ID", myContol.ID), new XAttribute("Type", "CheckBox")));
                            }
                            break;
                        case "CheckBoxList":
                            CheckBoxList chklst = (CheckBoxList)myContol;

                            // try this one by yourself - hint: use a loop to concatenate the selected values
                            break;

                        default:
                            break;
                    }

                }
                string xmlData = xmlForm.ToString();  //deserialization 
                //End of XML processing


                //Get AppID from QueryString -- using the URL to pass values.
                string queryAppID = Request.QueryString["AppID"];
                string queryAction = Request.QueryString["Action"];
                //========DB Operations==========

                //Establish a SQL connection to my Database                
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MortgageAppDB"].ConnectionString);

                try
                {
                    conn.Open(); //it's not for sure. 
                    conn.ChangeDatabase("jwang");

                    if (queryAction != "Edit")
                    {
                        /*
                        string sqlQuery = "INSERT INTO MortgageApplicationXML VAlUES (";
                        sqlQuery += "'" + customerName + "',";
                        sqlQuery += "'" + customerEmail + "',";
                        sqlQuery += "'" + customerSSN + "',";
                        sqlQuery += "'" + customerLoanAmount + "',";
                        sqlQuery += "'" + xmlData + "'";
                        sqlQuery += "); SELECT CAST(scope_identity() AS INT);";
                        */

                        //Interpolation option - more efficient
                        //SQL injection?

                        //This is not very safe.
                        
                        string sqlQuery = $@"
                                            INSERT INTO MortgageApplicationXML 
                                            VALUES ('{customerName}', '{customerEmail}', '{customerSSN}', '{customerLoanAmount}', '{xmlData}');
                                            SELECT CAST(scope_identity() AS INT);";
                                                
                        SqlCommand cmdMortgageApp = new SqlCommand(sqlQuery, conn);
                        

                        //This is safer for a real app, we love stored proc(edures) in production!
                       
                        /*
                        string sqlQuery = @"
                        INSERT INTO MortgageApplicationXML (CustomerName, CustomerEmail, CustomerSSN, CustomerLoanAmount, DataFormXML)
                        VALUES (@CustomerName, @CustomerEmail, @CustomerSSN, @CustomerLoanAmount, @DataFormXML);
                        SELECT CAST(scope_identity() AS INT);";

                        SqlCommand cmdMortgageApp = new SqlCommand(sqlQuery, conn);
                          
                        cmdMortgageApp.Parameters.AddWithValue("@CustomerName", customerName);
                        cmdMortgageApp.Parameters.AddWithValue("@CustomerEmail", customerEmail);
                        cmdMortgageApp.Parameters.AddWithValue("@CustomerSSN", customerSSN);
                        cmdMortgageApp.Parameters.AddWithValue("@CustomerLoanAmount", customerLoanAmount);
                        cmdMortgageApp.Parameters.AddWithValue("@DataFormXML", xmlData);
                        //cmdMortgageApp.Parameters.AddWithValue("@AppID", int.Parse(queryAppID));
                        
                        */

                        int newMortgageAppID = (int)cmdMortgageApp.ExecuteScalar();

                        //Add a SendFacultyEmail(newRequestID, emailAddress);

                        ResultMsg.Text = "Your application has been succesfully submitted!" + "<a href=\"MortgageApplicationXMLMain.aspx \"> Click here</a> to view the results! ";
                    }
                    else
                    {
                        /*
                        string sqlQuery = "UPDATE MortgageApplicationXML SET ";
                        sqlQuery += "CustomerName='" + customerName + "',";
                        sqlQuery += "CustomerEmail='" + customerEmail + "',";
                        sqlQuery += "CustomerSSN='" + customerSSN + "',";
                        sqlQuery += "CustomerLoanAmount=" + customerLoanAmount + ",";
                        sqlQuery += "DataFormXML='" + xmlData + "'";
                        sqlQuery += "WHERE AppID=" + int.Parse(queryAppID);
                        */

                        //Interpolation Option

                        string sqlQuery = $@"
                                    UPDATE MortgageApplicationXML 
                                    SET CustomerName = '{customerName}', 
                                        CustomerEmail = '{customerEmail}', 
                                        CustomerSSN = '{customerSSN}', 
                                        CustomerLoanAmount = {customerLoanAmount}, 
                                        DataFormXML = '{xmlData}' 
                                    WHERE AppID = {int.Parse(queryAppID)};";

                        SqlCommand cmdMortgageApp = new SqlCommand(sqlQuery, conn);

                        //Parameter version
                        /*
                        string sqlQuery = @"
                                UPDATE MortgageApplicationXML 
                                SET CustomerName = @CustomerName, 
                                    CustomerEmail = @CustomerEmail, 
                                    CustomerSSN = @CustomerSSN, 
                                    CustomerLoanAmount = @CustomerLoanAmount, 
                                    DataFormXML = @DataFormXML 
                                WHERE AppID = @AppID";                     
                                                
                        cmdMortgageApp.Parameters.AddWithValue("@CustomerName", customerName);
                        cmdMortgageApp.Parameters.AddWithValue("@CustomerEmail", customerEmail);
                        cmdMortgageApp.Parameters.AddWithValue("@CustomerSSN", customerSSN);
                        cmdMortgageApp.Parameters.AddWithValue("@CustomerLoanAmount", customerLoanAmount);
                        cmdMortgageApp.Parameters.AddWithValue("@DataFormXML", xmlData);
                        cmdMortgageApp.Parameters.AddWithValue("@AppID", int.Parse(queryAppID));
                        */
                        
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