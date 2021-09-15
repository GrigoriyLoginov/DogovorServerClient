using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogService
{
    public class Dogovor
    {
        public int ID { get; set; }
        public string DOG_NO { get; set; } = string.Empty;
        public DateTime DOG_DATE { get; set; }
        public DateTime LAST_UPDATE { get; set; }
        public bool ACTUAL { get; set; }
    }
}
