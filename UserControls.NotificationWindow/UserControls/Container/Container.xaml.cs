using System;
using System.Windows;

namespace UserControls.NotificationPanel
{
    /// <summary>
    /// The host window for notification items.
    /// </summary>
    public partial class Container : BaseContainer
    {
        public Container()
        {
            InitializeComponent();

            MaxNotifications = 3;
        }

        public int MaxNotifications { get; set; }

        /// <summary>
        /// Adds a notification to the container.
        /// </summary>
        /// <param name="notificationType">The notification type</param>
        /// <param name="header">The header text of the notification</param>
        /// <param name="message">The message text of the notification</param>
        public void AddNotification(NotificationType notificationType, string header, string message)
        {
            var notification = new Notification(header, message);

            NotificationList.Visibility = Visibility.Visible;

            if (NotificationList.Children.Count == MaxNotifications)
            {
                RemoveNotification((Notification)NotificationList.Children[0]);
            }

            switch (notificationType)
            {
                case NotificationType.Info:
                    notification.Color = _informationColor;
                    break;
                case NotificationType.Warning:
                    notification.Color = _warningColor;
                    break;
                case NotificationType.Error:
                    notification.Color = _errorColor;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("notificationType");
            }

            NotificationList.Children.Add(notification);
            notification.Completed += OnNotificationCompleted;
        }

        public void RemoveNotification(Notification notification)
        {
            NotificationList.Children.Remove(notification);
            notification.RaiseCompleted(new DisposeNotificationEventArgs(notification));
        }

        internal void SetStartupLocation(double left, double top)
        {
            WindowStartupLocation = WindowStartupLocation.Manual;
            Left = left;
            Top = top;
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
