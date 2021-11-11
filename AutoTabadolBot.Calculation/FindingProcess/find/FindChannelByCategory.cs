using AutoTabadol.DataLayer;
using AutoTabadol.DataLayer.Context;
using AutoTabadol.ViewModel.JsonClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace AutoTabadol.Calculation.FindingProcess
{
    public class FindChannelByCategory
    {
        public static void ChannelFinderByCategory(TelegramBotClient bot)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                try
                {
                    foreach (var del in db.TabRepository.Get())
                    {
                        File.Delete(del.JsonFilePath);
                        db.TabRepository.Delete(del.Id);
                        db.Save();
                    }
                }
                catch
                {
                }

                List<UserInfo_Table> category_getter;
                int w = 0;

                foreach (var cat in db.CategoryRepository.GetAllCategories())
                {
                    category_getter = db.userAccountRepository.FindChannelCatgoery(cat.Code);
                    JsonImportViaCategory RT = new JsonImportViaCategory();
                    int i = 0;

                    RT.Categoties = new Categoty[category_getter.Count];

                    try
                    {
                        while (i < category_getter.Count)
                        {
                            RT.Categoties[i] = new Categoty();
                            RT.Categoties[i].id = category_getter[i].ChatId;
                            i++;
                        }
                    }
                    catch
                    {
                    }

                    w++;

                    var FileName = Guid.NewGuid();
                    File.WriteAllText(@"D:\files\Telegram Bot\AutoTabadolBot\AutoTabadolBot\JsonFiles\" + FileName + ".json", JsonConvert.SerializeObject(RT));

                    Tab_Table tt = new Tab_Table()
                    {
                        Id = w,
                        JsonFilePath = @"D:\files\Telegram Bot\AutoTabadolBot\AutoTabadolBot\JsonFiles\" + FileName + ".json"
                    };

                    try
                    {
                        db.TabRepository.Insert(tt);
                        db.Save();
                    }
                    catch
                    {
                        db.tabRepository.UpdateTable(tt);
                        db.Save();
                    }
                }
                SetChannelBySameCategory.ChannelSeterByCategory(bot);
            }
        }
    }
}
