using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TankSprint_3.Interface;

namespace TankSprint_3.Classes
{
    class Graphics : IGraphics
    {
        public Texture2D Load(string name)
        {
            return TankGame.GlobalContent.Load<Texture2D>(name);
        }

        public void Draw(Texture2D texture, Vector2 position, Color col, float rotation, Vector2 origin)
        {
            TankGame.SpriteBatch.Draw(texture, position, null, col, rotation, origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
