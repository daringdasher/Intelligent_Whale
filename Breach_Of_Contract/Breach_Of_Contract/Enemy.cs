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

        //Properties
        public Vector2 Position
        {
            get { return position; }
        }

        //Constructor
        public Enemy( /*Weapon[] weaps,*/ Vector2 pos):base()
        {
            health = 100;
            //weapons = weaps;
            position = pos;
            enemyRec = new Rectangle(10, 10, 16, 16);
        }
        public override void Shoot()
        {
            throw new NotImplementedException();
        }
    }
}
