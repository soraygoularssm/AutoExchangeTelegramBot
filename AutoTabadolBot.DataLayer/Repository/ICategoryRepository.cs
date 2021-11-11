using AutoTabadol.ViewModel.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTabadol.DataLayer.Repository
{
    public interface ICategoryRepository
    {
        List<ListCategoriesNameViewModel> GetAllCategories();
        Category_Table GetCategoryByCode(string Code);
    }
}
