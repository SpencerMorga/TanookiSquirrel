using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TanookiSquirrel
{
    class Labels
    {
        public SpriteFont font;      

        public Vector2 position;
        public Color color;
        public string text;
        public Labels (SpriteFont font, string text, Vector2 position, Color color)
        {
            this.font = font;
            this.text = text;
            this.position = position;
            this.color = color;
        }
        public void Draw (SpriteBatch spritebatch)
        {
            spritebatch.DrawString(font, text, position, color);
        }
    }
}
