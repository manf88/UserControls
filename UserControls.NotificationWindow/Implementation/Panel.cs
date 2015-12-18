using System;

namespace UserControls.NotificationPanel
{
    public class Panel : IPanel
    {
        private Container _container;

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
