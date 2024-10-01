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

            //Constant and variable declarations
            const double LOAN_AMOUNT_UPPER = 200000;
            const double LOAN_AMOUNT_LOWER = 100000;

            //Declare variables. Initiatiaze those who values are determined in decision-making structures.
            double discountState = 0;
            double discountLoanTerm = 0;
            double discountLoanAmount = 0;
            double purchasePrice, loanAmount, annualPercentageRate = 0, downPaymentPercentage, downPaymentAmount, monthlyPayment;
            int loanTerm = 0, numberOfAccounts = 0;
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
            switch (State.SelectedValue)   //Drop down list
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

            switch (LoanTerm.SelectedValue)  //Radiobutton list
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
                default:  //not gonna get here.
                    discountLoanTerm = 0;
                    break;
            }

            //Rule #4 Loan Account Discount - nasty IFs (nested IFs)
            //A typical tier (bracket) decision-making structure.
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

            //While Loop - this is the most flexiable repeating structure!

            /*
            int i = 0;
            while (i < ExistingAccounts.Items.Count) //similar to .Length
            {
                //Object instantiation to create an item object which represents each choice.
                ListItem accountChoiceItem = ExistingAccounts.Items[i];
                if (accountChoiceItem.Selected)
                {
                    //numberOfAccounts = numberOfAccounts + 1;
                    numberOfAccounts++;   // > 1?
                    accountList += accountChoiceItem.Text + ", "; //string manipulation
                    //search substring()
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

            downPaymentAmount = CalculateDownPayment(purchasePrice, downPaymentPercentage, discountState,
                                                discountLoanTerm, discountLoanAmount,
                                                discountMultipleAccounts);

            //Do you see another bug here? :)
            loanAmount = purchasePrice - downPaymentAmount;

            //Calculate monthly payment, using C# to simulate the PMT function in Excel
            monthlyPayment = CalculatePMT(loanAmount, annualPercentageRate, loanTerm);


            //====================Output===============================
            //Hide the web form
            FormPanel.Visible = false;

            resultMsg = "<h1>Thanks for using the Mortgage Calculator App!</h1>" +
                "<p><table>" +
                "<tr><td><strong> Customer Name: </td><td>" + CustomerName.Text + "</td></tr>" +
                "<tr><td><strong> Purchase Price: </td><td>" + purchasePrice.ToString("C") + "</td></tr>" +
                "<tr><td><strong> Effective Down Payment Amount: </td><td>" + downPaymentAmount.ToString("C") + "</td></tr>" +
                "<tr><td><strong> Loan Amount: </td><td>" + loanAmount.ToString("C") + "</td>" +
                "<tr><td><strong> Monthly Payment: </td><td>" + monthlyPayment.ToString("C") + "</td></tr>" +
                "</table>";

            ResultMsg.Text = resultMsg;

        }

        public double CalculateDownPayment(double calPurchasePrice,
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
            double downPayment = calPurchasePrice * calDownPaymentPercentage
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





    }
}