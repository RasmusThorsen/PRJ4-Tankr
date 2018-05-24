using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using TankSprint_3.Classes;

namespace TankSprint_3.Interface
{
    public interface ICanon
    {
        float ShootDelay { get; set; }
        float CurrentTime { get; set; }
        Bullet Shoot(Vector2 direction, Vector2 position);
    }
}
