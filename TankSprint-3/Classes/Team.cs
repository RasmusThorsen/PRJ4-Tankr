using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankSprint_3.Classes
{
    class Team
    {
        public List<Tank> Tanks { get; private set; }
        public int Score { get; set; } = 0;

        public Team()
        {
            Tanks = new List<Tank>();
        }
    }
}
