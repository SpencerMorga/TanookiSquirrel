using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TanookiSquirrel
{
    class ReverseFrames : MovingTanookiAnimation
    {
        Dictionary<TanookiEnums.TanookiFrames2, List<Frame>> animation;
        private TanookiEnums.TanookiFrames2 TanookiState2;

        TanookiEnums.TanookiFrames2 currentTanookiState
        {
            get { return TanookiState2; }
            set { if (TanookiState2 != value) { TanookiState2 = value; currentTanookiframeIndex = 0; } }
        }

        public ReverseFrames(Texture2D image, Vector2 position, Vector2 speed, Color color, List<Frame> frames)
            : base (image, position, speed, color, frames)
        {
            List<Frame> rWalking = new List<Frame>()
            {
                new Frame(new Rectangle(732, 278, 22, 29), new Vector2()),
                new Frame(new Rectangle(757, 278, 21, 29), new Vector2()),
            };
            animation = new Dictionary<TanookiEnums.TanookiFrames2, List<Frame>>();
            animation.Add(TanookiEnums.TanookiFrames2.rWalking, rWalking);

            List<Frame> rIdle = new List<Frame>()
            {
                new Frame(new Rectangle(757, 278, 21, 29), new Vector2()),
            };
            currentTanookiState = TanookiEnums.TanookiFrames2.rIdle;
            this.frames = animation[currentTanookiState];
            
        }
        public void Update (GameTime gTime, KeyboardState ks)
        {
            frames = animation[currentTanookiState];
            if (currentTanookiState == TanookiEnums.TanookiFrames2.rWalking)
            {
                if (currentTanookiframeIndex + 1 >= frames.Count)
                {
                    currentTanookiState = TanookiEnums.TanookiFrames2.rIdle;
                }
            }
            if (ks.IsKeyDown(Keys.A))
            {
                currentTanookiState = TanookiEnums.TanookiFrames2.rWalking;
                position.X -= position.X;
            }
            base.Update(gTime);

        }
    }
}
