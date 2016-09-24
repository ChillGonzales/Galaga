﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace x_platform.GameObjects
{
    public class Projectile : Entity
    {
        public bool IsHit { get; private set; }
        private float flySpeed_;
        public bool Active { get; private set; }

        public Projectile(Texture2D texture, Vector2 startPos, float flySpeed) : base(startPos)
        {
            flySpeed_ = flySpeed;
            texture_ = texture;
            this.setActive(false);
        }

        protected override void UpdateLogic(GameTime gameTime)
        {
            if (Active == true) { 
                this.Move(new Vector2(0f, -flySpeed_));
                if (this.position_.X < 0 || this.position_.X > GameLoop.GraphicsDimensions.X + 30 || this.position_.Y < 0 || this.position_.Y > GameLoop.GraphicsDimensions.Y + 30)
                {
                    Active = false;
                }
            }
        }

        public void setActive(bool flag)
        {
            Active = flag;
        }

        public void setPosition(Vector2 newPosition)
        {
            this.position_ = newPosition;
        }
    }

}
