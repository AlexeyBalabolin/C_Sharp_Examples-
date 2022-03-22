using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Telegram.Bot;

namespace Telegram_Bot
{
    static class Downloader
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
    }
}
