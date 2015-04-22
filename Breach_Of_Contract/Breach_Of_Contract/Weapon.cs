using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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

        //Constructor;
        public Weapon(double fr,double sp,double bps,bool active)
        {
            fireRate = fr;
            spread = sp;
            bulletsPerShot = bps;
            canFire = true;
            timeToNextShot = fireRate;
            isActiveWeap = active;
        }
        public Weapon()
        {
            fireRate = 2;
            spread = 5;
            bulletsPerShot = 1;
            canFire = true;
            timeToNextShot = fireRate;
            isActiveWeap = true;
        }
        public void update()
        {
            if (timeToNextShot <= 0)
            {
                canFire = true;
                timeToNextShot = fireRate;
            }
            if ((!canFire)&&timeToNextShot > 0)
            {
                timeToNextShot = (timeToNextShot - (1 / 60.0));
            }
        }
    }
}
