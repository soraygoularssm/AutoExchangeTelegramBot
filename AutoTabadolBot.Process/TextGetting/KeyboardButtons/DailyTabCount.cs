using AutoTabadol.DataLayer.Context;
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
    public class DailyTabCount : IRunBot
    {
        public bool prosecc(MessageEventArgs up, TelegramBotClient bot)
        {
            if (up.Message.Text == "🔁 تبادلات روزانه 🔁")
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"تعداد تبادلات روزانه شما: {db.UserAccountRepository.GetById(up.Message.Chat.Id).DayliTab}");
                    sb.AppendLine("");
                    sb.AppendLine("برای تغییر تعداد تبادلات روزانه از دکمه زیر استفاده کنید");

                    bot.SendTextMessageAsync(up.Message.Chat.Id,sb.ToString(),Telegram.Bot.Types.Enums.ParseMode.Default,false,false,0,InlineKeyboards.change_dailytabcount_markup);
                }
                    return true;
            }
            return false;
        }
    }
}
