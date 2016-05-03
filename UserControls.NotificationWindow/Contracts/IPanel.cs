namespace UserControls.NotificationPanel
{
    public interface IPanel
    {
        int MaxNotifications { get; set; }

        void AddNotification(NotificationType notificationType, string header, string message);

        void Activate();

        void Deactivate();

        void SetStartupLocation(double left, double right);
    }
}
