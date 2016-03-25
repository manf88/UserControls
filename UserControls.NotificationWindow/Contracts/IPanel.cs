namespace UserControls.NotificationPanel
{ 
    public interface IPanel
    {
        int MaxNotifications { get; set; }

        void AddNotification(string header, string message);

        void Activate();

        void Deactivate();
    }
}
