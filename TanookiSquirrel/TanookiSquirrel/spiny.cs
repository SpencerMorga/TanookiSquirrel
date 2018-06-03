using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TanookiSquirrel
{
    class spiny : MovingTanookiAnimation
    {
        public spiny(Texture2D image, Vector2 position, Vector2 speed, Color color, List<Frame> frames)
            : base(image, position, speed, color, frames)
        {
            this.frames = frames;
        }
      
    }
}
