using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TankSprint_3
{
    public class CircleCollider
    {
        public Vector2 Center { get; set; }
        public float Radius { get; set; }
        public Vector2 RelativePosition;

        public CircleCollider(Sprite sprite)
        {
            Radius = sprite.Texture.Width / 2;
            Center = sprite.Position;
            RelativePosition = Vector2.Zero;
        }

        public bool Contains(Vector2 point)
        {
            return ((point - Center).Length() <= Radius);
        }

        public bool Intersects(CircleCollider other)
        {
            RelativePosition = other.Center - this.Center;
            float distanceBetweenCenters = RelativePosition.Length();
            if (distanceBetweenCenters <= this.Radius + other.Radius) { return true; }
            else { return false; }
        }

    }
}
