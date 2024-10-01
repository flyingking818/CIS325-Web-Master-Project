/*
 Documentation comments:

 Created by Dr. Jeremy Wang
 Last updated: 9/30/2024
 Version: 1.0
  
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

/* 
 Hint:
 
 Use the "Manage NuGet packages" to install
 1) IronPDF (or PDFSharp)
 2) Htmlrender.PDFSharp
 
 */

//using PdfSharp.Drawing.Layout;
//using PdfSharp.Drawing;
//using PdfSharp.Pdf;


namespace CIS325_Master_Project.Demos.MortgageProject
{
    public partial class MortgageCal : System.Web.UI.Page
    {//applies to the auto post back event.
        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoanTerm.SelectedValue!= "7ARM")            
                ARMNotes.Visible = false;           
            else            
                ARMNotes.Visible = true;                          

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //Constant and variable declarations
            const double LOAN_AMOUNT_UPPER = 200000;
            const double LOAN_AMOUNT_LOWER = 100000;

            //Declare variables. Initiatiaze those who values are determined in decision-making structures.
            double discountState = 0;
            double discountLoanTerm = 0;
            double discountLoanAmount = 0;
            double purchasePrice, loanAmount, annualPercentageRate=0,downPaymentPercentage, downPaymentAmount, monthlyPayment;
            int loanTerm=0, numberOfAccounts = 0;
            string accountList = "";
            bool isEmailSuccess;
            string resultMsg;


            //Rule 1: Age over 18
            //int customerAge = int.Parse(CustomerAge.Text); //popular with ASP.NET
            int customerAge = Convert.ToInt32(CustomerAge.Text);

            ErrorMsg.Text = "";

            if (customerAge >= 18 && customerAge <= 80)  //&& => AND , || OR 
            {
                ResultMsg.Text = "Welcome to the Mortgage Cal App!";
                //don't use Response.Write for format output, use it only for debugging.
            }
            else
            {
                ErrorMsg.Text = "Sorry, not for you";
                return;  //exit 
            }

            // Rule 2: State discount
            switch (State.SelectedValue)
            {
                case "CO":
                case "FL":
                    discountState = 0.1;
                    break;
                case "GA":
                    discountState = 0.08;
                    break;
                case "MI":
                    discountState = 0.05;
                    break;
                case "NY":
                    discountState = 0.03;
                    break;
                default:
                    discountState = 0;
                    break;
            }

            //Rule #3 Discount based on LoanTerm. Also set the APR
            
            switch (LoanTerm.SelectedValue)
            {
                case "7ARM":
                    discountLoanTerm = 0.01;
                    annualPercentageRate = 0.082;
                    loanTerm = 7;
                    break;
                case "10Year":
                    discountLoanTerm = 0.03;
                    annualPercentageRate = 0.067;
                    loanTerm = 10;
                    break;
                case "30Year":
                    discountLoanTerm = 0.075;
                    annualPercentageRate = 0.078;
                    loanTerm = 30;
                    break;
                default:
                    discountLoanTerm = 0;
                    break;
            }

            //Rule #4 Loan Account Discount - nasty IFs (nested IFs)
            purchasePrice = double.Parse(PurchasePrice.Text);
            downPaymentPercentage = double.Parse(DownPayment.Text) / 100;
            loanAmount = purchasePrice * (1 - downPaymentPercentage); 
            if (loanAmount >= LOAN_AMOUNT_UPPER)
            {
                discountLoanAmount = 0.05;
            }
            else
            {
                if (loanAmount >= LOAN_AMOUNT_LOWER)
                {
                    discountLoanAmount = 0.03;
                }
                else
                {
                    discountLoanAmount = 0;
                }
            }

            //Demo - loops in a GUI app - compare the three major types
            //Very useful for loop through ListItem object 

        

            //While Loop - this is the most flexiable repeating structure!
            
            /*
            int i = 0;
            while (i < ExistingAccounts.Items.Count) //similar to .Length
            {
                ListItem accountChoiceItem = ExistingAccounts.Items[i];
                if (accountChoiceItem.Selected )
                {
                    //numberOfAccounts = numberOfAccounts + 1;
                    numberOfAccounts++;   // > 1?
                    accountList += accountChoiceItem.Text + ", "; //string manipulation
                }
                i++; // VERY IMPORTANT!!!! 
            }
            */

            //For Loop 
            
            /*
             for (int i = 0; i < ExistingAccounts.Items.Count; ++i)
             {
                 ListItem accountChoiceItem = ExistingAccounts.Items[i];
                 if (accountChoiceItem.Selected)
                 {
                     numberOfAccounts++;
                     accountList += accountChoiceItem.Text + ", "; //substring can get rid of any extra characters.
                 }
             }
            */

            //This is the best solution in ASP.NET           
            foreach (ListItem accountChoiceItem in ExistingAccounts.Items) //instantiation of item object 
            {
                if (accountChoiceItem.Selected)
                {
                    numberOfAccounts++;
                    accountList += accountChoiceItem.Text + ", ";  //SubString function
                }
            }
            

            //Rule #5 Multiple Account Discount
            double discountMultipleAccounts = 0;
            if (numberOfAccounts > 1)
            {
                discountMultipleAccounts = 0.03;
            }

            //Calculate the effective down payment amount! 

            downPaymentAmount = CalculateDownPayment(loanAmount, downPaymentPercentage, discountState,
                                                discountLoanTerm, discountLoanAmount,
                                                discountMultipleAccounts);

            //Calculate monthly payment, using C# to simulate the PMT function in Excel
            monthlyPayment = CalculatePMT(loanAmount, annualPercentageRate, loanTerm);

            //Hide the web form
            FormPanel.Visible = false;
                        
            

            //====================Output===============================
            resultMsg = "<h1>Thanks for using the Mortgage Calculator App!</h1>" +
                "<p><table>"+
                "<tr><td><strong> Customer Name: </td><td>" + CustomerName.Text + "</td></tr>" +
                "<tr><td><strong> Purchase Price: </td><td>" + purchasePrice.ToString("C") + "</td></tr>" +
                "<tr><td><strong> Effective Down Payment Amount: </td><td>" + downPaymentAmount.ToString("C") + "</td></tr>" +
                "<tr><td><strong> Loan Amount: </td><td>" + loanAmount.ToString("C")+ "</td>" +
                "<tr><td><strong> Monthly Payment: </td><td>" + monthlyPayment.ToString("C") + "</td></tr>" +
                "</table>";

            //Send email notifications to the user

            isEmailSuccess = SendCustomerEmail(CustomerEmail.Text, CustomerName.Text, resultMsg);


            if (isEmailSuccess) {
                resultMsg += "The email notification was successfully sent! :)"; 
            }
            ResultMsg.Text = resultMsg;

        }

        public double CalculateDownPayment(double calLoanAmount,
                          double calDownPaymentPercentage,
                          double calDiscountState,
                          double calDiscountLoanTerm,
                          double calDisountLoanAmount,
                          double calDiscountMultipleAccounts)
        {
            //==========Do you see a major logical error here? :) Please debug. =============

            /*
            //Calculate Down Payment without discounts
            double downPayment = calLoanAmount * calDownPaymentPercentage;

            //Apply discounts step by step
            //1) Discount State
            downPayment = downPayment * (1 - calDiscountState);  // = is NOT equal! is "assignment!" instead.
            //2) Discount Loan Term
            downPayment = downPayment * (1 - calDiscountLoanTerm);
            downPayment = downPayment * (1 - calDisountLoanAmount);
            downPayment = downPayment * (1 - calDiscountMultipleAccounts);
            */

            //A better format! :)
            double downPayment = calLoanAmount * calDownPaymentPercentage
                                 * (1 - calDiscountState)
                                 * (1 - calDiscountLoanTerm)
                                 * (1 - calDisountLoanAmount)
                                 * (1 - calDiscountMultipleAccounts);

            return downPayment;

            
        }

        public static double CalculatePMT(double loanAmount, double annualInterestRate, int loanTermInYears)
        {
            double monthlyInterestRate = annualInterestRate / 12;
            int numberOfPayments = loanTermInYears * 12;

            double monthlyPayment = loanAmount * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, numberOfPayments)) /
                                    (Math.Pow(1 + monthlyInterestRate, numberOfPayments) - 1);

            return monthlyPayment;
        }

        public bool SendCustomerEmail(string sendCustomerEmail, string sendCustomerName, string sendResultMsg)
        {
            string sendFromEmail = "flaglercisapp@gmail.com";

            string sendFromName = "Mortgage Calculator";
            string sendToEmail = sendCustomerEmail;
            string sendToName = sendCustomerName;

            string messageSubject = "Your mortgage calculator summary";
            string messageBody = sendResultMsg;  //Here, you may customize the message a bit. :)

            //This is standard procedure for object instatiation!!!
            MailAddress from = new MailAddress(sendFromEmail, sendFromName);
            MailAddress to = new MailAddress(sendToEmail, sendToName);
            MailMessage emailMessage = new MailMessage(from, to);

            emailMessage.Subject = messageSubject;
            emailMessage.Body = messageBody;
            emailMessage.IsBodyHtml = true;

            //Hint: Create a method here to generete PDF (return true if successful)


            //Using email client/server to send out emails. Watch out for the run-time errors!

            try
            {
                SmtpClient client = new SmtpClient();

                client.Host = "smtp.gmail.com";
                System.Net.NetworkCredential basicauthenticationinfo = new System.Net.NetworkCredential("flaglercisapp@gmail.com", "PUT_YOUR_APP_PASSCODE_HERE");                               
                client.Port = int.Parse("587");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicauthenticationinfo;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //attachment - add one here using the attachment property.
                client.Send(emailMessage);

                /*
                    Go to https://myaccount.google.com/apppasswords
                    Create an app and generate a passcode. This replaces your real password in your app.
                    Use the generated app passcode in your code.

                    Tips:
                    If you’ve set up 2-Step Verification but can’t find the option to add an app password, it might be because:
                    Your Google Account has 2-Step Verification set up only for security keys.
                    You’re logged into a work, school, or another organization account.
                    Your Google Account has Advanced Protection.
                */

                return true;
            }
            catch (Exception ex)
            {
                ErrorMsg.Text = $"An error occurred: {ex.Message}|{ex.HResult}";
                throw;
            }          
        }

    }
}