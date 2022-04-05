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

namespace TelegramBot_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MessageClient client;
        public MainWindow()
        {
            InitializeComponent();

            client = new MessageClient(this);
            logList.ItemsSource = client.BotMessageLog;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            client.SendMessage(msgSend.Text, TargetSend.Text);
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            Serializer.Serialize(client.Messages);
        }
    }
}
