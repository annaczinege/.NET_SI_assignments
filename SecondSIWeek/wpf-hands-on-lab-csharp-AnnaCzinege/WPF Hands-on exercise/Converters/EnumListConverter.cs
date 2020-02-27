using System;
using System.Globalization;
using System.Windows.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HandsOnLab1.Converters
{
    /// <summary>
    /// Converts an <see cref="T:System.Enum"/> type to a <see cref="T:System.Collections.Generic.IList`1"/> type.
    /// </summary>
    [ValueConversion(typeof(Type), typeof(IList<String>))]
    public class EnumListConverter : IValueConverter
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
            Type enumValue = value as Type;
            if (enumValue is null)
            {
                throw new System.ArgumentException("value must be a Type", "value");
            }

            if (enumValue.BaseType != typeof(Enum))
            {
                throw new System.ArgumentException("value must be an Enum Type", "value");
            }

            Collection<String> results = new Collection<String>();
            EnumValueToDescriptionConverter memberConverter = new EnumValueToDescriptionConverter();
            System.Array values = Enum.GetValues(enumValue);
            foreach (object val in values)
            {
                results.Add(memberConverter.Convert(val as Enum));
            }

            return results;
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
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
