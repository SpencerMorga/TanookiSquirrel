using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TanookiSquirrel
{
    public class MovingTanookiAnimation : TanookiAnimation
    {
        public Vector2 speed;
        
        public MovingTanookiAnimation(Texture2D image, Vector2 position, Vector2 speed,Color color, List<Frame> frames)
            : base (image, position, color, frames)
        {
            this.speed = speed;
            this.frames = frames;
        }
        public override void Update(GameTime gTime)
        {
            base.Update(gTime);
        }
    }
}
