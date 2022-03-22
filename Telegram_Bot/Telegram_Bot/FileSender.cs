using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Telegram.Bot;

namespace Telegram_Bot
{
    static class FileSender
    {
        public static void GetDownloadedFiles(TelegramBotClient bot, string path, long chatID)
        {
            string[] fileEntries = Directory.GetFiles(path);
            foreach (string fileName in fileEntries)
            {
                Console.WriteLine(fileName);
                SendDocumentToUser(bot, chatID, fileName);
            }
        }
        public static void SendDocumentToUser(TelegramBotClient bot , long chatID, string filePath)
        {
            var f = File.Open(filePath, FileMode.Open);
            bot.SendDocumentAsync(chatID,f);

        }
    }
}
