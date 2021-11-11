using AutoTabadol.DataLayer.Repository.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTabadol.DataLayer.Services.Json
{
    public class JsonExchangedRepository : IJsonExchangedRepository
    {
        private AutoTabadol_DBEntities db;
        public JsonExchangedRepository(AutoTabadol_DBEntities context)
        {
            db = context;
        }
        public bool IsItValid(string jsonStr)
        {
            return db.Exchanged_Table.Any(a => a.Exchanged == jsonStr);
        }
    }
}
