using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankSprint_3
{
    interface IVehicle
    {
        float Speed { get; set; }
        float RotationSpeed { get; set; }
        Texture2D Texture { get; set; }
        Vector2 Direction { get; set; }
        Vector2 Position { get; set; }
        CircleCollider Collider { get; set; }
        Vector2 inputAngle { get; set; }
        void Update();
        void Draw();
        void Move();
        void MoveForward();
    }
}
