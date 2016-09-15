using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace x_platform.GameObjects
{
    public abstract class Character : Entity
    {
        protected Texture2D projectileTexture_;
        protected Projectile[] projectiles_;
        protected const int PROJECTILE_MAX = 512;
        protected int projectileCounter_;
        protected float movementSpeed_ = 5f;

        protected Character(Texture2D texture, Vector2 startPos, Texture2D projectileTexture) : base(startPos)
        {
            this.projectileTexture_ = projectileTexture;
            this.texture_ = texture;
            this.projectiles_ = new Projectile[512];
        }

        protected virtual void SpawnProjectile(float flySpeed)
        {
            var proj = new Projectile(this.projectileTexture_, new Vector2(this.position_.X + (this.texture_.Width / 2), this.position_.Y), flySpeed);

            // Check if any projectiles in current array are out of bounds and can be overwritten
            for (int i = 0; i < PROJECTILE_MAX; i++)
            {
                if (projectiles_[i] != null)
                {
                    {
                        projectileCounter_ = i;
                        i = PROJECTILE_MAX;
                    }
                }
            }
            projectiles_[projectileCounter_] = proj;
            projectileCounter_ += 1;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            foreach (var p in projectiles_)
            {
                if (p != null)
                {
                    spriteBatch.Draw(p.Texture, p.Position, Color.White);
                }
            }
        }
    }
}
