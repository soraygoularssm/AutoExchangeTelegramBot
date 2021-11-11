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
using Telegram.Bot.Types.InputFiles;

namespace AutoTabadol.Process.TextGetting
{
    public class GetBanner : IRunBot
    {
        private static Message ForwardToChannelBank;
        public bool prosecc(MessageEventArgs up, TelegramBotClient bot)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                try
                {
                    if (db.UserAccountRepository.GetById(up.Message.Chat.Id).Recive == true)
                    {
                        SaveBannerPath(up, bot);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        private async void SaveBannerPath(MessageEventArgs up, TelegramBotClient bot)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                ButtonKeyboard.SettingsMarkUp.ResizeKeyboard = true;
                ButtonKeyboard.SettingsMarkUp.OneTimeKeyboard = true;

                switch (up.Message.Type.ToString())
                {
                    case "Text":
                        ForwardToChannelBank = await bot.SendTextMessageAsync(-1001367898784, up.Message.Text);
                        break;
                    case "Photo":
                        if (up.Message.Caption == null)
                        {
                            var CaptionLessEror = bot.SendTextMessageAsync(up.Message.Chat.Id, "بنر شما باید  کپشن و متنی در زیرش داسته باشد");
                        }
                        else
                        {
                            ForwardToChannelBank = await bot.SendPhotoAsync(-1001367898784, new InputOnlineFile(up.Message.Photo.Last().FileId), up.Message.Caption);
                        }
                        break;
                    case "Video":
                        if (up.Message.Caption == null)
                        {
                            var CaptionLessEror = bot.SendTextMessageAsync(up.Message.Chat.Id, "بنر شما باید  کپشن و متنی در زیرش داسته باشد");
                        }
                        else
                        {
                            ForwardToChannelBank = await bot.SendVideoAsync(-1001367898784, new InputOnlineFile(up.Message.Video.FileId), 0, 0, 0, up.Message.Caption);
                        }
                        break;
                    case "Document":
                        if (up.Message.Caption == null)
                        {
                            var CaptionLessEror = bot.SendTextMessageAsync(up.Message.Chat.Id, "بنر شما باید  کپشن و متنی در زیرش داسته باشد");
                        }
                        else
                        {
                            ForwardToChannelBank = await bot.SendDocumentAsync(-1001367898784, new InputOnlineFile(up.Message.Document.FileId), up.Message.Caption);
                        }
                        break;
                    default:
                        var DocumentEror = bot.SendTextMessageAsync(up.Message.Chat.Id, "شما تنها میتوانید از ویدیو یا عکس یا تکست برای بنر استفاده کنید");
                        break;
                }

                try
                {
                    var Get = db.UserAccountRepository.GetById(up.Message.Chat.Id);
                    UserInfo_Table MT = new UserInfo_Table()
                    {
                        ChatId = up.Message.Chat.Id,
                        ChannelId = Get.ChannelId,
                        Category1 = Get.Category1,
                        Category2 = Get.Category2,
                        Category3 = Get.Category3,
                        MemberCount = Get.MemberCount,
                        DayliTab = Get.DayliTab,
                        BannerPath = ForwardToChannelBank.MessageId,
                        LastTabTimeToDay = Get.LastTabTimeToDay, 
                        Recive = false
                    };

                    if (db.UserAccountRepository.GetById(up.Message.Chat.Id).BannerPath == null)
                    {
                        db.userAccountRepository.UpdateUser(MT);
                        db.Save();

                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("بنر شما با موفقیت ثبت شد");
                        sb.AppendLine("");
                        sb.AppendLine("");
                        sb.AppendLine("حال تعداد تبادلات ربات در روز را انتخاب کنید");
                        sb.AppendLine("شما میتوانید روزانه بین 1 تا 6 تبادل داشته باشید");

                        await bot.SendTextMessageAsync(up.Message.Chat.Id, sb.ToString(), Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, InlineKeyboards.count_tab);
                    }
                    else
                    {
                        var DeleteMessage = bot.DeleteMessageAsync(-1001367898784, (int)db.UserAccountRepository.GetById(up.Message.Chat.Id).BannerPath);

                        db.userAccountRepository.UpdateUser(MT);
                        db.Save();

                        await bot.SendTextMessageAsync(up.Message.Chat.Id, "بنر شما با موفقیت ثبت شد", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, ButtonKeyboard.SettingsMarkUp);
                    }
                }
                catch
                {
                }

            }
        }
    }
}
