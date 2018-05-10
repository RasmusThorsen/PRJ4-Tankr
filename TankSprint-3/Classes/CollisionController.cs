using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TankSprint_3.Interface;

namespace TankSprint_3.Classes
{
    class CollisionController : ICollisionController
    {
        private List<Tank> _tanks;
        //private Thread thr;
        public CollisionController(List<Tank> tanks)
        {
            _tanks = tanks;
            //thr = new Thread(CheckCollisions);
            //thr.IsBackground = true;
            //thr.Start();
        }

        public void CheckCollisions(string gameID)
        {         
            //while(true) her
            for (int i = 0; i < _tanks.Count; i++)
            {
                for (int j = 0; j < _tanks.Count; j++)
                {
                    if (_tanks[i] != _tanks[j])
                    {
                        var currentTank = _tanks[i];
                        foreach (var bullet in _tanks[j]._bullets)
                        {
                            if (currentTank.Vehicle.Collider.Intersects(bullet.Collider))
                            {
                                bullet.IsRemoved = true;
                                currentTank.isDead = true;
                                TankGame.Hub.Invoke("PlayerDead", _tanks[j].Name, _tanks[i].Name, gameID);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < _tanks.Count; i++)
                if (_tanks[i].isDead)
                    _tanks.RemoveAt(i);
        }
    }
}
