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
    public class AddChannel : IRunBot
    {
        public bool prosecc(CallbackQueryEventArgs up, TelegramBotClient bot)
        {
            try
            {
                if (up.CallbackQuery.Data == "HowAddChannel")
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("برای کار با ربات باید ربات را به بخش ادمین های کانال خود اضافه کنید");
                    sb.AppendLine("برای این کار مراحل زیر را دنبال کنید یا از طریق ویدیو آموزشی زیر استفاده کنید");
                    sb.AppendLine("");
                    sb.AppendLine("1-وارد کانال خود شوید");
                    sb.AppendLine("2-وارد قسمت ادمین ها شوید");
                    sb.AppendLine("3-در قسمت جست و جو ایدی ربات را سرچ کنید و به ادمین های کانال اضافه کنید");
                    sb.AppendLine("");
                    sb.AppendLine("و پس از تمام این مراحل یک پیام از کانال خود که از جایی دیگر فوروارد نشده باشد و مختص کانال شما است را برای ربات بفرستید");
                    sb.AppendLine("");
                    sb.AppendLine("ربات هیچگونه تغییری در کانال ایجاد نمیکند و تنها تبادل ها را در کانال قرار میدهد");
                    sb.AppendLine("ایدی ربات برای جست و جو: @tabadol_ibot ");

                    bot.SendTextMessageAsync(up.CallbackQuery.Message.Chat.Id,sb.ToString(),Telegram.Bot.Types.Enums.ParseMode.Html,false,false,0, InlineKeyboards.video_tutorial_markup);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
