using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using TankSprint_3.Interface;

namespace TankSprint_3.Classes
{
    class GameController : IGameController
    {
        public ICollisionController CollisionController { get; set; }
        public List<Tank> Tanks { get; set; }
        public bool GameOver { get; set; } = false;

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

            if (Tanks.Count == 1) GameOver = true;
            CollisionController.CheckCollisions(); //køres i separat tråd?? Ændrer dog på listen i main tråd. spørg henrik!
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
            curTank?.Vehicle.Move(x, y);
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
