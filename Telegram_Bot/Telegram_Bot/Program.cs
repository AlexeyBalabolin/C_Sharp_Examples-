using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram_Bot
{
    class Program
    {
        static TelegramBotClient bot;
        static void Main(string[] args)
        {
            string path = @"C:/Users/VR/Desktop/Token.txt";
            string token = File.ReadAllText(path);
            bot = Bot.GetBot();
            bot.StartReceiving();
            bot.OnMessage += SenderMessages.OnMessageHandler;
            Console.ReadLine();
            bot.StartReceiving();
        }
    }
}
