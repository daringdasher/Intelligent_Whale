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
    //Parent Class to Players and Enemies
    abstract class Character
    {
        //Attributes
        protected Weapon weapon;
        protected Vector2 position;
        protected int health;
        protected bool isBehindCover;
        protected bool isDead;
        protected Rectangle rect;
        protected float roataion;

        //Properties
        public Vector2 Position
        {
            get { return position; }
        }
        public Rectangle Rectangle
        {
            get { return rect; }
        }
        //Constructor
        public Character()
        {
        }
    
        //Methods
        public abstract void Shoot(Vector2 bulletDest, List<Enemy> target, out List<Enemy> enemiesStillAlive);
        public abstract void Shoot(Vector2 bulletDest, List<Player> target);

    }
}
