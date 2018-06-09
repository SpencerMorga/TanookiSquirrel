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
            DEATH,
            Fleap,
            Fwalk,
            Fwim,
            Fwall,
            Fly2
        }

        public enum PixelTypes
        {
            Wall,
            RedWall,
            Water,
            Lava,
            Flag,
            Star,
            Sword,
            Mush,
            Button,
            LaserWall,
            Bowser,
            Shield,
            Goomba,
            Revshield,
            SecretFlag,
            CheepCheep,
            Cactus,
            Coral,
            Coin
        }
        public enum TanookiFrames2
        {
            rWalking,
            rIdle
        }

    }
}
