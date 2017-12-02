using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TanookiSquirrel
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        TheGenuineTanooki RaccoonDog;

       
        public Map map;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            graphics.PreferredBackBufferWidth = 1900;
            graphics.PreferredBackBufferHeight = 1000;
            graphics.ApplyChanges();
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            RaccoonDog = new TheGenuineTanooki(Content.Load<Texture2D>("raccoon dog"), new Vector2(60, 570), new Vector2(3), Color.White, new List<Frame>());

            PixelItem.AddItem(TanookiEnums.PixelTypes.Wall, new PixelItem(Color.Black, Content.Load<Texture2D>("wall"), Color.White, new Vector2(0.08f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.Lava, new PixelItem(Color.Red, Content.Load<Texture2D>("lava"), Color.White, new Vector2(0.03f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.Flag, new PixelItem(Color.Green, Content.Load<Texture2D>("flag"), Color.White, new Vector2(2.9f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.Star, new PixelItem(Color.Yellow, Content.Load<Texture2D>("star"), Color.White, new Vector2(.06f)));
            map = new Map(Content.Load<Texture2D>("map"));
            
        }



        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            KeyboardState ks = Keyboard.GetState();
            // TODO: Add your update logic here
            RaccoonDog.Update(gameTime, ks);

            RaccoonDog.isFalling = true;

            for (int i = 0; i < map.Items[TanookiEnums.PixelTypes.Wall].Count; i++)
            {
                if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.Wall][i].hitbox))
                {
                    RaccoonDog.isFalling = false;
                }
            }
            for (int j = 0; j < map.Items[TanookiEnums.PixelTypes.Star].Count; j++)
            {
                if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.Star][j].hitbox))
                {
                    RaccoonDog.isFalling = false;
                }
                base.Update(gameTime);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {            
            GraphicsDevice.Clear(Color.Lerp(Color.CornflowerBlue, Color.Gainsboro, .85f));
          //  GraphicsDevice.Clear(Color.Coral);

            spriteBatch.Begin();

            map.Draw(spriteBatch);

            RaccoonDog.DrawFloor(spriteBatch, GraphicsDevice);
            RaccoonDog.Draw(spriteBatch);
           
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
