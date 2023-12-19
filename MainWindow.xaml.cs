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

namespace WpfApp49
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string myNumber = "";
        public string op = "";
        public double sum = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button bt)
            {
                myNumber += bt.Content;
            }
            ShowLbl.Content = myNumber;
        }

        private void CEBtn_Click(object sender, RoutedEventArgs e)
        {
            myNumber = "";
            ShowLbl.Content = "";
            SumLbl.Content = "";
            sum = 0;
            op = "";
        }

        private void CBtn_Click(object sender, RoutedEventArgs e)
        {
            SumLbl.Content = sum.ToString();
            myNumber = "";
            ShowLbl.Content = "";
            sum = 0;
            
        }

        private void OperationBtn_Click(object sender, RoutedEventArgs e)
        {
            sum= Convert.ToDouble(myNumber);
            myNumber = "";
            if (sender is Button bt)
            {
                op=bt.Content.ToString();
            }
            SumLbl.Content = sum.ToString();
        }

        private void DotBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button bt)
            {
                myNumber += bt.Content;
            }
        }
        private double Calculate(string op, double num1, double num2)
        {
            if (op == "*")
            {
                return num1 * num2;
            }
            else if (op == "/")
            {
                if (num2!=0)
                {
                  return num1 / num2;
                }
                throw new Exception("Cant Divide zero");
            }
            else if (op == "+")
            {
                return num1 + num2;
            }
            else if (op == "%")
            {
                if (num2 != 0)
                {
                    return num1 % num2;
                }
                throw new Exception("Cant Divide zero");
            }
            else if (op == "-")
            {
                return num1 - num2;
            }
            throw new Exception("Wrong Input");
        }
        private void EqualBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button bt)
            {            
            try
            {
                sum = Calculate(op,sum, Convert.ToDouble(myNumber));
            }
            catch (Exception  ex)
            {

                MessageBox.Show(ex.Message);
            }
            SumLbl.Content= sum.ToString();
            }
        }
    }
}
