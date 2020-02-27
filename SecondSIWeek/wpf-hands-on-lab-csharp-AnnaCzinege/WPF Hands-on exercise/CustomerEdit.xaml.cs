using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using HandsOnLab1.ClientEntities;

namespace HandsOnLab1
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class CustomerEdit : UserControl, INotifyPropertyChanged
    {
        private CustomerUpdate _customer = new CustomerUpdate(123);

        public CustomerEdit()
        {
            InitializeComponent();
            DataContext = this;
        }

        public CustomerUpdate Customer
        {
            get { return _customer; }

            set
            {
                if (_customer != value)
                {
                    _customer = value;
                    OnPropertyChanged("Customer");
                }
            }
        }

        private void CanSave(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExecuteSave(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Assume the save worked.");
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new
                PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}

