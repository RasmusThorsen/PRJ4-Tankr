using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankSprint_3.Interface
{
    interface IGameMode
    {
        IGameController GameController { get; set; }
        void initGame(string[] players);
    }
}
