using Microsoft.Xna.Framework;
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
        public bool OutOfBounds { get; private set; }

        public Projectile(Texture2D texture, Vector2 startPos, float flySpeed) : base(texture, startPos)
        {
            flySpeed_ = flySpeed;
        }

        protected override void UpdateLogic(GameTime gameTime)
        {
            this.Move(new Vector2(0f, -flySpeed_));
            if (this.position_.X < 0 || this.position_.X > GameLoop.GraphicsDimensions.X + 30 || this.position_.Y < 0 || this.position_.Y > GameLoop.GraphicsDimensions.Y + 30)
            {
                OutOfBounds = true;
            }
        }
    }

}
