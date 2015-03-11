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
        protected int health;
        protected Vector2 position;
        protected bool isBehindCover;
        protected bool isDead;

        //Constructor
        public Character()
        {
        }
    
        //Methods
        public abstract void Shoot();
    }
}
