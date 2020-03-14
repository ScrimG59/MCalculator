using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using Taschenrechner.Model.Helper;
using Taschenrechner.Model.TokenApproach;
using Taschenrechner.ViewModel;

namespace Taschenrechner
{
    public partial class MainWindow : Window
    {
        private string tempResult = "";
        Checker c = new Checker();
        Filler f = new Filler();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            if (c.checkNumbersForAutoComplete(textbox.Text))
            {
                textbox.Text += "×0";
            }

            else if (textbox.Text == "") { textbox.Text += "0"; }
            else if (!c.checkOperations(textbox.Text)) { textbox.Text += "0"; }
            else if (c.checkZero(textbox.Text)) { textbox.Text += "0"; }
            else {}
        }

        private void one_Click(object sender, RoutedEventArgs e)
        {
            if (c.checkNumbersForAutoComplete(textbox.Text))
            {
                textbox.Text += "×1";
            }
            else { textbox.Text += "1"; }
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            if (c.checkNumbersForAutoComplete(textbox.Text))
            {
                textbox.Text += "×2";
            }
            else { textbox.Text += "2"; }
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            if (c.checkNumbersForAutoComplete(textbox.Text))
            {
                textbox.Text += "×3";
            }
            else { textbox.Text += "3"; }
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            if (c.checkNumbersForAutoComplete(textbox.Text))
            {
                textbox.Text += "×4";
            }
            else { textbox.Text += "4"; }
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            if (c.checkNumbersForAutoComplete(textbox.Text))
            {
                textbox.Text += "×5";
            }
            else { textbox.Text += "5"; }
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            if (c.checkNumbersForAutoComplete(textbox.Text))
            {
                textbox.Text += "×6";
            }
            else { textbox.Text += "6"; }
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            if (c.checkNumbersForAutoComplete(textbox.Text))
            {
                textbox.Text += "×7";
            }
            else { textbox.Text += "7"; }
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            if (c.checkNumbersForAutoComplete(textbox.Text))
            {
                textbox.Text += "×8";
            }
            else { textbox.Text += "8"; }
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            if (c.checkNumbersForAutoComplete(textbox.Text))
            {
                textbox.Text += "×9";
            }
            else { textbox.Text += "9"; }
        }

        private void multi_Click(object sender, RoutedEventArgs e)
        {
            if(c.checkOperations(textbox.Text))
            {
                textbox.Text += "×";
            }
        }

        private void division_Click(object sender, RoutedEventArgs e)
        {
            if (c.checkOperations(textbox.Text))
            {
                textbox.Text += "÷";
            }
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            if (c.checkOperations(textbox.Text))
            {
                textbox.Text += "-";
            }
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            if (c.checkOperations(textbox.Text))
            {
                textbox.Text += "+";
            }
        }

        private void equals_Click(object sender, RoutedEventArgs e)
        {
            /*------------Comment this in and the code below out, to get the "token approach"-------------*/
            if (c.checkEqualBracketAmount(textbox.Text))
            {
                tempResult = textbox.Text;
                textbox.Text = "";
                textbox.Text = f.calculateToken(tempResult);
            }

            /*------------Comment this in and the code above out, to get the "string approach"-------------*/

            /*if (c.checkEqualBracketAmount(textbox.Text))
            {
                tempResult = textbox.Text;
                textbox.Text = "";
                textbox.Text = f.calculateString(tempResult);
            }*/

            /*-----------------------------------------------------------------------------------------------*/

            /*tempResult = textbox.Text.ToString();
            if (c.checkEqualBracketAmount(tempResult))
            {
                textbox.Text = "";
                result = "";
                tempToken = syt.toPolishNotation(tempResult);
                foreach (var token in tempToken)
                {
                    result += token.Value + " ";
                    Console.WriteLine($"[MainWindow] Token: {token.Value}");
                }
                result = eit.evaluate(result);
                tempToken.Clear();
                textbox.Text = result;
            }*/

            /*
            tempResult = textbox.Text.ToString();
            Console.WriteLine($"Inhalt: {tempResult}");
            if (c.checkEqualBrackets(tempResult))
            {
                textbox.Text = "";
                tempResult = sy.stringToInfix(tempResult);
                result = ei.evaluate(tempResult);
                Console.WriteLine($"Ergebnis: {result}");
                textbox.Text = result;
            }
            */
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (!(textbox.Text.Length > 0))
            {
                return;
            }
            else { textbox.Text = f.setSubstringForDelete(textbox.Text); }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
                textbox.Text = "";
        }

        private void comma_Click(object sender, RoutedEventArgs e)
        {
            if (c.checkOperations(textbox.Text))
            {
                textbox.Text += ",";
            }
        }

        private void parenleft_Click(object sender, RoutedEventArgs e)
        {
            if (c.autoCompleteMultiply(textbox.Text))
            {
                textbox.Text += "×(";
            }
            else
            {
                textbox.Text += "(";
            }
        }

        private void parenright_Click(object sender, RoutedEventArgs e)
        {
            if (c.checkRightParen(textbox.Text))
            {
                textbox.Text += ")";
            }
        }

        private void power_Click(object sender, RoutedEventArgs e)
        {
            if (c.checkOperations(textbox.Text))
            {
                textbox.Text += "^";
            }
        }

        private void cosinus_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += "cos(";
        }

        private void sinus_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += "sin(";
        }

        private void exponential_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += "e^";
        }

        private void e_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += "e";
        }

        private void pi_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += "π";
        }

        private void tangens_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += "tan(";
        }

        private void logarithm10_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += "log(";
        }

        private void logarithmnaturalis_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += "ln(";
        }

        private void squareroot_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += "√(";
        }
    }
}
