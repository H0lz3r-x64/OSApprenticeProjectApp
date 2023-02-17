using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfApplication.ViewModel
{
    partial class NavigationVM : ObservableRecipient
    {
        [ObservableProperty]
        private object _currentView;

        public NavigationVM()
        {
            // Startup Page
            CurrentView = new HomeVM();
        }

        [RelayCommand]
        private void Home() => CurrentView = new HomeVM();
        [RelayCommand]
        private void Customers() => CurrentView = new CustomersVM();
        [RelayCommand]
        private void Products() => CurrentView = new ProductsVM();
        [RelayCommand]
        private void Metadata() => CurrentView = new MetadataVM();
        [RelayCommand]
        private void Settings() => CurrentView = new SettingsVM();
    }
}
