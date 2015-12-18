using System;
using System.Windows;
using System.Windows.Controls;

namespace UserControls.NotificationWindow
{
    /// <summary>
    /// Interaktionslogik für PopupNotification.xaml
    /// </summary>
    public partial class NotificationItem : UserControl
    {
        private NotificationContainer _container;

        public NotificationItem(string header, string message, NotificationContainer container)
        {
            InitializeComponent();

            Header = header;
            Message = message;

            _container = container;
        }

        private void DoubleAnimation_Completed(object sender, EventArgs e)
        {
            RaiseCompleted(new DisposeNotificationEventArgs(this));
        }

        internal event EventHandler Completed;
        internal virtual void RaiseCompleted(DisposeNotificationEventArgs e)
        {
            var handler = Completed;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(NotificationItem), new FrameworkPropertyMetadata(
                "...",
                FrameworkPropertyMetadataOptions.None,
                OnHeaderChanged));

        private static void OnHeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var content = e.NewValue as string;
            var notificationWindow = d as NotificationItem;

            if (notificationWindow == null)
                return;

            //not working currently
            notificationWindow.HeaderRow.Height = string.IsNullOrEmpty(content) ? new GridLength(0, GridUnitType.Star) : new GridLength(1, GridUnitType.Star);

        }

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(NotificationItem), new PropertyMetadata(""));

        private void Close(object sender, EventArgs e)
        {
            _container.RemoveNotification(this);
        }
    }
}