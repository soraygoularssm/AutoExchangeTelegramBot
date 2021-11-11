using AutoTabadol.DataLayer;
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

namespace AutoTabadol.Process.TextGetting
{
    public class GetChannelName : IRunBot
    {
        public bool prosecc(MessageEventArgs up, TelegramBotClient bot)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                try
                {
                    if (up.Message.ForwardFromChat.Username != null)
                    {
                        if (bot.GetChatMemberAsync(up.Message.ForwardFromChat.Id, bot.BotId).Result.Status == Telegram.Bot.Types.Enums.ChatMemberStatus.Administrator)
                        {
                            if (db.userAccountRepository.CheckChannelExitance(up.Message.ForwardFromChat.Id) == true)
                            {
                                if (db.userAccountRepository.GetIdByChannelId(up.Message.ForwardFromChat.Id) == up.Message.Chat.Id)
                                {
                                    bot.SendTextMessageAsync(up.Message.Chat.Id, "شما قبلا این کانال را ثبت کرده اید ");
                                }
                                else
                                {
                                    bot.SendTextMessageAsync(up.Message.Chat.Id, "این کانال قبلا توسط شخص دیگری ثبت شده");
                                }
                            }
                            else
                            {
                                UserInfo_Table MT = new UserInfo_Table()
                                {
                                    ChatId = up.Message.Chat.Id,
                                    LastTabTimeToDay = 0,
                                    ChannelId = up.Message.ForwardFromChat.Id
                                };

                                db.UserAccountRepository.Update(MT);
                                db.Save();

                                StringBuilder sb = new StringBuilder();
                                sb.AppendLine("کانال شما با موفقیت ثبت شد");
                                sb.AppendLine("");
                                sb.AppendLine("حال از بین دسته بندی های زیر 3 دسته بندی را برای کانل خود انتخاب کنید");

                                bot.SendTextMessageAsync(up.Message.Chat.Id, sb.ToString(), Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, InlineKeyboards.category1(up.Message.Chat.Id));
                            }
                        }
                        else
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine("ربات به کانال اضافه نشده است لطفا دوباره تلاش کنید");
                            sb.AppendLine("");
                            sb.AppendLine("توجه کنید که پیام حتما از کانال خودتون فوروارد شده باشد");

                            bot.SendTextMessageAsync(up.Message.Chat.Id, sb.ToString());
                        }
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
