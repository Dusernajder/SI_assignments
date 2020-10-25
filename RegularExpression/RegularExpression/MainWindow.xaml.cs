using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace RegularExpression
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!ValidateName(InputName.Text))
            {
                MessageBox.Show("The name is invalid, it can not contain any number or special character.");
            }

            if (!ValidatePhone(InputPhone.Text))
            {
                MessageBox.Show("The phone number is invalid, please use a format like this: 012-345-6789.");
            }

            if (!ValidateEmail(InputEmail.Text))
            {
                MessageBox.Show("The email is invalid, please use a correct email.");
            }
        }

        private bool ValidateName(string inputNameText)
        {
            return Regex.IsMatch(inputNameText, @"^([A-Za-z'.]+\s*)+$");
        }

        private bool ValidatePhone(string inputPhoneText)
        {
            return Regex.IsMatch(inputPhoneText, @"[0-9]{3}[-.][0-9]{3}[-.][0-9]{4}$");
        }

        private bool ValidateEmail(string inputEmailText)
        {
            return Regex.IsMatch(inputEmailText, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }


    }
}