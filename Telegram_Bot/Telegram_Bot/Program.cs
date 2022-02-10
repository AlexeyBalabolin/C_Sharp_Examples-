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
        static string[] stikers = new string[3] { "Дыра", "Отэц", "Роскошно" };

        static void Main(string[] args)
        {
            string path = @"C:/Users/VR/Desktop/Token.txt";
            string token = File.ReadAllText(path);
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
                    if(message.Text== stikers[0])
                    {
                        var stik = bot.SendStickerAsync(message.Chat.Id, sticker:
                            "https://cdn.tlgrm.app/stickers/ec5/c1b/ec5c1b75-12ea-45bd-aa7b-33491089b8e5/96/1.webp");
                    }
                    else if (message.Text == stikers[1])
                    {
                        var stik = bot.SendStickerAsync(message.Chat.Id, sticker:
                            "https://cdn.tlgrm.app/stickers/ec5/c1b/ec5c1b75-12ea-45bd-aa7b-33491089b8e5/96/6.webp");
                    }
                    else if (message.Text == stikers[2])
                    {
                        var stik = bot.SendStickerAsync(message.Chat.Id, sticker:
                            "https://cdn.tlgrm.app/stickers/ec5/c1b/ec5c1b75-12ea-45bd-aa7b-33491089b8e5/96/7.webp");
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
                    new List<KeyboardButton>{ new KeyboardButton {Text = stikers[0]},
                    new KeyboardButton {Text = stikers[1]},
                    new KeyboardButton {Text = stikers[2]}}
                }
            };
        }

        private static async void DownloadDocument(string fileId, string fileName)
        {
            var file = await bot.GetFileAsync(fileId);
            FileStream fStream = new FileStream(fileName, FileMode.Create);
            await bot.DownloadFileAsync(file.FilePath, fStream);
            fStream.Close();
            fStream.Dispose();
        }

    }
}
