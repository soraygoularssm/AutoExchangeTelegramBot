using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace AutoTabadol.Process.BotRunning.CallBackRunning
{
    public class RunBot
    {
        List<IRunBot> BotList = new List<IRunBot>();
        public RunBot(List<IRunBot> botlist)
        {
            BotList = botlist;
        }

        public void Answer(CallbackQueryEventArgs up, TelegramBotClient bot)
        {
            foreach (IRunBot item in BotList)
            {
                if (item.prosecc(up, bot) == true)
                    break;
            }
        }
    }
}
