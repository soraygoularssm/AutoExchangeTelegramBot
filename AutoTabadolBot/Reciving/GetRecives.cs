using AutoTabadol.Process.CallbackProcess;
using AutoTabadol.Process.CallbackProcess.InlineChanging;
using AutoTabadol.Process.CallbackProcess.MainProcess;
using AutoTabadol.Process.CallbackProcess.OtherProcess;
using AutoTabadol.Process.TextGetting;
using AutoTabadol.Process.TextGetting.KeyboardButtons;
using AutoTabadol.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using AutoTabadol.Process.Admin.TextGetting;
using AutoTabadol.Process.Admin.CallbackProcess;
using System.IO;
using System.Threading;
using Telegram.Bot.Types;

namespace AutoTabadolBot.Reciving
{
    public class GetRecives
    {
        static string Token = "";
        public static TelegramBotClient bot = new TelegramBotClient(Token);

        public static void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs up)
        {
            List<AutoTabadol.Process.BotRunning.MessageRunning.IRunBot> list = new List<AutoTabadol.Process.BotRunning.MessageRunning.IRunBot>();

            if (up.Message.Chat.Id == 109403941)
            {
                list.Add(new AdminStart());
                list.Add(new GetStatistics());
                list.Add(new SendTextMessage());
                list.Add(new GetTheBannerPath());
            }
            else
            {
                list.Add(new Start());
                list.Add(new GetChannelName());
                list.Add(new GetBanner());
                list.Add(new Settings());
                list.Add(new Back());
                list.Add(new MyChannel());
                list.Add(new MyBanner());
                list.Add(new DailyTabCount());
                list.Add(new Categories());
            }

            AutoTabadol.Process.BotRunning.MessageRunning.RunBot botruner = new AutoTabadol.Process.BotRunning.MessageRunning.RunBot(list);
            botruner.Answer(up, bot);
        }

        public static void Bot_OnCallbackQuery(object sender, Telegram.Bot.Args.CallbackQueryEventArgs up)
        {
            List<AutoTabadol.Process.BotRunning.CallBackRunning.IRunBot> inlinelist = new List<AutoTabadol.Process.BotRunning.CallBackRunning.IRunBot>();

            if (up.CallbackQuery.Message.Chat.Id == 109403941)
            {
                inlinelist.Add(new SettingCategory());
                inlinelist.Add(new SendMessageToBotUsers());
                inlinelist.Add(new SendMessageToChannelByCategory());
                inlinelist.Add(new SendMessageToChannels());
            }
            else
            {
                inlinelist.Add(new TutorialVideo());
                inlinelist.Add(new ChangeTheChannel());
                inlinelist.Add(new ChangeTheBanner());
                inlinelist.Add(new ChangeTheDailyTabCount());
                inlinelist.Add(new ChangeTheCategories());
                inlinelist.Add(new GetDailyTabCount());
                inlinelist.Add(new GetCategories());
                inlinelist.Add(new AddChannel());
            }

            AutoTabadol.Process.BotRunning.CallBackRunning.RunBot botruner = new AutoTabadol.Process.BotRunning.CallBackRunning.RunBot(inlinelist);
            botruner.Answer(up, bot);
        }
    }
}
