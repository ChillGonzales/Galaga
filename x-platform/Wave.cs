using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using x_platform.GameObjects;

namespace x_platform
{
    public class Wave : Entity
    {
        private int waveSize_;
        private Player[] waveUnits_;
        private Texture2D enemyTexture_, projectileTexture_;

        public Wave(int numEnemies)
        {
            waveSize_ = numEnemies;
            enemyTexture_ = x_platform.GameLoop.textureDict[GameLoop.TextureNames.Enemy];
            projectileTexture_ = x_platform.GameLoop.textureDict[GameLoop.TextureNames.Projectile];
        }
        public void Start()
        {
            for (int i = 0; i < waveSize_; i++)
            {
                var startPos = new Vector2((float)i * 200, 200);
                waveUnits_[i] = new Player(enemyTexture_, startPos, projectileTexture_);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {

        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

    }
}
