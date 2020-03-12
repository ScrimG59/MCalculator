using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Taschenrechner.Model.Helper;
using Taschenrechner.Model.TokenApproach;

namespace Taschenrechner
{
    public partial class MainWindow : Window
    {
        private string tempResult = "";
        private string result = "";
        private List<Token> tempToken = new List<Token>();
        string substring = "";
        ShuntingYard sy = new ShuntingYard();
        EvaluateInfix ei = new EvaluateInfix();
        ShuntingYardToken syt = new ShuntingYardToken();
        EvaluateInfixToken eit = new EvaluateInfixToken();
        Checker c = new Checker();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += "0";
        }

        private void one_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += "1";
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += "2";
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += "3";
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += "4";
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += "5";
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += "6";
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += "7";
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += "8";
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += "9";
        }

        private void multi_Click(object sender, RoutedEventArgs e)
        {
            if(textbox.Text != ""
               && (textbox.Text[textbox.Text.Length - 1] != '+'
               && textbox.Text[textbox.Text.Length - 1] != '-'
               && textbox.Text[textbox.Text.Length - 1] != '×'
               && textbox.Text[textbox.Text.Length - 1] != '÷'
               && textbox.Text[textbox.Text.Length - 1] != '^'
               && textbox.Text[textbox.Text.Length - 1] != '('
               && textbox.Text[textbox.Text.Length - 1] != ','))
            {
                textbox.Text += "×";
            }
        }

        private void division_Click(object sender, RoutedEventArgs e)
        {
            if (textbox.Text != ""
               && (textbox.Text[textbox.Text.Length - 1] != '+'
               && textbox.Text[textbox.Text.Length - 1] != '-'
               && textbox.Text[textbox.Text.Length - 1] != '×'
               && textbox.Text[textbox.Text.Length - 1] != '÷'
               && textbox.Text[textbox.Text.Length - 1] != '^'
               && textbox.Text[textbox.Text.Length - 1] != '('
               && textbox.Text[textbox.Text.Length - 1] != ','))
            {
                textbox.Text += "÷";
            }
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            if (textbox.Text != ""
               && (textbox.Text[textbox.Text.Length - 1] != '+'
               && textbox.Text[textbox.Text.Length - 1] != '-'
               && textbox.Text[textbox.Text.Length - 1] != '×'
               && textbox.Text[textbox.Text.Length - 1] != '÷'
               && textbox.Text[textbox.Text.Length - 1] != '^'
               && textbox.Text[textbox.Text.Length - 1] != '('
               && textbox.Text[textbox.Text.Length - 1] != ','))
            {
                textbox.Text += "-";
            }
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            if (textbox.Text != ""
               && (textbox.Text[textbox.Text.Length - 1] != '+'
               && textbox.Text[textbox.Text.Length - 1] != '-'
               && textbox.Text[textbox.Text.Length - 1] != '×'
               && textbox.Text[textbox.Text.Length - 1] != '÷'
               && textbox.Text[textbox.Text.Length - 1] != '^'
               && textbox.Text[textbox.Text.Length - 1] != '('
               && textbox.Text[textbox.Text.Length - 1] != ','))
            {
                textbox.Text += "+";
            }
        }

        private void equals_Click(object sender, RoutedEventArgs e)
        {
            /*------------Comment this in and the code below out, to get the "token approach"-------------*/
            tempResult = textbox.Text.ToString();
            Console.WriteLine($"[MainWindow] Content: {tempResult}");
            if (c.checkEqualBrackets(tempResult))
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
            }

            /*------------Comment this in and the code above out, to get the "string approach"-------------*/

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
        {   // TODO: Implement good delete function for cos, sin, exp
            if (!(textbox.Text.Length > 0))
            {
                return;
            }
            if (textbox.Text.Length >= 4 && 
                (textbox.Text.Substring(textbox.Text.Length - 4, 4).Contains("cos(") 
                || textbox.Text.Substring(textbox.Text.Length - 4, 4).Contains("sin(")))
            {
                    substring = textbox.Text.Substring(0, textbox.Text.Length - 4);
                    textbox.Text = substring;
            }
            else
            {
                substring = textbox.Text.Substring(0, textbox.Text.Length - 1);
                textbox.Text = substring;
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            if (tempToken.Count == 0 || tempToken == null)
            {
                textbox.Text = "";
            }
            else
            {
                tempToken.Clear();
                textbox.Text = "";
            }
    }

        private void comma_Click(object sender, RoutedEventArgs e)
        {
            if (textbox.Text != ""
               && (textbox.Text[textbox.Text.Length - 1] != '+'
               && textbox.Text[textbox.Text.Length - 1] != '-'
               && textbox.Text[textbox.Text.Length - 1] != '×'
               && textbox.Text[textbox.Text.Length - 1] != '÷'
               && textbox.Text[textbox.Text.Length - 1] != '^'
               && textbox.Text[textbox.Text.Length - 1] != '('
               && textbox.Text[textbox.Text.Length - 1] != ','))
            {
                textbox.Text += ",";
            }
        }

        private void parenleft_Click(object sender, RoutedEventArgs e)
        {
            if (textbox.Text == "" 
               || textbox.Text[textbox.Text.Length - 1] == '+'
               || textbox.Text[textbox.Text.Length - 1] == '-'
               || textbox.Text[textbox.Text.Length - 1] == '×'
               || textbox.Text[textbox.Text.Length - 1] == '÷'
               || textbox.Text[textbox.Text.Length - 1] == '^')
            {
                textbox.Text += "(";
            }
        }

        private void parenright_Click(object sender, RoutedEventArgs e)
        {
            if (textbox.Text != ""
               && (textbox.Text[textbox.Text.Length - 1] != '+'
               && textbox.Text[textbox.Text.Length - 1] != '-'
               && textbox.Text[textbox.Text.Length - 1] != '×'
               && textbox.Text[textbox.Text.Length - 1] != '÷'
               && textbox.Text[textbox.Text.Length - 1] != '^'
               && textbox.Text[textbox.Text.Length - 1] != '('
               && textbox.Text[textbox.Text.Length - 1] != ',') 
               && !c.checkEqualBrackets(textbox.Text))
            {
                textbox.Text += ")";
            }
        }

        private void power_Click(object sender, RoutedEventArgs e)
        {
            if (textbox.Text != ""
               && (textbox.Text[textbox.Text.Length - 1] != '+'
               && textbox.Text[textbox.Text.Length - 1] != '-'
               && textbox.Text[textbox.Text.Length - 1] != '×'
               && textbox.Text[textbox.Text.Length - 1] != '÷'
               && textbox.Text[textbox.Text.Length - 1] != '^'
               && textbox.Text[textbox.Text.Length - 1] != '('
               && textbox.Text[textbox.Text.Length - 1] != ','))
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

        private void multi_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }

        private void multi_KeyDown_1(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }
    }
}
