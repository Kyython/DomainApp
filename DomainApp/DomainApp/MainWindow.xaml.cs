using System;
using System.Threading.Tasks;
using System.Windows;

namespace DomainApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ExecuteAssemblyAsync(string fileName, string domainName)
        {
            SetLoading(true);
            downloadFileButton.IsEnabled = false;
            exponentiationButton.IsEnabled = false;

            var currentDomain = AppDomain.CurrentDomain;

            var domainApp = AppDomain.CreateDomain(domainName);

            var appPath = currentDomain.BaseDirectory + fileName;

            try
            {
                await Task.Run(() => domainApp.ExecuteAssembly(appPath));
            }

            catch (Exception exception)
            {
                SetLoading(false);
                MessageBox.Show(exception.Message);
                AppDomain.Unload(domainApp);
                return;
            }

            downloadFileButton.IsEnabled = true;
            exponentiationButton.IsEnabled = true;
            SetLoading(false);

            MessageBox.Show("Задача завершена!");
            AppDomain.Unload(domainApp);
        }

        private void ExponentiationButtonClick(object sender, RoutedEventArgs e)
        {
            ExecuteAssemblyAsync("ExponentiationApp.exe", "ExponentiationApp");
        }

        private void DownloadFileButtonClick(object sender, RoutedEventArgs e)
        {
            ExecuteAssemblyAsync("DownloadFile.exe", "DownloadFile");
        }

        private void SetLoading(bool isLoading)
        {
            if (isLoading)
            {
                progressBar.Visibility = Visibility.Visible;
                statusTextBlock.Text = "Please wait...";
            }
            else
            {
                progressBar.Visibility = Visibility.Collapsed;
                statusTextBlock.Text = "Done";
            }
        }
    }
}
