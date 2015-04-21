using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace Breach_Of_Contract
{
    class Bullet:Object
    {
        //Attributes
        protected Vector2 position;
        protected Rectangle bulletRect;
        protected float rotation;
        public bool isActive;

        //Properties
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public float Rotation
        {
            get { return rotation; }
        }
        //Constructor
        public Bullet()
        {
            position = new Vector2(0, 0);
            bulletRect = new Rectangle(0, 0, 64, 64);
            isActive = false;
        }
        
        public void move(Vector2 dest)
        {
            if (dest != Vector2.Zero)
            {
                Vector2 vector = new Vector2(dest.X - position.X, dest.Y - position.Y);
                Vector2 unitVector = Vector2.Normalize(vector);
                Vector2 newPosition = new Vector2(position.X + unitVector.X * 10, position.Y + unitVector.Y * 10);
                position = newPosition;
                bulletRect = new Rectangle((int)position.X - 16, (int)position.Y - 16, 64,64);
                rotation = (float)Math.Atan2(vector.X, -vector.Y);
            }

        }
    }
}
