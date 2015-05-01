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
    //  Class that represents the various covers
    class Cover
    {
        // attribs
        protected Rectangle objrect; 
        protected Vector2 position;
        protected int objectID;
       
        // properties
        public Rectangle ObjRect
        { get { return objrect; } }

        public Vector2 Position
        { get { return position; } }

        public int ObjectID
        { get { return objectID; } }

        // constructor
        public Cover(Vector2 pos, int objID)
        {
            position = pos;
            objectID = objID;
            if (objID == 2) { objrect = new Rectangle((int)position.X, (int)position.Y, 64, 64); } // params for a wall

            if (objID == 3) { objrect = new Rectangle((int)position.X, (int)position.Y, 128, 64); } // params for a couch
        }
    }
}
