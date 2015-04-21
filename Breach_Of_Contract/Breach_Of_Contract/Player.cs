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
            weapons = weaps;
            position = pos;
            playerRect = new Rectangle(0, 0, 64, 64);
        }
        public void move(Vector2 dest)
        {
            if (dest != Vector2.Zero)
            {
                Vector2 vector = new Vector2(dest.X - position.X, dest.Y - position.Y);
                Vector2 unitVector = Vector2.Normalize(vector);
                Vector2 newPosition = new Vector2(position.X + unitVector.X * 2, position.Y + unitVector.Y * 2);
                position = newPosition;
                playerRect = new Rectangle((int)position.X - 32, (int)position.Y - 32, 64, 64);
                rotation = (float)Math.Atan2(vector.X, -vector.Y);
            }

        }
        public override void Shoot()
        {
            throw new NotImplementedException();
        }
    }
}
