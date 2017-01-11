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
        public Enemy(Texture2D texture, Vector2 startPos, Texture2D projectileTexture) : base(texture, startPos, projectileTexture)
        {

        }

        protected override void UpdateLogic(GameTime gameTime)
        {
        }
    }
}
