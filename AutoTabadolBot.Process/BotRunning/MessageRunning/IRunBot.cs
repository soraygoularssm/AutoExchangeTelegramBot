using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace AutoTabadol.Process.BotRunning.MessageRunning
{
    public interface IRunBot
    {
        bool prosecc(MessageEventArgs up, TelegramBotClient bot);
    }
}
