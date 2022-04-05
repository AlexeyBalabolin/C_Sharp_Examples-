using System;
using System.Collections.Generic;
using System.IO;
using Telegram.Bot;

namespace TelegramBot_WPF
{
    static class FileManager
    {
        public static async void DownloadDocument(TelegramBotClient bot, string fileId, string fileName)
        {
            var file = await bot.GetFileAsync(fileId);
            fileName = $"Downloads/{fileName}";
            FileStream fStream = new FileStream(fileName, FileMode.Create);
            await bot.DownloadFileAsync(file.FilePath, fStream);
            fStream.Close();
            fStream.Dispose();
        }

        public static void GetDownloadedFiles(TelegramBotClient bot, string path, long chatID)
        {
            string[] fileEntries = Directory.GetFiles(path);
            foreach (string fileName in fileEntries)
            {
                Console.WriteLine(fileName);
                SendDocumentToUser(bot, chatID, fileName);
            }
        }

        public static void SendDocumentToUser(TelegramBotClient bot, long chatID, string filePath)
        {
            var f = File.Open(filePath, FileMode.Open);
            bot.SendDocumentAsync(chatID, f);

        }
    }
}
