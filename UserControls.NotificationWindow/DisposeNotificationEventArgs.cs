using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControls.NotificationWindow
{
    internal class DisposeNotificationEventArgs : EventArgs
    {
        public DisposeNotificationEventArgs(NotificationItem item)
        {
            _parent = item;
        }

        private NotificationItem _parent;
        public NotificationItem Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

    }
}
