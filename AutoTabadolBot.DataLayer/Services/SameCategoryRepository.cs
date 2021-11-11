using AutoTabadol.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTabadol.DataLayer.Services
{
    public class SameCategoryRepository : ISameCategoryRepository
    {
        private AutoTabadol_DBEntities db;
        public SameCategoryRepository(AutoTabadol_DBEntities context)
        {
            db = context;
        }

        public bool UpdateTable(SameCategory_Table info)
        {
            var local = db.Set<SameCategory_Table>()
              .Local
              .FirstOrDefault(f => f.Id == info.Id);
            if (local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }
            db.Entry(info).State = EntityState.Modified;
            return true;
        }

        public bool ValidAlready(string jsonStr, bool condition)
        {
            try
            {
                if (condition == true)
                {
                    List<JsonString> DbList = new List<JsonString>();

                    foreach (var item in db.SameCategory_Table.ToList())
                    {
                        DbList.Add(new JsonString { JsonStr = File.ReadAllText(item.JsonFilePath) });
                    }

                    return DbList.Any(a => a.JsonStr == jsonStr);
                }
                else
                {
                    List<JsonString> DbList = new List<JsonString>();

                    foreach (var item in db.CloseMember_Table.ToList())
                    {
                        DbList.Add(new JsonString { JsonStr = File.ReadAllText(item.JsonFilePath) });
                    }

                    return DbList.Any(a => a.JsonStr == jsonStr);
                }
            } catch
            {
                return false;
            }
        }
    }
    public class JsonString
    {
        public string JsonStr { get; set; }
    }
}
