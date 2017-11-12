using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TanookiSquirrel
{
    class PlantThing : MovingTanookiAnimation
    {
        Vector2 speed;

        public PlantThing (Texture2D image, Vector2 position, Vector2 speed, Color color, List<Frame> frames)
            : base (image, position, speed, color, frames)
        {
            this.speed = speed;
        }
    }
}
