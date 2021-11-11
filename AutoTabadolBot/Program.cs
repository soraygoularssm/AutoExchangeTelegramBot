using AutoTabadol.Calculation.ExchangingProcess;
using AutoTabadol.Calculation.FindingProcess;
using AutoTabadolBot.Reciving;
using System;
using System.Timers;
using Telegram.Bot;

namespace AutoTabadolBot
{
    class Program
    {
        static string Token = "";
        public static TelegramBotClient bot = new TelegramBotClient(Token);
        static void Main(string[] args)
        {
            bot.OnMessage += GetRecives.Bot_OnMessage;
            bot.OnCallbackQuery += GetRecives.Bot_OnCallbackQuery;
            bot.StartReceiving();

            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(myTimer_Elapsed);
            aTimer.Interval = 3600000;
            aTimer.Enabled = true;


            Console.Read();
        }

        private static void myTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now.Hour == 7)
            {
                Exchanging.exchanger(bot);
                FindChannelByCategory.ChannelFinderByCategory(bot);
            }
        }
    }
}
