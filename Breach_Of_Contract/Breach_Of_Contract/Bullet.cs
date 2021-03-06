﻿using System;
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
    class Bullet
    {
        //Attributes
        protected Vector2 position;
        protected Rectangle bulletRect;
        protected float rotation;
        public bool isActive;
        public Vector2 destination;
        public bool canDraw;
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

        public Rectangle BulletRect
        {
            get { return bulletRect; }
            set { bulletRect = value; }
        }
        //Constructor
        public Bullet()
        {
            position = new Vector2(0, 0);
            bulletRect = new Rectangle(1, 1, 16, 16);
            isActive = false;
            canDraw = false;
        }
        
        public void move()
        {
            if (destination != Vector2.Zero)
            {
                Vector2 vector = new Vector2(destination.X - position.X, destination.Y - position.Y);
                Vector2 unitVector = Vector2.Normalize(vector);
                Vector2 newPosition = new Vector2(position.X + unitVector.X * 6, position.Y + unitVector.Y * 6);
                position = newPosition;
                bulletRect = new Rectangle((int)position.X - 4, (int)position.Y - 4, 16,16);
                rotation = (float)Math.Atan2(vector.X, -vector.Y);
                if ((position.X > destination.X - 3) && (position.X < destination.X + 3) && (position.Y > destination.Y - 3) && (position.Y < destination.Y + 3)) { destination = new Vector2(0, 0); isActive = false; }

            }
            if (bulletRect.Center.Y < 0 || bulletRect.Center.Y > 720||bulletRect.Center.X<0||bulletRect.Center.X>1280) { destination = new Vector2(0, 0); isActive = false; }
        }
        public void Collision(Enemy target,out bool hit)
        {
            if (bulletRect.Intersects(target.Rectangle)&&isActive) {
                isActive = false; destination = new Vector2(0, 0); hit = true; canDraw = false;
            }
            else hit = false;
        }

        public void Collision(Player target, out bool hit)
        {
            if (bulletRect.Intersects(target.Rectangle) && isActive)
            {
                isActive = false; destination = new Vector2(0, 0); hit = true; canDraw = false;
            }
            else hit = false;
        }
    }
}
