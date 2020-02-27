using System;
using System.Globalization;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Data;

namespace HandsOnLab1.Converters
{
    /// <summary>
    /// Supports conversion from an enum value to the description of that value.  If the enum value is decorated
    /// with the <see cref="System.ComponentModel.DescriptionAttribute"/> attribute, its Description value is returned.
    /// Otherwise, the name of the enum value is returned.
    /// </summary>
    /// <remarks>
    /// The <see cref="System.ComponentModel.DescriptionAttribute"/> attribute is optional, however its value must be unique
    /// within the enum for the <c>ConvertBack</c> method to work correctly.
    /// </remarks>
    [ValueConversion(typeof(Enum), typeof(string))]
    public class EnumValueToDescriptionConverter : IValueConverter
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
        /// A converted value. If the method returns null, the valid null value is used.A return value of <see cref="T:System.Windows.DependencyProperty"></see>.<see cref="F:System.Windows.DependencyProperty.UnsetValue"></see> indicates that the converter produced no value and that the binding uses the <see cref="P:System.Windows.Data.BindingBase.FallbackValue"></see>, if available, or the default value instead.A return value of <see cref="T:System.Windows.Data.Binding"></see>.<see cref="F:System.Windows.Data.Binding.DoNothing"></see> indicates that the binding does not transfer the value or use the <see cref="P:System.Windows.Data.BindingBase.FallbackValue"></see> or default value.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Enum == false)
            {
                throw new ArgumentException("'value' must be an enum.", "value");
            }

            // Get the field in the enum type which represents the argument value.
            FieldInfo field = value.GetType().GetField(value.ToString());

            return Convert(field);
        }

        /// <summary>
        /// Converts a value. The data binding engine calls this method when it propagates a value from the binding target to the binding source.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.A return value of <see cref="T:System.Windows.DependencyProperty"></see>.<see cref="F:System.Windows.DependencyProperty.UnsetValue"></see> indicates that the converter produced no value and that to the binding uses the <see cref="P:System.Windows.Data.BindingBase.FallbackValue"></see>, if available, or the default value instead.A return value of <see cref="T:System.Windows.Data.Binding"></see>.<see cref="F:System.Windows.Data.Binding.DoNothing"></see> indicates that the binding does not transfer the value or use the <see cref="P:System.Windows.Data.BindingBase.FallbackValue"></see> or default value.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value as string;
            Object returnValue = null;

            if (Enum.IsDefined(targetType, strValue))
            {
                returnValue = Enum.Parse(targetType, strValue);
            }
            else
            {
                FieldInfo[] fields = targetType.GetFields();
                foreach (FieldInfo field in fields)
                {
                    object[] attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (attributes.Length > 0)
                    {
                        DescriptionAttribute descriptionAttribute = attributes[0] as DescriptionAttribute;
                        if (descriptionAttribute.Description == strValue)
                        {
                            returnValue = Enum.Parse(targetType, field.Name);
                            break;
                        }
                    }
                }
            }

            return returnValue;
        }
        #endregion // IValueConverter Members

        /// <summary>
        /// Convert the <see cref="Enum"/> to a string.
        /// </summary>
        /// <param name="value">Enum value</param>
        /// <returns>Converterted string representation of the <see cref="Enum"/> value.</returns>
        public string Convert(Enum value)
        {
            return (string)Convert(value, typeof(string), null, null);
        }

        /// <summary>
        /// Convert the <see cref="MemberInfo"/> to a string.
        /// </summary>
        /// <param name="member">Member information</param>
        /// <returns>Convertered string representation of the <see cref="MemberInfo"/></returns>
        public string Convert(MemberInfo member)
        {
            // Get the DescriptionAttribute on that field, if it exists.
            object[] attributes = member.GetCustomAttributes(typeof(DescriptionAttribute), false);

            // The enum value is not decorated with the attribute, so just return the value itself.
            if (attributes.Length == 0)
            {
                return member.Name;
            }

            // Return the description applied to the enum value.
            DescriptionAttribute descriptionAttribute = attributes[0] as DescriptionAttribute;
            return descriptionAttribute.Description;
        }
    }
}
