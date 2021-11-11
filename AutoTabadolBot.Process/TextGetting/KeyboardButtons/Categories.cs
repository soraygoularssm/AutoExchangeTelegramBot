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
    public class Categories : IRunBot
    {
        public bool prosecc(MessageEventArgs up, TelegramBotClient bot)
        {
            if (up.Message.Text == "دسته بندی کانال")
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    var Cat1st = db.CategoryRepository.GetCategoryByCode(db.UserAccountRepository.GetById(up.Message.Chat.Id).Category1).Category;
                    var Cat2nd = db.CategoryRepository.GetCategoryByCode(db.UserAccountRepository.GetById(up.Message.Chat.Id).Category2).Category;
                    var Cat3rd = db.CategoryRepository.GetCategoryByCode(db.UserAccountRepository.GetById(up.Message.Chat.Id).Category3).Category;

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("دسته بندی های کانال شما شامل:");
                    sb.AppendLine($"1_{Cat1st}");
                    sb.AppendLine($"2_{Cat2nd}");
                    sb.AppendLine($"3_{Cat3rd}");
                    sb.AppendLine("");
                    sb.AppendLine("میتوانید با استفاده از دکمه زیر دسته بندی های کانال خود را تغییر دهید");

                    bot.SendTextMessageAsync(up.Message.Chat.Id,sb.ToString(), Telegram.Bot.Types.Enums.ParseMode.Default ,false,false,0,InlineKeyboards.change_categories_markup);
                }
                return true;
            }
            return false;
        }
    }
}
