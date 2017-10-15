using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static TanookiSquirrel.TanookiEnums;

namespace TanookiSquirrel
{
    public class PixelItem 
    {
        private static Dictionary<PixelTypes, PixelItem> items = new Dictionary<PixelTypes, PixelItem>();

        public static Dictionary<PixelTypes, PixelItem> Items
        {
            get { return items; }
        }

        private Color pixelColor;

        public Color PixelColor
        {
            get { return pixelColor; }
        }

        private TanookiSprite sprite;

        public TanookiSprite Sprite
        {
            get { return sprite; }
        }

        public PixelItem(Color pixelColor, Texture2D image, Color tint)
        {
            this.pixelColor = pixelColor;
            sprite = new TanookiSprite(image, Vector2.Zero, tint);
            sprite.scale = new Vector2(.2f);
        }

        public static bool AddItem(PixelTypes pixelType, PixelItem pixelItem)
        {
            if (!items.ContainsKey(pixelType))
            {
                items.Add(pixelType, pixelItem);
                return true;
            }

            return false;
        }
    }
}
