using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankSprint_3.Interface;

namespace TankSprint_3
{
    public class GameTimer : IGameTimer
    {
        public double TotalSeconds => TankGame.GameTime.ElapsedGameTime.TotalSeconds;
    }
}
