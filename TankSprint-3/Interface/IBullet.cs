using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using TankSprint_3.Classes;

namespace TankSprint_3.Interface
{
    public interface IBullet
    {
        bool IsRemoved { get; set; }
        float LifeSpan { get; }
        float Speed { get; }
        CircleCollider Collider { get; set; }
        void Update();
        void Draw();
    }
}
