using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using Telegram.Bot;

namespace TelegramBot_WPF
{
    public class MessageClient
    {
        private MainWindow w;

        private TelegramBotClient bot;
        public ObservableCollection<MessageLog> BotMessageLog { get; set; }

        List<MessageLog> messages = new List<MessageLog>();

        public List<MessageLog> Messages { get { return messages; } }

        private void MessageListener(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            Debug.WriteLine("+++---");

            string text = $"{DateTime.Now.ToLongTimeString()}: {e.Message.Chat.FirstName} {e.Message.Chat.Id} {e.Message.Text}";

            Debug.WriteLine($"{text} TypeMessage: {e.Message.Type.ToString()}");

            MessagesFilter.OnMessageHandler(bot, sender, e);

            if (e.Message.Text == null) return;

            var messageText = e.Message.Text;

            w.Dispatcher.Invoke(() =>
            {

                MessageLog mLog = new MessageLog(DateTime.Now.ToLongTimeString(), 
                    messageText, e.Message.Chat.FirstName, e.Message.Chat.Id);

                BotMessageLog.Add(mLog);
                messages.Add(mLog);
            });
        }

        public MessageClient(MainWindow W, string PathToken = @"C:/Users/VR/Desktop/Token.txt")
        {
            this.BotMessageLog = new ObservableCollection<MessageLog>();
            this.w = W;

            bot = new TelegramBotClient(File.ReadAllText(PathToken));

            bot.OnMessage += MessageListener;

            bot.StartReceiving();
        }

        public void SendMessage(string Text, string Id)
        {
            long id = Convert.ToInt64(Id);
            bot.SendTextMessageAsync(id, Text);
        }
    }
}
