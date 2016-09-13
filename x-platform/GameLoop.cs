using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using x_platform.GameObjects;

namespace x_platform
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameLoop : Game
    {
        static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static Dictionary<TextureNames, Texture2D> textureDict;
        public enum TextureNames { MainCharacter, Enemy, Projectile }
        private List<Entity> activeObjects;
        private Player player1;
        public static Vector2 GraphicsDimensions { get { return new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight); } }

        public GameLoop()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
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
            textureDict = new Dictionary<TextureNames, Texture2D>();
            activeObjects = new List<Entity>();
          
            textureDict.Add(TextureNames.MainCharacter, this.Content.Load<Texture2D>("playerChar/spaceshipMain"));
            textureDict.Add(TextureNames.Enemy, this.Content.Load<Texture2D>("enemyChar/enemyMain"));
            textureDict.Add(TextureNames.Projectile, this.Content.Load<Texture2D>("enemyChar/bulletEnemy"));

            player1 = new Player(textureDict[TextureNames.MainCharacter], new Vector2(250, 250), textureDict[TextureNames.Projectile]);
            activeObjects.Add(player1);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            textureDict = null;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Space)) { player1.Firing = true; }
            if (Keyboard.GetState().IsKeyUp(Keys.Space)) { player1.Firing = false; }
            if (Keyboard.GetState().IsKeyDown(Keys.W)) { player1.MoveObject(MovementDirections.Up); }
            if (Keyboard.GetState().IsKeyDown(Keys.A)) { player1.MoveObject(MovementDirections.Left); }
            if (Keyboard.GetState().IsKeyDown(Keys.S)) { player1.MoveObject(MovementDirections.Down); }
            if (Keyboard.GetState().IsKeyDown(Keys.D)) { player1.MoveObject(MovementDirections.Right); }

            foreach (var obj in activeObjects)
            {
                obj.Update(gameTime);
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
            spriteBatch.Begin();

            foreach(var obj in activeObjects)
            {
                obj.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
