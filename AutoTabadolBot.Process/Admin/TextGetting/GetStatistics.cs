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
    public class GetStatistics : IRunBot
    {
        public bool prosecc(MessageEventArgs up, TelegramBotClient bot)
        {
            if (up.Message.Text == "/Statistics")
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    int MemberCount = 0;
                    foreach (var Counter in db.UserAccountRepository.Get())
                    {
                        if (Counter.DayliTab != null)
                        {
                            MemberCount++;
                        }
                    }
                    bot.SendTextMessageAsync(up.Message.Chat.Id , MemberCount.ToString());
                }
                return true;
            } else
            {
                return false;
            }
        }
    }
}
