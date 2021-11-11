using AutoTabadol.Process.Keyboards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace AutoTabadol.Process.Admin.InlineKeyboard
{
    class AdminInlineKeyboad
    {
        static InlineKeyboardButton[] inlinerow_row1 = { InlineKeyboardButton.WithCallbackData("BotUsers", "BU") };
        static InlineKeyboardButton[] inlinerow_row2 = { InlineKeyboardButton.WithCallbackData("Channels", "CH")};
        static InlineKeyboardButton[] inlinerow_row3 = { InlineKeyboardButton.WithCallbackData("ChannelByCategory", "CBC")};
        static InlineKeyboardButton[][] Admin_SendMessage_Rows = { inlinerow_row1, inlinerow_row2, inlinerow_row3 };
        public static InlineKeyboardMarkup Admin_SendMessage = new InlineKeyboardMarkup(Admin_SendMessage_Rows);

        public static InlineKeyboardMarkup Category_Markup1(long ChatId)
        {
            GenericInlineKeyboard MUG1 = new GenericInlineKeyboard();
            return MUG1.markupgrouping1(ChatId);
        }
        public static InlineKeyboardMarkup Category_Markup2(long ChatId)
        {
            GenericInlineKeyboard MUG2 = new GenericInlineKeyboard();
            return MUG2.markupgrouping2(ChatId);
        }
    }
}
