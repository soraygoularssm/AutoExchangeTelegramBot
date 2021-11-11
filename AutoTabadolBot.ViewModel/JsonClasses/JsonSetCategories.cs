using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTabadol.ViewModel.JsonClasses
{
    public class JsonSetCategeories
    {
        public List<CategorySeted> Categoties = new List<CategorySeted>();
    }
    public class CategorySeted
    {
        public long id { get; set; }
    }
} 
