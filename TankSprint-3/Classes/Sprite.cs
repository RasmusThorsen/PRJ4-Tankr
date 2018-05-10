using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TankSprint_3
{
    public abstract class Sprite
    {
        private Vector2 _position;
        private Vector2 _origin;
        private float _rotation;
        private Texture2D _texture;
        private Vector2 _direction = new Vector2(0, -1);
        private CircleCollider _collider; 
        
        public Vector2 Position
        {
            get => _position;
            set
            { 
                _position = value;
            }
        }
        public Vector2 Origin
        {
            get => _origin;
            set => _origin = value;
        }
        protected float Rotation
        {
            get => _rotation;
            set => _rotation = value;
        }
        public Texture2D Texture
        {
            get => _texture;
            set => _texture = value;
        }

        public Vector2 Direction
        {
            
            get => _direction;
            set => _direction = value;
        }
        public CircleCollider Collider
        {
            get => _collider;
            set => _collider = value;
        }

        public Sprite()
        {
            Position = Vector2.Zero;
            Origin = Vector2.Zero;
            Rotation = 0;

            LoadContent();
        }

        public virtual void Draw()
        {
            TankGame.SpriteBatch.Draw(_texture, _position, null, Color.White, _rotation, _origin, 1f, SpriteEffects.None, 0f);
        }

        public abstract void Update();
        public abstract void LoadContent();


    }
}
