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
        static Dictionary<string, string> stikersDictionary = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            string path = @"C:/Users/VR/Desktop/Token.txt";
            string token = File.ReadAllText(path);
            stikersDictionary.Add("Дыра", "https://cdn.tlgrm.app/stickers/ec5/c1b/ec5c1b75-12ea-45bd-aa7b-33491089b8e5/96/1.webp");
            stikersDictionary.Add("Отэц", "https://cdn.tlgrm.app/stickers/ec5/c1b/ec5c1b75-12ea-45bd-aa7b-33491089b8e5/96/6.webp");
            stikersDictionary.Add("Роскошно", "https://cdn.tlgrm.app/stickers/ec5/c1b/ec5c1b75-12ea-45bd-aa7b-33491089b8e5/96/7.webp");
            bot = new TelegramBotClient(token);
            bot.StartReceiving();
            bot.OnMessage += OnMessageHandler;
            Console.ReadLine();
            bot.StartReceiving();
        }

        private static void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            if(message.Text==string.Empty)
            {
                return;
            }
            switch(message.Type)
            {
                case Telegram.Bot.Types.Enums.MessageType.Document:
                    DownloadDocument(message.Document.FileId, message.Document.FileName);
                    bot.SendTextMessageAsync(message.Chat.Id, "Сейчас посмотрим, что ты скинул!");
                    Thread.Sleep(5000);
                    bot.SendTextMessageAsync(message.Chat.Id, "Интересное чтиво!");
                    break;
                case Telegram.Bot.Types.Enums.MessageType.Text:
                    Console.WriteLine(message.Text);
                    if(message.Text.Contains("Привет"))
                    {
                        bot.SendTextMessageAsync(message.Chat.Id, "Приветствую!");
                    }
                    else if(message.Text.Contains("Покажи файлы"))
                    {
                        GetDownloadedFiles("Downloads", message.Chat.Id);
                        
                    }
                    if(stikersDictionary.ContainsKey(message.Text))
                    {
                        var stik = bot.SendStickerAsync(message.Chat.Id, sticker: stikersDictionary[message.Text]);
                    }
                    else
                        bot.SendTextMessageAsync(message.Chat.Id, "Что нужно сделать?", replyMarkup: GetButtons());
                    break;
                case Telegram.Bot.Types.Enums.MessageType.Photo:
                    bot.SendTextMessageAsync(message.Chat.Id,"Крутая картинка!");
                    break;
            }
        }

        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton {Text = "Дыра"},
                    new KeyboardButton {Text = "Отэц"},
                    new KeyboardButton {Text = "Роскошно"}}
                }
            };
        }

        private static async void DownloadDocument(string fileId, string fileName)
        {
            var file = await bot.GetFileAsync(fileId);
            fileName = $"Downloads/{fileName}";
            FileStream fStream = new FileStream(fileName, FileMode.Create);
            await bot.DownloadFileAsync(file.FilePath, fStream);
            fStream.Close();
            fStream.Dispose();
        }

        public static void GetDownloadedFiles(string path, long chatID)
        {
            string[] fileEntries = Directory.GetFiles(path);
            foreach (string fileName in fileEntries)
                bot.SendTextMessageAsync(chatID, fileName);

        }
        public static void SendDocumentToUser(long chatID, string filePath, string fileName)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                bot.SendDocumentAsync(chatId: chatID,
                    document: new Telegram.Bot.Types.InputFiles.InputOnlineFile(fileStream, fileName),
                    caption: "Test");                  
            }
            
        }
    }
}
