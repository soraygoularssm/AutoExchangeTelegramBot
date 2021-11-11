using AutoTabadol.DataLayer.Repository.Json;
using AutoTabadol.ViewModel.JsonClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTabadol.DataLayer.Services.Json
{
    class JsonRepositoryCategory : IJsonRepositoryCategory
    {
        private AutoTabadol_DBEntities db;
        public JsonRepositoryCategory(AutoTabadol_DBEntities context)
        {
            db = context;
        }

        public bool CheckExist(long ChatId, int Id)
        {
            var GetJsonFile = db.Tab_Table.SingleOrDefault(s => s.Id == Id).JsonFilePath;
            var JsonStr = File.ReadAllText(GetJsonFile);
            var DesJson = JsonConvert.DeserializeObject<JsonImportViaCategory>(JsonStr);
            return DesJson.Categoties.Any(a => a.id == ChatId);
        }

        public JsonImportViaCategory GetById(int Id)
        {
            var GetJsonFile = db.Tab_Table.SingleOrDefault(s => s.Id == Id).JsonFilePath;
            var JsonStr = File.ReadAllText(GetJsonFile);
            return JsonConvert.DeserializeObject<JsonImportViaCategory>(JsonStr);


        }

        public string Insert(int ArrayValue, int sequence, long IdValue)
        {
            throw new NotImplementedException();
        }

        public bool Update(string customer)
        {
            throw new NotImplementedException();

        }
    }
}
