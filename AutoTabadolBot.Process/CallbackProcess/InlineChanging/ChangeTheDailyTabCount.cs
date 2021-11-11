using AutoTabadol.DataLayer.Context;
using AutoTabadol.Process.BotRunning.CallBackRunning;
using AutoTabadol.Process.Keyboards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace AutoTabadol.Process.CallbackProcess.OtherProcess
{
    public class ChangeTheDailyTabCount : IRunBot
    {
        public bool prosecc(CallbackQueryEventArgs up, TelegramBotClient bot)
        {
            if (up.CallbackQuery.Data == "ChangeDayliTabCount")
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    bot.EditMessageTextAsync(up.CallbackQuery.Message.Chat.Id, up.CallbackQuery.Message.MessageId, "برای تغییر تعداد تبادلات روزانه جدید را انتخاب کنید", Telegram.Bot.Types.Enums.ParseMode.Default, false, InlineKeyboards.get_count_tab);

                    bot.SendTextMessageAsync(up.CallbackQuery.Message.Chat.Id, "🙂", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, new ReplyKeyboardRemove());
                    bot.DeleteMessageAsync(up.CallbackQuery.Message.Chat.Id, up.CallbackQuery.Message.MessageId + 1);
                }
                    return true;
            }
            return false;
        }
    }
}
