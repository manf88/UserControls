using System.Windows;
using System.Windows.Media;
using UserControls.NotificationPanel;

namespace TestApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IPanel _panel;

        public MainWindow()
        {
            InitializeComponent();

            _panel = new Panel();
            _panel.Activate();
            //_panel.SetStartupLocation(Left,Top);
            _panel.MaxNotifications = 5;
            _panel.MaxWidth = 300;
            _panel.MinWidth = 150;
            //_panel.InformationColor = Brushes.Green;
            //_panel.WarningColor = Brushes.Green;
            //_panel.ErrorColor = Brushes.Magenta;
            _panel.Parent = this;
            _panel.StartupLocation = StartupLocation.TopRight;
        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            _panel.AddNotification(NotificationType.Info, HeaderInfo.Text, MessageInfo.Text);
        }

        private void BtnWarning_Click(object sender, RoutedEventArgs e)
        {
            _panel.AddNotification(NotificationType.Warning, HeaderWarning.Text, MessageWarning.Text);
        }

        private void BtnError_Click(object sender, RoutedEventArgs e)
        {
            _panel.AddNotification(NotificationType.Error, HeaderError.Text, MessageError.Text);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _panel.Deactivate();
        }
    }
}
