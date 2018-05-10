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
using TankSprint_3.Classes;

namespace TankSprint_3
{
    class Tank
    {
        private ICanon Canon;
        public IVehicle Vehicle; //skal være private
        public bool isDead;
        public List<IBullet> _bullets = new List<IBullet>(); //skal være private
        public string Name { get; }
        public bool isShooting = false;
        public bool isSpeeding = false;
        public Stats _stats { get; }

        public Tank(string n)
        {
            Name = n;
            _stats = new Stats(n);
            Canon = new StandardCanon();
            Vehicle = new Vehicle();
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

            Vehicle.Move();
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
            if (newBullet != null)
            {
                _bullets.Add(newBullet);
                _stats.NumOfShots++;
            }
        }

    }
}
