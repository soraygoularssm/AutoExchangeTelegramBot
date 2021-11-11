using AutoTabadol.ViewModel.ChannelExist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTabadol.DataLayer.Repository
{
    public interface IUserAccountRepository
    {
        bool CheckExitance(long ChatId);
        bool CheckChannelExitance(long ChannelId);
        long GetIdByChannelId(long ChannelId);
        bool UpdateUser(UserInfo_Table user);
        List<UserInfo_Table> FindChannelCatgoery(string Category);
    }
}
