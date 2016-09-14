using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using UserControls.NotificationPanel;

namespace TestApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private IPanel _panel;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            _panel = new Panel();
            _panel.Activate();
            _panel.MaxNotifications = 5;
            _panel.MaxWidth = 300;
            _panel.MinWidth = 150;
            //_panel.InformationColor = Brushes.Green;
            //_panel.WarningColor = Brushes.Green;
            //_panel.ErrorColor = Brushes.Magenta;
            _panel.Parent = this;
            _panel.StartupLocation = StartupLocation.TopRight;
        }

        public List<StartupLocation> StartupLocations
        {
            get
            {
                return Enum.GetValues(typeof(StartupLocation)).Cast<StartupLocation>().ToList();
            }
        }

        public StartupLocation CurrentStartupLocation
        {
            get
            {
                if (_panel != null)
                {
                    return _panel.StartupLocation;
                }
                else
                {
                    return StartupLocation.TopRight;
                }
            }
            set
            {
                _panel.StartupLocation = value;
                NotifyPropertyChanged("CurrentStartupLocation");
            }
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
