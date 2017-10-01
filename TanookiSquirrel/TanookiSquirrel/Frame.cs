using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TanookiSquirrel
{
    public class Frame
    {
        public Rectangle frame;
        public Vector2 origin;

        public Frame(Rectangle frame, Vector2 origin)
        {
            this.frame = frame;
            this.origin = origin;

        }
    }
}
