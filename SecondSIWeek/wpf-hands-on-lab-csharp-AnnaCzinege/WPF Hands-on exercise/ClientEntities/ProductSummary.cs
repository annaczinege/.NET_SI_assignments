using System;
using System.ComponentModel;

namespace HandsOnLab1.ClientEntities
{
#pragma warning disable CS1574 // XML comment has cref attribute that could not be resolved
    /// <summary>
    /// Product summary information.
    /// </summary>
    /// <remarks>
    /// Summary information for a product. Useful for displaying in lists. For a complete representation for a product consider <see cref="T:ClientEntities.Product"/>.
    /// </remarks>
    /// <seealso cref="ClientEntities.Product"/>
    /// <seealso cref="ClientEntities.ProductSummaryCollection"/>
    public class ProductSummary : INotifyPropertyChanged
#pragma warning restore CS1574 // XML comment has cref attribute that could not be resolved
    {
        #region Private Fields
        private int _productId;
        private string _sku;
        private string _code;
        private string _name;
        private string _shortDescription;
        private string _manufacturer;
        private double _unitPrice;
        private double _lowestPrice;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductSummary"/> class.
        /// </summary>
        public ProductSummary()
        {
        }

        #region Properties

        /// <summary>
        /// Gets or sets the unique ProductId.
        /// </summary>
        /// <value>The product id.</value>
        public int ProductId
        {
            get
            {
                return _productId;
            }

            set
            {
                if (_productId != value)
                {
                    _productId = value;
                    OnPropertyChanged("ProductId");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Stock Keeping Unit for the product.
        /// </summary>
        /// <value>The sku.</value>
        public string Sku
        {
            get
            {
                return _sku;
            }

            set
            {
                if (_sku != value)
                {
                    _sku = value;
                    OnPropertyChanged("Sku");
                }
            }
        }

        /// <summary>
        /// Gets or sets the product code for the sku.
        /// </summary>
        /// <value>The product code.</value>
        public string Code
        {
            get
            {
                return _code;
            }

            set
            {
                if (_code != value)
                {
                    _code = value;
                    OnPropertyChanged("Code");
                }
            }
        }

        /// <summary>
        /// Gets or sets the descriptive name of the product.
        /// </summary>
        /// <value>The product name.</value>
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        /// <summary>
        /// Gets or sets the short description of the product.
        /// </summary>
        /// <value>The short product description.</value>
        public string ShortDescription
        {
            get
            {
                return _shortDescription;
            }

            set
            {
                if (_shortDescription != value)
                {
                    _shortDescription = value;
                    OnPropertyChanged("ShortDescription");
                }
            }
        }

        /// <summary>
        /// Gets or sets the manufacturer name.
        /// </summary>
        /// <value>The manufacturer.</value>
        public string Manufacturer
        {
            get
            {
                return _manufacturer;
            }

            set
            {
                if (_manufacturer != value)
                {
                    _manufacturer = value;
                    OnPropertyChanged("Manufacturer");
                }
            }
        }

        /// <summary>
        /// Gets or sets the default unit price.
        /// </summary>
        /// <value>Default unit price.</value>
        public double UnitPrice
        {
            get
            {
                return _unitPrice;
            }

            set
            {
                if (_unitPrice != value)
                {
                    _unitPrice = value;
                    OnPropertyChanged("UnitPrice");
                }
            }
        }

        /// <summary>
        /// Gets or sets the lowest price available for the product.
        /// </summary>
        /// <value>The lowest price.</value>
        public double LowestPrice
        {
            get
            {
                return _lowestPrice;
            }

            set
            {
                if (_lowestPrice != value)
                {
                    _lowestPrice = value;
                    OnPropertyChanged("LowestPrice");
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

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
