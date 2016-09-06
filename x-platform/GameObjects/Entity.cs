using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace x_platform.GameObjects
{
    public abstract class Entity
    {
        protected Texture2D texture_;
        protected Vector2 position_;
        protected double updateTimer_;
        protected const double updateFrequency_ = 1/60f; // all inherited objects will update at 60 fps
        public Vector2 Position { get { return position_; } }
        public Texture2D Texture { get { return texture_; } }

        protected Entity(Texture2D entityTexture, Vector2 startPos)
        {
            this.texture_ = entityTexture;
            this.position_ = startPos;
        }

        protected virtual void Move(Vector2 displacement)
        {
            this.position_ += displacement;
        }

        public virtual void Update(GameTime gameTime)
        {
            if (CheckUpdateTime(gameTime))
            {
                UpdateLogic(gameTime);
            }
        }
        
        protected bool CheckUpdateTime(GameTime gameTime)
        {
            updateTimer_ += gameTime.ElapsedGameTime.TotalSeconds;
            if (updateTimer_ > updateFrequency_)
            {
                updateTimer_ -= updateFrequency_;
                return true;
            }
            else { return false; }
        }
        protected abstract void UpdateLogic(GameTime gameTime);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture_, position_, Color.White);
        }


    }
}
