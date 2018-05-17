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
    class TeamGameMode : IGameMode
    {
        public IGameController GameController { get; set; }
        private Random _rand = new Random();

        public void initGame(string[] args)
        {
            Team teamRed = new Team(), teamBlue = new Team();
            var playerNum = int.Parse(args[2]);

            for (var i = 0; i < playerNum; i++)
            {
                if(i % 2 == 0) teamRed.Tanks.Add(new Tank(args[i + 3]));
                else teamBlue.Tanks.Add(new Tank(args[i + 3]));
            }

            foreach (var tank in teamRed.Tanks)
            {
                tank.Vehicle.Position = new Vector2(_rand.Next(TankGame.Graphics.PreferredBackBufferWidth), _rand.Next(TankGame.Graphics.PreferredBackBufferHeight - 30));
                tank.Vehicle.Collider.Center = tank.Vehicle.Position;
                tank.Vehicle.Texture = TankGame.GlobalContent.Load<Texture2D>("Tank-5");
            }

            foreach (var tank in teamBlue.Tanks)
            {
                tank.Vehicle.Position = new Vector2(_rand.Next(TankGame.Graphics.PreferredBackBufferWidth), _rand.Next(TankGame.Graphics.PreferredBackBufferHeight - 30));
                tank.Vehicle.Collider.Center = tank.Vehicle.Position;
                tank.Vehicle.Texture = TankGame.GlobalContent.Load<Texture2D>("Tank-4");
            }

            GameController = new TeamGameController(teamRed, teamBlue) {gameID = args[0]};
        }
    }
}
