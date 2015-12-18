using System;
using System.Windows;

namespace UserControls.NotificationPanel
{
    /// <summary>
    /// The host window for notification items.
    /// </summary>
    internal partial class Container : Window
    {
        public Container()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds a notification to the container.
        /// </summary>
        /// <param name="notification"></param>
        public void AddNotification(string header, string message)
        {
            var notification = new Notification(header, message);

            NotificationList.Visibility = Visibility.Visible;

            NotificationList.Children.Add(notification);
            notification.Completed += OnNotificationCompleted;
        }

        public void RemoveNotification(Notification notification)
        {
            NotificationList.Children.Remove(notification);
            notification.RaiseCompleted(new DisposeNotificationEventArgs(notification));
        }

        private void OnNotificationCompleted(object sender, EventArgs e)
        {
            var args = (DisposeNotificationEventArgs)e;
            NotificationList.Children.Remove(args.Notification);

            if (NotificationList.Children.Count == 0)
            {
                NotificationList.Visibility = Visibility.Hidden;
            }
        }
    }
}
