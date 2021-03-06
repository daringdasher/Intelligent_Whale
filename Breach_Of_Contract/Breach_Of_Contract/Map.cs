﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace Breach_Of_Contract
{
    //Class that creates, and handels the main map (and possibly the mini-map)
    class Map
    {
        //Attributes
        private StreamReader reader;
        private List<object> objects = new List<object>();
        public Map() { }

        public List<object> LoadMap(string fileName)
        {

            try
            {
                fileName = "Content/Maps/" + fileName;
                reader = new StreamReader(fileName);
                int numOfLines = System.IO.File.ReadAllLines(fileName).Length;
                int idNum;int xCord;int yCord;
                string[] contentStringArray;
                string contentString;
                while (!reader.EndOfStream)
                {
                    contentString = reader.ReadLine();
                    contentStringArray = contentString.Split(',');
                    int.TryParse(contentStringArray[0], out idNum);
                    int.TryParse(contentStringArray[1], out xCord);
                    int.TryParse(contentStringArray[2], out yCord);
                    if (idNum == 0) createPlayer(xCord, yCord);
                    if (idNum == 1) createEnemy(xCord, yCord);
                    if (idNum == 2) createWall(xCord, yCord);
                    if (idNum == 3) createCouch(xCord, yCord);
                }
                return objects;
            }
            catch (FileNotFoundException FNFE) { Console.WriteLine("File Not Found"); return objects; }
        }
        public void createPlayer(int xPos, int yPos)
        {
            Weapon[] playerWeapons1 = { new Weapon(), new Weapon(3, 5, 3, false) };
            Weapon[] playerWeapons2 = { new Weapon(), new Weapon(3, 5, 3, false) };
            Weapon[] playerWeapons3 = { new Weapon(), new Weapon(3, 5, 3, false) };
            Weapon[] playerWeapons4 = { new Weapon(), new Weapon(3, 5, 3, false) };

            objects.Add(new Player("blue",playerWeapons1, new Vector2(xPos-64, yPos)));
            objects.Add(new Player("orange", playerWeapons2, new Vector2(xPos, yPos - 64)));
            objects.Add(new Player("brown", playerWeapons3, new Vector2(xPos + 64, yPos)));
            objects.Add(new Player("scott", playerWeapons4, new Vector2(xPos, yPos + 64)));
        }
        public void createEnemy(int xPos, int yPos)
        {
            objects.Add(new Enemy( new Vector2(xPos, yPos)));
        }
        public void createWall(int xPos, int yPos)
        {
            objects.Add(new Cover(new Vector2(xPos, yPos), 2));
        }
        public void createCouch(int xPos, int yPos)
        {
            objects.Add(new Cover(new Vector2(xPos, yPos), 3));
        }
    }
}
