using AutoTabadol.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace AutoTabadol.Process.Keyboards
{
    public class GenericInlineKeyboard
    {
        public InlineKeyboardMarkup markupgrouping1(long ChatId)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var cat = db.CategoryRepository.GetAllCategories();
                int rownum1 = cat.Count / 4;
                InlineKeyboardButton[][] rows = new InlineKeyboardButton[rownum1 + 1][];
                int i = 0;
                int f = 0;
                int s = 1;
                while (i < rownum1 + 1)
                {
                    var u1 = f + 1;
                    var u2 = s + 1;
                    if (i == rownum1)
                    {
                        rows[i] = new InlineKeyboardButton[]
                    {
                    InlineKeyboardButton.WithCallbackData("صفحه بعد", "next")
                    };
                    }
                    else
                    {
                        rows[i] = new InlineKeyboardButton[]
                    {
                    InlineKeyboardButton.WithCallbackData(db.CategoriesRepository.GetById(u1).Category,db.CategoriesRepository.GetById(u1).Code) , InlineKeyboardButton.WithCallbackData(db.CategoriesRepository.GetById(u2).Category, db.CategoriesRepository.GetById(u2).Code)
                    };
                    }
                    f = f + 2;
                    s = s + 2;
                    i++;
                }
                InlineKeyboardMarkup inline = new InlineKeyboardMarkup(rows);
                return inline;
            }
        }
        public InlineKeyboardMarkup markupgrouping2(long ChatId)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                var cat = db.CategoryRepository.GetAllCategories();
                var rownum2 = cat.Count / 4;
                var rownum3 = cat.Count / 2;
                InlineKeyboardButton[][] rows = new InlineKeyboardButton[rownum2 + 1][];
                int i = 0;
                int f = rownum3;
                int s = rownum3 + 1;
                while (i < rownum2 + 1)
                {
                    var u1 = f + 1;
                    var u2 = s + 1;
                    if (i == rownum2)
                    {
                        rows[i] = new InlineKeyboardButton[]
                    {
                    InlineKeyboardButton.WithCallbackData("بازگشت", "back")
                    };
                    }
                    else
                    {
                        rows[i] = new InlineKeyboardButton[]
                    {
                    InlineKeyboardButton.WithCallbackData(db.CategoriesRepository.GetById(u1).Category,db.CategoriesRepository.GetById(u1).Code) , InlineKeyboardButton.WithCallbackData(db.CategoriesRepository.GetById(u2).Category, db.CategoriesRepository.GetById(u2).Code)
                    };
                    }
                    f = f + 2;
                    s = s + 2;
                    i++;
                }
                InlineKeyboardMarkup inline = new InlineKeyboardMarkup(rows);
                return inline;
            }
        }
    }
}
