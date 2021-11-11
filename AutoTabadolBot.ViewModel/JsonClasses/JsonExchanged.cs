using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTabadol.ViewModel.JsonClasses
{
    public class JsonExchanged
    {
        public List<CatAndTimeSeted> Channels = new List<CatAndTimeSeted>();
    }
    public class CatAndTimeSeted
    {
        public long id { get; set; }
        public int time { get; set; }
    }
}
