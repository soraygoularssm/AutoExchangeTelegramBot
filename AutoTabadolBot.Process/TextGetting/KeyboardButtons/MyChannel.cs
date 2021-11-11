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
using Telegram.Bot.Types;

namespace AutoTabadol.Process.TextGetting.KeyboardButtons
{
    public class MyChannel : IRunBot
    {
        public bool prosecc(MessageEventArgs up, TelegramBotClient bot)
        {
            if (up.Message.Text == "📣 کانال من 📣")
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    var Cat1st = db.CategoryRepository.GetCategoryByCode(db.UserAccountRepository.GetById(up.Message.Chat.Id).Category1).Category;
                    var Cat2nd = db.CategoryRepository.GetCategoryByCode(db.UserAccountRepository.GetById(up.Message.Chat.Id).Category2).Category;
                    var Cat3rd = db.CategoryRepository.GetCategoryByCode(db.UserAccountRepository.GetById(up.Message.Chat.Id).Category3).Category;
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"کانال شما:  @{bot.GetChatAsync(db.UserAccountRepository.GetById(up.Message.Chat.Id).ChannelId).Result.Username}");
                    sb.AppendLine($"تعداد تبادل در روز:  {db.UserAccountRepository.GetById(up.Message.Chat.Id).DayliTab}");
                    sb.AppendLine($"دسته بندی ها: {Cat1st} ,  {Cat2nd} , {Cat3rd}");
                    sb.AppendLine("");
                    sb.AppendLine("اگر میخواهید میتوانید با استفاده از دکمه زیر کانالتان را تغییر دهید و به کانال دیگری مهاجرت کنید");

                    bot.SendTextMessageAsync(up.Message.Chat.Id, sb.ToString(), Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0,InlineKeyboards.inline_change_channel_markup);
                }
                return true;
            }
            return false;
        }
    }
}
