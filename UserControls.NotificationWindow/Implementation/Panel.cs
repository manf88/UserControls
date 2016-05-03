﻿namespace UserControls.NotificationPanel
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
