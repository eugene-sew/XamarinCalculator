using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TodoListApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private decimal firstNumber;
        private string operatorName;
        private bool isOperatorClicked;


        void btnCommon_Clicked(object sender, System.EventArgs e)
        {
            var button = sender as Button;
            if(LblResult.Text == "0" || isOperatorClicked)
            {
                isOperatorClicked = false;
                LblResult.Text = button.Text;
            }
            else {
                LblResult.Text += button.Text;
            }
        }


         void btnCommonOperation_Clicked(object sender, System.EventArgs e)
        {
            var button = sender as Button;
            isOperatorClicked = true;
            operatorName = button.Text;
            firstNumber = Convert.ToDecimal(LblResult.Text);
            
        }



        void btnClear_Clicked(object sender, System.EventArgs e)
        {
            isOperatorClicked = false;
            LblResult.Text = "0";
            firstNumber = 0;
        }

        //delete the previous/current number
        void btnX_Clicked(System.Object sender, System.EventArgs e)
        {
            string number = LblResult.Text;
            if(number != "0")
            {
                //remove the number at the last index of the number string
                number = number.Remove(number.Length - 1,1);
                if (string.IsNullOrEmpty(number))
                {
                    LblResult.Text = "0";

                }
                else
                {
                    LblResult.Text = number;
                }
            }
        }

       async void btnPercentage_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                string number = LblResult.Text;
                if (number != "0")
                {
                    decimal percentageVal = Convert.ToDecimal(number);
                    string result = (percentageVal / 100).ToString("0.####");
                    LblResult.Text = result;
                    Console.Write(result);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

       async void btnEqual_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                decimal secondNumber = Convert.ToDecimal(LblResult.Text);
                string finalResult = Calculate(firstNumber, secondNumber).ToString("0.###");
                LblResult.Text = finalResult;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        public decimal Calculate(decimal firstNum, decimal secondNum)
        {
            decimal result = 0;

            switch (operatorName)
            {
                case "+":
                    result = firstNum + secondNum;
                    break;
                case "-":
                    result = firstNum - secondNum;
                    break;
                case "*":
                    result = firstNum * secondNum;
                    break;
                case "/":
                    result = firstNum / secondNum;
                    break;
            }
            return result;
        }
    }
}
