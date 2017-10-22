using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TanookiSquirrel
{
    public class Map
    {
        Color[,] pixels;

        public Dictionary<TanookiEnums.PixelTypes, List<TanookiSprite>> Items { get; private set; }

        //make sure the images are the same size which is 200x200
        Vector2 scale = PixelItem.Items[TanookiEnums.PixelTypes.Wall].Sprite.scale;
        Vector2 imageSize = new Vector2(PixelItem.Items[TanookiEnums.PixelTypes.Wall].Sprite.image.Width, PixelItem.Items[TanookiEnums.PixelTypes.Wall].Sprite.image.Height);


        public Map(Texture2D mapImage)
        {
            Items = new Dictionary<TanookiEnums.PixelTypes, List<TanookiSprite>>();

            Color[] colors = new Color[mapImage.Width * mapImage.Height];
            
            mapImage.GetData(colors);
                        
            pixels = new Color[mapImage.Width, mapImage.Height];

            int counter = 0;

            
            for (int i = 0; i < mapImage.Height; i++)
            {
                for (int j = 0; j < mapImage.Width; j++)
                {
                    pixels[j, i] = colors[counter];

                    Vector2 position = new Vector2(j * (scale.X * imageSize.X), i * (scale.Y * imageSize.Y));

                    if (pixels[j, i] == PixelItem.Items[TanookiEnums.PixelTypes.Wall].PixelColor)
                    {
                        AddSprite(TanookiEnums.PixelTypes.Wall, position);
                    }
                    
                    counter++;
                }
            }
        }

        void AddSprite(TanookiEnums.PixelTypes pixelType, Vector2 position)
        {
            if (!Items.Keys.Contains(pixelType))
            {
                Items.Add(pixelType, new List<TanookiSprite>());
            }

            Items[pixelType].Add(new TanookiSprite(PixelItem.Items[pixelType].Sprite.image, position, PixelItem.Items[pixelType].Sprite.color));
            Items[pixelType][Items[pixelType].Count - 1].scale = scale;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (KeyValuePair<TanookiEnums.PixelTypes, List<TanookiSprite>> item in Items)
            {
                for (int i = 0; i < item.Value.Count; i++)
                {
                    item.Value[i].Draw(spriteBatch);                    
                }                
            }
        }        
    }
}
