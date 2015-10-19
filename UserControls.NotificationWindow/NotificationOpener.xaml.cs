using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserControls.NotificationWindow
{
    /// <summary>
    /// Interaction logic for NotificationOpener.xaml
    /// </summary>
    public partial class NotificationOpener : Button
    {
        private NotificationBox _box;

        public NotificationOpener()
        {
            InitializeComponent();

            _box = new NotificationBox();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _box.AddNotification(new NotificationItem("test", "test"));
            _box.Show();
        }
    }
}
