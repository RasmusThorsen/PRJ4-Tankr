using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TankSprint_3.Interface;

namespace TankSprint_3.Classes
{
    class TeamGameController : IGameController
    {
        private Team _teamRed;
        private Team _teamBlue;
        private int _winningScore = 20;

        private double _currentTime = 0;
        private double _respawnTime = 3;
        private Random _rand = new Random();

        public TeamCollisionController CollisionController { get; set; }
        public bool GameOver { get; set; }

        public string gameID { get; set; }
        public List<Stats> Stats { get; } = new List<Stats>();

        private Dictionary<string, double> _graveyard = new Dictionary<string, double>();

        public TeamGameController(Team t1, Team t2)
        {
            _teamRed = t1;
            _teamBlue = t2;
            CollisionController = new TeamCollisionController(_teamRed.Tanks, _teamBlue.Tanks);
            CollisionController.Collision += (s, e) =>
            {
                FindTank(e.deadTank)._stats.Dead++;
                FindTank(e.deadTank).isDead = true;
                FindTank(e.killerTank)._stats.Kills++;
                FindTank(e.killerTank)._stats.Hit++;
                if (e.teamColor == "red") _teamRed.Score++;
                else _teamBlue.Score++;

                TankGame.Hub.Invoke("PlayerDead", e.killerTank, e.deadTank, gameID);
            };
        }

        public void Update()
        {
            _currentTime += TankGame.GameTime.ElapsedGameTime.TotalSeconds;
            if (_currentTime >= 3)
            {
                UpdateTeam(ref _teamRed);
                UpdateTeam(ref _teamBlue);

                if (_teamRed.Score == _winningScore || _teamBlue.Score == _winningScore)
                    EndGame();

                CollisionController.CheckCollisions(gameID);

                CheckDeadTeamMate(ref _teamRed);
                CheckDeadTeamMate(ref _teamBlue);

                UpdateRespawn();

            }
        }

        private void UpdateRespawn()
        {
            foreach (var key in _graveyard.Keys.ToList())
            {
                _graveyard[key] -= TankGame.GameTime.ElapsedGameTime.TotalSeconds;

                if (_graveyard[key] < 0)
                {
                    var tank = FindTank(key);
                    tank.isDead = false;
                    tank.Vehicle.Position = new Vector2(_rand.Next(TankGame.Graphics.PreferredBackBufferWidth), _rand.Next(TankGame.Graphics.PreferredBackBufferHeight - 30));
                    tank.Vehicle.Collider.Center = tank.Vehicle.Position;
                    _graveyard.Remove(key);
                    TankGame.Hub.Invoke("RespawnPlayer", key, gameID);
                }
            }
        }

        private void CheckDeadTeamMate(ref Team team)
        {
            foreach (var tank in team.Tanks)
            {
                if (tank.isDead && !_graveyard.ContainsKey(tank.Name))
                {
                    tank.Vehicle.Collider.Center = new Vector2(-1000, -1000);
                    tank._stats.Dead++;
                    _graveyard.Add(tank.Name, _respawnTime);
                }
            }
        }

        private void EndGame()
        {
            var winnerTeamTanks = _teamRed.Score == _winningScore ? _teamRed.Tanks : _teamBlue.Tanks;
            var allTanks = _teamRed.Tanks.Concat(_teamBlue.Tanks).ToList();

            foreach (var tank in winnerTeamTanks)
                tank._stats.Winner++;

            foreach (var tank in allTanks)
            {
                if (tank._stats.NumOfShots != 0)
                    tank._stats.HitRate = (float)tank._stats.Hit / tank._stats.NumOfShots;
                else tank._stats.HitRate = 0;

                Stats.Add(tank._stats);
            }

            GameOver = true;
        }

        private void UpdateTeam(ref Team team)
        {
            foreach (var tank in team.Tanks)
            {
                tank.Update();
            }
        }

        public void Draw()
        {
            if (_currentTime < 3) DrawCountDown();
            DrawTanks(_teamRed);
            DrawTanks(_teamBlue);
            var font = TankGame.GlobalContent.Load<SpriteFont>("Font");
            TankGame.SpriteBatch.DrawString(font, "Team Red kills: " + _teamRed.Score + "/" + _winningScore + "\n" + "Team Blue kills: " + _teamBlue.Score + "/" + _winningScore, 
                new Vector2(10, 10), Color.White);
        }

        private void DrawTanks(Team team)
        {
            foreach (var tank in team.Tanks)
            {
                if(!tank.isDead)
                    tank.Draw();
            }
        }

        private void DrawCountDown()
        {
            var font = TankGame.GlobalContent.Load<SpriteFont>("BigFont");
            TankGame.SpriteBatch.DrawString(font, (3 - _currentTime).ToString("F1"), new Vector2(TankGame.Graphics.PreferredBackBufferWidth / 2, TankGame.Graphics.PreferredBackBufferHeight / 2), Color.White);
        }

        public void MoveHandler(string x, string y, string username)
        {
            var curTank = FindTank(username);
            curTank.Vehicle.inputAngle = new Vector2(int.Parse(x), int.Parse(y));
        }

        public void ShootHandler(bool isShooting, string username)
        {
            var curTank = FindTank(username);
            if (curTank == null) return;

            curTank.isShooting = isShooting;
        }

        public void SpeedHandler(bool isSpeeding, string username)
        {
            var curTank = FindTank(username);
            if (curTank == null) return;

            curTank.isSpeeding = isSpeeding;
        }

        private Tank FindTank(string username)
        {
            var allTanks = _teamBlue.Tanks.Concat(_teamRed.Tanks).ToList();
            return allTanks.Find(e => e.Name == username);
        }

        
    }
}
