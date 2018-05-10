using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TankSprint_3
{
    class Vehicle : Sprite, IVehicle
    {
        public float Speed { get; set; } = 3f;
        public float RotationSpeed { get; set; } = 10f;
        private readonly IInput _input;

        private Vector2 _position;
        public new Vector2 Position
        {
            get => _position;
            set
            {
                if (value.X > 16 && value.X < TankGame.Graphics.PreferredBackBufferWidth - Texture.Width / 2 &&
                    value.Y > 16 && value.Y < TankGame.Graphics.PreferredBackBufferHeight - Texture.Height / 2)
                    _position = value;
            }
        }

        public Vehicle(IInput input)
        {
            _input = input;
            Position = new Vector2(50, 50);
            Collider = new CircleCollider(this);
        }

        public override void Draw()
        {
            TankGame.SpriteBatch.Draw(Texture, Position, null, Color.White, Rotation, Origin, 1f, SpriteEffects.None, 0f);
        }

        public override void LoadContent()
        {
            Texture = TankGame.GlobalContent.Load<Texture2D>("Tank");
            Origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
        }

        public void MoveForward()
        {
            Position += Direction * Speed;
            Collider.Center = Position;
        }

        public void Move(string x, string y)
        {
            //var state = Keyboard.GetState();
            //foreach (var key in state.GetPressedKeys())
            //{
            //    Direction = new Vector2((float)Math.Cos(MathHelper.ToRadians(90) - Rotation), -(float)Math.Sin(MathHelper.ToRadians(90) - Rotation));
            //    if (key == _input.Left) Rotation -= MathHelper.ToRadians(RotationSpeed);
            //    else if (key == _input.Right) Rotation += MathHelper.ToRadians(RotationSpeed);
            //    else if (key == _input.Up)
            //    {
            //        Position += Direction * Speed;
            //    }
            //}

            if (int.Parse(x) > 0)
            {
                Rotation += MathHelper.ToRadians(RotationSpeed);

            } else if (int.Parse(x) < 0)
            {
                Rotation -= MathHelper.ToRadians(RotationSpeed);
            }

            Direction = new Vector2((float)Math.Cos(MathHelper.ToRadians(90) - Rotation), -(float)Math.Sin(MathHelper.ToRadians(90) - Rotation));

            //var angle = Math.Acos(vector.X / vector.Length());
            //if (Rotation != (float)angle)
            //{
            //    Rotation += MathHelper.ToRadians(0.5f);
            //}
        }

        public override void Update() { }
    }
}
