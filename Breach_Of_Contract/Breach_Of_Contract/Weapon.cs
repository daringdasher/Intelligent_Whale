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
using System.Threading;

namespace Breach_Of_Contract
{
    //Parent Class to Gun and Melee
    class Weapon
    {
        //Attributes
        public double fireRate;        //Seconds between shots
        public double spread;          //Degrees
        public double bulletsPerShot;  //Number of bullets fired each time the gun is shot
        public bool canFire;           //If the weapon can currently fire
        public double timeToNextShot;
        public int damage;
        public bool isActiveWeap;
        public List<Bullet> bullets = new List<Bullet>();
        Random rgen;
        //Constructor;
        public Weapon(double fr,double sp,double bps,bool active)
        {
            fireRate = fr;
            spread = sp;
            bulletsPerShot = bps;
            canFire = true;
            timeToNextShot = fireRate;
            isActiveWeap = active;
            for(int i=0;i<bulletsPerShot;i++){
                bullets.Add(new Bullet());
            }
        }
        public Weapon()
        {
            fireRate = 2;
            spread = 5;
            bulletsPerShot = 1;
            canFire = true;
            timeToNextShot = fireRate;
            isActiveWeap = true;
            for (int i = 0; i < bulletsPerShot; i++)
            {
                bullets.Add(new Bullet());
            }
        }
        public void update()
        {
            if (timeToNextShot <= 0)
            {
                canFire = true;
                timeToNextShot = fireRate;
            }
            if ((!(canFire))&&timeToNextShot > 0)
            {
                timeToNextShot = (timeToNextShot - (1 / 60.0));
            }

        }

        internal void Shoot(Vector2 startPos, Vector2 endDest, List<Enemy> enems)
        {
            if (canFire&&isActiveWeap)
            {
                for (int i = 0; i < bullets.Count;i++ )
                {
                    if (bullets[i].isActive)
                    {
                        bullets[i].canDraw = true;
                        bullets[i].move();
                        Console.WriteLine("Active");
                    }
                    else if(!(bullets[i].isActive))
                    {
                        bullets[i].canDraw = false;
                        canFire = false;
                        bullets[i].isActive = true;
                        bullets[i].destination = endDest;
                        bullets[i].Position = startPos;
                        Vector2 vector = new Vector2(bullets[i].destination.X - bullets[i].Position.X, bullets[i].destination.Y - bullets[i].Position.Y);
                        Vector2 unitVector = Vector2.Normalize(vector);
                        bullets[i].Position = startPos - ((25*i) * unitVector);
                        Console.WriteLine("InActive");
                    }
                    foreach (Enemy enemy in enems)
                    {
                        bullets[i].Collision(enemy);
                    }

                }
            }
        }
    }
}
