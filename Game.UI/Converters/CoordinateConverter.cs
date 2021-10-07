using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Game.UI.Converters
{
    public class CoordinateConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Length == 2)
            {
                var dataGridCellInfo = (DataGridCellInfo)values[0];
                var dataGrid = (DataGrid)values[1];
                DataGridRow dataGridRow = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(dataGridCellInfo.Item);
                return new[]
                {
                    dataGridRow?.GetIndex() ?? 0,
                    dataGridCellInfo.Column?.DisplayIndex ?? 0
                };
            }

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
