using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using TankSprint_3.Interface;

namespace TankSprint_3.Classes
{
    class CollisionController : ICollisionController
    {
        private List<Tank> _tanks;
        private List<IPowerUp> _powerUps;
        public event EventHandler<Arguments> Collision; 

        public CollisionController(List<Tank> tanks, List<IPowerUp> powerUps)
        {
            _tanks = tanks;
            _powerUps = powerUps;
        }

        public void CheckCollisions(string gameID)
        {
            Parallel.For(0, _tanks.Count, i =>
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
                                //bullet.IsRemoved = true;
                                //currentTank.isDead = true;
                                //TankGame.Hub.Invoke("PlayerDead", _tanks[j].Name, _tanks[i].Name, gameID);
                                //currentTank._stats.Dead++;
                                //_tanks[j]._stats.Hit++;
                                //_tanks[j]._stats.Kills++;

                                var handler = Collision;
                                handler?.Invoke(this, new Arguments
                                {
                                    Bullet = bullet,
                                    DeadTank = currentTank.Name,
                                    KillerTank = _tanks[j].Name
                                });
                            }
                        }

                        foreach (var powerUp in _powerUps)
                        {
                            if (currentTank.Vehicle.Collider.Intersects(powerUp.Collider))
                            {
                                powerUp.PowerUp(currentTank, _tanks);
                                powerUp.Collider.Center = new Vector2(-500, -500);
                                powerUp.isUsed = true;
                            }
                        }
                    }
                }
            }); 
        }
    }

    public class Arguments
    {
        public string KillerTank { get; set; }
        public string DeadTank { get; set; }
        public IBullet Bullet { get; set; }
    }
}
