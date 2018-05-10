using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TankSprint_3
{
    public interface ICanon
    {
        float ShootDelay { get; set; }
        float CurrentTime { get; set; }
        Bullet Shoot(Vector2 direction, Vector2 position);
    }
}
