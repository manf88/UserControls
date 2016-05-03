using System;
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
        }

        public void SetStartupLocation(double left, double right)
        {
            _container.SetStartupLocation(left, right);
        }

    }
}
