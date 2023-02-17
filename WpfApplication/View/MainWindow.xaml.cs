using System.Windows;
using System.Windows.Media;
using WpfApplication.Utilities;
using WpfApplication.ViewModel;

namespace WpfApplication.View
{
    /// <summary>
    /// The main window of the WPF application, responsible for initializing the user interface and setting the data context.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Background = new SolidColorBrush(Colors.Black) { Opacity = 0.01 };
        }

        /// <summary>
        /// Handles the `Loaded` event of the window, setting the data context to an anonymous object with two properties: Blur and Navigation.
        /// 
        /// The Blur property is an instance of the WindowBlurEffect class, which applies a blur effect to the windows transaparent parts.
        /// The Navigation property is the viewmodel of the left navigation panel.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new
            {
                Blur = new WindowBlurEffect(this, AccentState.ACCENT_ENABLE_ACRYLICBLURBEHIND)
                {
                    BlurBackgroundFromHex = "#1F1F1F",
                    BlurOpacity = 100
                },
                Navigation = new NavigationVM()
            };
        }
    }
}
