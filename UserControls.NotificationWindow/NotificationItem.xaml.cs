using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaktionslogik für PopupNotification.xaml
    /// </summary>
    public partial class NotificationItem : UserControl
    {
        public NotificationItem(string header, string message, NotificationItem followingNotification = null)
        {
            InitializeComponent();

            Header = header;
            Message = message;
        }

        private void DoubleAnimation_Completed(object sender, EventArgs e)
        {
            RaiseCompleted(new DisposeNotificationEventArgs(this));
        }

        internal event EventHandler Completed;
        internal virtual void RaiseCompleted(DisposeNotificationEventArgs e)
        {
            EventHandler handler = Completed;
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
    }
}