using System.Windows.Data;
using System;
using System.Globalization;
using System.Threading;

namespace HandsOnLab1.Converters
{
    /// <summary>
    /// Converts numeric values to a currency representation as a string. Can convert back again.
    /// </summary>
    [ValueConversion(typeof(object), typeof(string))]
    public class CurrencyConverter : IValueConverter
    {
        #region IValueConverter Members

        /// <summary>
        /// Converts a value. The data binding engine calls this method when it propagates a value from the binding source to the binding target.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value.If the method returns null, the valid null value is used.A return value of <see cref="T:System.Windows.DependencyProperty"></see>.<see cref="F:System.Windows.DependencyProperty.UnsetValue"></see> indicates that the converter produced no value and that the binding uses the <see cref="P:System.Windows.Data.BindingBase.FallbackValue"></see>, if available, or the default value instead.A return value of <see cref="T:System.Windows.Data.Binding"></see>.<see cref="F:System.Windows.Data.Binding.DoNothing"></see> indicates that the binding does not transfer the value or use the <see cref="P:System.Windows.Data.BindingBase.FallbackValue"></see> or default value.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IFormattable formattable;
            string strValue = value as string;
            if (strValue != null)
            {
                decimal decValue;
                if (Decimal.TryParse(strValue, out decValue))
                {
                    formattable = decValue;
                }
                else
                {
                    return Binding.DoNothing;
                }
            }
            else
            {
                formattable = value as IFormattable;
            }

            if (formattable == null)
            {
                return Binding.DoNothing;
            }

            return formattable.ToString("c", culture);
        }

        /// <summary>
        /// Converts a value. The data binding engine calls this method when it propagates a value from the binding target to the binding source.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value.If the method returns null, the valid null value is used.A return value of <see cref="T:System.Windows.DependencyProperty"></see>.<see cref="F:System.Windows.DependencyProperty.UnsetValue"></see> indicates that the converter produced no value and that to the binding uses the <see cref="P:System.Windows.Data.BindingBase.FallbackValue"></see>, if available, or the default value instead.A return value of <see cref="T:System.Windows.Data.Binding"></see>.<see cref="F:System.Windows.Data.Binding.DoNothing"></see> indicates that the binding does not transfer the value or use the <see cref="P:System.Windows.Data.BindingBase.FallbackValue"></see> or default value.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string val = value.ToString();
                NumberFormatInfo nfi = culture == null ? Thread.CurrentThread.CurrentCulture.NumberFormat : culture.NumberFormat;
                val = val.Replace(nfi.CurrencyGroupSeparator, string.Empty).Replace(nfi.CurrencySymbol, string.Empty);

                decimal result;
                if (Decimal.TryParse(val, out result))
                {
                    return ((IConvertible)result).ToType(targetType, culture);
                }
            }

            return Binding.DoNothing;
        }

        #endregion
    }
}
