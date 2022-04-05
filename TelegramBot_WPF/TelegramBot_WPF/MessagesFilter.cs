using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot_WPF
{
    static class MessagesFilter
    {
        public static void OnMessageHandler(TelegramBotClient bot, object sender, MessageEventArgs e)
        {
            var message = e.Message;
            if (message.Text == string.Empty)
            {
                return;
            }
            switch (message.Type)
            {
                case Telegram.Bot.Types.Enums.MessageType.Document:
                    FileManager.DownloadDocument(bot, message.Document.FileId, message.Document.FileName);
                    bot.SendTextMessageAsync(message.Chat.Id, "Сейчас посмотрим, что ты скинул!");
                    Thread.Sleep(5000);
                    bot.SendTextMessageAsync(message.Chat.Id, "Интересное чтиво!");
                    break;
                case Telegram.Bot.Types.Enums.MessageType.Text:
                    Console.WriteLine(message.Text);
                    if (message.Text.Contains("Привет"))
                    {
                        bot.SendTextMessageAsync(message.Chat.Id, "Приветствую!");
                    }
                    else if (message.Text.Contains("Покажи файлы"))
                    {
                        FileManager.GetDownloadedFiles(bot, "Downloads", message.Chat.Id);

                    }
                    if (Stickers.stikersDictionary.ContainsKey(message.Text))
                    {
                        var stik = bot.SendStickerAsync(message.Chat.Id, sticker: Stickers.stikersDictionary[message.Text]);
                    }
                    else
                        bot.SendTextMessageAsync(message.Chat.Id, "Что нужно сделать?", replyMarkup: GetButtons());
                    break;
                case Telegram.Bot.Types.Enums.MessageType.Photo:
                    bot.SendTextMessageAsync(message.Chat.Id, "Крутая картинка!");
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
