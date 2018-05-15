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
    public class EnemyBigTurns : Sprite, IPowerUp
    {
        public bool isUsed { get; set; }
        public bool isRemoved { get; set; }

        private Random _rand = new Random();
        private double _currentTime = 0;
        private double _lifeSpan = 5;
        private float _defaultRotation = 3f;
        private Tank _tank;
        private List<Tank> _tankList;

        public void PowerUp(Tank poweredTank, List<Tank> otherTanks)
        {
            _tankList = otherTanks;
            _tank = otherTanks.Find(e => e.Name == poweredTank.Name);
            foreach (var otherTank in otherTanks)
            {
                if(otherTank != _tank)
                    otherTank.Vehicle.RotationSpeed = 1f;
            }
        }

        public override void Update()
        {
            _currentTime += TankGame.GameTime.ElapsedGameTime.TotalSeconds;
            if (_currentTime > _lifeSpan)
            {
                foreach (var tank in _tankList)
                {
                    tank.Vehicle.RotationSpeed = _defaultRotation;
                }
               isRemoved = true;
            }
        }


        public override void LoadContent()
        {
            Texture = TankGame.GlobalContent.Load<Texture2D>("EnemyBigTurns");
            Origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
            Position = new Vector2(_rand.Next(TankGame.Graphics.PreferredBackBufferWidth),
                _rand.Next(TankGame.Graphics.PreferredBackBufferHeight));
            Collider = new CircleCollider(this);
            Collider.Center = Position;
        }
    }
}
