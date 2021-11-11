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
using Telegram.Bot.Types;

namespace AutoTabadol.Calculation.ExchangingProcess
{
    public class Exchanging
    {

        static List<Categoty> CategoryList;
        static JsonImportViaCategory JE;
        public static void exchanger(TelegramBotClient bot)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                try
                {
                   if (DateTime.Now.Hour == 20)
                    {
                        foreach (var del in db.ExchangedRepository.Get())
                        {
                            db.SameRepository.Delete(del.Id);
                            db.Save();
                        }
                    }
                }
                catch
                {
                }

                foreach (var item in db.CloseMamberRepository.Get())
                {
                    JsonImportViaCategory JSC = new JsonImportViaCategory();
                    SetByTime(db);
                    try
                    {
                        for (int i = 0; i < CategoryList.Count(); i++)
                        {
                            for (int w = 1; w < CategoryList.Count(); w++)
                            {
                                if (db.UserAccountRepository.GetById(CategoryList[i].id).LastTabTimeToDay != DateTime.Now.Hour)
                                {
                                    if (db.UserAccountRepository.GetById(CategoryList[w].id).LastTabTimeToDay != DateTime.Now.Hour)
                                    {
                                        if (i != w)
                                        {
                                            if (db.ExchangedRepository.Get().Count() == 0)
                                            {
                                                DoExchanging(bot, db, JSC, i, w);
                                            }
                                            else
                                            {
                                                Console.WriteLine(CategoryList.Count);
                                                JE = new JsonImportViaCategory();
                                                MakeJsonString(CategoryList[i].id, CategoryList[w].id, JE);
                                                if (db.exchangedJsonRepository.IsItValid(JsonConvert.SerializeObject(JE)) == false)
                                                {
                                                    JE = new JsonImportViaCategory();
                                                    MakeJsonString(CategoryList[i].id, CategoryList[w].id, JE, true);
                                                    if (db.exchangedJsonRepository.IsItValid(JsonConvert.SerializeObject(JE)) == false)
                                                    {
                                                        DoExchanging(bot, db, JSC, i, w);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        public static void SetByTime(UnitOfWork db)
        {
            try
            {

                foreach (var ByTheTime in db.CloseMamberRepository.Get())
                {
                    CategoryList = new List<Categoty>();
                    var ChatIdList = JsonConvert.DeserializeObject<JsonSetCategeories>(System.IO.File.ReadAllText(ByTheTime.JsonFilePath));
                    for (int i = 0; i < ChatIdList.Categoties.Count; i++)
                    {
                        switch (DateTime.Now.Hour)
                        {
                            case 8:
                                if (db.UserAccountRepository.GetById(ChatIdList.Categoties[i].id).DayliTab == 6 || db.UserAccountRepository.GetById(ChatIdList.Categoties[i].id).DayliTab == 4)
                                {
                                    CategoryList.Add(new Categoty { id = ChatIdList.Categoties[i].id });
                                }
                                break;
                            case 10:
                                if (db.UserAccountRepository.GetById(ChatIdList.Categoties[i].id).DayliTab == 6 || db.UserAccountRepository.GetById(ChatIdList.Categoties[i].id).DayliTab == 5 || db.UserAccountRepository.GetById(ChatIdList.Categoties[i].id).DayliTab == 3)
                                {
                                    CategoryList.Add(new Categoty { id = ChatIdList.Categoties[i].id });
                                }
                                break;
                            case 12 :
                                if (db.UserAccountRepository.GetById(ChatIdList.Categoties[i].id).DayliTab == 6 || db.UserAccountRepository.GetById(ChatIdList.Categoties[i].id).DayliTab == 5 || db.UserAccountRepository.GetById(ChatIdList.Categoties[i].id).DayliTab == 4 || db.UserAccountRepository.GetById(ChatIdList.Categoties[i].id).DayliTab == 2)
                                {
                                    CategoryList.Add(new Categoty { id = ChatIdList.Categoties[i].id });
                                }
                                break;
                            case 14:
                                if (db.UserAccountRepository.GetById(ChatIdList.Categoties[i].id).DayliTab == 6 || db.UserAccountRepository.GetById(ChatIdList.Categoties[i].id).DayliTab == 5 || db.UserAccountRepository.GetById(ChatIdList.Categoties[i].id).DayliTab == 3)
                                {
                                    CategoryList.Add(new Categoty { id = ChatIdList.Categoties[i].id });
                                }
                                break;
                            case 16:
                                if (db.UserAccountRepository.GetById(ChatIdList.Categoties[i].id).DayliTab == 6 || db.UserAccountRepository.GetById(ChatIdList.Categoties[i].id).DayliTab == 5 || db.UserAccountRepository.GetById(ChatIdList.Categoties[i].id).DayliTab == 4 || db.UserAccountRepository.GetById(ChatIdList.Categoties[i].id).DayliTab == 1)
                                {
                                    CategoryList.Add(new Categoty { id = ChatIdList.Categoties[i].id });
                                }
                                break;
                            case 18:
                                if (db.UserAccountRepository.GetById(ChatIdList.Categoties[i].id).DayliTab == 6 || db.UserAccountRepository.GetById(ChatIdList.Categoties[i].id).DayliTab == 5 || db.UserAccountRepository.GetById(ChatIdList.Categoties[i].id).DayliTab == 4 || db.UserAccountRepository.GetById(ChatIdList.Categoties[i].id).DayliTab == 3 || db.UserAccountRepository.GetById(ChatIdList.Categoties[i].id).DayliTab == 2)
                                {
                                    CategoryList.Add(new Categoty { id = ChatIdList.Categoties[i].id });
                                }
                                break;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public static void DoExchanging(TelegramBotClient bot, UnitOfWork db, JsonImportViaCategory JSC, int i, int w)
        {
            bot.ForwardMessageAsync(db.UserAccountRepository.GetById(CategoryList[i].id).ChannelId, -1001367898784, (int)db.UserAccountRepository.GetById(CategoryList[w].id).BannerPath);
            bot.ForwardMessageAsync(db.UserAccountRepository.GetById(CategoryList[w].id).ChannelId, -1001367898784, (int)db.UserAccountRepository.GetById(CategoryList[i].id).BannerPath);

            MakeJsonString(CategoryList[i].id, CategoryList[w].id, JSC);
            InsertInToDB(db, JSC);

            SaveUserChanges(db, i);
            SaveUserChanges(db, w);
        }

        public static void SaveUserChanges(UnitOfWork db, int user)
        {
            var Get1 = db.UserAccountRepository.GetById(CategoryList[user].id);
            UserInfo_Table MT = new UserInfo_Table()
            {
                ChatId = Get1.ChatId,
                ChannelId = Get1.ChannelId,
                Category1 = Get1.Category1,
                Category2 = Get1.Category2,
                Category3 = Get1.Category3,
                MemberCount = Get1.MemberCount,
                BannerPath = Get1.BannerPath,
                Recive = Get1.Recive,
                LastTabTimeToDay = DateTime.Now.Hour,
                DayliTab = Get1.DayliTab
            };
            db.userAccountRepository.UpdateUser(MT);
            db.Save();
        }

        public static void MakeJsonString(long FstChatId, long SndChatId, JsonImportViaCategory JSC, bool reverse = false)
        {
            //if (JsonConvert.DeserializeObject<JsonExchanged>(JsonConvert.SerializeObject(JSC)).Channels.Any(a => a.id == FstChatId))
            //{
            //}
            //else
            //{

            JSC.Categoties = new Categoty[2];
            JSC.Categoties[0] = new Categoty();
            JSC.Categoties[1] = new Categoty();

            if (reverse == false)
            {
                JSC.Categoties[0].id = FstChatId;
                JSC.Categoties[1].id = SndChatId;
            }
            else
            {
                JSC.Categoties[0].id = SndChatId;
                JSC.Categoties[1].id = FstChatId;
            }

            //}
        }

        public static void InsertInToDB(UnitOfWork db, JsonImportViaCategory JSC)
        {
            if (JsonConvert.DeserializeObject<JsonImportViaCategory>(JsonConvert.SerializeObject(JSC)).Categoties.Count() == 0)
            {
            }
            else
            {

                Exchanged_Table tt = new Exchanged_Table()
                {
                    Exchanged = JsonConvert.SerializeObject(JSC)
                };

                try
                {
                    db.ExchangedRepository.Insert(tt);
                    db.Save();
                }
                catch
                {
                }
            }
        }
    }
}
