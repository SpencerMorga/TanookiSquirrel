using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TanookiSquirrel
{
    public static class TanookiEnums
    {
        public enum TanookiFrames
        {
            Flying, //
            Tumbling, 
            Running, //
            Swimming,
            Sitting,
            Idle, //
            Stone, //
            Pull_Hat_Over_Head,
            SpinAttack,
            DEATH
        }

        public enum PixelTypes
        {
            Wall,
            Water,
            Lava,
            Flag,
            Star,
            Sword,
            Mush,
            Button,
            LaserWall
        }
        public enum TanookiFrames2
        {
            rWalking,
            rIdle
        }

    }
}
