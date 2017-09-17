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
        Dictionary<TanookiEnums.TanookiFrames, List<Rectangle>> aneemayshun;
        private TanookiEnums.TanookiFrames TanookiState;
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
        public TheGenuineTanooki(Texture2D image, Vector2 position, Vector2 speed, Color color, List<Rectangle> frames)
            : base (image, position, speed, color, frames)
        {
            List<Rectangle> ExperimentalRunning = new List<Rectangle>()
            {
                new Rectangle(86, 278, 22, 29),
                new Rectangle(62, 278, 21, 29),
                new Rectangle(562, 277, 22, 29),
            };
            aneemayshun = new Dictionary<TanookiEnums.TanookiFrames, List<Rectangle>>();
            aneemayshun.Add(TanookiEnums.TanookiFrames.Running, ExperimentalRunning);

            List<Rectangle> RegularFlying = new List<Rectangle>()
            {
                new Rectangle(419, 278, 24, 28),
                new Rectangle(446, 279, 24, 27),
                new Rectangle(473, 279, 24, 27)

            };
          //  aneemayshun = new Dictionary<TanookiEnums.TanookiFrames, List<Rectangle>>();
            aneemayshun.Add(TanookiEnums.TanookiFrames.Flying, RegularFlying);
            currentTanookiState = TanookiEnums.TanookiFrames.Running;
            this.frames = aneemayshun[currentTanookiState];
        }

        public void Update (GameTime gTime, KeyboardState ks)
        {
            frames = aneemayshun[currentTanookiState];
            if (currentTanookiState == TanookiEnums.TanookiFrames.Running)
            {
                if (currentTanookiframeIndex + 1 >= frames.Count)
                {
                    currentTanookiState = TanookiEnums.TanookiFrames.Running;
                }
            }
            if (ks.IsKeyDown(Keys.R))
            {
                currentTanookiState = TanookiEnums.TanookiFrames.Running;
            }

            if (currentTanookiState == TanookiEnums.TanookiFrames.Flying)
            {
                if (currentTanookiframeIndex + 1 >= frames.Count)
                {
                    currentTanookiState = TanookiEnums.TanookiFrames.Running;
                }
            }
            if (ks.IsKeyDown(Keys.F))
            {
                currentTanookiState = TanookiEnums.TanookiFrames.Flying;
                position.Y -= speed.Y;
            }
            else
            {
                position.Y += speed.Y;
            }
            //make stationary flying frame when falling
            base.Update(gTime);
        }



    }
}
