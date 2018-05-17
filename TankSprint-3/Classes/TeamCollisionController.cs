using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankSprint_3.Interface;

namespace TankSprint_3.Classes
{
    class TeamCollisionController : ICollisionController
    {
        private List<Tank> _teamRed;
        private List<Tank> _teamBlue;
        public event EventHandler<CollisionEventArgs> Collision; 
        

        public TeamCollisionController(List<Tank> teamRed, List<Tank> teamBlue)
        {
            _teamRed = teamRed;
            _teamBlue = teamBlue;
        }
        public void CheckCollisions(string gameID)
        {
            for (int i = 0; i < _teamRed.Count; i++)
            {
                for (int j = 0; j < _teamBlue.Count; j++)
                {
                    if(_teamRed[i].isDead) continue;
                    foreach (var bullet in _teamBlue[j]._bullets)
                    {
                        if (_teamRed[i].Vehicle.Collider.Intersects(bullet.Collider))
                        {
                            bullet.IsRemoved = true;
                            var handler = Collision;
                            handler?.Invoke(this, new CollisionEventArgs
                            {
                                killerTank = _teamBlue[j].Name,
                                deadTank = _teamRed[i].Name,
                                teamColor = "blue"
                            });
                        }
                    }                   
                }
            }

            for (int i = 0; i < _teamBlue.Count; i++)
            {
                for (int j = 0; j < _teamRed.Count; j++)
                {
                    if (_teamBlue[i].isDead) continue;
                    foreach (var bullet in _teamRed[j]._bullets)
                    {
                        if (_teamBlue[i].Vehicle.Collider.Intersects(bullet.Collider))
                        {
                            var handler = Collision;
                            handler?.Invoke(this, new CollisionEventArgs
                            {
                                killerTank = _teamRed[j].Name,
                                deadTank = _teamBlue[i].Name,
                                teamColor = "red"
                            });
                        }
                    }
                }
            }
        }
    }

    public class CollisionEventArgs : EventArgs
    {
        public string killerTank { get; set; }
        public string deadTank { get; set; }
        public string teamColor { get; set; }
    }
}
