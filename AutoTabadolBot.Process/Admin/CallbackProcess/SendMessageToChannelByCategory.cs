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
    public class SendMessageToChannelByCategory : IRunBot
    {
        public bool prosecc(CallbackQueryEventArgs up, TelegramBotClient bot)
        {
            if (up.CallbackQuery.Data == "CBC")
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    Admin_Table AT = new Admin_Table()
                    {
                        ChatId = up.CallbackQuery.Message.Chat.Id,
                        SendMessage = true,
                        UserType = 3
                    };
                    db.AdminRepository.Update(AT);
                    db.Save();
                };

                bot.SendTextMessageAsync(up.CallbackQuery.Message.Chat.Id, "Choose the category that you want to your message send to", Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, AdminInlineKeyboad.Category_Markup1(up.CallbackQuery.Message.Chat.Id));
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
