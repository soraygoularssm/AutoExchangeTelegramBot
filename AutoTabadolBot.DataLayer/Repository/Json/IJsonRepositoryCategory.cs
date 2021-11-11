using AutoTabadol.ViewModel.JsonClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTabadol.DataLayer.Repository.Json
{
    public interface IJsonRepositoryCategory
    {
        JsonImportViaCategory GetById(int Id);
        bool CheckExist(long ChatId, int Id);
        string Insert(int ArrayValue, int sequence, long IdValue);
        bool Update(string customer);
    }
}
