using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using TankSprint_3.Interface;

namespace TankSprint_3.Classes
{
    class GameMode : IGameMode
    {
        public IGameController GameController { get; set; }
        private readonly Random _rand = new Random();
        public void initGame(string[] args)
        {
            var tanks = new List<Tank>();
            for (int i = 0; i < int.Parse(args[2]); i++)
            {
                tanks.Add(new Tank(new WASDInput(), args[3 + i]));
            }
            //her sættes tanks alt efter gamemode.
            foreach (var tank in tanks)
            {
                tank.Vehicle.Position = new Vector2(_rand.Next(TankGame.Graphics.PreferredBackBufferWidth), _rand.Next(TankGame.Graphics.PreferredBackBufferHeight));
            }
            GameController = new GameController(tanks);
            GameController.gameID = args[0];
        }
    }
}
