using System;
using Telegram.Bot;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Project_WELT.Welt_Secondary;


namespace Project_WELT
{

    class Welt_Main
    {
        static readonly TelegramBotClient Welt = new TelegramBotClient("1490665480:AAEF9wmeDVeFx1hvs3kiOZ_4mxn82bePmQo");

        static void Main(string[] args)
        {
            Welt.OnMessage += Welt_OnMessage;
            Welt.StartReceiving();
            Console.ReadLine();
            Welt.StopReceiving();
        }

        static void Welt_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Type ==Telegram.Bot.Types.Enums.MessageType.Text)
            {
                string m = e.Message.Text;
                Console.WriteLine(m);
                if (m == "Du")
                {
                    Welt.SendTextMessageAsync(e.Message.Chat.Id, "Du hast");
                }
                if (m == "Du hast mich")
                {
                    Welt.SendTextMessageAsync(e.Message.Chat.Id, "Du hast mich gefragt");
                }
                if (m == "Шути")
                {
                    SendRandMilJoke(sender, e);
                }
            }
        }
    }
}
