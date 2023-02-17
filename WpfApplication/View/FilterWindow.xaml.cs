using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApplication.Model;
using WpfApplication.Utilities;
using WpfApplication.ViewModel;

namespace WpfApplication.View
{
    /// <summary>
    /// Interaction logic for FilterWindow.xaml
    /// </summary>
    public partial class FilterWindow : Window, ICloseable
    {
        public FilterWindow(DataGrid dataGrid, int columnIndex, string startFilterMode, ref ObservableCollection<ObservableCollection<FilterCondition>> filterConditions, bool isNumericalColumn)
        {
            InitializeComponent();
            DataContext = new FilterVM(dataGrid, columnIndex, startFilterMode, ref filterConditions, isNumericalColumn);
            Title = dataGrid.Columns[columnIndex].Header.ToString() + " - Column Filters";
        }

        private void FilterValueTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Delegate the event to the viewmodel
            (DataContext as FilterVM).FilterValueTextBox_TextChanged(sender, e);
        }
    }
}