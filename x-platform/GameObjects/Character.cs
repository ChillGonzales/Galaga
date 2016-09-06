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
        protected List<Projectile> projectiles_;
        protected float movementSpeed_ = 5f;

        protected Character(Texture2D texture, Vector2 startPos, Texture2D projectileTexture) : base(texture, startPos)
        {
            this.projectileTexture_ = projectileTexture;
            projectiles_ = new List<Projectile>();
        }

        protected virtual void SpawnProjectile()
        {
            var proj = new Projectile(this.projectileTexture_, this.position_);
            projectiles_.Add(proj);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            foreach (var p in projectiles_)
            {
                spriteBatch.Draw(p.Texture, p.Position, Color.White);
            }
        }
    }
}
