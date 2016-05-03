using System;
using System.Windows;

namespace UserControls.NotificationPanel
{
    public class BaseContainer : Window
    {
        #region Dependency Properties

        /// <summary>
        /// Sets the max notification width.
        /// </summary>
        public double MaxNotificationWidth
        {
            get { return (double)GetValue(MaxNotificationWidthProperty); }
            set { SetValue(MaxNotificationWidthProperty, value); }
        }

        public static readonly DependencyProperty MaxNotificationWidthProperty =
            DependencyProperty.Register("MaxNotificationWidth", typeof(double), typeof(BaseContainer),
                new FrameworkPropertyMetadata(Double.NaN,
                    new PropertyChangedCallback(OnMaxNotificationWidthChanged)));

        private static void OnMaxNotificationWidthChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var width = Convert.ToDouble(e.NewValue);
            var container = sender as Container;

            if (container == null)
                return;

            container.NotificationList.MaxWidth = width;
        }

        /// <summary>
        /// Sets the min notification width.
        /// </summary>
        public double MinNotificationWidth
        {
            get { return (double)GetValue(MinNotificationWidthProperty); }
            set { SetValue(MinNotificationWidthProperty, value); }
        }

        public static readonly DependencyProperty MinNotificationWidthProperty =
            DependencyProperty.Register("MinNotificationWidth", typeof(double), typeof(BaseContainer),
                new FrameworkPropertyMetadata(Double.NaN,
                    new PropertyChangedCallback(OnMinNotificationWidthChanged)));

        private static void OnMinNotificationWidthChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var width = Convert.ToDouble(e.NewValue);
            var container = sender as Container;

            if (container == null)
                return;

            container.NotificationList.MinWidth = width;
        }

        #endregion
    }
}
