using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private Character ownerInstance_;

        public Projectile(Texture2D texture, Vector2 startPos, float flySpeed, Character owner, List<Entity> otherEntities) : base(startPos, otherEntities)
        {
            flySpeed_ = flySpeed;
            texture_ = texture;
            this.ownerInstance_= owner;
            this.setActive(false);
            this.damage = 3;
        }
        protected override void UpdateLogic(GameTime gameTime)
        {
            if (Active == true) { 
                this.Move(new Vector2(0f, -flySpeed_));
                if (this.position_.X < 0 || this.position_.X > GameLoop.GraphicsDimensions.X + 30 || this.position_.Y < 0 || this.position_.Y > GameLoop.GraphicsDimensions.Y + 30)
                {
                    this.setActive(false);
                }
            }
        }
        protected override void CheckCollisions()
        {
            foreach(var ent in otherEntities_)
            {
                if (this.CollisionRectangle.Intersects(ent.CollisionRectangle) && (ent.objectID != this.ownerInstance_.objectID))
                {
                    ent.HandleDamage(this.damage);
                    this.Destroy();
                    Debug.Print("Collision!");
                }
            }
        }
        public void setActive(bool flag)
        {
            if (!flag)
            {
                this.ownerInstance_.RemoveActiveProjectile(this);
            }
            Active = flag;
        }
        public void setPosition(Vector2 newPosition)
        {
            this.position_ = newPosition;
        }
        protected override void Destroy()
        {
            this.setActive(false);
        }
    }

}
