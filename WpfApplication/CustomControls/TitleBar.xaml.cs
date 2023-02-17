using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApplication.CustomControls
{
    /// <summary>
    /// Interaktionslogik für TitleBar.xaml
    /// </summary>
    [ObservableObject]
    public partial class TitleBar : UserControl
    {
        private Window ParentWindow;

        [ObservableProperty]
        public string _title;
        [ObservableProperty]
        public Brush _barSplitBackground;
        [ObservableProperty]
        public int _barSplitColumn;

        public TitleBar()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(TitleBar_Loaded);
        }

        private void TitleBar_Loaded(object sender, RoutedEventArgs e)
        {
            ParentWindow = Window.GetWindow(this);
            if (ParentWindow != null)
            {
                ParentWindow.StateChanged += MainWindowStateChangeRaised;
                ParentWindow.SizeChanged += MainWindowStateSizeChanged;
            }
            MainWindowStateSizeChanged(null, null);
        }

        // Can execute
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        // Minimize
        private void CommandBinding_Executed_Minimize(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(ParentWindow);
        }

        // Maximize
        private void CommandBinding_Executed_Maximize(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MaximizeWindow(ParentWindow);
        }

        // Restore
        private void CommandBinding_Executed_Restore(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.RestoreWindow(ParentWindow);
        }

        // Close
        private void CommandBinding_Executed_Close(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.CloseWindow(ParentWindow);
        }

        // State change
        private void MainWindowStateChangeRaised(object sender, EventArgs e)
        {
            if (ParentWindow.WindowState == WindowState.Maximized)
            {
                ((Border)ParentWindow.FindName("MainWindowBorder")).BorderThickness = new Thickness(8);
                RestoreButton.Visibility = Visibility.Visible;
                MaximizeButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                ((Border)ParentWindow.FindName("MainWindowBorder")).BorderThickness = new Thickness(0);
                RestoreButton.Visibility = Visibility.Collapsed;
                MaximizeButton.Visibility = Visibility.Visible;
            }
        }

        private void MainWindowStateSizeChanged(object sender, EventArgs e)
        {
            if (Parent.GetType() == typeof(Grid))
            {
                ColumnDefinitionCollection parentContainerColumns = ((Grid)Parent).ColumnDefinitions;
                if (parentContainerColumns.Count != 0)
                {
                    int i = 0;
                    foreach (ColumnDefinition columnDefinition in new ColumnDefinition[] { Column1, Column2 })
                    {
                        columnDefinition.Width = parentContainerColumns[i].Width;
                        columnDefinition.MinWidth = parentContainerColumns[i].MinWidth;
                        columnDefinition.MaxWidth = parentContainerColumns[i].MaxWidth;
                        i++;
                    }
                }
            }
        }
    }
}
