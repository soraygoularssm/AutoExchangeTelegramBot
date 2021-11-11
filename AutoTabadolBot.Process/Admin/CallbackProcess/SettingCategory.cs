using AutoTabadol.DataLayer;
using AutoTabadol.DataLayer.Context;
using AutoTabadol.Process.Admin.InlineKeyboard;
using AutoTabadol.Process.BotRunning.CallBackRunning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace AutoTabadol.Process.Admin.CallbackProcess
{
    public class SettingCategory : IRunBot
    {
        public bool prosecc(CallbackQueryEventArgs up, TelegramBotClient bot)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                foreach (var cat in db.CategoriesRepository.Get())
                {
                    if (up.CallbackQuery.Data == cat.Code)
                    {

                        Admin_Table AT = new Admin_Table()
                        {
                            ChatId = up.CallbackQuery.Message.Chat.Id,
                            SendMessage = true,
                            UserType = 3,
                            Category = up.CallbackQuery.Data
                        };
                        db.AdminRepository.Update(AT);
                        db.Save();

                        bot.SendTextMessageAsync(up.CallbackQuery.Message.Chat.Id,"now sedn the code of the link in baner bank channel");
                    }
                }
                switch (up.CallbackQuery.Data)
                {
                    case "next":

                        bot.EditMessageReplyMarkupAsync(up.CallbackQuery.Message.Chat.Id, up.CallbackQuery.Message.MessageId, AdminInlineKeyboad.Category_Markup2(up.CallbackQuery.Message.Chat.Id));
                        return true;
                    case "back":

                        bot.EditMessageReplyMarkupAsync(up.CallbackQuery.Message.Chat.Id, up.CallbackQuery.Message.MessageId, AdminInlineKeyboad.Category_Markup1(up.CallbackQuery.Message.Chat.Id));
                        return true;
                    default:

                        return false;
                }
            }
        }
    }
}
