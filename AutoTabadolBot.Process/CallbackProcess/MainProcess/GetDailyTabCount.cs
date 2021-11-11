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
using Telegram.Bot.Types;

namespace AutoTabadol.Process.CallbackProcess
{
    public class GetDailyTabCount : IRunBot
    {
        public bool prosecc(CallbackQueryEventArgs up, TelegramBotClient bot)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                ButtonKeyboard.SettingsMarkUpBTN.ResizeKeyboard = true;

                try
                {
                    var Get = db.UserAccountRepository.GetById(up.CallbackQuery.Message.Chat.Id);

                    UserInfo_Table MT = new UserInfo_Table()
                    {
                        ChatId = Get.ChatId,
                        ChannelId = Get.ChannelId,
                        Category1 = Get.Category1,
                        Category2 = Get.Category2,
                        Category3 = Get.Category3,
                        MemberCount = bot.GetChatMembersCountAsync(db.UserAccountRepository.GetById(up.CallbackQuery.Message.Chat.Id).ChannelId).Result,
                        BannerPath = Get.BannerPath,
                        Recive = Get.Recive
                    };

                    if (Get.LastTabTimeToDay == null)
                    {
                        MT.LastTabTimeToDay = 0;
                    } else
                    {
                        MT.LastTabTimeToDay = Get.LastTabTimeToDay;
                    }

                    switch (up.CallbackQuery.Data)
                    {
                        case "once":

                            MT.DayliTab = 1;

                            db.userAccountRepository.UpdateUser(MT);
                            db.Save();

                            bot.DeleteMessageAsync(up.CallbackQuery.Message.Chat.Id, up.CallbackQuery.Message.MessageId);
                            bot.SendTextMessageAsync(up.CallbackQuery.Message.Chat.Id, "تمام تغییرات با موفقیت ذخیره شدند", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, ButtonKeyboard.SettingsMarkUpBTN);

                            return true;

                        case "twice":

                            MT.DayliTab = 2;

                            db.userAccountRepository.UpdateUser(MT);
                            db.Save();

                            bot.DeleteMessageAsync(up.CallbackQuery.Message.Chat.Id, up.CallbackQuery.Message.MessageId);
                            bot.SendTextMessageAsync(up.CallbackQuery.Message.Chat.Id, "تمام تغییرات با موفقیت ذخیره شدند", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, ButtonKeyboard.SettingsMarkUpBTN);


                            return true;

                        case "3times":

                            MT.DayliTab = 3;

                            db.userAccountRepository.UpdateUser(MT);
                            db.Save();

                            bot.DeleteMessageAsync(up.CallbackQuery.Message.Chat.Id, up.CallbackQuery.Message.MessageId);
                            bot.SendTextMessageAsync(up.CallbackQuery.Message.Chat.Id, "تمام تغییرات با موفقیت ذخیره شدند", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, ButtonKeyboard.SettingsMarkUpBTN);

                            return true;

                        case "4times":

                            MT.DayliTab = 4;

                            db.userAccountRepository.UpdateUser(MT);
                            db.Save();

                            bot.DeleteMessageAsync(up.CallbackQuery.Message.Chat.Id, up.CallbackQuery.Message.MessageId);
                            bot.SendTextMessageAsync(up.CallbackQuery.Message.Chat.Id, "تمام تغییرات با موفقیت ذخیره شدند", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, ButtonKeyboard.SettingsMarkUpBTN);

                            return true;

                        case "5times":

                            MT.DayliTab = 5;

                            db.userAccountRepository.UpdateUser(MT);
                            db.Save();

                            bot.DeleteMessageAsync(up.CallbackQuery.Message.Chat.Id, up.CallbackQuery.Message.MessageId);
                            bot.SendTextMessageAsync(up.CallbackQuery.Message.Chat.Id, "تمام تغییرات با موفقیت ذخیره شدند", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, ButtonKeyboard.SettingsMarkUpBTN);

                            return true;

                        case "6times":

                            MT.DayliTab = 6;

                            db.userAccountRepository.UpdateUser(MT);
                            db.Save();

                            bot.DeleteMessageAsync(up.CallbackQuery.Message.Chat.Id, up.CallbackQuery.Message.MessageId);
                            bot.SendTextMessageAsync(up.CallbackQuery.Message.Chat.Id, "تمام تغییرات با موفقیت ذخیره شدند", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, ButtonKeyboard.SettingsMarkUpBTN);

                            return true;

                        default:
                            return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
