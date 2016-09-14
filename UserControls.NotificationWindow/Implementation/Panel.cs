using System;
using System.Windows;
using System.Windows.Media;

namespace UserControls.NotificationPanel
{
    public class Panel : IPanel
    {
        private Container _container;

        /// <summary>
        /// Offset in pixels that is used for the positioning of the notification panel
        /// to not hide the window controls (min, max, close).
        /// </summary>
        private const int _startupLocationOffset = 25;

        /// <see cref="IPanel.MaxNotifications"/>
        public int MaxNotifications { get; set; }

        /// <see cref="IPanel.MaxWidth"/> 
        public double MaxWidth { get; set; }

        /// <see cref="IPanel.MinWidth"/> 
        public double MinWidth { get; set; }

        /// <see cref="IPanel.InformationColor"/> 
        public Brush InformationColor { get; set; }

        /// <see cref="IPanel.WarningColor"/> 
        public Brush WarningColor { get; set; }

        /// <see cref="IPanel.ErrorColor"/> 
        public Brush ErrorColor { get; set; }

        /// <see cref="IPanel.StartupLocation"/> 
        public StartupLocation StartupLocation { get; set; }

        /// <see cref="IPanel.NotificationMode"/> 
        public NotificationMode NotificationMode { get; private set; }

        private Window _parent;
        /// <see cref="IPanel.Parent"/> 
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

                _parent.StateChanged -= OnStateChanged;
                _parent.StateChanged += OnStateChanged;
            }
        }

        private void OnStateChanged(object sender, EventArgs e)
        {
            var window = sender as Window;
            if (window == null)
                return;

            switch (window.WindowState)
            {
                case WindowState.Maximized:
                case WindowState.Minimized:
                    NotificationMode = NotificationMode.OnScreen;
                    break;
                case WindowState.Normal:
                    NotificationMode = NotificationMode.AttachedToWindow;
                    break;
            }

            SetPosition(sender, e);
        }

        /// <see cref="IPanel.Activate"/>
        public void Activate()
        {
            _container = new Container();
            _container.Show();
        }

        /// <see cref="IPanel.Deactivate"/>
        public void Deactivate()
        {
            _container.Close();
        }

        /// <see cref="IPanel.AddNotification(NotificationType, string, string)"/>
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

            switch (StartupLocation)
            {
                case StartupLocation.TopLeft:
                    SetTopLeftPosition(window);
                    break;

                case StartupLocation.TopRight:
                    SetTopRightPosition(window);
                    break;

                case StartupLocation.BottomLeft:
                    SetBottomLeftPosition(window);
                    break;

                case StartupLocation.BottomRight:
                    SetBottomRightPosition(window);
                    break;
            }
        }

        private void SetTopRightPosition(Window window)
        {
            if (NotificationMode == NotificationMode.AttachedToWindow)
            {
                //window.left + width to get the endposition of the window than the container width + offset is supstracted
                //to show the notifications inside the window. Window.Top + offset to not hide the close button of the window. 
                _container.SetStartupLocation(window.Left + window.ActualWidth - _container.Width - 10, window.Top + _startupLocationOffset);
            }
            else
            {
                //get the screen area of the main display
                var workingArea = SystemParameters.WorkArea;
                _container.SetStartupLocation(workingArea.Right - _container.Width, workingArea.Top + _startupLocationOffset);
            }
        }

        private void SetTopLeftPosition(Window window)
        {
            if(NotificationMode == NotificationMode.AttachedToWindow)
            {
                _container.SetStartupLocation(window.Left, window.Top + _startupLocationOffset);
            }
            else
            {
                var workingArea = SystemParameters.WorkArea;
                _container.SetStartupLocation(workingArea.Left, workingArea.Top + _startupLocationOffset);
            }
        }

        private void SetBottomLeftPosition(Window window)
        {
            if (NotificationMode == NotificationMode.AttachedToWindow)
            {
                _container.SetStartupLocation(window.Left, window.Top + window.ActualHeight - _container.Height);
            }
            else
            {
                var workingArea = SystemParameters.WorkArea;
                _container.SetStartupLocation(workingArea.Left, workingArea.Bottom - _container.Height);
            }
        }

        private void SetBottomRightPosition(Window window)
        {
            if (NotificationMode == NotificationMode.AttachedToWindow)
            {
                _container.SetStartupLocation(window.Left + window.ActualWidth - _container.Width - 10, window.Top + window.ActualHeight - _container.Height);
            }
            else
            {
                var workingArea = SystemParameters.WorkArea;
                _container.SetStartupLocation(workingArea.Right - _container.Width, workingArea.Bottom - _container.Height);
            }
        }
    }
}
