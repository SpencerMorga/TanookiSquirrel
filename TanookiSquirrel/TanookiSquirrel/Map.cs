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
        //wall
        Vector2 scale =  PixelItem.Items[TanookiEnums.PixelTypes.Wall].Sprite.Scale;
        Vector2 imageSize = new Vector2(PixelItem.Items[TanookiEnums.PixelTypes.Wall].Sprite.image.Width, PixelItem.Items[TanookiEnums.PixelTypes.Wall].Sprite.image.Height);

        //lava
        Vector2 scaleLava = PixelItem.Items[TanookiEnums.PixelTypes.Lava].Sprite.Scale;
        Vector2 imageSizeLava = new Vector2(PixelItem.Items[TanookiEnums.PixelTypes.Lava].Sprite.image.Width, PixelItem.Items[TanookiEnums.PixelTypes.Lava].Sprite.image.Height);

        //flag
        Vector2 scaleflag = PixelItem.Items[TanookiEnums.PixelTypes.Flag].Sprite.Scale;
        
        Vector2 imageSizeflag = new Vector2(PixelItem.Items[TanookiEnums.PixelTypes.Flag].Sprite.image.Width, PixelItem.Items[TanookiEnums.PixelTypes.Flag].Sprite.image.Height);

        //star
        Vector2 scalestar = PixelItem.Items[TanookiEnums.PixelTypes.Star].Sprite.Scale;
        Vector2 imageSizeStar = new Vector2(PixelItem.Items[TanookiEnums.PixelTypes.Star].Sprite.image.Width, PixelItem.Items[TanookiEnums.PixelTypes.Star].Sprite.image.Height);

        //flying mushroom
        Vector2 scaleMush = PixelItem.Items[TanookiEnums.PixelTypes.Mush].Sprite.Scale;
        Vector2 imageSizeMush = new Vector2(PixelItem.Items[TanookiEnums.PixelTypes.Mush].Sprite.image.Width, PixelItem.Items[TanookiEnums.PixelTypes.Mush].Sprite.image.Height);

        //sword
        Vector2 scaleSword = PixelItem.Items[TanookiEnums.PixelTypes.Sword].Sprite.Scale;
        Vector2 imageSizeSword = new Vector2(PixelItem.Items[TanookiEnums.PixelTypes.Sword].Sprite.image.Width, PixelItem.Items[TanookiEnums.PixelTypes.Sword].Sprite.image.Height);


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
                    // duplicate for lava and everything else
                    if (pixels[j, i] == PixelItem.Items[TanookiEnums.PixelTypes.Lava].PixelColor)
                    {
                        AddSprite(TanookiEnums.PixelTypes.Lava, position);
                    }
                    if (pixels[j, i] == PixelItem.Items[TanookiEnums.PixelTypes.Flag].PixelColor)
                    {
                        AddSprite(TanookiEnums.PixelTypes.Flag, position);
                    }
                    if (pixels[j, i] == PixelItem.Items[TanookiEnums.PixelTypes.Star].PixelColor)
                    {
                        AddSprite(TanookiEnums.PixelTypes.Star, position);
                    }
                    
                    if (pixels[j, i] == PixelItem.Items[TanookiEnums.PixelTypes.Mush].PixelColor)
                    {
                        AddSprite(TanookiEnums.PixelTypes.Mush, position);
                    }

                    
                    if (pixels[j, i] == PixelItem.Items[TanookiEnums.PixelTypes.Sword].PixelColor)
                    {
                        AddSprite(TanookiEnums.PixelTypes.Sword, position);
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
            // line below makes everything go to wall's scale
            // TODO: find a way to make scales of pixelitems independent of eachother
            Items[pixelType][Items[pixelType].Count - 1].Scale = scale;
          
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
