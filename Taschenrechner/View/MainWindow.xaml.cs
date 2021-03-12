using System.Windows;
using System.Windows.Media;
using Taschenrechner.Helper;
using Taschenrechner.ViewModel;
using System.Windows.Input;

namespace Taschenrechner
{
    public partial class MainWindow : Window
    {
        private string tempResult = "";
        private Checker c = new Checker();
        private Printer f = new Printer();
        private string modeString = "radiant";
        private bool switchMode = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void zero_Click(object sender, RoutedEventArgs e)
        { 
            textbox.Text += f.printZero(textbox.Text);
        }

        private void one_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printNumber(textbox.Text, 1);
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printNumber(textbox.Text, 2);
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printNumber(textbox.Text, 3);
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printNumber(textbox.Text, 4);
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printNumber(textbox.Text, 5);
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printNumber(textbox.Text, 6);
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printNumber(textbox.Text, 7);
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printNumber(textbox.Text, 8);
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printNumber(textbox.Text, 9);
        }

        private void multi_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printOperator(textbox.Text, "×");
        }

        private void division_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printOperator(textbox.Text, "÷");
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printOperator(textbox.Text, "-");
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printOperator(textbox.Text, "+");
        }

        private void equals_Click(object sender, RoutedEventArgs e)
        {
            /*------------Comment this in and the code below out, to get the "token approach"-------------*/
            if (c.checkEqualBracketAmount(textbox.Text) && textbox.Text != "" && c.checkForEquals(textbox.Text))
            {
                tempResult = textbox.Text;
                history.Content = textbox.Text;
                textbox.Text = "";
                textbox.Text = f.calculateToken(tempResult, modeString);
            }

            /*------------Comment this in and the code above out, to get the "string approach"-------------*/

            /*if (c.checkEqualBracketAmount(textbox.Text))
            {
                tempResult = textbox.Text;
                textbox.Text = "";
                textbox.Text = f.calculateString(tempResult);
            }*/
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (textbox.Text.Length == 0)
            {
                history.Content = "";
                return;
            }
            else if(textbox.Text.Length == 1)
            {
                history.Content = "";
                textbox.Text = f.setSubstringForDelete(textbox.Text);
            }
            else { textbox.Text = f.setSubstringForDelete(textbox.Text); }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text = "";
            history.Content = "";
        }

        private void comma_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printComma(textbox.Text);
        }

        private void parenleft_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printLeftParen(textbox.Text);
        }

        private void parenright_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printRightParen(textbox.Text);
        }

        private void power_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printOperator(textbox.Text, "^");
        }

        private void cosinus_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printFunction(textbox.Text, "cos");
        }

        private void sinus_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printFunction(textbox.Text, "sin");
        }

        private void exponential_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printFunction(textbox.Text, "exp");
        }

        private void e_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printConstant(textbox.Text, "e");
        }

        private void pi_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printConstant(textbox.Text, "pi");
        }

        private void tangens_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printFunction(textbox.Text, "tan");
        }

        private void logarithm10_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printFunction(textbox.Text, "log");
        }

        private void logarithmnaturalis_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printFunction(textbox.Text, "ln");
        }

        private void squareroot_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printFunction(textbox.Text, "sqrt");
        }

        private void mode_Click(object sender, RoutedEventArgs e)
        {
            if (modeString.Equals("radiant"))
            {
                modeString = "degree";
                degree.Foreground = new SolidColorBrush(Colors.Red);
                radiant.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#686868"));
            }
            else if(modeString.Equals("degree"))
            {
                modeString = "radiant";
                degree.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#686868"));
                radiant.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void switch_Click(object sender, RoutedEventArgs e)
        {
            if (switchMode)
            {
                cosinus.Visibility = Visibility.Visible;
                sinus.Visibility = Visibility.Visible;
                tangens.Visibility = Visibility.Visible;
                cosinusH.Visibility = Visibility.Hidden;
                sinusH.Visibility = Visibility.Hidden;
                tangensH.Visibility = Visibility.Hidden;
                switchMode = false;
            }
            else
            {
                cosinus.Visibility = Visibility.Hidden;
                sinus.Visibility = Visibility.Hidden;
                tangens.Visibility = Visibility.Hidden;
                cosinusH.Visibility = Visibility.Visible;
                sinusH.Visibility = Visibility.Visible;
                tangensH.Visibility = Visibility.Visible;
                switchMode = true;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.Key.ToString());
            switch (e.Key.ToString())
            {
                case "D1":
                    one_Click(sender, e);
                    break;
                case "NumPad1":
                    one_Click(sender, e);
                    break;
                case "D2":
                    two_Click(sender, e);
                    break;
                case "NumPad2":
                    two_Click(sender, e);
                    break;
                case "D3":
                    three_Click(sender, e);
                    break;
                case "NumPad3":
                    three_Click(sender, e);
                    break;
                case "D4":
                    four_Click(sender, e);
                    break;
                case "NumPad4":
                    four_Click(sender, e);
                    break;
                case "D5":
                    five_Click(sender, e);
                    break;
                case "NumPad5":
                    five_Click(sender, e);
                    break;
                case "D6":
                    six_Click(sender, e);
                    break;
                case "NumPad6":
                    six_Click(sender, e);
                    break;
                case "D7":
                    seven_Click(sender, e);
                    break;
                case "NumPad7":
                    seven_Click(sender, e);
                    break;
                case "D8":
                    eight_Click(sender, e);
                    break;
                case "NumPad8":
                    eight_Click(sender, e);
                    break;
                case "D9":
                    nine_Click(sender, e);
                    break;
                case "NumPad9":
                    nine_Click(sender, e);
                    break;
                case "D0":
                    zero_Click(sender, e);
                    break;
                case "NumPad0":
                    zero_Click(sender, e);
                    break;
                case "Decimal":
                    comma_Click(sender, e);
                    break;
                case "Back":
                    delete_Click(sender, e);
                    break;
                case "Delete":
                    clear_Click(sender, e);
                    break;
                case "Add":
                    plus_Click(sender, e);
                    break;
                case "Subtract":
                    minus_Click(sender, e);
                    break;
                case "Multiply":
                    multi_Click(sender, e);
                    break;
                case "Divide":
                    division_Click(sender, e);
                    break;
                case "Up":
                    mode_Click(sender, e);
                    break;
                case "Down":
                    mode_Click(sender, e);
                    break;
                case "Right":
                    switch_Click(sender, e);
                    break;
                case "Left":
                    switch_Click(sender, e);
                    break;
                case "Return":
                    equals_Click(sender, e);
                    break;
                case "Power":
                    power_Click(sender, e);
                    break;
                case "Oem5":
                    power_Click(sender, e);
                    break;
            }
        }

        private void cosinusH_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printFunction(textbox.Text, "cosh");
        }

        private void sinusH_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printFunction(textbox.Text, "sinh");
        }

        private void tangensH_Click(object sender, RoutedEventArgs e)
        {
            textbox.Text += f.printFunction(textbox.Text, "tanh");
        }
    }
}
