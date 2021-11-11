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
    public class ChangeTheBanner : IRunBot
    {
        public bool prosecc(CallbackQueryEventArgs up, TelegramBotClient bot)
        {
            if (up.CallbackQuery.Data == "ChangeBanner")
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    var Get = db.UserAccountRepository.GetById(up.CallbackQuery.Message.Chat.Id);
                    ButtonKeyboard.SettingsMarkUpBTN.OneTimeKeyboard = true;
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
                        Recive = true
                    };
                    db.userAccountRepository.UpdateUser(UT);
                    db.Save();

                    bot.EditMessageTextAsync(up.CallbackQuery.Message.Chat.Id, up.CallbackQuery.Message.MessageId, "برای تغییر بنر کانالتان بنر جدید را اینحا بفرستید", Telegram.Bot.Types.Enums.ParseMode.Default, false, InlineKeyboards.cancel_markup);
                    bot.SendTextMessageAsync(up.CallbackQuery.Message.Chat.Id, "🙂", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, new ReplyKeyboardRemove());
                    bot.DeleteMessageAsync(up.CallbackQuery.Message.Chat.Id, up.CallbackQuery.Message.MessageId + 1);
                }
                return true;
            }
            return false;
        }
    }
}
