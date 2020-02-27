using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HandsOnLab1
{
    /// <summary>
    /// Interaction logic for ImageList.xaml
    /// </summary>
    public partial class ImageList : System.Windows.Controls.UserControl
    {
        private readonly ObservableCollection<String> _images = new ObservableCollection<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageList"/> class.
        /// </summary>
        public ImageList()
        {
            InitializeComponent();
            List<String> images = HandsOnLab1.ServiceAgents.ImageAgent.GetImages();
            foreach (string image in images)
            {
                Images.Add(image);
            }

            DataContext = this;
        }

        /// <summary>
        /// Gets all stored images.
        /// </summary>
        public ObservableCollection<String> Images
        {
            get { return _images; }
        }
    }
}