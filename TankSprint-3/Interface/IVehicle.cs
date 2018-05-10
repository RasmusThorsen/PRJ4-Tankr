using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TankSprint_3
{
    interface IVehicle
    {
        float Speed { get; set; }
        float RotationSpeed { get; set; }
        Vector2 Direction { get; set; }
        Vector2 Position { get; set; }
        CircleCollider Collider { get; set; }
        void Update();
        void Draw();
        void Move(string x, string y);
        void MoveForward();
    }
}
