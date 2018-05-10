using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TankSprint_3
{
    class Tank
    {
        private ICanon Canon;
        public IVehicle Vehicle; //skal være private
        private readonly IInput _input;
        public bool isDead;
        public List<IBullet> _bullets = new List<IBullet>(); //skal være private
        public string Name { get; }
        public bool isShooting = false;
        public bool isSpeeding = false;

        public Tank(IInput input, string n)
        {
            _input = input;
            Name = n;
            Canon = new StandardCanon();
            Vehicle = new Vehicle(_input);
        }

        public void Update()
        {
            foreach (var bullet in _bullets)
            {
                bullet.Update();
            }
            for (int i = 0; i < _bullets.Count; i++)
                if (_bullets[i].IsRemoved)
                    _bullets.RemoveAt(i);

            if (isSpeeding)
            {
                Vehicle.MoveForward();
            }

            Canon.CurrentTime += (float)TankGame.GameTime.ElapsedGameTime.TotalSeconds;
            if (isShooting)
            {
                Shoot();
            }

        }

        public void Draw()
        {
            foreach (var bullet in _bullets)
            {
                bullet.Draw();
            }
            Vehicle.Draw();
        }

        public void Shoot()
        {
            var newBullet = Canon.Shoot(Vehicle.Direction, Vehicle.Position);
            if(newBullet != null)_bullets.Add(newBullet);
        }

    }
}
