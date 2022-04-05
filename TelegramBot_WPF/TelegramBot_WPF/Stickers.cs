using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot_WPF
{
    static class Stickers
    {
        public static Dictionary<string, string> stikersDictionary = new Dictionary<string, string>();

        static Stickers()
        {
            stikersDictionary.Add("Дыра", "https://cdn.tlgrm.app/stickers/ec5/c1b/ec5c1b75-12ea-45bd-aa7b-33491089b8e5/96/1.webp");
            stikersDictionary.Add("Отэц", "https://cdn.tlgrm.app/stickers/ec5/c1b/ec5c1b75-12ea-45bd-aa7b-33491089b8e5/96/6.webp");
            stikersDictionary.Add("Роскошно", "https://cdn.tlgrm.app/stickers/ec5/c1b/ec5c1b75-12ea-45bd-aa7b-33491089b8e5/96/7.webp");
        }
    }
}
