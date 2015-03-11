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

        //Constructor
        public Player(string identity, Weapon[] weaps, Vector2 pos):base()
        {
            health = 100;
            id = identity;
            weapons = weaps;
            position = pos;
        }

        public override void Shoot()
        {
            throw new NotImplementedException();
        }
    }
}
