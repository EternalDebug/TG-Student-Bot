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
            Random rnd = new Random();
            Console.WriteLine(rnd);
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
                
                if (m.ToLower().Contains("привет") || m.ToLower().Contains("здорова") || m.ToLower().Contains("ку") || m.ToLower().Contains("здравствуй"))
                {
                    SendGreeting(sender, e);
                }
                if (m.ToLower().Contains("учиться"))
                {
                    Welt.SendTextMessageAsync(e.Message.Chat.Id, "Я раздолбай и умею только отдыхать. Шутка. Это просто ещё разрабатывается");
                }
                if (m.ToLower().Contains("отдохнуть"))
                {
                    Welt.SendTextMessageAsync(e.Message.Chat.Id, "Хорошо. Могу посоветовать хорошую музыку, рассказать анекдот...");
                    Welt.OnMessage += Welt_OnMessageSecondary;
                    //Welt_OnMessageSecondary(sender,e);
                    //Welt.StartReceiving();
                    //Console.ReadLine();
                    //Welt.StopReceiving();
                }
            }
        }

        static void SendGreeting(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            Welt.SendTextMessageAsync(e.Message.Chat.Id, "Привет-привет, студент)");
            Welt.SendTextMessageAsync(e.Message.Chat.Id, "Ну что, есть настроение поучиться или всё же отдохнуть? Я скоро смогу составить тебе персональное расписание к сессии, помочь советом, рассказать о сессии чуть больше. Сейчас я могу рассказать анекдот или посоветовать музыку...");
            System.Threading.Thread.Sleep(60);
            Welt.SendTextMessageAsync(e.Message.Chat.Id, "Если хочешь, то я могу чуть больше рассказать о себе");
        }

        static void Welt_OnMessageSecondary(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            Welt.OnMessage -= Welt_OnMessage;
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                string m = e.Message.Text;
                Console.WriteLine(m);
                if (m.ToLower().Contains("шути") || m.ToLower().Contains("анекдот"))
                {
                    SendRandMilJoke(sender, e);
                }
                if (m.ToLower().Contains("музык"))
                {
                    SendRandMusic(sender, e);
                }
                if (m.ToLower().Contains("завязывай") || m.ToLower().Contains("я передумал"))
                {
                    Welt.OnMessage -= Welt_OnMessageSecondary;
                    Welt.OnMessage += Welt_OnMessage;
                    return;
                }
                if (m.ToLower().Contains("жанр"))
                {
                    Welt.SendTextMessageAsync(e.Message.Chat.Id, "Хорошо, какой жанр? Я пока знаю Альтернативу, рок, поп и классическую");
                    Welt.OnMessage += Welt_OM_Janr;
                }
            }
        }

        static void Welt_OM_Janr(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            Welt.OnMessage -= Welt_OnMessageSecondary;

            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                string m = e.Message.Text;

                if (m.ToLower().Contains("альтерн"))
                {
                    SendThisMusic(sender, e,"альтернатива");
                }
                else
                if (m.ToLower().Contains("поп"))
                {
                    SendThisMusic(sender, e, "поп");
                }
                else
                if (m.ToLower().Contains("рок"))
                {
                    SendThisMusic(sender, e, "рок");
                }
                else
                if (m.ToLower().Contains("класси"))
                {
                    SendThisMusic(sender, e, "классическая");
                }
                else
                    Welt.SendTextMessageAsync(e.Message.Chat.Id, "Увы я не знаю такого жанра");
            }

            Welt.OnMessage -= Welt_OM_Janr;
            Welt.OnMessage += Welt_OnMessageSecondary;
        }




    }
}
