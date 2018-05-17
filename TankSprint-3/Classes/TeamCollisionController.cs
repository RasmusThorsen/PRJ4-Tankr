using System;
using System.Collections.Generic;
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
            Parallel.For(0, _teamRed.Count, i =>
            {
                for (int j = 0; j < _teamBlue.Count; i++)
                {
                    foreach (var bullet in _teamBlue[j]._bullets)
                    {
                        if (_teamRed[i].Vehicle.Collider.Intersects(bullet.Collider))
                        {

                        }
                    }                   
                }
            });
        }
    }

    internal class CollisionEventArgs
    {
    }
}
