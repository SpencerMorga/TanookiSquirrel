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
            base.Update(gTime);
        }



    }
}
