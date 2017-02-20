using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace x_platform.GameObjects
{
    public class Enemy : Character
    {
        public Enemy(Texture2D texture, Vector2 startPos, Texture2D projectileTexture, List<Entity> otherEntities) : base(texture, startPos, projectileTexture, otherEntities)
        {
            this.objectID = 2;
            this.armor = 2;
            this.health = 50;
        }

        protected override void Destroy()
        {
        }

        protected override void UpdateLogic(GameTime gameTime)
        {
        }

        protected override void CheckCollisions()
        {
        }
    }
}
