using AutoTabadol.Process.BotRunning.MessageRunning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace AutoTabadol.Process.Admin.TextGetting
{
    public class AdminStart : IRunBot
    {
        public bool prosecc(MessageEventArgs up, TelegramBotClient bot)
        {
            if (up.Message.Text == "/start")
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Welcom Admin");
                sb.AppendLine("You Can Use These Two Commands");
                sb.AppendLine("");
                sb.AppendLine("/Statistics and /SendMessage");
                bot.SendTextMessageAsync(up.Message.Chat.Id, sb.ToString());
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
