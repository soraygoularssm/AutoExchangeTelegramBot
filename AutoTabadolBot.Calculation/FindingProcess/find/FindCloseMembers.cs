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

namespace AutoTabadol.Calculation.FindingProcess.find
{
    public class FindCloseMembers
    {
        public static void ChannelCloseMemberFinder(TelegramBotClient bot)
        {
            using (UnitOfWork db = new UnitOfWork())
            {

                try
                {
                    foreach (var del in db.CloseMamberRepository.Get())
                    {
                        File.Delete(del.JsonFilePath);
                        db.CloseMamberRepository.Delete(del.Id);
                        db.Save();
                    }
                }
                catch
                {
                }

                foreach (var User in db.UserAccountRepository.Get())
                {
                    var Get = db.UserAccountRepository.GetById(User.ChatId);

                    UserInfo_Table MT = new UserInfo_Table()
                    {
                        ChatId = Get.ChatId,
                        ChannelId = Get.ChannelId,
                        Category1 = Get.Category1,
                        Category2 = Get.Category2,
                        Category3 = Get.Category3,
                        MemberCount = bot.GetChatMembersCountAsync(db.UserAccountRepository.GetById(User.ChatId).ChannelId).Result,
                        BannerPath = Get.BannerPath,
                        Recive = Get.Recive,
                        DayliTab = Get.DayliTab, LastTabTimeToDay = Get.LastTabTimeToDay
                    };
                    db.userAccountRepository.UpdateUser(MT);
                    db.Save();
                }
                try
                {

                    foreach (var item in db.SameRepository.Get())
                    {
                        JsonSetCategeories JSC = new JsonSetCategeories();
                        var ChatIdList = JsonConvert.DeserializeObject<JsonSetCategeories>(File.ReadAllText(item.JsonFilePath));
                        for (int i = 0; i < ChatIdList.Categoties.Count; i++)
                        {
                            try
                            {
                                for (int w = 1; i < ChatIdList.Categoties.Count; w++)
                                {
                                    if (db.UserAccountRepository.GetById(ChatIdList.Categoties[i].id).MemberCount > db.UserAccountRepository.GetById(ChatIdList.Categoties[i + w].id).MemberCount - 250)
                                    {
                                        if (db.UserAccountRepository.GetById(ChatIdList.Categoties[i].id).MemberCount < db.UserAccountRepository.GetById(ChatIdList.Categoties[i + w].id).MemberCount + 250)
                                        {
                                            MakeJsonString(ChatIdList.Categoties[i].id, JSC);
                                            MakeJsonString(ChatIdList.Categoties[i + w].id, JSC);
                                        }
                                    }
                                }
                            }
                            catch
                            {
                            }
                        }
                        InsertInToDB(db, JSC);
                    }
                } catch
                {
                }
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
                if (db.sameRepository.ValidAlready(JsonConvert.SerializeObject(JSC), false) == true)
                {
                }
                else
                {

                    var FileName = Guid.NewGuid();
                    File.WriteAllText(@"D:\files\Telegram Bot\AutoTabadolBot\AutoTabadolBot\JsonFiles\" + FileName + ".json", JsonConvert.SerializeObject(JSC));

                    CloseMember_Table tt = new CloseMember_Table()
                    {
                        JsonFilePath = @"D:\files\Telegram Bot\AutoTabadolBot\AutoTabadolBot\JsonFiles\" + FileName + ".json"
                    };

                    try
                    {
                        db.CloseMamberRepository.Insert(tt);
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
