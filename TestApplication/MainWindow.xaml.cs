using System.Windows;
using UserControls.NotificationPanel;

namespace TestApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IPanel _panel;
        private int _counter;

        public MainWindow()
        {
            InitializeComponent();

            _panel = new Panel();
            _panel.Activate();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _panel.AddNotification("Erfolg", _counter++.ToString());
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _panel.Deactivate();
        }        
    }
}
