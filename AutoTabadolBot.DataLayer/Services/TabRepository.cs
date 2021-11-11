using AutoTabadol.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTabadol.DataLayer.Services
{
    public class TabRepository : ITabRepository
    {

        private AutoTabadol_DBEntities db;
        public TabRepository(AutoTabadol_DBEntities context)
        {
            db = context;
        }

        public bool UpdateTable(Tab_Table info)
        {
            var local = db.Set<Tab_Table>()
              .Local
              .FirstOrDefault(f => f.Id == info.Id);
            if (local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }
            db.Entry(info).State = EntityState.Modified;
            return true;
        }
    }
}
