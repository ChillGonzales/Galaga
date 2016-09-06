using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace x_platform.GameObjects
{
    public class Player : Character
    {
        public bool Firing { get; set; }

        public Player(Texture2D texture, Vector2 startPos, Texture2D projectileTexture) : base(texture, startPos, projectileTexture)
        {
            this.movementSpeed_ = 10f;
        }

        protected override void UpdateLogic(GameTime gameTime)
        {
            if (Firing)
            {
                SpawnProjectile();
            }
            if (this.projectiles_.Capacity > 0)
            {
                foreach(var proj in this.projectiles_)
                {
                    proj.Update(gameTime);
                }
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
    }

    public enum MovementDirections
    {
        Up,
        Down,
        Left,
        Right
    }
}
