using System.ComponentModel;

namespace HandsOnLab1.ClientEntities
{
    /// <summary>
    /// This class is a ViewModel for customer edit page.
    /// </summary>
    public class CustomerUpdate : INotifyPropertyChanged
    {
        #region Private Fields
        private readonly int _accountId;
        private string _companyName;
        private string _companyPhoneNumber;
        private string _mainContactFirstName;
        private string _mainContactLastName;
        private string _mainContactNumber;
        private string _mainContactRole;
        private string _address1;
        private string _address2;
        private string _address3;
        private string _address4;
        private string _city;
        private AustralianStates _state = AustralianStates.WestAustralia;
        private string _postCode;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerUpdate"/> class.
        /// </summary>
        /// <param name="accountId">Identifier of the account.</param>
        public CustomerUpdate(int accountId)
        {
            _accountId = accountId;
        }

        #region Properties

        /// <summary>
        /// Gets account identifier.
        /// </summary>
        public int AccountId
        {
            get
            {
                return _accountId;
            }
        }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        public string CompanyName
        {
            get
            {
                return _companyName;
            }

            set
            {
                if (_companyName != value)
                {
                    _companyName = value;
                    OnPropertyChanged("CompanyName");
                }
            }
        }

        /// <summary>
        /// Gets or sets the phone number of the company.
        /// </summary>
        public string CompanyPhoneNumber
        {
            get
            {
                return _companyPhoneNumber;
            }

            set
            {
                if (_companyPhoneNumber != value)
                {
                    _companyPhoneNumber = value;
                    OnPropertyChanged("CompanyPhoneNumber");
                }
            }
        }

        /// <summary>
        /// Gets or sets main contact person's first name.
        /// </summary>
        public string MainContactFirstName
        {
            get
            {
                return _mainContactFirstName;
            }

            set
            {
                if (_mainContactFirstName != value)
                {
                    _mainContactFirstName = value;
                    OnPropertyChanged("MainContactFirstName");
                }
            }
        }

        /// <summary>
        /// Gets or sets main contact person's last name.
        /// </summary>
        public string MainContactLastName
        {
            get
            {
                return _mainContactLastName;
            }

            set
            {
                if (_mainContactLastName != value)
                {
                    _mainContactLastName = value;
                    OnPropertyChanged("MainContactLastName");
                }
            }
        }

        /// <summary>
        /// Gets or sets main contact person's ContactNumber.
        /// </summary>
        public string MainContactNumber
        {
            get
            {
                return _mainContactNumber;
            }

            set
            {
                if (_mainContactNumber != value)
                {
                    _mainContactNumber = value;
                    OnPropertyChanged("MainContactNumber");
                }
            }
        }

        /// <summary>
        /// Gets or sets main contact person's role.
        /// </summary>
        public string MainContactRole
        {
            get
            {
                return _mainContactRole;
            }

            set
            {
                if (_mainContactRole != value)
                {
                    _mainContactRole = value;
                    OnPropertyChanged("MainContactRole");
                }
            }
        }

        /// <summary>
        /// Gets or sets the first address of the company.
        /// </summary>
        public string Address1
        {
            get
            {
                return _address1;
            }

            set
            {
                if (_address1 != value)
                {
                    _address1 = value;
                    OnPropertyChanged("Address1");
                }
            }
        }

        /// <summary>
        /// Gets or sets the alternative address of the company.
        /// </summary>
        public string Address2
        {
            get
            {
                return _address2;
            }

            set
            {
                if (_address2 != value)
                {
                    _address2 = value;
                    OnPropertyChanged("Address2");
                }
            }
        }

        /// <summary>
        /// Gets or sets the another alternative address of the company.
        /// </summary>
        public string Address3
        {
            get
            {
                return _address3;
            }

            set
            {
                if (_address3 != value)
                {
                    _address3 = value;
                    OnPropertyChanged("Address3");
                }
            }
        }

        /// <summary>
        /// Gets or sets the another address of the company.
        /// </summary>
        public string Address4
        {
            get
            {
                return _address4;
            }

            set
            {
                if (_address4 != value)
                {
                    _address4 = value;
                    OnPropertyChanged("Address4");
                }
            }
        }

        /// <summary>
        /// Gets or sets the city of the customer.
        /// </summary>
        public string City
        {
            get
            {
                return _city;
            }

            set
            {
                if (_city != value)
                {
                    _city = value;
                    OnPropertyChanged("City");
                }
            }
        }

        /// <summary>
        /// Gets or sets the state of the customer.
        /// </summary>
        public AustralianStates State
        {
            get
            {
                return _state;
            }

            set
            {
                if (_state != value)
                {
                    _state = value;
                    OnPropertyChanged("State");
                }
            }
        }

        /// <summary>
        /// Gets or sets the post code of the customer.
        /// </summary>
        public string PostCode
        {
            get
            {
                return _postCode;
            }

            set
            {
                if (_postCode != value)
                {
                    _postCode = value;
                    OnPropertyChanged("PostCode");
                }
            }
        }
        #endregion

        #region INotifyPropertyChanged Members

#pragma warning disable SA1201 // Elements should appear in the correct order
        /// <summary>
        /// Implicit implementation of the INotifyPropertyChanged.PropertyChanged event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore SA1201 // Elements should appear in the correct order

        /// <summary>
        /// Throws the <c>PropertyChanged</c> event.
        /// </summary>
        /// <param name="propertyName">The name of the property that was modified.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
