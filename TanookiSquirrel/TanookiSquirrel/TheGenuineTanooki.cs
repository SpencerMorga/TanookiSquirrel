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
            List<Rectangle> FlyingFrames = new List<Rectangle>()
            {



            };

        }




    }
}
