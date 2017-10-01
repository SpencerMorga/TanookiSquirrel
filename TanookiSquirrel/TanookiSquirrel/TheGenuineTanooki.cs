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
        private TanookiEnums.TanookiFrames TanookiState;
        int floor = 800;
        TanookiEnums.TanookiFrames currentTanookiState
        {
            get
            {
                return TanookiState;
            }
            set
            {
                if (TanookiState != value)
                {
                    TanookiState = value;
                    currentTanookiframeIndex = 0;
                }
            }
        }

        /*
         * 
         *flying
264, 280, 23, 27
290, 280, 23, 27
316, 279, 22, 28

p speed flying
419, 278, 24, 28
446, 279, 24, 27
473, 279, 24, 27

pull hat over head
500, 279, 21, 27

stone raccoon dog
523, 277, 16, 29

swimming
661, 278, 24, 28
742, 279, 23, 27
768, 279, 24, 27
         *
         *
         * 
        
        */
        public TheGenuineTanooki(Texture2D image, Vector2 position, Vector2 speed, Color color, List<Frame> frames)
            : base (image, position, speed, color, frames)
        {
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


            currentTanookiState = TanookiEnums.TanookiFrames.Idle;
            this.frames = aneemayshun[currentTanookiState];
        }

        bool isFalling = true;

        public void Update (GameTime gTime, KeyboardState ks)
        {
            if (position.Y + frames[currentTanookiframeIndex].frame.Height > floor)
            {
                position.Y = floor - frames[currentTanookiframeIndex].frame.Height;
                isFalling = false;
            }

            frames = aneemayshun[currentTanookiState];
            if (currentTanookiState == TanookiEnums.TanookiFrames.Running)
            {
                if (currentTanookiframeIndex + 1 >= frames.Count)
                {
                    currentTanookiState = TanookiEnums.TanookiFrames.Idle;
                }
            }
            if (ks.IsKeyDown(Keys.R))
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
            if (ks.IsKeyDown(Keys.F))
            {
                currentTanookiState = TanookiEnums.TanookiFrames.Flying;
                position.Y -= speed.Y;
                isFalling = true;
            }
            else
            {
                if (isFalling)
                {
                    position.Y += speed.Y;
                }
            }
            if (currentTanookiState == TanookiEnums.TanookiFrames.Idle)
            {
                if (currentTanookiframeIndex + 1 >= frames.Count)
                {
                    currentTanookiState = TanookiEnums.TanookiFrames.Idle;
                }
            }
            if (ks.IsKeyDown(Keys.I))
            {
                currentTanookiState = TanookiEnums.TanookiFrames.Idle;
                position.X -= speed.X;
            }
            if (currentTanookiState == TanookiEnums.TanookiFrames.Stone)
            {
                if (currentTanookiframeIndex + 1 >= frames.Count)
                {
                    currentTanookiState = TanookiEnums.TanookiFrames.Idle;
                }
            }
            if (ks.IsKeyDown(Keys.S))
            {
                currentTanookiState = TanookiEnums.TanookiFrames.Stone;
            }

            if (currentTanookiState == TanookiEnums.TanookiFrames.Pull_Hat_Over_Head)
            {
                if (currentTanookiframeIndex + 1 >= frames.Count)
                {
                    currentTanookiState = TanookiEnums.TanookiFrames.Idle;
                }

            }
            if (ks.IsKeyDown(Keys.P))
            {
                currentTanookiState = TanookiEnums.TanookiFrames.Pull_Hat_Over_Head;
            }

            if (currentTanookiState == TanookiEnums.TanookiFrames.Tumbling)
            {
                if (currentTanookiframeIndex + 1 >= frames.Count)
                {
                    currentTanookiState = TanookiEnums.TanookiFrames.Idle;
                }
            }
            if (ks.IsKeyDown(Keys.T))
            {
                currentTanookiState = TanookiEnums.TanookiFrames.Tumbling;
                position.X += speed.X;
            }
            //make stationary flying frame when falling
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
