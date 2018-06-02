using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TanookiSquirrel
{
    class TheGenuineTanooki : MovingTanookiAnimation
    {
        Dictionary<TanookiEnums.TanookiFrames, List<Frame>> aneemayshun;
        private TanookiEnums.TanookiFrames TanookiStatesss;
        int floor = 800;
        TanookiEnums.TanookiFrames currentTanookiState
        {
            get
            {
                return TanookiStatesss;
            }
            set
            {
                if (TanookiStatesss != value)
                {
                    TanookiStatesss = value;
                    currentTanookiframeIndex = 0;
                }
            }
        }

        public bool isFalling = true;
        public bool yesFly = false;
        public bool dead = false;
        public bool fight = false;
        public bool big = false;
        public bool shield = false;
        public bool invincible = false;
        public bool hasReverseShield = false;
        public float acceleration = .2f;
        float initialYSpeed;

        public TheGenuineTanooki(Texture2D image, Vector2 position, Vector2 speed, Color color, List<Frame> frames)
            : base(image, position, speed, color, frames)
        {
            Scale = new Vector2(1.3f);
            initialYSpeed = speed.Y;
            List<Frame> ExperimentalRunning = new List<Frame>()
            {
                new Frame(new Rectangle(86, 278, 22, 29), new Vector2()),
                new Frame(new Rectangle(62, 278, 21, 29), new Vector2()),
                new Frame(new Rectangle(562, 277, 22, 29), new Vector2()),
            };
            aneemayshun = new Dictionary<TanookiEnums.TanookiFrames, List<Frame>>();
            aneemayshun.Add(TanookiEnums.TanookiFrames.Running, ExperimentalRunning);

            List<Frame> PSpeedFlying = new List<Frame>()
            {
                new Frame(new Rectangle(419, 278, 24, 28), new Vector2()),
                new Frame(new Rectangle(446, 279, 24, 27), new Vector2()),
                new Frame(new Rectangle(473, 279, 24, 27), new Vector2()),
            };
            //  aneemayshun = new Dictionary<TanookiEnums.TanookiFrames, List<Rectangle>>();
            aneemayshun.Add(TanookiEnums.TanookiFrames.Flying, PSpeedFlying);

            List<Frame> Dead = new List<Frame>()
            {
                new Frame(new Rectangle(111, 280, 23, 27), new Vector2()),


            };
            aneemayshun.Add(TanookiEnums.TanookiFrames.DEATH, Dead);
            List<Frame> BeingShotOutofACannon = new List<Frame>()
            {
                new Frame(new Rectangle (442, 390, 21, 20), new Vector2(-6, -5)),
                new Frame(new Rectangle (446, 387, 20, 23), new Vector2(-5, -6)),
                new Frame(new Rectangle (489, 389, 20, 20), new Vector2(-5, -5)),
                new Frame(new Rectangle (320, 390, 23, 20), new Vector2(-6, -5)),
                new Frame(new Rectangle (346, 390, 22, 20), new Vector2(-6, -5)),
                new Frame(new Rectangle (370, 387, 20, 23), new Vector2(-5, -6)),
                new Frame(new Rectangle (393, 389, 20, 21), new Vector2(-5, -6)),
                new Frame(new Rectangle (416, 390, 23, 20), new Vector2(-6, -5)),
            };
            aneemayshun.Add(TanookiEnums.TanookiFrames.Tumbling, BeingShotOutofACannon);

            List<Frame> Idle = new List<Frame>()
            {
                new Frame(new Rectangle (62, 278, 21, 29), new Vector2()),

            };
            aneemayshun.Add(TanookiEnums.TanookiFrames.Idle, Idle);

            List<Frame> StoneMarioWithABulletInHisHead = new List<Frame>()
            { new Frame(new Rectangle (524, 277, 16, 29), new Vector2()), };
            aneemayshun.Add(TanookiEnums.TanookiFrames.Stone, StoneMarioWithABulletInHisHead);

            List<Frame> PullingHatOverHead = new List<Frame>()
            { new Frame(new Rectangle (500, 280, 21, 26), new Vector2()),};
            aneemayshun.Add(TanookiEnums.TanookiFrames.Pull_Hat_Over_Head, PullingHatOverHead);

            List<Frame> SpinAttack = new List<Frame>()
            {
                new Frame(new Rectangle (156, 278, 16, 29), new Vector2()),
                new Frame(new Rectangle (175, 278, 23, 29), new Vector2()),
                new Frame(new Rectangle (200, 278, 16, 29), new Vector2()),
                new Frame(new Rectangle (62, 278, 21, 29), new Vector2()),
                new Frame(new Rectangle (62, 278, 21, 29), new Vector2()),
            };
            aneemayshun.Add(TanookiEnums.TanookiFrames.SpinAttack, SpinAttack);

            List<Frame> Swimming = new List<Frame>()
            {
                new Frame(new Rectangle(543, 279, 16, 27), new Vector2()),


            };
            aneemayshun.Add(TanookiEnums.TanookiFrames.Swimming, Swimming);

            List<Frame> Fwalking = new List<Frame>()
            {
                new Frame(new Rectangle(229, 208, 16, 28), new Vector2()),
                new Frame(new Rectangle(248, 209, 16, 27), new Vector2()),
                new Frame(new Rectangle(211, 208, 16, 28), new Vector2()),
            };
            aneemayshun.Add(TanookiEnums.TanookiFrames.Fwalk, Fwalking);

            List<Frame> Fleaping = new List<Frame>()
            {
                new Frame(new Rectangle(225, 240, 20, 29), new Vector2()),
                new Frame(new Rectangle(248, 240, 20, 29), new Vector2()),
                new Frame(new Rectangle(271, 240, 19, 30), new Vector2()),
            };
            aneemayshun.Add(TanookiEnums.TanookiFrames.Fleap, Fleaping);
            List<Frame> Fwimming = new List<Frame>()
            {
                new Frame(new Rectangle(558, 243, 20, 27), new Vector2()),
                new Frame(new Rectangle(581, 243, 20, 27), new Vector2()),
                new Frame(new Rectangle(606, 243, 24, 27), new Vector2()),
            };
            aneemayshun.Add(TanookiEnums.TanookiFrames.Fwim, Fwimming);

            List<Frame> Fwalling = new List<Frame>()
            {
                new Frame(new Rectangle(482, 245, 16, 25), new Vector2()),
            };
            aneemayshun.Add(TanookiEnums.TanookiFrames.Fwall, Fwalling);

            List<Frame> Fly2 = new List<Frame>()
            {
                new Frame(new Rectangle(409, 209, 19, 27), new Vector2()),
            };
            aneemayshun.Add(TanookiEnums.TanookiFrames.Fly2, Fly2);
            currentTanookiState = TanookiEnums.TanookiFrames.Idle;
            this.frames = aneemayshun[currentTanookiState];
        }



        public void Update(GameTime gTime, KeyboardState ks)
        {
            if (position.Y + frames[currentTanookiframeIndex].frame.Height > floor)
            {
                position.Y = floor - frames[currentTanookiframeIndex].frame.Height;
                isFalling = false;
            }


            switch (currentTanookiState)
            {
                case TanookiEnums.TanookiFrames.Swimming:
                    Time2wait4tanooki = new TimeSpan(0, 0, 0, 0, 100);
                    break;
                default:
                    Time2wait4tanooki = new TimeSpan(0, 0, 0, 0, 70);
                    break;
            }


            frames = aneemayshun[currentTanookiState];
            if (currentTanookiState == TanookiEnums.TanookiFrames.Running)
            {
                if (currentTanookiframeIndex + 1 >= frames.Count)
                {
                    currentTanookiState = TanookiEnums.TanookiFrames.Idle;
                }
            }
            if (ks.IsKeyDown(Keys.D))
            {
                currentTanookiState = TanookiEnums.TanookiFrames.Running;
                position.X += speed.X;
            }

            if (currentTanookiState == TanookiEnums.TanookiFrames.Flying)
            {
                if (currentTanookiframeIndex + 1 >= frames.Count)
                {
                    currentTanookiState = TanookiEnums.TanookiFrames.Idle;
                }
            }
            if (currentTanookiState == TanookiEnums.TanookiFrames.Fly2)
            {
                if (currentTanookiframeIndex + 1 >= frames.Count)
                {
                    currentTanookiState = TanookiEnums.TanookiFrames.Idle;
                }
            }
            if (yesFly == true)
            {
                if (ks.IsKeyDown(Keys.W))
                {
                    currentTanookiState = TanookiEnums.TanookiFrames.Flying;
                    position.Y -= speed.Y;
                    isFalling = false;
                }
                if (ks.IsKeyDown(Keys.K))
                {
                    currentTanookiState = TanookiEnums.TanookiFrames.Fly2;
                    position.Y -= speed.Y;
                    isFalling = false;
                }
            }




            if (isFalling)
            {
                speed.Y += acceleration;
                position.Y += speed.Y;
            }
            else
            {
                speed.Y = initialYSpeed;
            }

            if (big)
            {
                if (ks.IsKeyDown(Keys.D4)) {
                    Scale = new Vector2(4f); acceleration = .5f; }
                if (ks.IsKeyDown(Keys.D1)) { Scale = new Vector2(1f); acceleration = .1f; }
                if (ks.IsKeyDown(Keys.D3)) { Scale = new Vector2(3f); acceleration = .4f; }
                if (ks.IsKeyDown(Keys.D2)) { Scale = new Vector2(2f); acceleration = .3f; }
                if (ks.IsKeyDown(Keys.D5)) { Scale = new Vector2(5f); acceleration = .6f; }
                if (ks.IsKeyDown(Keys.D9)) { Scale = new Vector2(9f); acceleration = 1f; }
                if (ks.IsKeyDown(Keys.D0))
                {
                    Scale = new Vector2(.1f); acceleration = .000000000000001f;
                }

            }

            if (ks.IsKeyDown(Keys.A))
            {
                currentTanookiState = TanookiEnums.TanookiFrames.Idle;
                position.X -= speed.X;
            }

            if (currentTanookiState == TanookiEnums.TanookiFrames.Idle)
            {
                if (currentTanookiframeIndex + 1 >= frames.Count)
                {
                    currentTanookiState = TanookiEnums.TanookiFrames.Idle;
                }
            }



            if (currentTanookiState == TanookiEnums.TanookiFrames.Stone)
            {
                if (currentTanookiframeIndex + 1 >= frames.Count)
                {
                    currentTanookiState = TanookiEnums.TanookiFrames.Idle;
                }

            }
            if (currentTanookiState == TanookiEnums.TanookiFrames.DEATH)
            {
                if (currentTanookiframeIndex + 1 >= frames.Count)
                {
                    currentTanookiState = TanookiEnums.TanookiFrames.Idle;
                }
            }
            if (dead == true)
            {
                position = new Vector2(60, 570);
                dead = false;
            }

            if (currentTanookiState == TanookiEnums.TanookiFrames.Pull_Hat_Over_Head)
            {
                if (currentTanookiframeIndex + 1 >= frames.Count)
                {
                    currentTanookiState = TanookiEnums.TanookiFrames.Idle;
                }

            }
            if (ks.IsKeyDown(Keys.S))
            {
                currentTanookiState = TanookiEnums.TanookiFrames.Pull_Hat_Over_Head;
            }

            if (currentTanookiState == TanookiEnums.TanookiFrames.Fwalk)
            {
                if (currentTanookiframeIndex + 1 >= frames.Count)
                {
                    currentTanookiState = TanookiEnums.TanookiFrames.Idle;
                }
            }

            if (ks.IsKeyDown(Keys.Right))
            {
                currentTanookiState = TanookiEnums.TanookiFrames.Fwalk;
                position.X += speed.X;
            }

            if (currentTanookiState == TanookiEnums.TanookiFrames.Fleap)
            {
                if (currentTanookiframeIndex + 1 >= frames.Count)
                {
                    currentTanookiState = TanookiEnums.TanookiFrames.Idle;
                }
            }
            if (ks.IsKeyDown(Keys.Up))
            {
                currentTanookiState = TanookiEnums.TanookiFrames.Fleap;
                position.Y -= speed.Y;
            }

            if (currentTanookiState == TanookiEnums.TanookiFrames.Fwim)
            {
                if (currentTanookiframeIndex +1 >= frames.Count)
                {
                    currentTanookiState = TanookiEnums.TanookiFrames.Idle;
                }
            }
            if (ks.IsKeyDown(Keys.Left))
            {
                currentTanookiState = TanookiEnums.TanookiFrames.Fwim;
                position.X += speed.X;
            }
            if (currentTanookiState == TanookiEnums.TanookiFrames.Fwall)
            {
                if (currentTanookiframeIndex +1 >= frames.Count)
                {
                    currentTanookiState = TanookiEnums.TanookiFrames.Idle;
                }
            }
            if (ks.IsKeyDown(Keys.S))
            {
                currentTanookiState = TanookiEnums.TanookiFrames.Fwall;
                position.Y += speed.Y;
            }


            if (currentTanookiState == TanookiEnums.TanookiFrames.SpinAttack)
            {

                if (currentTanookiframeIndex + 1 >= frames.Count)
                {
                    currentTanookiState = TanookiEnums.TanookiFrames.SpinAttack;
                
                }

            }
            if (fight == true)
            {
                if (ks.IsKeyDown(Keys.Space)) 
                {
                    currentTanookiState = TanookiEnums.TanookiFrames.SpinAttack;
                    position.X += speed.X;
                }
            }
            
           

           
            base.Update(gTime);
        }


        public void DrawFloor(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            Texture2D pixel = new Texture2D(graphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });

            spriteBatch.Draw(pixel, new Rectangle(0, floor, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height - floor), Color.Gray);
        }
    }
}
