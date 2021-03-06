﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TanookiSquirrel
{
    public class TanookiAnimation : TanookiSprite
    {
        TimeSpan elaspedtanookiTime;
        public TimeSpan Time2wait4tanooki = new TimeSpan(0, 0, 0, 0, 70);
        protected List<Frame> frames;
        public int currentTanookiframeIndex = 0;

        public TanookiAnimation (Texture2D image, Vector2 position, Color color, List<Frame> frames)
            : base (image, position, color)
        {
            this.image = image;
            this.position = position;
            this.frames = frames;
            this.color = color;
            elaspedtanookiTime = TimeSpan.Zero;
        }

        public virtual void Update(GameTime gTime)
        {
            elaspedtanookiTime += gTime.ElapsedGameTime;
            
            if (elaspedtanookiTime > Time2wait4tanooki)
            {
                currentTanookiframeIndex++;
                if (currentTanookiframeIndex >= frames.Count)
                {
                    currentTanookiframeIndex = 0;
                }
                elaspedtanookiTime = TimeSpan.Zero;
            }
            sourceRectangle = frames[currentTanookiframeIndex].frame;
            //hitbox = new Rectangle((int)position.X, (int)position.Y, frames[currentTanookiframeIndex].frame.Width, frames[currentTanookiframeIndex].frame.Height);
        }
        
    }
}
