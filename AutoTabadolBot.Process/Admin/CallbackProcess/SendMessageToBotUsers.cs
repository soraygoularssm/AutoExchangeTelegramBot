using AutoTabadol.DataLayer;
using AutoTabadol.DataLayer.Context;
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
    public class SendMessageToBotUsers : IRunBot
    {
        public bool prosecc(CallbackQueryEventArgs up, TelegramBotClient bot)
        {
            if (up.CallbackQuery.Data == "BU")
            {
                using (UnitOfWork db = new UnitOfWork())
                {
                    Admin_Table AT = new Admin_Table()
                    {
                        ChatId = up.CallbackQuery.Message.Chat.Id,
                        SendMessage = true,
                        UserType = 1
                    };
                    db.AdminRepository.Update(AT);
                    db.Save();

                    bot.SendTextMessageAsync(up.CallbackQuery.Message.Chat.Id, "Give bot link code of the text");
                };
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
