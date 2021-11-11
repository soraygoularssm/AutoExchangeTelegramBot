using AutoTabadol.Process.BotRunning.CallBackRunning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace AutoTabadol.Process.CallbackProcess.MainProcess
{
    public class TutorialVideo : IRunBot
    {
        public bool prosecc(CallbackQueryEventArgs up, TelegramBotClient bot)
        {
            if (up.CallbackQuery.Data == "VideoTutorial")
            {
                bot.ForwardMessageAsync(up.CallbackQuery.Message.Chat.Id, -1001367898784, 349);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
