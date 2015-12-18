using System;
using System.Windows;

namespace UserControls.NotificationWindow
{
    /// <summary>
    /// Interaction logic for NotificationContainer.xaml
    /// </summary>
    public partial class NotificationContainer : Window
    {
        public NotificationContainer()
        {
            InitializeComponent();
        }

        public void AddNotification(NotificationItem notification)
        {
            NotificationList.Visibility = Visibility.Visible;

            NotificationList.Children.Add(notification);
            notification.Completed += OnNotificationCompleted;

        }

        public void RemoveNotification(NotificationItem notification)
        {
            NotificationList.Children.Remove(notification);
            notification.RaiseCompleted(new DisposeNotificationEventArgs(notification));
        }

        private void OnNotificationCompleted(object sender, EventArgs e)
        {
            var args = (DisposeNotificationEventArgs)e;
            NotificationList.Children.Remove(args.Parent);

            if (NotificationList.Children.Count == 0)
            {
                NotificationList.Visibility = Visibility.Hidden;
            }
        }
    }
}
