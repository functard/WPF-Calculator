using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double result = 0;
        string operation = "";
        bool enterValue = false;


        public MainWindow()
        {
            InitializeComponent();
        }

  
        private void numbers_Only(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            if (txtDisplay.Text == "0" || enterValue)
                txtDisplay.Text = "";

            enterValue = false; 

            //if decimal
            if(b.Content == ".")
            {

                if (txtDisplay.Text.Contains("."))
                    txtDisplay.Text = txtDisplay.Text + b.Content; //split
            }
            else
            {
                txtDisplay.Text = txtDisplay.Text + b.Content;
            }

        }

        private void operator_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            if(result != 0)
            {
                //press button within code
                btnEquals.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));


                enterValue = true;
                operation = (string)b.Content;
                lblShowOps.Content = System.Convert.ToString(result) + "   " + operation;

            }
            else
            {
                operation = (string)b.Content;
                result = double.Parse(txtDisplay.Text);
                txtDisplay.Text = "";
                lblShowOps.Content = System.Convert.ToString(result) + "   " + operation;
            }

        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            lblShowOps.Content = "";

            switch (operation)
            {
                case "+":
                    txtDisplay.Text = (result + double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (result - double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (result * double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "/":
                    txtDisplay.Text = (result / double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "%":
                    txtDisplay.Text = (result % double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "√":
                    txtDisplay.Text = (Math.Sqrt(result).ToString());
                    break;
                case "x²":
                    txtDisplay.Text = Math.Pow(result, 2).ToString();
                    break;

            }

            result = double.Parse(txtDisplay.Text);
            operation = "";
   
           
        }

        private void btnCE_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "0";
        }

        
        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "0";
            result = 0;
        }



        private void btnBackspace_Click(object sender, RoutedEventArgs e)
        {
            if(txtDisplay.Text.Length > 0)
            {
                //remove 1 digit
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }

            if(txtDisplay.Text == "")
            {
                txtDisplay.Text = "0";
            }
        }
    }
}
