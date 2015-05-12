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
        protected Weapon weapon = new Weapon();
        protected Vector2 position;
        protected int health;
        protected bool isBehindCover;
        protected bool isDead;
        protected Rectangle enemyRec;
        protected float rotation;


        //Properties
        public Vector2 Position
        {
            get { return position; }
        }
        public float Rotation
        {
            get { return rotation; }
        }
        public Rectangle Rectangle
        {
            get { return enemyRec; }
        }
        public bool IsDead
        {
            get { return isDead; }
            set { isDead = value; }
        }

        //Constructor
        public Enemy(Vector2 pos):base()
        {
            health = 100;
            weapon = new Weapon();
            position = pos;
            enemyRec = new Rectangle((int)position.X-32, (int)position.Y-32, 64, 64);
        }
        
        public override void Shoot(Vector2 bulletDest, List<Enemy> target) { }

        public override void Shoot(Vector2 bulletDest, List<Player> players)
        {
            if (!isDead && weapon.canFire)
            {
                for(int i = 0; i < weapon.bullets.Count; i++)
                {
                    if (weapon.bullets[i].isActive)
                    {

                        weapon.bullets[i].canDraw = true;
                        weapon.bullets[i].move();
                        Console.WriteLine("Active");
                    }
                    
                    else if (!(weapon.bullets[i].isActive))
                    {
                        weapon.bullets[i].canDraw = false;
                        weapon.canFire = false;
                        weapon.bullets[i].isActive = true;
                        weapon.bullets[i].destination = bulletDest;
                        weapon.bullets[i].Position = position;
                        weapon.bullets[i].BulletRect = new Rectangle((int)position.X, (int)position.Y, 16, 16);
                        Vector2 vector = new Vector2(weapon.bullets[i].destination.X - weapon.bullets[i].Position.X, weapon.bullets[i].destination.Y - weapon.bullets[i].Position.Y);
                        Vector2 unitVector = Vector2.Normalize(vector);
                        weapon.bullets[i].Position = position - ((25 * i) * unitVector);
                        Console.WriteLine("InActive");
                    }
                    
                    foreach (Player play in players)
                    {
                        bool hit;
                        weapon.bullets[i].Collision(play, out hit);
                        if (hit) { play.IsDead = true; }
                    }

                }
            }
            
        }

        public void update(Vector2 bulletDestination, List<Player> plays, List<Cover> cover)
        {            
            if(weapon.canFire)
            Shoot(bulletDestination, plays);
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
                rotation = (float)Math.Atan2(vector.X, -vector.Y);
            }
        }
    }
}
