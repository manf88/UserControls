using System;

namespace UserControls.NotificationPanel
{
    internal class DisposeNotificationEventArgs : EventArgs
    {
        public DisposeNotificationEventArgs(Notification item)
        {
            _notification = item;
        }

        private Notification _notification;
        public Notification Notification
        {
            get { return _notification; }
            set { _notification = value; }
        }

    }
}
