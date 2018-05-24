using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using TankSprint_3.Classes;

namespace TankSprint_3.Interface
{
    public interface IPowerUp
    {
        void PowerUp(Tank poweredTank, List<Tank> otherTanks);
        void Draw();
        void Update();
        bool isUsed { get; set; }
        bool isRemoved { get; set; }
        Vector2 Position { get; }
        CircleCollider Collider { get; }
    }
}
