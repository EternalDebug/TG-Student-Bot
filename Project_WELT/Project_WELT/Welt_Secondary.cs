using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Project_WELT.Welt_Main;
using Telegram.Bot;

namespace Project_WELT
{
    class Welt_Secondary
    {
        static readonly TelegramBotClient Welt = new TelegramBotClient("1490665480:AAEF9wmeDVeFx1hvs3kiOZ_4mxn82bePmQo");
        public static void SendRandMilJoke(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            string path = "MilJoke.txt";
            string[] joke = File.ReadAllLines(path).ToArray();
            Random rnd = new Random();

            Welt.SendTextMessageAsync(e.Message.Chat.Id, joke[rnd.Next(0,joke.Length)]);
           
            
        }
    }
}
