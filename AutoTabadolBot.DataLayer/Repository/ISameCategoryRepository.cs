using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTabadol.DataLayer.Repository
{
    public interface ISameCategoryRepository
    {
        bool ValidAlready(string jsonStr, bool condition);
        bool UpdateTable(SameCategory_Table info);
    }
}
