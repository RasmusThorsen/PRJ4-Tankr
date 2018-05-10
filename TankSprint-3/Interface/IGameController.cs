using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankSprint_3.Classes;

namespace TankSprint_3.Interface
{
    interface IGameController
    {
        ICollisionController CollisionController { get; set; }
        List<Tank> Tanks { get; set; }
        bool GameOver { get; set; }
        void Draw();
        void Update();
        void MoveHandler(string x, string y, string username);
        void ShootHandler(bool isShooting, string username);
        void SpeedHandler(bool isSpeeding, string username);
        string gameID { get; set; }
        List<Stats> Stats { get; }
    }
}
