using System;
using System.Collections.Generic;
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
using HandsOnLab1.ClientEntities;
using HandsOnLab1.ServiceAgents;

namespace HandsOnLab1
{
    /// <summary>
    /// Interaction logic for ProductList.xaml
    /// </summary>
    public partial class ProductList : System.Windows.Controls.UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductList"/> class.
        /// </summary>
        public ProductList()
        {
            InitializeComponent();
            _products = ProductAgent.GetProductList();
            DataContext = this;
        }

        private ProductSummaryCollection _products;

        public ProductSummaryCollection Products { get { return _products; } }
    }
}