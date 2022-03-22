using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Telegram.Bot;

namespace Telegram_Bot
{
    static class Bot
    {
       
        public static TelegramBotClient GetBot()
        {
            string path = @"C:/Users/VR/Desktop/Token.txt";
            string token = File.ReadAllText(path);
            TelegramBotClient bot = new TelegramBotClient(token);
            
            return bot;
        }
    }
}
