using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace AutoTabadol.Process.BotRunning.CallBackRunning
{
    public interface IRunBot
    {
        bool prosecc(CallbackQueryEventArgs up, TelegramBotClient bot);
    }
}
