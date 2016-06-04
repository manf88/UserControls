using System;
using System.Windows;
using System.Windows.Media;

namespace UserControls.NotificationPanel
{
    public class Panel : IPanel
    {
        private Container _container;

        public int MaxNotifications
        {
            get
            {
                return _container.MaxNotifications;
            }

            set
            {
                _container.MaxNotifications = value;
            }
        }

        public double MaxWidth
        {
            get
            {
                return _container.MaxNotificationWidth;
            }

            set
            {
                _container.MaxNotificationWidth = value;
            }
        }

        public double MinWidth
        {
            get
            {
                return _container.MinWidth;
            }

            set
            {
                _container.MinWidth = value;
            }
        }

        public Brush InformationColor
        {
            get
            {
                return _container.InformationColor;
            }

            set
            {
                _container.InformationColor = value;
            }
        }

        public Brush WarningColor
        {
            get
            {
                return _container.WarningColor;
            }

            set
            {
                _container.WarningColor = value;
            }
        }

        public Brush ErrorColor
        {
            get
            {
                return _container.ErrorColor;
            }

            set
            {
                _container.ErrorColor = value;
            }
        }

        private Window _parent;
        public Window Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;

                _parent.LocationChanged -= SetPosition;
                _parent.LocationChanged += SetPosition;

                _parent.SizeChanged -= SetPosition;
                _parent.SizeChanged += SetPosition;

                _parent.StateChanged -= SetPosition;
                _parent.StateChanged += SetPosition;
            }
        }

        private StartupLocation _startupLocation;
        public StartupLocation StartupLocation
        {
            get
            {
                return _startupLocation;
            }

            set
            {
                _startupLocation = value;
            }
        }

        public void Activate()
        {
            _container = new Container();
            _container.Show();
        }

        public void Deactivate()
        {
            _container.Close();
        }

        public void AddNotification(NotificationType notificationType, string header, string message)
        {
            _container.AddNotification(notificationType, header, message);
            SetPosition(Parent, null);
        }

        private void SetPosition(object sender, EventArgs e)
        {
            var window = sender as Window;
            if (window == null)
                return;

            switch (_startupLocation)
            {
                case StartupLocation.TopLeft:
                    _container.SetStartupLocation(window.Left, window.Top);
                    break;

                case StartupLocation.TopRight:
                    _container.SetStartupLocation(window.Left + window.ActualWidth - _container.Width - 10, window.Top + 25);
                    break;
            }

        }
    }
}
