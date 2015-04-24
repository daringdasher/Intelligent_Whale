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
    class Enemy:Character
    {
        //Attributes
        protected Weapon weapon;
        protected Vector2 position;
        protected int health;
        protected bool isBehindCover;
        protected bool isDead;
        protected Rectangle enemyRec;
        protected float rotaion;

        //Properties
        public Vector2 Position
        {
            get { return position; }
        }
        public float Rotation
        {
            get { return rotaion; }
        }
        public Rectangle Rectangle
        {
            get { return enemyRec; }
        }

        //Constructor
        public Enemy( /*Weapon[] weaps,*/ Vector2 pos):base()
        {
            health = 100;
            //weapons = weaps;
            position = pos;
            enemyRec = new Rectangle((int)position.X-32, (int)position.Y-32, 64, 64);
        }
        public override void Shoot(Vector2 bulletDest, List<Enemy> target, out List<Enemy> enemiesStillAlive) { enemiesStillAlive = new List<Enemy>(); }

        public override void Shoot(Vector2 bulletDest, List<Player> player)
        {
            throw new NotImplementedException();
        }
        public void move(Vector2 dest)
        {
            if (dest != Vector2.Zero)
            {
                Vector2 vector = new Vector2(dest.X - position.X, dest.Y - position.Y);
                Vector2 unitVector = Vector2.Normalize(vector);
                Vector2 newPosition = new Vector2(position.X + unitVector.X * 1, position.Y + unitVector.Y * 1);
                position = newPosition;
                enemyRec = new Rectangle((int)position.X - 32, (int)position.Y - 32, 64, 64);
                rotaion = (float)Math.Atan2(vector.X, -vector.Y);
            }
        }
    }
}
