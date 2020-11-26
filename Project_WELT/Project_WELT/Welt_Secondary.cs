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

            Welt.SendTextMessageAsync(e.Message.Chat.Id, joke[rnd.Next(0,joke.Length-1)]);
           
            
        }

        /// <summary>
        /// Считает музыку из БД
        /// </summary>
        /// <param name="path"></param>
        /// <param name="janr"></param>
        /// <returns></returns>
        protected static string[] GetMusic(string path, string janr)
        {
            string[] mus = File.ReadAllLines(path).ToArray();
            if (janr.Length >0)
            {
                int counter = 0;
                string[] res = new string[mus.Length];

                int ind_ptr = 0;
                while (mus[ind_ptr].ToLower()!=janr)
                {
                    ind_ptr++;
                }

                for (int i = ind_ptr + 1; i < mus.Length; i++)
                {
                    if (mus[i][0] == '*')
                    {
                        break;
                    }

                    res[counter] = mus[i];
                    counter++;

                }
                Array.Resize(ref res, counter);
                return res;
            }
            else
            {
                int counter = 0;
                string[] res = new string[mus.Length];
                for (int i =0; i< mus.Length; i++)
                {
                    if (mus[i][0]!='*')
                    {
                        res[counter] = mus[i];
                        counter++;
                    }
                        
                }
                Array.Resize(ref res, counter);
                return res;
            }

        }

        /// <summary>
        /// Выведет рандомную музыку рандомного жанра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SendRandMusic(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            string path = "Music.txt";
            string[] mus = GetMusic(path, "");
            Random rnd = new Random();

            Welt.SendTextMessageAsync(e.Message.Chat.Id, mus[rnd.Next(0, mus.Length - 1)]);


        }

        /// <summary>
        /// Выведет рандомную музыку определённого жанра: Альтернатива, поп, рок, классическая
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="janr"></param>
        public static void SendThisMusic(object sender, Telegram.Bot.Args.MessageEventArgs e, string janr)
        {
            string path = "Music.txt";
            string j1 = "*";
            j1 += janr.ToLower();
            string[] mus = GetMusic(path, j1);
            Random rnd = new Random();

            Welt.SendTextMessageAsync(e.Message.Chat.Id, mus[rnd.Next(0, mus.Length - 1)]);
        }



    }
}
