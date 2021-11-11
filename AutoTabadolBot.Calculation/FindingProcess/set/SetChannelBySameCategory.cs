using AutoTabadol.Calculation.FindingProcess.find;
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
    public class SetChannelBySameCategory
    {
        public static void ChannelSeterByCategory(TelegramBotClient bot)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                try
                {
                    foreach (var del in db.SameRepository.Get())
                    {
                        File.Delete(del.JsonFilePath);
                        db.SameRepository.Delete(del.Id);
                        db.Save();
                    }
                }
                catch
                {
                }

                foreach (var item in db.TabRepository.Get())
                {
                    JsonSetCategeories JSC = new JsonSetCategeories();
                    var row = db.jsonCategory.GetById(item.Id);
                    for (int i = 0; i < row.Categoties.Count(); i++)
                    {
                        long ChatId = db.jsonCategory.GetById(item.Id).Categoties[i].id;
                        bool IsItExist;
                        foreach (var item2 in db.TabRepository.Get())
                        {
                            IsItExist = db.jsonCategory.CheckExist(ChatId, item2.Id);
                            if (IsItExist == true)
                            {
                                var row2 = db.jsonCategory.GetById(item2.Id);
                                for (int w = 1; w <= row2.Categoties.Count(); w++)
                                {
                                    try
                                {
                                    bool IsItExist2 = db.jsonCategory.CheckExist(db.jsonCategory.GetById(item.Id).Categoties[i + w].id, item2.Id);
                                    if (IsItExist2 == true)
                                    {
                                        MakeJsonString(db.jsonCategory.GetById(item.Id).Categoties[i].id, JSC);
                                        MakeJsonString(db.jsonCategory.GetById(item.Id).Categoties[i + w].id, JSC);
                                    }
                                }
                                catch
                                {
                                }
                                }
                            }
                        }
                    }
                    InsertInToDB(db, JSC);
                }
                FindCloseMembers.ChannelCloseMemberFinder(bot);
            }
        }
        public static void MakeJsonString(long ChatId, JsonSetCategeories JSC)
        {
            if (JsonConvert.DeserializeObject<JsonSetCategeories>(JsonConvert.SerializeObject(JSC)).Categoties.Any(a => a.id == ChatId))
            {
            }
            else
            {
                JSC.Categoties.Add(new CategorySeted { id = ChatId });
            }
        }
        public static void InsertInToDB(UnitOfWork db, JsonSetCategeories JSC)
        {
            if (JsonConvert.DeserializeObject<JsonSetCategeories>(JsonConvert.SerializeObject(JSC)).Categoties.Count == 0)
            {
            }
            else
            {
                if (db.sameRepository.ValidAlready(JsonConvert.SerializeObject(JSC), true) == true)
                {
                }
                else
                {
                    var FileName = Guid.NewGuid();
                    File.WriteAllText(@"D:\files\Telegram Bot\AutoTabadolBot\AutoTabadolBot\JsonFiles\" + FileName + ".json", JsonConvert.SerializeObject(JSC));

                    SameCategory_Table tt = new SameCategory_Table()
                    {
                        JsonFilePath = @"D:\files\Telegram Bot\AutoTabadolBot\AutoTabadolBot\JsonFiles\" + FileName + ".json"
                    };

                    try
                    {
                        db.SameRepository.Insert(tt);
                        db.Save();
                    }
                    catch
                    {
                    }
                }
            }
        }
    }
}
