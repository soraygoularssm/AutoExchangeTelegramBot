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

namespace AutoTabadol.Process.CallbackProcess
{
    public class GetCategories : IRunBot
    {
        public bool prosecc(CallbackQueryEventArgs up, TelegramBotClient bot)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var Get = db.UserAccountRepository.GetById(up.CallbackQuery.Message.Chat.Id);

                UserInfo_Table MT3 = new UserInfo_Table()
                {
                    ChatId = Get.ChatId,
                    ChannelId = Get.ChannelId,
                    BannerPath = Get.BannerPath,
                    DayliTab = Get.DayliTab,
                    MemberCount = Get.MemberCount,
                    LastTabTimeToDay = Get.LastTabTimeToDay
                };

                for (int i = 0; i < db.CategoryRepository.GetAllCategories().Count; i++)
                {
                    if (up.CallbackQuery.Data == db.CategoriesRepository.GetById(i + 1).Code)
                    {
                        if (db.UserAccountRepository.GetById(up.CallbackQuery.Message.Chat.Id).Category1 == null)
                        {
                            MT3.Category1 = up.CallbackQuery.Data;
                            MT3.Category2 = Get.Category2;
                            MT3.Category3 = Get.Category3;

                            db.userAccountRepository.UpdateUser(MT3);
                            db.Save();
                        }
                        else
                        {
                            if (db.UserAccountRepository.GetById(up.CallbackQuery.Message.Chat.Id).Category2 == null && db.UserAccountRepository.GetById(up.CallbackQuery.Message.Chat.Id).Category1 != up.CallbackQuery.Data)
                            {
                                MT3.Category1 = Get.Category1;
                                MT3.Category2 = up.CallbackQuery.Data;
                                MT3.Category3 = Get.Category3;

                                db.userAccountRepository.UpdateUser(MT3);
                                db.Save();
                            }
                            else
                            {
                                if (db.UserAccountRepository.GetById(up.CallbackQuery.Message.Chat.Id).Category3 == null && db.UserAccountRepository.GetById(up.CallbackQuery.Message.Chat.Id).Category1 != up.CallbackQuery.Data && db.UserAccountRepository.GetById(up.CallbackQuery.Message.Chat.Id).Category2 != up.CallbackQuery.Data)
                                {
                                    MT3.Category1 = Get.Category1;
                                    MT3.Category2 = Get.Category2;
                                    MT3.Category3 = up.CallbackQuery.Data;

                                    if (db.UserAccountRepository.GetById(up.CallbackQuery.Message.Chat.Id).DayliTab != null)
                                    {
                                        ButtonKeyboard.SettingsMarkUp.ResizeKeyboard = true;

                                        db.userAccountRepository.UpdateUser(MT3);
                                        MT3.Recive = false;
                                        db.Save();

                                        bot.SendTextMessageAsync(up.CallbackQuery.Message.Chat.Id, "دسته بندی کانال شما با موفقیت تغییر کرد", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, ButtonKeyboard.SettingsMarkUp);
                                        bot.DeleteMessageAsync(up.CallbackQuery.Message.Chat.Id, up.CallbackQuery.Message.MessageId);
                                    }
                                    else
                                    {
                                        db.userAccountRepository.UpdateUser(MT3);
                                        MT3.Recive = true;
                                        db.Save();

                                        StringBuilder sb = new StringBuilder();
                                        sb.AppendLine("حالا بنر خود را به همراه عکس و متن بفرستید");
                                        sb.AppendLine("");
                                        sb.AppendLine("توجه کنید بنر نباید از جایی فوروارد شده باشه");

                                        bot.EditMessageTextAsync(up.CallbackQuery.Message.Chat.Id, up.CallbackQuery.Message.MessageId, sb.ToString());

                                    }
                                }
                                else
                                {
                                }
                            }
                        }
                    }
                }

                switch (up.CallbackQuery.Data)
                {
                    case "next":

                        bot.EditMessageReplyMarkupAsync(up.CallbackQuery.Message.Chat.Id, up.CallbackQuery.Message.MessageId, InlineKeyboards.category2(up.CallbackQuery.Message.Chat.Id));
                        return true;
                    case "back":

                        bot.EditMessageReplyMarkupAsync(up.CallbackQuery.Message.Chat.Id, up.CallbackQuery.Message.MessageId, InlineKeyboards.category1(up.CallbackQuery.Message.Chat.Id));
                        return true;
                    default:

                        return false;
                }
            }
        }
    }
}
