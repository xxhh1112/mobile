using System.Globalization;
using System.Linq;
using CommunityToolkit.Maui.Converters;
using Microsoft.Maui.Controls;

namespace Bit.App.Controls
{
    public class ExtendedCollectionView : CollectionView
    {
        public string ExtraDataForLogging { get; set; }
    }

    public class SelectionChangedEventArgsConverter : BaseConverterOneWay<SelectionChangedEventArgs, object>
    {
        public override object DefaultConvertReturnValue { get; set; } = null;

        public override object ConvertFrom(SelectionChangedEventArgs value, CultureInfo culture)
        {
            return value?.CurrentSelection.FirstOrDefault();
        }
    }
}
