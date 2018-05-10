using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TankSprint_3
{
    class Canon : ICanon
    {
        public float ShootDelay { get; set; }
        public float CurrentTime { get; set; }
        public void Shoot(GameTime gameTime, Vector2 direction, Vector2 position)
        {
            CurrentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Keyboard.GetState().IsKeyDown(_input.Shoot) && CurrentTime > ShootDelay)
            {
                SpriteBatch s = SpriteBatch;
                _bullets.Add(new Bullet(ref s, Content, direction, position));
                CurrentTime = 0f;
            }
        }
    }
}
