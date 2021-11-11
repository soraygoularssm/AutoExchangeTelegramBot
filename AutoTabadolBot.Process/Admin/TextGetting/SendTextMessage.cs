using AutoTabadol.Process.Admin.InlineKeyboard;
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
    public class SendTextMessage : IRunBot
    {
        public bool prosecc(MessageEventArgs up, TelegramBotClient bot)
        {
            if (up.Message.Text == "/SendMessage")
            {
                bot.SendTextMessageAsync(up.Message.Chat.Id, "what kind of audiense do you want to send message to?",Telegram.Bot.Types.Enums.ParseMode.Default,false,false,0, AdminInlineKeyboad.Admin_SendMessage);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
