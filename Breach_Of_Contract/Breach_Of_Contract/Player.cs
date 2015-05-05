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
    //Player Class that will control the 4 Main characters.
    class Player:Character
    {
        //Attributes
        protected string id;
        protected Weapon[] weapons;
        protected Vector2 position;
        protected int health;
        protected bool isBehindCover;
        protected bool isDead;
        protected Rectangle playerRect;
        protected float rotation;
        public Vector2 destination;
        //Properties
        public Vector2 Position
        {
            get { return position; }
        }
        public String ID
        {
            get { return id; }
        }
        public Rectangle PlayerRect
        {
            get { return playerRect; }
        }
        public Weapon[] Weapons
        {
            get { return weapons; }
        }
        public float Rotation
        {
            get { return rotation; }
        }
        //Constructor
        public Player(string identity, Weapon[] weaps, Vector2 pos):base()
        {
            health = 100;
            id = identity;
            weapons = new Weapon[weaps.Length];
            for(int i = 0; i < weaps.Length; i++)
            {
                weapons[i] = weaps[i];
            }
            position = pos;
            playerRect = new Rectangle((int)position.X-32, (int)position.Y-32, 64, 64);
        }
        public void move(List<Cover> cov)
        {
            if (destination != Vector2.Zero)
            {
                Vector2 vector = new Vector2(destination.X - position.X, destination.Y - position.Y);
                Vector2 unitVector = Vector2.Normalize(vector);
                Vector2 newPosition = new Vector2(position.X + unitVector.X * 2, position.Y + unitVector.Y * 2);
                foreach (Cover c in cov)
                {
                    if (new Rectangle((int)newPosition.X - 32, (int)newPosition.Y - 32, 64, 64).Intersects(c.ObjRect))
                    {
                        Vector2 tempDest = new Vector2(-unitVector.Y, -unitVector.X);
                        vector = new Vector2(tempDest.X - position.X, tempDest.Y - position.Y);
                        unitVector = Vector2.Normalize(vector);
                        newPosition = new Vector2(position.X + unitVector.X * 2, position.Y + unitVector.Y * 2);
                    }
                }

                playerRect = new Rectangle((int)position.X - 32, (int)position.Y - 32, 64, 64);
                position = newPosition;

                rotation = (float)Math.Atan2(vector.X, -vector.Y);
            }

        }

        public void update( Vector2 bulletDestination,List<Enemy> enems,List<Cover> cover)
        {
            if ((position.X > destination.X - 1) && (position.X < destination.X + 1) && (position.Y > destination.Y - 1) && (position.Y < destination.Y + 1)) destination = new Vector2(0, 0);
            move(cover);
            Shoot(bulletDestination, enems);
           
        }

        public override void Shoot(Vector2 bulletDest, List<Player> target) { }

        public override void Shoot(Vector2 bulletDest, List<Enemy> enemies)
        {
            
            //Rotate to shoot
            Vector2 vector = new Vector2(bulletDest.X - position.X, bulletDest.Y - position.Y);
            rotation = (float)Math.Atan2(vector.X, -vector.Y);
            foreach (Weapon element in weapons)
            {
                if (element.isActiveWeap)
                {
                    element.update();
                    element.Shoot(position, bulletDest,enemies);
                }
               
            }
        }
        public void SwitchWeapon()
        {
            if (weapons[0].isActiveWeap) { weapons[1].isActiveWeap = true; weapons[0].isActiveWeap = false; return; }
            if (weapons[1].isActiveWeap) { weapons[0].isActiveWeap = true; weapons[1].isActiveWeap = false; return; }
        }
    }
}
