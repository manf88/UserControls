namespace UserControls.NotificationPanel
{
    public interface IPanel
    {
        /// <summary>
        /// Sets/Gets the number of notifications that can simultaneously be displayed.
        /// </summary>
        int MaxNotifications { get; set; }

        /// <summary>
        /// Sets/Gets the maximum width of the notifications.
        /// </summary>
        double MaxWidth{ get; set; }

        /// <summary>
        /// Sets/Gets the minimum width of the notifications.
        /// </summary>
        double MinWidth { get; set; }

        /// <summary>
        /// Displays a notification in the panel.
        /// </summary>
        /// <param name="notificationType">Type of the notification</param>
        /// <param name="header">Header message.</param>
        /// <param name="message">Further information.</param>
        void AddNotification(NotificationType notificationType, string header, string message);

        /// <summary>
        /// Activates the panel.
        /// </summary>
        void Activate();

        /// <summary>
        /// Deaktivates the panel.
        /// </summary>
        void Deactivate();

        //TODO: maybe set the position relative to the parent control.
        void SetStartupLocation(double left, double right);
    }
}
