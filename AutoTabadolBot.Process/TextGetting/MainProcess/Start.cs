using AutoTabadol.Process.BotRunning.MessageRunning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using AutoTabadol.DataLayer.Context;
using AutoTabadol.DataLayer;
using AutoTabadol.Process.Keyboards;
using AutoTabadol.Calculation.FindingProcess;
using AutoTabadol.Calculation.ExchangingProcess;

namespace AutoTabadol.Process.TextGetting
{
    public class Start : IRunBot
    {
        public bool prosecc(MessageEventArgs up, TelegramBotClient bot)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                if (up.Message.Text == "/start")
                {
                    bool ResExist = db.userAccountRepository.CheckExitance(up.Message.Chat.Id);

                    if (ResExist == false)
                    {
                        UserInfo_Table MT = new UserInfo_Table()
                        {
                            ChatId = up.Message.Chat.Id
                        };
                        db.UserAccountRepository.Insert(MT);
                        db.Save();

                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine($"کاربر {up.Message.Chat.FirstName} خوش آمدید");
                        sb.AppendLine("شما میتوانید با این ربات با استفاده از تبادل روزانه برای کانال خود ممبر جذب کنید ");
                        sb.AppendLine("و تمام فرایند تبادل کاملا اوتوماتیک توسط ربات انجام میشه برای شروع کافی است که ربات را به کانال خود اضافه کنید");
                        sb.AppendLine("و بعد یکی از پیام های کانال خود را برای ربات فوروارد کنید");
                        sb.AppendLine("");
                        sb.AppendLine("برای مشاهده چگونگی این کار بر روی دکمه زیر کلیک کنید");

                        bot.SendTextMessageAsync(up.Message.Chat.Id, sb.ToString(), Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, Keyboards.InlineKeyboards.add_markup);
                    }
                    else if (ResExist == true && db.UserAccountRepository.GetById(up.Message.Chat.Id).DayliTab == null)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine($"کاربر {up.Message.Chat.FirstName} خوش آمدید");
                        sb.AppendLine("شما میتوانید با این ربات با استفاده از تبادل روزانه برای کانال خود ممبر جذب کنید ");
                        sb.AppendLine("و تمام فرایند تبادل کاملا اوتوماتیک توسط ربات انجام میشه برای شروع کافی است که ربات را به کانال خود اضافه کنید");
                        sb.AppendLine("و بعد یکی از پیام های کانال خود را برای ربات فوروارد کنید");
                        sb.AppendLine("");
                        sb.AppendLine("برای مشاهده چگونگی این کار بر روی دکمه زیر کلیک کنید");

                        bot.SendTextMessageAsync(up.Message.Chat.Id, sb.ToString(), Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, Keyboards.InlineKeyboards.add_markup);

                    }
                    else
                    {
                        ButtonKeyboard.SettingsMarkUpBTN.ResizeKeyboard = true;

                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine($"کاربر {up.Message.Chat.Username} گرامی خوش آمدید");
                        sb.AppendLine("");
                        sb.AppendLine("شما میتوانید با استفاده از دکمه تنضیمات در پایین صفحه ربات را کنترل کنید");

                        bot.SendTextMessageAsync(up.Message.Chat.Id, sb.ToString(), Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, ButtonKeyboard.SettingsMarkUpBTN);

                        FindChannelByCategory.ChannelFinderByCategory(bot);
                        Exchanging.exchanger(bot);
                    }
                    return true;
                }
                return false;
            }
        }
    }
}
