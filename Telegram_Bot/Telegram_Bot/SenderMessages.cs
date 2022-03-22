using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram_Bot
{
    static class SenderMessages
    {
        public static void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            if (message.Text == string.Empty)
            {
                return;
            }
            switch (message.Type)
            {
                case Telegram.Bot.Types.Enums.MessageType.Document:
                    Downloader.DownloadDocument(Bot.GetBot(), message.Document.FileId, message.Document.FileName);
                    Bot.GetBot().SendTextMessageAsync(message.Chat.Id, "Сейчас посмотрим, что ты скинул!");
                    Thread.Sleep(5000);
                    Bot.GetBot().SendTextMessageAsync(message.Chat.Id, "Интересное чтиво!");
                    break;
                case Telegram.Bot.Types.Enums.MessageType.Text:
                    Console.WriteLine(message.Text);
                    if (message.Text.Contains("Привет"))
                    {
                        Bot.GetBot().SendTextMessageAsync(message.Chat.Id, "Приветствую!");
                    }
                    else if (message.Text.Contains("Покажи файлы"))
                    {
                        FileSender.GetDownloadedFiles(Bot.GetBot(),"Downloads", message.Chat.Id);

                    }
                    if (Stickers.stikersDictionary.ContainsKey(message.Text))
                    {
                        var stik = Bot.GetBot().SendStickerAsync(message.Chat.Id, sticker: Stickers.stikersDictionary[message.Text]);
                    }
                    else
                        Bot.GetBot().SendTextMessageAsync(message.Chat.Id, "Что нужно сделать?", replyMarkup: GetButtons());
                    break;
                case Telegram.Bot.Types.Enums.MessageType.Photo:
                    Bot.GetBot().SendTextMessageAsync(message.Chat.Id, "Крутая картинка!");
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
    }
}
