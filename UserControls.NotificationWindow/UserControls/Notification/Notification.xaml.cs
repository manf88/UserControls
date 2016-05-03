using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UserControls.NotificationPanel
{
    /// <summary>
    /// A Notification item that will be displayed in a notification container.
    /// </summary>
    public partial class Notification : UserControl
    { 
        public Notification(string header, string message)
        {
            InitializeComponent();

            Header = header;
            Message = message;
        }

        private void DoubleAnimation_Completed(object sender, EventArgs e)
        {
            RaiseCompleted(new DisposeNotificationEventArgs(this));
        }

        /// <summary>
        /// Event that will be raised when the notification item is dismissed or runs out.
        /// </summary>
        internal event EventHandler Completed;
        internal virtual void RaiseCompleted(DisposeNotificationEventArgs e)
        {
            var handler = Completed;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Message header of the notification item.
        /// </summary>
        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(Notification), new FrameworkPropertyMetadata(
                "...",
                FrameworkPropertyMetadataOptions.None,
                OnHeaderChanged));

        private static void OnHeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var content = e.NewValue as string;
            var notificationWindow = d as Notification;

            if (notificationWindow == null)
                return;

            //not working currently
            //todo remove the header grid row if the header is empty
            notificationWindow.HeaderRow.Height = string.IsNullOrEmpty(content) ? new GridLength(0, GridUnitType.Star) : new GridLength(1, GridUnitType.Star);

        }

        /// <summary>
        /// Message of the notification item.
        /// </summary>
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(Notification), new PropertyMetadata(""));

        /// <summary>
        /// Message of the notification item.
        /// </summary>
        public Brush Color
        {
            get { return (Brush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Brush), typeof(Notification), new PropertyMetadata(Brushes.Transparent));

        /// <summary>
        /// Removes the notification item from its parent.
        /// </summary>
        private void Close(object sender, EventArgs e)
        {
            //_container.RemoveNotification(this);
            RaiseCompleted(new DisposeNotificationEventArgs(this));
        }
    }
}