using System;

namespace UserControls.NotificationPanel
{
    public class Panel : IPanel
    {
        private Container _container;

        private int _maxNotifications;
        public int MaxNotifications
        {
            get
            {
                return _maxNotifications;
            }

            set
            {
                _maxNotifications = value;
            }
        }

        public void Activate()
        {
            _container = new Container();
            _container.Show();
        }

        public void AddNotification(string header, string message)
        {
            _container.AddNotification(header, message);
        }

        public void Deactivate()
        {
            _container.Close();
        }
    }
}
