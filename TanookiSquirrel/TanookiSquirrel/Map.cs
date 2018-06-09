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

        //laserwall
        Vector2 scaleLaserwall = PixelItem.Items[TanookiEnums.PixelTypes.LaserWall].Sprite.Scale;
        Vector2 imageSizeLaserwall = new Vector2(PixelItem.Items[TanookiEnums.PixelTypes.LaserWall].Sprite.image.Width, PixelItem.Items[TanookiEnums.PixelTypes.LaserWall].Sprite.image.Height);

        //button
        Vector2 scaleButton = PixelItem.Items[TanookiEnums.PixelTypes.Button].Sprite.Scale;
        Vector2 imageSizeButton = new Vector2(PixelItem.Items[TanookiEnums.PixelTypes.Button].Sprite.image.Width, PixelItem.Items[TanookiEnums.PixelTypes.Button].Sprite.image.Height);

        //poisonwall
        Vector2 scaleRedWall = PixelItem.Items[TanookiEnums.PixelTypes.RedWall].Sprite.Scale;
        Vector2 imageSizeRedWall = new Vector2(PixelItem.Items[TanookiEnums.PixelTypes.RedWall].Sprite.image.Width, PixelItem.Items[TanookiEnums.PixelTypes.RedWall].Sprite.image.Height);

        //bowser
        Vector2 scalebowser = PixelItem.Items[TanookiEnums.PixelTypes.Bowser].Sprite.Scale;
        Vector2 imageSizebowser = new Vector2(PixelItem.Items[TanookiEnums.PixelTypes.Bowser].Sprite.image.Width, PixelItem.Items[TanookiEnums.PixelTypes.Bowser].Sprite.image.Height);

        //shield
        Vector2 scaleshield = PixelItem.Items[TanookiEnums.PixelTypes.Shield].Sprite.Scale;
        Vector2 imageSizeshield = new Vector2(PixelItem.Items[TanookiEnums.PixelTypes.Shield].Sprite.image.Width, PixelItem.Items[TanookiEnums.PixelTypes.Shield].Sprite.image.Height);

        //goomba
        Vector2 scalegoomba = PixelItem.Items[TanookiEnums.PixelTypes.Goomba].Sprite.Scale;
        Vector2 imageSizegoomba = new Vector2(PixelItem.Items[TanookiEnums.PixelTypes.Goomba].Sprite.image.Width, PixelItem.Items[TanookiEnums.PixelTypes.Shield].Sprite.image.Height);
        
        //reverseshield
        Vector2 scalerevshield = PixelItem.Items[TanookiEnums.PixelTypes.Revshield].Sprite.Scale;
        Vector2 imageSizerevshield = new Vector2(PixelItem.Items[TanookiEnums.PixelTypes.Revshield].Sprite.image.Width, PixelItem.Items[TanookiEnums.PixelTypes.Revshield].Sprite.image.Height);

        //secret flag
        Vector2 scalesecretflag = PixelItem.Items[TanookiEnums.PixelTypes.SecretFlag].Sprite.Scale;
        Vector2 imageSizesecretflag = new Vector2(PixelItem.Items[TanookiEnums.PixelTypes.SecretFlag].Sprite.image.Width, PixelItem.Items[TanookiEnums.PixelTypes.SecretFlag].Sprite.image.Height);

        //cheep cheep
        Vector2 scalecheepcheep = PixelItem.Items[TanookiEnums.PixelTypes.CheepCheep].Sprite.Scale;
        Vector2 imageSizecheepcheep = new Vector2(PixelItem.Items[TanookiEnums.PixelTypes.CheepCheep].Sprite.image.Width, PixelItem.Items[TanookiEnums.PixelTypes.CheepCheep].Sprite.image.Height);

        //coral
        Vector2 scalecoral = PixelItem.Items[TanookiEnums.PixelTypes.Coral].Sprite.Scale;
        Vector2 imageSizecoral = new Vector2(PixelItem.Items[TanookiEnums.PixelTypes.Coral].Sprite.image.Width, PixelItem.Items[TanookiEnums.PixelTypes.Coral].Sprite.image.Height);

        //cactus thingy
        Vector2 scalecactus = PixelItem.Items[TanookiEnums.PixelTypes.Cactus].Sprite.Scale;
        Vector2 imageSizecactus = new Vector2(PixelItem.Items[TanookiEnums.PixelTypes.Cactus].Sprite.image.Width, PixelItem.Items[TanookiEnums.PixelTypes.Cactus].Sprite.image.Height);

        //actual water
        Vector2 scalewater = PixelItem.Items[TanookiEnums.PixelTypes.Water].Sprite.Scale;
        Vector2 imageSizewater = new Vector2(PixelItem.Items[TanookiEnums.PixelTypes.Water].Sprite.image.Width, PixelItem.Items[TanookiEnums.PixelTypes.Water].Sprite.image.Height);

        //coin
        Vector2 scalecoin = PixelItem.Items[TanookiEnums.PixelTypes.Coin].Sprite.Scale;
        Vector2 imageSizecoin = new Vector2(PixelItem.Items[TanookiEnums.PixelTypes.Coin].Sprite.image.Width, PixelItem.Items[TanookiEnums.PixelTypes.Coin].Sprite.image.Height);
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
                    if (pixels[j, i] == PixelItem.Items[TanookiEnums.PixelTypes.Button].PixelColor)
                    {
                        AddSprite(TanookiEnums.PixelTypes.Button, position);
                    }
                    if (pixels[j, i] == PixelItem.Items[TanookiEnums.PixelTypes.LaserWall].PixelColor)
                    {
                        AddSprite(TanookiEnums.PixelTypes.LaserWall, position);
                    }
                    if (pixels[j, i] == PixelItem.Items[TanookiEnums.PixelTypes.RedWall].PixelColor)
                    {
                        AddSprite(TanookiEnums.PixelTypes.RedWall, position);
                    }
                    if (pixels[j, i] == PixelItem.Items[TanookiEnums.PixelTypes.Bowser].PixelColor)
                    {
                        AddSprite(TanookiEnums.PixelTypes.Bowser, position);
                    }
                    if (pixels[j, i] == PixelItem.Items[TanookiEnums.PixelTypes.Shield].PixelColor)
                    {
                        AddSprite(TanookiEnums.PixelTypes.Shield, position);
                    }
                    if (pixels[j, i] == PixelItem.Items[TanookiEnums.PixelTypes.Goomba].PixelColor)
                    {
                        AddSprite(TanookiEnums.PixelTypes.Goomba, position);
                    }
                    if (pixels[j, i] == PixelItem.Items[TanookiEnums.PixelTypes.Revshield].PixelColor)
                    {
                        AddSprite(TanookiEnums.PixelTypes.Revshield, position);
                    }
                    if (pixels[j, i] == PixelItem.Items[TanookiEnums.PixelTypes.SecretFlag].PixelColor)
                    {
                        AddSprite(TanookiEnums.PixelTypes.SecretFlag, position);
                    }
                    if (pixels[j, i] == PixelItem.Items[TanookiEnums.PixelTypes.CheepCheep].PixelColor)
                    {
                        AddSprite(TanookiEnums.PixelTypes.CheepCheep, position);
                    }
                    if (pixels[j, i] == PixelItem.Items[TanookiEnums.PixelTypes.Coral].PixelColor)
                    {
                        AddSprite(TanookiEnums.PixelTypes.Coral, position);
                    }
                    if (pixels[j, i] == PixelItem.Items[TanookiEnums.PixelTypes.Cactus].PixelColor)
                    {
                        AddSprite(TanookiEnums.PixelTypes.Cactus, position);
                    }
                    if (pixels[j, i] == PixelItem.Items[TanookiEnums.PixelTypes.Water].PixelColor)
                    {
                        AddSprite(TanookiEnums.PixelTypes.Water, position);
                    }
                    if (pixels[j, i] == PixelItem.Items[TanookiEnums.PixelTypes.Coin].PixelColor)
                    {
                        AddSprite(TanookiEnums.PixelTypes.Coin, position);
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
            Items[pixelType][Items[pixelType].Count - 1].Scale = PixelItem.Items[pixelType].Sprite.Scale;
          
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
