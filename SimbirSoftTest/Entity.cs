using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbirSoftTest
{
    public class Stats
    {
        ///// <summary>
        ///// Статистика в базу
        ///// </summary>
        public long Id { get; set; }
        public string Status { get; set; }
        public long Value { get; set; }
        public System.DateTime CreateDate { get; set; }
    }
}
