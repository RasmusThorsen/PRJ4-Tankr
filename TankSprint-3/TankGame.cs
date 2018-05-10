using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using TankSprint_3.Classes;
using TankSprint_3.Interface;

namespace TankSprint_3
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class TankGame : Game
    {
        static GraphicsDeviceManager graphics;
        static SpriteBatch spriteBatch;
        static ContentManager _content;
        private string[] _args;
        private static GameTime _gameTime;
        GameMode gm = new GameMode();
        static IHubProxy proxy;

        public static ContentManager GlobalContent => _content;
        public static SpriteBatch SpriteBatch => spriteBatch;
        public static GameTime GameTime => _gameTime;
        public static GraphicsDeviceManager Graphics => graphics;
        public static IHubProxy Hub => (proxy as HubProxy);

        public TankGame(string args) 
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;
            //Array med ID, Antal spillere, navne på spillere.
            _args = args.Split(';');
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _content = Content;

            // TODO: use this.Content to load your game content here
            gm.initGame(_args);
            ConnectToHub();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            _gameTime = gameTime;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic her
            gm.GameController.Update();

            if (gm.GameController.GameOver)
            {
                string statsJSON = JsonConvert.SerializeObject(gm.GameController.Stats);
                var task = proxy.Invoke("RoundOver", statsJSON, gm.GameController.gameID);
                Task.WaitAll(task);
                Exit();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            gm.GameController.Draw();
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void ConnectToHub()
        {
            var hubConnection = new HubConnection("https://tankweb.azurewebsites.net");
            proxy = hubConnection.CreateHubProxy("GameHub");
            proxy.On<string, string, string>("MoveCalled", gm.GameController.MoveHandler);
            proxy.On<bool, string>("ShootCalled", gm.GameController.ShootHandler);
            proxy.On<bool, string>("SpeedCalled", gm.GameController.SpeedHandler);
            hubConnection.Start().Wait();
            proxy.Invoke("ConnectToGameSession", _args[0]);
        }
    }
}
