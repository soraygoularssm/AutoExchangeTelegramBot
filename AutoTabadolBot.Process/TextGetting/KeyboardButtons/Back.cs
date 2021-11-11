using AutoTabadol.Process.BotRunning.MessageRunning;
using AutoTabadol.Process.Keyboards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace AutoTabadol.Process.TextGetting.KeyboardButtons
{
    public class Back : IRunBot
    {
        public bool prosecc(MessageEventArgs up, TelegramBotClient bot)
        {
            if (up.Message.Text == "بازگشت 🔙")
            {
                ButtonKeyboard.SettingsMarkUpBTN.ResizeKeyboard = true;
                bot.SendTextMessageAsync(up.Message.Chat.Id, "شما به صفحه اصلی بازگشتید" , Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, ButtonKeyboard.SettingsMarkUpBTN);

                return true;
            }
            return false;
        }
    }
}
