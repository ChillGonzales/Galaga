using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace x_platform.GameObjects
{
    public class Player : Character
    {
        public bool Firing { get; set; }
        private const float FIRE_RATE = 70, PROJECTILE_SPEED = 5;
        private int projectilesToAdd_ = 0;
        private Timer projectileTimer_;
        private bool projectileTimerElapsed_;

        public Player(Texture2D texture, Vector2 startPos, Texture2D projectileTexture, List<Entity> otherEntities) : base(texture, startPos, projectileTexture, otherEntities)
        {
            this.movementSpeed_ = 10f;
            projectileTimer_ = new Timer(FIRE_RATE);
            projectileTimer_.Elapsed += ProjectileTimer_Elapsed;
            this.objectID = 1;
        }

        private void ProjectileTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            projectileTimerElapsed_ = true;
        }

        protected override void UpdateLogic(GameTime gameTime)
        {
            if (Firing && projectileTimerElapsed_) 
            {
                projectilesToAdd_ += 1;
                projectileTimerElapsed_ = false;
            }
            else if(Firing && !projectileTimerElapsed_) { projectileTimer_.Start(); }
            for (int i = 0; i < projectilesToAdd_; i++)
            {
                SpawnProjectile();
                projectilesToAdd_ -= 1;
            }
            foreach (var p in projectilesPool_[3].Where(x => x.Active))
            {
                p.Update(gameTime);
            }
        }
        public void MoveObject(MovementDirections direction)
        {
            switch (direction)
            {
                case MovementDirections.Down:
                    this.Move(new Vector2(0f, movementSpeed_));
                    return;
                case MovementDirections.Left:
                    this.Move(new Vector2(-movementSpeed_, 0f));
                    return;
                case MovementDirections.Right:
                    this.Move(new Vector2(movementSpeed_, 0f));
                    return;
                case MovementDirections.Up:
                    this.Move(new Vector2(0, -movementSpeed_));
                    return;
            }
        }

        protected override void CheckCollisions()
        {
        }

        protected override void Destroy()
        {
        }
    }

    public enum MovementDirections
    {
        Up,
        Down,
        Left,
        Right
    }
}
