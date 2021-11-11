using AutoTabadol.DataLayer;
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
    public class ChangeTheChannel : IRunBot
    {
        public bool prosecc(CallbackQueryEventArgs up, TelegramBotClient bot)
        {
            if (up.CallbackQuery.Data == "ChangeChannel")
            {
                bot.EditMessageTextAsync(up.CallbackQuery.Message.Chat.Id, up.CallbackQuery.Message.MessageId, "آیا شما از حذف و تغییر کانال فعلی اطمینان دارید؟", Telegram.Bot.Types.Enums.ParseMode.Default, false, InlineKeyboards.inline_change_markup_decide);
                return true;
            }
            else if (up.CallbackQuery.Data == "YesChange")
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    UserInfo_Table UT = new UserInfo_Table()
                    {
                        ChatId = up.CallbackQuery.Message.Chat.Id
                    };
                    db.userAccountRepository.UpdateUser(UT);
                    db.Save();

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("کانال قبلی شما حذف شد و الان شما میتوانید کانال جدیدی را در ربات ثبت کنید");
                    sb.AppendLine("");
                    sb.AppendLine("مراحل ثبت کانال جدید دقیقا همانند اولین کانال میباشد");
                    sb.AppendLine("اگر نمیدانید چگونه باید کانال جدیدی را به کانال اضافه کنید میتوانید از دکمه راهنما زیر استفاده کنید");

                    bot.EditMessageTextAsync(up.CallbackQuery.Message.Chat.Id, up.CallbackQuery.Message.MessageId, sb.ToString(), Telegram.Bot.Types.Enums.ParseMode.Default, false, InlineKeyboards.add_markup);

                    bot.SendTextMessageAsync(up.CallbackQuery.Message.Chat.Id, "🙂", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, new ReplyKeyboardRemove());
                    bot.DeleteMessageAsync(up.CallbackQuery.Message.Chat.Id, up.CallbackQuery.Message.MessageId + 1);
                    return true;
                }
            }
            else if (up.CallbackQuery.Data == "Cancel")
            {
                ButtonKeyboard.SettingsMarkUp.ResizeKeyboard = true;

                using (UnitOfWork db = new UnitOfWork())
                {
                    var Get = db.UserAccountRepository.GetById(up.CallbackQuery.Message.Chat.Id);
                    UserInfo_Table UT = new UserInfo_Table()
                    {
                        ChatId = up.CallbackQuery.Message.Chat.Id,
                        ChannelId = Get.ChannelId,
                        Category1 = Get.Category1,
                        Category2 = Get.Category2,
                        Category3 = Get.Category3,
                        MemberCount = Get.MemberCount,
                        DayliTab = Get.DayliTab,
                        BannerPath = Get.BannerPath,
                        LastTabTimeToDay = Get.LastTabTimeToDay,
                        Recive = false
                    };
                    db.userAccountRepository.UpdateUser(UT);
                    db.Save();

                    bot.DeleteMessageAsync(up.CallbackQuery.Message.Chat.Id, up.CallbackQuery.Message.MessageId);
                    bot.SendTextMessageAsync(up.CallbackQuery.Message.Chat.Id, " لغو شد ", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, ButtonKeyboard.SettingsMarkUp);
                }
                return true;
            }
            return false;
        }
    }
}
