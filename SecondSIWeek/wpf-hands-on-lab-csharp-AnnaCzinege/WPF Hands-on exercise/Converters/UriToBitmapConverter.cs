using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace HandsOnLab1.Converters
{
    /// <summary>
    /// Converter for transforming between <see cref="Uri"/> and <see cref="BitMap"/>.
    /// </summary>
    public class UriToBitmapConverter : IValueConverter
    {
        /// <summary>
        /// Convert <see cref="Uri"/> to <see cref="BitMap"/>
        /// </summary>
        /// <param name="value">An Unique Resource Identifier.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Additional parameter</param>
        /// <param name="culture">CultureInfo</param>
        /// <returns><see cref="BitMap"/> object based on the uri.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.DecodePixelWidth = 200;
            bi.CacheOption = BitmapCacheOption.OnLoad;
            bi.UriSource = new Uri(value.ToString());
            bi.EndInit();
            return bi;
        }

        /// <summary>
        /// Convert a <see cref="BitMap"/> image to an <see cref="Uri"/>.
        /// </summary>
        /// <param name="value">The bitmap image to convert.</param>
        /// <param name="targetType">Target type</param>
        /// <param name="parameter">Additional parameter.</param>
        /// <param name="culture">Culture info.</param>
        /// <returns>Reuturns an <see cref="Uri"/> for the image.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
