using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankSprint_3.Classes
{
    public class Stats
    {
        public string UserName { get; }
        public int Kills { get; set; } = 0;
        public int NumOfShots { get; set; } = 0;
        public int HitRate { get; set; } = 0;
        public int Distance { get; set; } = 0;
        public int Dead { get; set; } = 0;
        public int Winner { get; set; } = 0;
        public int Hit { get; set; } = 0;

        public Stats(string n) => UserName = n;
    }
}
