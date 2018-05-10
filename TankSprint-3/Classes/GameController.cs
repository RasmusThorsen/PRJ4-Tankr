using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using TankSprint_3.Interface;

namespace TankSprint_3.Classes
{
    class GameController : IGameController
    {
        public ICollisionController CollisionController { get; set; }
        public List<Tank> Tanks { get; set; }
        public List<Stats> Stats { get; private set; } = new List<Stats>();
        public bool GameOver { get; set; } = false;
        public string gameID { get; set; }

        public GameController(List<Tank> tanks)
        {
            Tanks = tanks;
            CollisionController = new CollisionController(tanks);
        }

        public void Update()
        {
            foreach (var tank in Tanks)
            {
                tank.Update();
            }

            if (Tanks.Count == 1)
            {
                Tanks[0]._stats.Winner++;
                Stats.Add(Tanks[0]._stats);
                foreach (var tank in Stats)
                {
                    if (tank.NumOfShots != 0)
                        tank.HitRate = (float)tank.Hit / tank.NumOfShots;
                    else tank.HitRate = 0;
                }
                GameOver = true;
            }
            CollisionController.CheckCollisions(gameID);

            for(int i = 0; i < Tanks.Count; i++)
            {
                if(Tanks[i].isDead)
                {
                    Stats.Add(Tanks[i]._stats);
                    Tanks.RemoveAt(i);
                }
            }
        }

        public void Draw()
        {
            foreach (var tank in Tanks)
            {
                tank.Draw();
            }
        }

        public void MoveHandler(string x, string y, string username)
        {
            var curTank = Tanks.Find(e => e.Name == username);
            curTank.Vehicle.inputAngle = new Vector2(int.Parse(x), int.Parse(y));
        }

        public void ShootHandler(bool isShooting, string username)
        {
            var curTank = Tanks.Find(e => e.Name == username);
            if (curTank == null) return;

            curTank.isShooting = isShooting;
        }

        public void SpeedHandler(bool isSpeeding, string username)
        {
            var curTank = Tanks.Find(e => e.Name == username);
            if (curTank == null) return;

            curTank.isSpeeding = isSpeeding;
        }
    }
}
