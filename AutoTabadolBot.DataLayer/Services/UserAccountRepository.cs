using AutoTabadol.DataLayer.Repository;
using AutoTabadol.ViewModel.ChannelExist;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTabadol.DataLayer.Services
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private AutoTabadol_DBEntities db;
        public UserAccountRepository(AutoTabadol_DBEntities context)
        {
            db = context;
        }

        public bool CheckChannelExitance(long ChannelId)
        {
            return db.UserInfo_Table.Any(a => a.ChannelId == ChannelId);
        }

        public bool CheckExitance(long ChatId)
        {
            return db.UserInfo_Table.Any(a => a.ChatId == ChatId);
        }

        public List<UserInfo_Table> FindChannelCatgoery(string Category)
        {
            return db.UserInfo_Table.Where(w => w.Category1 == Category || w.Category2 == Category || w.Category3 == Category).ToList();
        }

        public long GetIdByChannelId(long ChannelId)
        {
            return db.UserInfo_Table.First(s => s.ChannelId == ChannelId).ChatId;
        }

        public bool UpdateUser(UserInfo_Table user)
        {
            var local = db.Set<UserInfo_Table>()
              .Local
              .FirstOrDefault(f => f.ChatId == user.ChatId);
            if (local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }
            db.Entry(user).State = EntityState.Modified;
            return true;
        }
    }
}
