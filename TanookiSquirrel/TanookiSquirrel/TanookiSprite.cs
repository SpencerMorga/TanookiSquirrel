using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TanookiSquirrel
{
    public class TanookiSprite
    {
        public Texture2D image;
        public Vector2 position;
        public Color color;        
        public Vector2 scale;
        public Rectangle? sourceRectangle;
        public Rectangle hitbox
        {
            get
            {
                if (sourceRectangle == null)
                {
                    return new Rectangle((int)position.X, (int)position.Y, (int)(image.Width * scale.X), (int)(image.Height * scale.Y));
                }
                
                return new Rectangle((int)position.X, (int)position.Y, (int)(sourceRectangle.Value.Width * scale.X), (int)(sourceRectangle.Value.Height * scale.Y));
            }
        }

        public TanookiSprite (Texture2D image, Vector2 position, Color color)
        {
            this.image = image;
            this.position = position;
            this.color = color;
            scale = Vector2.One;            
        }

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(image, position, sourceRectangle, color, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }

        public void DrawHitbox(SpriteBatch sb, Color hitboxColor, GraphicsDevice graphicsDevice)
        {
            Texture2D pixel = new Texture2D(graphicsDevice, 1, 1);
            pixel.SetData(new Color[] { hitboxColor });

            sb.Draw(pixel, hitbox, Color.White);
        }
    }
}
