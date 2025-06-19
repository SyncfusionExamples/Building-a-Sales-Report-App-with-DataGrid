using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AnnualSalesReportDemoUsingGrid
{
    public class PercentageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return System.String.Format("{0}%", value); ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if((bool)value)
            {
                if(parameter?.ToString() == "AnnualReport")
                    return new BitmapImage(new Uri(string.Format(@"..\..\Images\{0}", "sales_increased.png"), UriKind.Relative));
                else
                    return new BitmapImage(new Uri(string.Format(@"..\..\Images\{0}", "up-2-24.png"), UriKind.Relative));
            }                
            else
            {
                if (parameter?.ToString() == "AnnualReport")
                    return new BitmapImage(new Uri(string.Format(@"..\..\Images\{0}", "sales_decrease.png"), UriKind.Relative));
                else
                    return new BitmapImage(new Uri(string.Format(@"..\..\Images\{0}", "down-arrow-28.png"), UriKind.Relative));
            }
                
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var increased = (value as MonthlySalesReport).IsSalesIncreased;

            //custom condition is checked based on data.

            if (increased)
                return new SolidColorBrush(Colors.PaleGreen);
            else
                return new SolidColorBrush(Colors.OrangeRed);

            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
