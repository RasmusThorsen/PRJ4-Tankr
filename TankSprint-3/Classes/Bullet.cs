using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TankSprint_3.Interface;

namespace TankSprint_3.Classes
{
    public class Bullet : Sprite, IBullet
    {
        public float Speed { get; set; } = 5f;
        public float LifeSpan { get; set; } = 4f;
        private float _currentTime = 0f;
        public bool IsRemoved { get; set; }

        public Bullet(Vector2 direction, Vector2 position)
        {
            Direction = direction;
            Position = position;
            IsRemoved = false;
            Collider = new CircleCollider(this);
            LoadContent();
        }

        public override void Update()
        {
            _currentTime += (float)TankGame.GameTime.ElapsedGameTime.TotalSeconds;
            if (_currentTime > LifeSpan) IsRemoved = true;
            Position += Direction * Speed;
            Collider.Center = Position;
        }

        public override void LoadContent()
        {
            Texture = TankGame.GlobalContent.Load<Texture2D>("Bullet");
            Origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
        }
    }
}
