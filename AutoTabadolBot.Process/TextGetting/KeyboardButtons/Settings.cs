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
    public class Settings : IRunBot
    {
        public bool prosecc(MessageEventArgs up, TelegramBotClient bot)
        {
            if (up.Message.Text == "⚙️ تنضیمات ⚙️")
            {
                ButtonKeyboard.SettingsMarkUp.ResizeKeyboard = true; 
                bot.SendTextMessageAsync(up.Message.Chat.Id, "شما میتوانید از دکمه های زیر برای کنترل وضعیت ربات و تبادلات استفاده کنید",Telegram.Bot.Types.Enums.ParseMode.Default,false,false,0,ButtonKeyboard.SettingsMarkUp);

                return true;
            }
            return false;
        }
    }
}
