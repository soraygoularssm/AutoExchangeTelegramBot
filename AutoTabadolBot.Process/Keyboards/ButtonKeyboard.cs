using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace AutoTabadol.Process.Keyboards
{
    public class ButtonKeyboard
    {
        //settings 
        static KeyboardButton button1 = new KeyboardButton("⚙️ تنضیمات ⚙️");
        static KeyboardButton[] row1 = { button1 };
        public static ReplyKeyboardMarkup SettingsMarkUpBTN = new ReplyKeyboardMarkup(row1);


        //the channel
        static KeyboardButton button2 = new KeyboardButton("📃 بنر من 📃");
        static KeyboardButton button3 = new KeyboardButton("📣 کانال من 📣");
        static KeyboardButton button4 = new KeyboardButton("دسته بندی کانال");
        static KeyboardButton button5 = new KeyboardButton("🔁 تبادلات روزانه 🔁");
        static KeyboardButton button6 = new KeyboardButton("بازگشت 🔙");
        static KeyboardButton[] row2 = { button2 , button3 };
        static KeyboardButton[] row3 = { button4 , button5 };
        static KeyboardButton[] row4 = { button6 };
        static KeyboardButton[][] rowall1 = { row2 , row3 , row4 };
        public static ReplyKeyboardMarkup SettingsMarkUp = new ReplyKeyboardMarkup(rowall1);

        //Blanck 
        static KeyboardButton button22 = new KeyboardButton(" ");
        static KeyboardButton[] row22 = { button22 };
        public static ReplyKeyboardMarkup BlankMarkUp = new ReplyKeyboardMarkup(row22);
    }
}
