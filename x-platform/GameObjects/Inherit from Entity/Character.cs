using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public List<Projectile> ActiveProjectiles = new List<Projectile>();
        protected float movementSpeed_ = 5f;
        protected Vector2 ProjectilePosition { get { return new Vector2(this.position_.X + this.texture_.Width / 2, this.position_.Y); } }

        protected Character(Texture2D texture, Vector2 startPos, Texture2D projectileTexture, List<Entity> otherEntities) : base(startPos, otherEntities)
        {
            this.projectileTexture_ = projectileTexture;
            this.texture_ = texture;
            projectilesPool_.Add(3, new Queue<Projectile>());
            for (var i = 0; i < PROJECTILE_MAX; i++)
            {
                projectilesPool_[3].Enqueue(new Projectile(projectileTexture_, startPos, 15f, this, otherEntities_));
            }
        }
        protected virtual void SpawnProjectile()
        {
            Projectile p = projectilesPool_[3].Dequeue();
            p.setPosition(this.ProjectilePosition);
            p.setActive(true);
            projectilesPool_[3].Enqueue(p);
            ActiveProjectiles.Add(p);
        }
        public void RemoveActiveProjectile(Projectile proj)
        {
            ActiveProjectiles.Remove(proj);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            foreach (var p in projectilesPool_[3].Where(x => x.Active == true))
            {
                p.Draw(spriteBatch);
            }
        }
    }
}
