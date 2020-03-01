using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace RegularExpression
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ValidateData();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ValidateData();
            }
        }

        private bool ValidateData()
        {
            if (!ValidateName(txtName))
            {
                MessageBox.Show("The name is invalid!", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!ValidatePhoneNumber(ReformatPhone(txtPhone)))
            {
                MessageBox.Show("The phone number is invalid!", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            } 
            //else
            //{
            //    string formatted = ReformatPhone(txtPhone);
            //    txtPhone.Clear();
            //    txtPhone.Text = formatted;
            //}
            if (!ValidateEmail(txtEmail))
            {
                MessageBox.Show("The email is invalid!", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private bool ValidateEmail(TextBox emailInput)
        {
            string emailPattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            if (!Regex.IsMatch(emailInput.Text, emailPattern)) return false;
            return true;
        }

        private bool ValidatePhoneNumber(string phoneNumberString)
        {
            string phoneNumberPattern = @" ^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$";
            if (!Regex.IsMatch(phoneNumberString, phoneNumberPattern)) return false;
            return true;
        }

        private bool ValidateName(TextBox nameInput)
        {
            string namePattern = @"^([A-Za-z]+\s?)+$";
            if (!Regex.IsMatch(nameInput.Text, namePattern)) return false;
            return true;
        }

        private string ReformatPhone(TextBox phoneNumberInput)
        {
            return Convert.ToInt32(phoneNumberInput.Text).ToString("(000) 000 0000");
        }
    }
}
