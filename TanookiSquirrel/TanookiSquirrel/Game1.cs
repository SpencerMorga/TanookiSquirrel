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
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        int count = 0;
        Labels label;
        TheGenuineTanooki RaccoonDog;
        public Map map;
        int lvlcount = 1;
        public TimeSpan shieldTime = new TimeSpan(0, 0, 0, 3, 0);
        public TimeSpan revshieldTime = new TimeSpan(0, 0, 0, 3, 0);
        public bool wallbreak = false;
        Color colorswitch = Color.White;

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
            graphics.PreferredBackBufferWidth = 1950;
            graphics.PreferredBackBufferHeight = 1000;
            graphics.ApplyChanges();
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            label = new Labels(Content.Load<SpriteFont>("font"), $"Coins: {count}", new Vector2(50, 50), Color.Blue);
            
            RaccoonDog = new TheGenuineTanooki(Content.Load<Texture2D>("raccoon dog"), new Vector2(60, 550), new Vector2(3), Color.White, new List<Frame>());
            PixelItem.AddItem(TanookiEnums.PixelTypes.Wall, new PixelItem(Color.Black, Content.Load<Texture2D>("wall"), Color.White, new Vector2(0.08f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.RedWall, new PixelItem(Color.BlanchedAlmond, Content.Load<Texture2D>("poisonwall"), Color.White, new Vector2(0.08f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.Lava, new PixelItem(Color.Red, Content.Load<Texture2D>("lava"), Color.White, new Vector2(0.08f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.Flag, new PixelItem(Color.Green, Content.Load<Texture2D>("flag"), Color.White, new Vector2(.08f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.Star, new PixelItem(Color.Yellow, Content.Load<Texture2D>("bigmush"), Color.White, new Vector2(.08f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.Mush, new PixelItem(Color.Pink, Content.Load<Texture2D>("mush2"), Color.White, new Vector2(0.08f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.Sword, new PixelItem(Color.Blue, Content.Load<Texture2D>("sword"), Color.White, new Vector2(0.08f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.Button, new PixelItem(Color.Purple, Content.Load<Texture2D>("button"), Color.White, new Vector2(0.08f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.LaserWall, new PixelItem(Color.Brown, Content.Load<Texture2D>("laserwall"), Color.White, new Vector2(.08f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.Bowser, new PixelItem(Color.Olive, Content.Load<Texture2D>("bowser6"), Color.White, new Vector2(.2f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.Shield, new PixelItem(Color.Orange, Content.Load<Texture2D>("shield"), Color.White, new Vector2(.1f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.Goomba, new PixelItem(Color.Gold, Content.Load<Texture2D>("goomba"), Color.White, new Vector2(2.8f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.Revshield, new PixelItem(Color.DarkKhaki, Content.Load<Texture2D>("reverseshield"), Color.White, new Vector2(1f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.SecretFlag, new PixelItem(Color.Aquamarine, Content.Load<Texture2D>("secret"), Color.White, new Vector2(1f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.CheepCheep, new PixelItem(Color.CornflowerBlue, Content.Load<Texture2D>("cheepcheep"), Color.White, new Vector2(3f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.Cactus, new PixelItem(Color.YellowGreen, Content.Load<Texture2D>("cactus"), Color.White, new Vector2(1f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.Coral, new PixelItem(Color.DarkBlue, Content.Load<Texture2D>("coral"), Color.White, new Vector2(2.5f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.Water, new PixelItem(Color.DodgerBlue, Content.Load<Texture2D>("actual water"), Color.White, new Vector2(1f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.Coin, new PixelItem(Color.Firebrick, Content.Load<Texture2D>("coin"), Color.White, new Vector2(1f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.Shovel, new PixelItem(Color.LightCyan, Content.Load<Texture2D>("alexsbeautifiedshovel"), Color.White, new Vector2(1f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.Pepe, new PixelItem(Color.Khaki, Content.Load<Texture2D>("pepe"), Color.White, new Vector2(1f)));
            PixelItem.AddItem(TanookiEnums.PixelTypes.StoreSign, new PixelItem(Color.Bisque, Content.Load<Texture2D>("storesign"), Color.White, new Vector2(1f)));
            map = new Map(Content.Load<Texture2D>("map"));

            RaccoonDog.yesFly = true;
            RaccoonDog.big = true;
            RaccoonDog.attacking = true;


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


            if (map.Items.ContainsKey(TanookiEnums.PixelTypes.Flag))
            {
                for (int f = 0; f < map.Items[TanookiEnums.PixelTypes.Flag].Count; f++)
                {
                    if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.Flag][f].hitbox))
                    {
                        RaccoonDog.position = new Vector2(60, 570);
                        if (lvlcount == 1)
                        {
                            map = new Map(Content.Load<Texture2D>("map2"));
                            lvlcount++;

                        }
                        else if (lvlcount == 2)
                        {

                            map = new Map(Content.Load<Texture2D>("map3"));
                            lvlcount++;
                        }
                        else if (lvlcount == 3)
                        {
                            colorswitch = Color.White;
                            map = new Map(Content.Load<Texture2D>("map4"));
                            lvlcount++;
                        }
                        else if (lvlcount == 4)
                        {
                            map = new Map(Content.Load<Texture2D>("map5"));
                            lvlcount++;
                            colorswitch = Color.White;
                        }
                        break;
                    }
                }
            }
            if (map.Items.ContainsKey(TanookiEnums.PixelTypes.SecretFlag))
            {
                for (int s = 0; s < map.Items[TanookiEnums.PixelTypes.SecretFlag].Count; s++)
                {
                    if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.SecretFlag][s].hitbox))
                    {
                        RaccoonDog.position = new Vector2(60, 570);
                        if (lvlcount == 3)
                        {
                            RaccoonDog.position.Y += RaccoonDog.speed.Y;
                            RaccoonDog.acceleration = 0.0000000001f;
                            map = new Map(Content.Load<Texture2D>("water"));
                            colorswitch = Color.DodgerBlue;

                        }
                        break;
                    }
                }
            }
            if (map.Items.ContainsKey(TanookiEnums.PixelTypes.StoreSign))
            {
                for (int i = 0; i < map.Items[TanookiEnums.PixelTypes.StoreSign].Count; i++)
                {
                    if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.StoreSign][i].hitbox))
                    {
                        
                        
                            map = new Map(Content.Load<Texture2D>("map6"));
                            break;
                        
                    }
                }
            }
            if (map.Items.ContainsKey(TanookiEnums.PixelTypes.Pepe))
            {
                for (int i = 0; i < map.Items[TanookiEnums.PixelTypes.Pepe].Count; i++)
                {
                    if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.Pepe][i].hitbox) && count >= 20)
                    {
                        RaccoonDog.frogpowers = true;
                    }
                }
            }
            if (map.Items.ContainsKey(TanookiEnums.PixelTypes.Shovel))
            {
                for (int i = 0; i < map.Items[TanookiEnums.PixelTypes.Shovel].Count; i++)
                {
                    if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.Shovel][i].hitbox) && count >= 40)
                    {
                        wallbreak = true;
                    }
                }
            }
            if (wallbreak == true)
            {
if (map.Items.ContainsKey(TanookiEnums.PixelTypes.Wall))
            {
                for (int j = 0; j < map.Items[TanookiEnums.PixelTypes.Wall].Count; j++)
                {

                    if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.Wall][j].hitbox) && RaccoonDog.fight)
                    {
                        map.Items[TanookiEnums.PixelTypes.Wall].RemoveAt(j);
                        j--;
                    }

                }
            }
            }
            if (map.Items.ContainsKey(TanookiEnums.PixelTypes.Shield) && !RaccoonDog.shield)
            {
                for (int y = 0; y < map.Items[TanookiEnums.PixelTypes.Shield].Count; y++)
                {
                    if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.Shield][y].hitbox) && !RaccoonDog.shield)
                    {
                        RaccoonDog.shield = true;
                        RaccoonDog.invincible = true;
                    }
                }
            }


            if (map.Items.ContainsKey(TanookiEnums.PixelTypes.Bowser))
            {
                for (int z = 0; z < map.Items[TanookiEnums.PixelTypes.Bowser].Count; z++)
                {
                    if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.Bowser][z].hitbox) && !RaccoonDog.shield)
                    {
                        if (!RaccoonDog.shield)
                        {
                            RaccoonDog.dead = true;
                        }
                        else
                        {
                            //we got hit with a shield
                            RaccoonDog.shield = false;

                        }
                    }
                }
            }

            if (map.Items.ContainsKey(TanookiEnums.PixelTypes.RedWall))
            {
                for (int g = 0; g < map.Items[TanookiEnums.PixelTypes.RedWall].Count; g++)
                {
                    if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.RedWall][g].hitbox))
                    {
                        if (!RaccoonDog.shield)
                        {
                            RaccoonDog.dead = true;
                        }
                        else if (shieldTime == TimeSpan.Zero)
                        {
                            //RaccoonDog.shield = false;
                            RaccoonDog.invincible = true;
                            //we start ticking a timespan that counts as long as our invulnerablity time
                            //set a bool to true possibly, and outside of this if, check if that bool is true, if it is add to the timespan
                            //during the timer, we are invulnerable
                            //after the timer, we are able to be hit again
                            shieldTime = TimeSpan.Zero;
                        }
                    }
                }
            }
            RaccoonDog.isFalling = true;



            if (map.Items.ContainsKey(TanookiEnums.PixelTypes.Revshield))
            {
                for (int i = 0; i < map.Items[TanookiEnums.PixelTypes.Revshield].Count; i++)
                {
                    if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.Revshield][i].hitbox) && !RaccoonDog.hasReverseShield)
                    {
                        RaccoonDog.hasReverseShield = true;
                        //if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.Wall][i].hitbox))
                        //{
                        //    RaccoonDog.dead = true;
                        //}
                    }



                }
            }

            // check collision of raccoondog and wall
            if (map.Items.ContainsKey(TanookiEnums.PixelTypes.Wall))
            {
                for (int i = 0; i < map.Items[TanookiEnums.PixelTypes.Wall].Count; i++)
                {
                    if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.Wall][i].hitbox) && RaccoonDog.hasReverseShield)
                    {
                        RaccoonDog.dead = true;
                        RaccoonDog.hasReverseShield = false;
                    }
                    else
                    {
                        if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.Wall][i].hitbox))
                        {
                         RaccoonDog.isFalling = false;
                        }
                        
                    }
               
                }


            }




            if (map.Items.ContainsKey(TanookiEnums.PixelTypes.Cactus))
            {
                for (int i = 0; i < map.Items[TanookiEnums.PixelTypes.Cactus].Count; i++)
                {
                    if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.Cactus][i].hitbox))
                    {
                        RaccoonDog.isFalling = false;
                    }
                }
            }
            if (map.Items.ContainsKey(TanookiEnums.PixelTypes.Mush))
            {
                for (int j = 0; j < map.Items[TanookiEnums.PixelTypes.Mush].Count; j++)
                {
                    if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.Mush][j].hitbox))
                    {
                        RaccoonDog.yesFly = true;
                    }
                }
            }
            if (map.Items.ContainsKey(TanookiEnums.PixelTypes.Lava))
            {
                for (int a = 0; a < map.Items[TanookiEnums.PixelTypes.Lava].Count; a++)
                {
                    if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.Lava][a].hitbox) && !RaccoonDog.shield)
                    {

                        RaccoonDog.dead = true;
                    }
                }
            }
            if (map.Items.ContainsKey(TanookiEnums.PixelTypes.CheepCheep))
            {
                for (int i = 0; i < map.Items[TanookiEnums.PixelTypes.CheepCheep].Count; i++)
                {
                    if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.CheepCheep][i].hitbox) && RaccoonDog.fight)
                    {
                        map.Items[TanookiEnums.PixelTypes.CheepCheep].RemoveAt(i);
                        i--;
                    }
                    else if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.CheepCheep][i].hitbox) && !RaccoonDog.shield)
                    {
                        RaccoonDog.dead = true;
                    }


                }
            }
            if (map.Items.ContainsKey(TanookiEnums.PixelTypes.Coin))
            {
                for (int i = 0; i < map.Items[TanookiEnums.PixelTypes.Coin].Count; i++)
                {
                    if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.Coin][i].hitbox))
                    {
                        map.Items[TanookiEnums.PixelTypes.Coin].RemoveAt(i);
                        count++;
                        label.text = $"Coins: {count}";
                    }
                }
            }
          
            /*
            else
                    if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.Wall][i].hitbox))
            {
                RaccoonDog.isFalling = false;
                //RaccoonDog.dead = true;

            }
                }
            }
            */
            if (map.Items.ContainsKey(TanookiEnums.PixelTypes.Goomba))
            {
                for (int m = 0; m < map.Items[TanookiEnums.PixelTypes.Goomba].Count; m++)
                {
                    if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.Goomba][m].hitbox) && RaccoonDog.fight)
                    {
                        map.Items[TanookiEnums.PixelTypes.Goomba].RemoveAt(m);
                        m--;
                        count++;
                        label.text = $"Coins: {count}";
                    }
                    else if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.Goomba][m].hitbox) && !RaccoonDog.shield)
                    {
                        RaccoonDog.dead = true;
                    }
                }
            }
            if (map.Items.ContainsKey(TanookiEnums.PixelTypes.Sword))
            {
                for (int b = 0; b < map.Items[TanookiEnums.PixelTypes.Sword].Count; b++)
                {
                    if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.Sword][b].hitbox))
                    {
                        RaccoonDog.attacking = true;
                    }
                }
            }
            if (map.Items.ContainsKey(TanookiEnums.PixelTypes.Star))
            {
                for (int c = 0; c < map.Items[TanookiEnums.PixelTypes.Star].Count; c++)
                {
                    if (RaccoonDog.hitbox.Intersects(map.Items[TanookiEnums.PixelTypes.Star][c].hitbox))
                    {
                        RaccoonDog.big = true;
                    }

                }
            }

            if (RaccoonDog.invincible == true)
            {
                shieldTime += gameTime.ElapsedGameTime;

                if (shieldTime > TimeSpan.FromSeconds(10))
                {
                    RaccoonDog.invincible = false;
                    RaccoonDog.shield = false;
                    shieldTime = TimeSpan.Zero;
                }
            }
            if (RaccoonDog.hasReverseShield == true)
            {
                revshieldTime += gameTime.ElapsedGameTime;

                if (revshieldTime > TimeSpan.FromSeconds(15))
                {
                    RaccoonDog.hasReverseShield = false;
                    RaccoonDog.dead = false;
                    revshieldTime = TimeSpan.Zero;
                }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(colorswitch);
            spriteBatch.Begin();

            map.Draw(spriteBatch);

            RaccoonDog.DrawFloor(spriteBatch, GraphicsDevice);
            //spriteBatch.DrawString()
            label.Draw(spriteBatch);
            RaccoonDog.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
