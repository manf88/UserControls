using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserControls.NotificationWindow
{
    /// <summary>
    /// Interaction logic for NotificationContainer.xaml
    /// </summary>
    public partial class NotificationBox : Window
    {
        public NotificationBox()
        {
            InitializeComponent();
        }

        public void AddNotification(NotificationItem notification)
        {
            NotificationList.Visibility = Visibility.Visible;

            NotificationList.Children.Add(notification);
            notification.Completed += OnNotificationCompleted;

        }

        private void OnNotificationCompleted(object sender, EventArgs e)
        {
            var args = (DisposeNotificationEventArgs)e;
            NotificationList.Children.Remove(args.Parent);

            if(NotificationList.Children.Count == 0)
            {
                NotificationList.Visibility = Visibility.Hidden;
            }
        }
    }
}
