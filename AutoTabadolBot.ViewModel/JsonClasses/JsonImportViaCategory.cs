using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTabadol.ViewModel.JsonClasses
{
    public class JsonImportViaCategory
    {
        public Categoty[] Categoties { get; set; }
    }

    public class Categoty
    {
        public long id { get; set; }
    }
}
