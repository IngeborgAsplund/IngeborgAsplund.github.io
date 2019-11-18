using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CaclulatorDelegateCS.MathLib;


namespace CaclulatorDelegateCS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CalcManager calcMngr;
        private string decimalPartFormat = "0.00";
        private double calcResult = 0.0;

        public MainWindow()
        {
            InitializeComponent();
            calcMngr = new CalcManager();
            FillOperationTypesInTheList();
            lblResult.Content = string.Empty;

        }

        private void FillOperationTypesInTheList()
        {
            string[] operatorSymbols = CalcOperators.GetSymbols();

            for (int index=0; index < operatorSymbols.Length; index++)
                cmbOperator.Items.Add(operatorSymbols[index]);


            cmbOperator.SelectedIndex = 0;
        }



        private bool ReadInput(ref double value1, ref double value2)
        {
            value2 = 0.0;
            value2 = 0.0;

            bool bOK = double.TryParse(txtNumber1.Text, out value1);
            if (bOK)
            {
                bOK = double.TryParse(txtNumber2.Text, out value2);
            }
            return bOK;
        }

       private void UpdateResult()
        {
            lblResult.Content = calcResult.ToString(decimalPartFormat);
        }
        private string[] GetInitialDecimalFormatStrings()
        {
            //divide the format into two strings: left of '.' and right of "."
            string[] formatstr = new string[2] { "0", "." }; //two elements
       

            if (calcResult.ToString().IndexOf(".") >= 0)
            {
                formatstr = decimalPartFormat.Split('.');
            }
            return formatstr;
        }
        private void btnIncrDecimals_Click(object sender, RoutedEventArgs e)
        {
           //formatstr always get a an array with two elements from this call
            string[] formatstr = GetInitialDecimalFormatStrings();

            //'.'  is default from the above call
            //if there is any 0 after the point
            formatstr[1] += "0";
            decimalPartFormat = formatstr[0] + "." + formatstr[1];
            UpdateResult();
        }

        private void btnDecrDecimals_Click(object sender, RoutedEventArgs e)
        {
            //formatstr always get a an array with two elements from this call
            string[] formatstr = GetInitialDecimalFormatStrings();

            //'.'  is default from the above call
            //if there is any 0 after the point
            if (formatstr[1].Length > 0) 
                 formatstr[1] = formatstr[1].Substring(0, formatstr[1].Length - 1);
       

            decimalPartFormat = formatstr[0] + "." + formatstr[1];

            UpdateResult();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (cmbOperator.SelectedIndex < 0)
                return;

            CalcOperators.Operators operation = (CalcOperators.Operators)cmbOperator.SelectedIndex;

            //Read the user given values
            double value1 = 0.0;
            double value2 = 0.0;

            if (!ReadInput(ref value1, ref value2))
            {
                MessageBox.Show("Values are out of range!");
                return;
            }

            //GUI does not care about how 
            calcResult = calcMngr.DoCalculate(value1, value2, operation);
            UpdateResult();

        }
        
        private void cmbOperator_SelectionChanged (object sender, SelectionChangedEventArgs e)
        {
         
            if (cmbOperator.SelectedIndex < 0)
                return;

            CalcOperators.Operators operation = (CalcOperators.Operators)cmbOperator.SelectedIndex;

            //Read the user given values
            double value1 = 0.0;
            double value2 = 0.0;

            if (!ReadInput ( ref value1, ref value2 ))
            {
                MessageBox.Show ( "Values are out of range!" );
                return;
            }

            //GUI does not care about how 
            calcResult = calcMngr.PerformCalc (Calculator.Multiply, value1, value2 );
            UpdateResult ( );

        }
    }
}
