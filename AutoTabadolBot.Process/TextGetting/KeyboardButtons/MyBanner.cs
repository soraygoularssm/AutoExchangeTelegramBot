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
    public class MyBanner : IRunBot
    {
        public bool prosecc(MessageEventArgs up, TelegramBotClient bot)
        {
            if (up.Message.Text == "📃 بنر من 📃")
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    try
                    {
                        bot.ForwardMessageAsync(up.Message.Chat.Id, -1001367898784, (int)db.UserAccountRepository.GetById(up.Message.Chat.Id).BannerPath);
                        bot.SendTextMessageAsync(up.Message.Chat.Id, "میتوانید با استفاده از دکمه زیر بنر کانالتان را عوض کنید", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, InlineKeyboards.change_banner_markup);
                    }
                    catch
                    {
                    }
                }
                return true;
            }
            return false;
        }
    }
}
