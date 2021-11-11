using AutoTabadol.DataLayer.Repository;
using AutoTabadol.ViewModel.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTabadol.DataLayer.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private AutoTabadol_DBEntities db;

        public CategoryRepository(AutoTabadol_DBEntities context)
        {
            db = context;
        }

        public List<ListCategoriesNameViewModel> GetAllCategories()
        {
            return db.Category_Table.Select(s => new ListCategoriesNameViewModel
            {
                Category = s.Category,
                Code = s.Code
            }).ToList();
        }

        public Category_Table GetCategoryByCode(string Code)
        {
            return db.Category_Table.First(s => s.Code == Code);
        }
    }
}
