using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankSprint_3.Interface
{
    public interface IGraphics
    {
        Texture2D Load(string name);

        void Draw(Texture2D texture, Vector2 position, Color col, float rotation, Vector2 origin);
    }
}
