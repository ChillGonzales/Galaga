using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace x_platform.GameObjects
{
    public class Projectile : Entity
    {
        public bool IsHit { get; private set; }

        public Projectile(Texture2D texture, Vector2 startPos) : base(texture, startPos) { }

        protected override void UpdateLogic(GameTime gameTime)
        {
            this.Move(new Vector2(0f, -10f));
        }
    }

}
