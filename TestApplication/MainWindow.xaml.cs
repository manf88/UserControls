using System.Windows;
using UserControls.NotificationWindow;

namespace TestApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NotificationContainer _notificationContainer;

        private int _counter;

        public MainWindow()
        {
            InitializeComponent();

            _notificationContainer = new NotificationContainer();
            _notificationContainer.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _notificationContainer.AddNotification(new NotificationItem("Erfolg", _counter++.ToString(), _notificationContainer));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _notificationContainer.Close();
        }        
    }
}
