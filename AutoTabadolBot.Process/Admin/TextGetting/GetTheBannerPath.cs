using AutoTabadol.DataLayer.Context;
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
    public class GetTheBannerPath : IRunBot
    {
        public bool prosecc(MessageEventArgs up, TelegramBotClient bot)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                switch (db.AdminRepository.GetById(up.Message.Chat.Id).UserType)
                {
                    case 1:
                        foreach (var item in db.UserAccountRepository.Get())
                        {
                            bot.ForwardMessageAsync(item.ChatId, -1001367898784, Convert.ToInt16(up.Message.Text));
                        }
                        return true;
                    case 2:
                        foreach (var item in db.UserAccountRepository.Get())
                        {
                            bot.ForwardMessageAsync(item.ChannelId, -1001367898784, Convert.ToInt16(up.Message.Text));
                        }
                        return true;
                    case 3:
                        foreach (var item in db.UserAccountRepository.Get())
                        {
                            if (item.Category1 == db.AdminRepository.GetById(up.Message.Chat.Id).Category || item.Category2 == db.AdminRepository.GetById(up.Message.Chat.Id).Category || item.Category3 == db.AdminRepository.GetById(up.Message.Chat.Id).Category)
                            {
                                bot.ForwardMessageAsync(item.ChannelId, -1001367898784, Convert.ToInt16(up.Message.Text));
                            }
                        }
                        return true;
                    default:
                        return false;
                }
            }
        }
    }
}
