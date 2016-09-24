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
        protected const int PROJECTILE_MAX = 512;
        
        protected Texture2D projectileTexture_;
        protected Dictionary<int, Queue<Projectile>> projectilesPool_ = new Dictionary<int,Queue<Projectile>>();
        protected float movementSpeed_ = 5f;
        protected Vector2 ProjectilePosition { get { return new Vector2(this.position_.X + this.texture_.Width / 2, this.position_.Y); } }

        protected Character(Texture2D texture, Vector2 startPos, Texture2D projectileTexture) : base(startPos)
        {
            this.projectileTexture_ = projectileTexture;
            this.texture_ = texture;
            projectilesPool_.Add(123, new Queue<Projectile>());
            for (var i = 0; i < PROJECTILE_MAX; i++)
            {
                projectilesPool_[123].Enqueue(new Projectile(projectileTexture_, startPos, 15f));
            }
        }

        protected virtual void SpawnProjectile()
        {
            var p = projectilesPool_[123].Dequeue();
            p.setPosition(this.ProjectilePosition);
            p.setActive(true);
            projectilesPool_[123].Enqueue(p);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            foreach (var p in projectilesPool_[123].Where(x => x.Active == true))
            {
                p.Draw(spriteBatch);
            }
        }
    }
}
