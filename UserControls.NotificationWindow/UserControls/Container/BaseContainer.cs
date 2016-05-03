using System;
using System.Windows;
using System.Windows.Media;

namespace UserControls.NotificationPanel
{
    public class BaseContainer : Window
    {
        protected Brush _informationColor = Brushes.LightGreen;
        protected Brush _warningColor = Brushes.Orange;
        protected Brush _errorColor = Brushes.IndianRed;

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

        /// <summary>
        /// Sets the color of information notifications.
        /// </summary>
        public Brush InformationColor
        {
            get { return (Brush)GetValue(InformationColorProperty); }
            set { SetValue(InformationColorProperty, value); }
        }

        public static readonly DependencyProperty InformationColorProperty =
            DependencyProperty.Register("InformationColor", typeof(Brush), typeof(BaseContainer),
                new FrameworkPropertyMetadata(Brushes.LightGreen,
                    new PropertyChangedCallback(InformationColorPropertyChanged)));

        private static void InformationColorPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var container = sender as Container;
            if (container == null)
                return;

            var color = e.NewValue as Brush;
            if (color == null)
                return;

            container._informationColor = color;
        }

        /// <summary>
        /// Sets the color of warning notifications.
        /// </summary>
        public Brush WarningColor
        {
            get { return (Brush)GetValue(WarningColorProperty); }
            set { SetValue(WarningColorProperty, value); }
        }

        public static readonly DependencyProperty WarningColorProperty =
            DependencyProperty.Register("WarningColor", typeof(Brush), typeof(BaseContainer),
                new FrameworkPropertyMetadata(Brushes.Orange,
                    new PropertyChangedCallback(WarningColorPropertyChanged)));

        private static void WarningColorPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var container = sender as Container;
            if (container == null)
                return;

            var color = e.NewValue as Brush;
            if (color == null)
                return;

            container._warningColor = color;
        }

        /// <summary>
        /// Sets the color of error notifications.
        /// </summary>
        public Brush ErrorColor
        {
            get { return (Brush)GetValue(ErrorColorProperty); }
            set { SetValue(ErrorColorProperty, value); }
        }

        public static readonly DependencyProperty ErrorColorProperty =
            DependencyProperty.Register("ErrorColor", typeof(Brush), typeof(BaseContainer),
                new FrameworkPropertyMetadata(Brushes.IndianRed,
                    new PropertyChangedCallback(ErrorColorPropertyChanged)));

        private static void ErrorColorPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var container = sender as Container;
            if (container == null)
                return;

            var color = e.NewValue as Brush;
            if (color == null)
                return;

            container._errorColor = color;
        }

        #endregion
    }
}
