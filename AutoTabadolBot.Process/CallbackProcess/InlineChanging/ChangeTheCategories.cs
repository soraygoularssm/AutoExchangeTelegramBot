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

namespace AutoTabadol.Process.CallbackProcess.InlineChanging
{
    public class ChangeTheCategories : IRunBot
    {
        public bool prosecc(CallbackQueryEventArgs up, TelegramBotClient bot)
        {
            if (up.CallbackQuery.Data == "ChangeCategories")
            {
                bot.EditMessageTextAsync(up.CallbackQuery.Message.Chat.Id, up.CallbackQuery.Message.MessageId, "آیا شما از حذف و تغییر دسته بندی فعلی اطمینان دارید؟", Telegram.Bot.Types.Enums.ParseMode.Default, false, InlineKeyboards.inline_change_markup_decide2);
                return true;
            }
            else if (up.CallbackQuery.Data == "YesChange2")
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    var Get = db.UserAccountRepository.GetById(up.CallbackQuery.Message.Chat.Id);
                    UserInfo_Table UT = new UserInfo_Table()
                    {
                        ChatId = up.CallbackQuery.Message.Chat.Id,
                        ChannelId = Get.ChannelId,
                        Category1 = null,
                        Category2 = null,
                        Category3 = null,
                        MemberCount = Get.MemberCount,
                        DayliTab = Get.DayliTab,
                        BannerPath = Get.BannerPath,
                        LastTabTimeToDay = Get.LastTabTimeToDay,
                        Recive = Get.Recive
                    };
                    db.userAccountRepository.UpdateUser(UT);
                    db.Save();

                    bot.EditMessageTextAsync(up.CallbackQuery.Message.Chat.Id, up.CallbackQuery.Message.MessageId, "از بین گذینه های زیر 3 دسته بندی را انتخاب کنید", Telegram.Bot.Types.Enums.ParseMode.Default, false, InlineKeyboards.category1(up.CallbackQuery.Message.Chat.Id));
                    bot.SendTextMessageAsync(up.CallbackQuery.Message.Chat.Id, "🙂", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, new ReplyKeyboardRemove());
                    bot.DeleteMessageAsync(up.CallbackQuery.Message.Chat.Id, up.CallbackQuery.Message.MessageId + 1);
                }
            }
            return false;
        }
    }
}
