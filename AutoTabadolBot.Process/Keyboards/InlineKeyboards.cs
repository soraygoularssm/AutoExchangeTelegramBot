using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace AutoTabadol.Process.Keyboards
{
    public class InlineKeyboards
    {
        //Add Channel
        static InlineKeyboardButton[] inlinerow1 = { InlineKeyboardButton.WithCallbackData("راهنمای ثبت کانال", "HowAddChannel") };
        public static InlineKeyboardMarkup add_markup = new InlineKeyboardMarkup(inlinerow1);

        //Cancel Button
        static InlineKeyboardButton[] canecelrow = { InlineKeyboardButton.WithCallbackData("لغو", "Cancel") };
        public static InlineKeyboardMarkup cancel_markup = new InlineKeyboardMarkup(canecelrow);

        //Set Daily Exchanging
        static InlineKeyboardButton[] inlinerow_tab1 = { InlineKeyboardButton.WithCallbackData("1 بار در روز", "once"), InlineKeyboardButton.WithCallbackData("2 بار در روز", "twice") };
        static InlineKeyboardButton[] inlinerow_tab2 = { InlineKeyboardButton.WithCallbackData("3 بار در روز", "3times"), InlineKeyboardButton.WithCallbackData("4 بار در روز", "4times") };
        static InlineKeyboardButton[] inlinerow_tab3 = { InlineKeyboardButton.WithCallbackData("5 بار در روز", "5times"), InlineKeyboardButton.WithCallbackData("6 بار در روز", "6times") };
        static InlineKeyboardButton[][] inlinerows_tab = { inlinerow_tab1, inlinerow_tab2, inlinerow_tab3 };
        public static InlineKeyboardMarkup count_tab = new InlineKeyboardMarkup(inlinerows_tab);

        //Set Daily Exchanging 2
        static InlineKeyboardButton[][] inlinerows_count_tab = { inlinerow_tab1, inlinerow_tab2, inlinerow_tab3 , canecelrow };
        public static InlineKeyboardMarkup get_count_tab = new InlineKeyboardMarkup(inlinerows_count_tab);

        //Cahneging Channel
        static InlineKeyboardButton[] inlinerow2 = { InlineKeyboardButton.WithCallbackData("تغییر کانال", "ChangeChannel") };
        public static InlineKeyboardMarkup inline_change_channel_markup = new InlineKeyboardMarkup(inlinerow2);

        //Final Decide Changing 
        static InlineKeyboardButton[] inlinerow_yes = { InlineKeyboardButton.WithCallbackData("بله مطمئن هستم", "YesChange") };
        static InlineKeyboardButton[][] all_inlinerows = { inlinerow_yes, canecelrow };
        public static InlineKeyboardMarkup inline_change_markup_decide = new InlineKeyboardMarkup(all_inlinerows);

        //Final Decide Changing 2
        static InlineKeyboardButton[] inlinerow_yes2 = { InlineKeyboardButton.WithCallbackData("بله مطمئن هستم", "YesChange2") };
        static InlineKeyboardButton[][] all_inlinerows2 = { inlinerow_yes2 , canecelrow };
        public static InlineKeyboardMarkup inline_change_markup_decide2 = new InlineKeyboardMarkup(all_inlinerows2);

        //Change The Banner
        static InlineKeyboardButton[] inlinerow_change_banner = { InlineKeyboardButton.WithCallbackData("تغییر بنر کانال", "ChangeBanner") };
        public static InlineKeyboardMarkup change_banner_markup = new InlineKeyboardMarkup(inlinerow_change_banner);

        //Change The Daily Tab Count
        static InlineKeyboardButton[] inlinerow_change_dailytabcount = { InlineKeyboardButton.WithCallbackData("تغییر تعداد تبادل های روزانه", "ChangeDayliTabCount") };
        public static InlineKeyboardMarkup change_dailytabcount_markup = new InlineKeyboardMarkup(inlinerow_change_dailytabcount);

        //Change The Categories
        static InlineKeyboardButton[] inlinerow_change_categories = { InlineKeyboardButton.WithCallbackData("تغییر دسته بندی کانال", "ChangeCategories") };
        public static InlineKeyboardMarkup change_categories_markup = new InlineKeyboardMarkup(inlinerow_change_categories);

        //how to add our channel video
        static InlineKeyboardButton[] inline_video_tutorial = { InlineKeyboardButton.WithCallbackData("ویدئو آموزشی", "VideoTutorial") };
        public static InlineKeyboardMarkup video_tutorial_markup = new InlineKeyboardMarkup(inline_video_tutorial);

        //Generic Categories Keyboard
        public static InlineKeyboardMarkup category1(long ChatId)
        {
            GenericInlineKeyboard MUG1 = new GenericInlineKeyboard();
            return MUG1.markupgrouping1(ChatId);
        }
        public static InlineKeyboardMarkup category2(long ChatId)
        {
            GenericInlineKeyboard MUG2 = new GenericInlineKeyboard();
            return MUG2.markupgrouping2(ChatId);
        }
    }
}
