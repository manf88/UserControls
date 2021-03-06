﻿using System.Windows;
using System.Windows.Media;

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
        /// Sets/Gets the color of information notifications.
        /// </summary>
        Brush InformationColor { get; set; }

        /// <summary>
        /// Sets/Gets the color of warning notifications.
        /// </summary>
        Brush WarningColor { get; set; }

        /// <summary>
        /// Sets/Gets the color of error notifications.
        /// </summary>
        Brush ErrorColor { get; set; }

        /// <summary>
        /// The Parent of the current Panel.
        /// </summary>
        Window Parent { get; set; }

        /// <summary>
        /// Sets the Startup location of the notification container.
        /// </summary>
        StartupLocation StartupLocation { get; set; }

        /// <summary>
        /// Gets the current notification mode of the panel.
        /// </summary>
        NotificationMode NotificationMode { get; }

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
    }
}
