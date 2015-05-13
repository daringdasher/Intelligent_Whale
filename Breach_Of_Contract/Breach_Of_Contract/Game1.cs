#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System.Threading;
#endregion

namespace Breach_Of_Contract
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        #region Attributes
        GraphicsDeviceManager graphics;
        Vector2 mousePosition;
        SpriteBatch spriteBatch;
        Texture2D blueSprite;
        Texture2D brownSprite;
        Texture2D orangeSprite;
        Texture2D scottSprite;
        Texture2D enemy1Sprite;
        Texture2D enemy2Sprite;
        Texture2D enemy3Sprite;
        Texture2D bulletSprite;
        Player player1;
        Player player2;
        Player player3;
        Player player4;
        Vector2 p1Destination;
        Vector2 p2Destination;
        Vector2 p3Destination;
        Vector2 p4Destination;
        Vector2 bulletDest;
        String currentPlayer;
        Enemy testEnemy;
        float player1Rot = 0;
        float player2Rot = 0;
        float player3Rot = 0;
        float player4Rot = 0;
        float bulletRot = 0;
        bool startScreenActive;
        Map map;
        List<object> objectList = new List<object>();
        Random rgen;
        Bullet p1Bullet;
        Bullet p2Bullet;
        Bullet p3Bullet;
        Bullet p4Bullet;
        Player[] players = new Player[4];
        ScreenVariables gameVars;
        List<Enemy> enemies = new List<Enemy>();
        List<Enemy> enemiesAlive = new List<Enemy>();
        List<Cover> covers = new List<Cover>();
        MouseState previousMS;
        //Changes
        // added enum 
        Menus menuToggle = Menus.Main;

        //THESE ARE CHANGES
        Texture2D mainMenu;
        Texture2D hitbox;
        Texture2D helpMenu;
        // rectangle for use as play button
        Rectangle playButton;
        #endregion
        // enum for use in toggling menus/states
        public enum Menus { Main, Play, Help, Exit }

        //Constructor
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);

            //gameVars = new ScreenVariables(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width);
            currentPlayer = "blue";
            p1Destination = new Vector2(0, 0);
            p2Destination = new Vector2(0, 0);
            p3Destination = new Vector2(0, 0);
            p4Destination = new Vector2(0, 0);
            Content.RootDirectory = "Content";
            mousePosition = new Vector2();
            IsMouseVisible = true;
            startScreenActive = true;
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            map = new Map();
            objectList = map.LoadMap("test.txt");
            previousMS = Mouse.GetState();
            
            // NEW - initialize the playButton 
            playButton = new Rectangle(565, 355, 151, 33);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.IsFullScreen = false;
            //graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player1 = (Player)objectList[0]; blueSprite = Content.Load<Texture2D>("Players/Blue");
            player2 = (Player)objectList[1]; brownSprite = Content.Load<Texture2D>("Players/Brown");
            player3 = (Player)objectList[2]; orangeSprite= Content.Load<Texture2D>("Players/Orange");
            player4 = (Player)objectList[3]; scottSprite = Content.Load<Texture2D>("Players/Scott");
            hitbox = Content.Load<Texture2D>("HitBox");
            enemy1Sprite = Content.Load<Texture2D>("Enemies/Enemy1");
            enemy2Sprite = Content.Load<Texture2D>("Enemies/Enemy2");
            enemy3Sprite = Content.Load<Texture2D>("Enemies/Enemy3");
            bulletSprite = Content.Load<Texture2D>("Bullet");
            mainMenu = Content.Load<Texture2D>("MainMenu");
            helpMenu = Content.Load<Texture2D>("help_screen");
            p1Bullet = new Bullet();
            p2Bullet = new Bullet();
            p3Bullet = new Bullet();
            p4Bullet = new Bullet();
            rgen = new Random();
            foreach (object o in objectList)
            {
                if (o is Cover) { covers.Add((Cover)o); }
                if (o is Enemy) { enemies.Add((Enemy)o); }
            }
            
            //enemies.Add(testEnemy);

            players[0] = player1;
            players[1] = player2;
            players[2] = player3;
            players[3] = player4;
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (menuToggle == Menus.Main)
            {
                if (Mouse.GetState().Position.X > 565 && Mouse.GetState().Position.X < 716 
                    && Mouse.GetState().Position.Y > 355 && Mouse.GetState().Position.Y < 398 && Mouse.GetState().LeftButton == ButtonState.Released && previousMS.LeftButton == ButtonState.Pressed)
                {
                    menuToggle = Menus.Play;
                }
            }
            if (menuToggle == Menus.Play) 
            {
                mousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                foreach (Player element in players)
                {
                    //Character Movement
                    if ((element.ID == currentPlayer) && (Mouse.GetState().LeftButton == ButtonState.Pressed) && (menuToggle == Menus.Play)) { element.destination = mousePosition; }

                    //Character Switch
                    if ((element.PlayerRect.Contains(mousePosition)) && (Mouse.GetState().RightButton == ButtonState.Pressed)) { currentPlayer = element.ID; }



                    //Weapon Switch
                    if ((element.ID == currentPlayer) && (Keyboard.GetState().IsKeyDown(Keys.Space))) { element.SwitchWeapon(); }

                    //Determine Closest Enemy
                    Enemy closestEnemy = testEnemy;
                    float smallestDist = 10000;
                    foreach(Enemy enem in enemies)
                    {
                        //rememeber to add check to see if enemy is supposed to be targeted (ie they are alive)
                        if (!enem.IsDead) { 
                            float dist = Vector2.Distance(element.Position, enem.Position);
                            if (dist < smallestDist) 
                            { 
                                smallestDist = dist; closestEnemy = enem; 
                            }
                        }
                        
                    }


                    //Player Updating

                    if (closestEnemy != testEnemy) { element.update(closestEnemy.Position, enemies, covers); }
                    if (closestEnemy == testEnemy) { element.update(covers); }
                }

                //testEnemy.move(player4.Position);
                //enemies[0]=(testEnemy);
                players[0] = player1;
                players[1] = player2;
                players[2] = player3;
                players[3] = player4;
            }
            foreach (Enemy e in enemies)
            {
                Weapon[] playerWeapons1 = { new Weapon(), new Weapon(3, 5, 3, false) };
                Player closestPlayer = new Player("testPlayer",playerWeapons1,new Vector2(0,0));
                float smallestDistPlayer = 1000000;
                foreach (Player p in players)
                {
                    //rememeber to add check to see if enemy is supposed to be targeted (ie they are alive)
                    if (!p.IsDead)
                    {
                        float dist = Vector2.Distance(e.Position, p.Position);
                        if (dist < smallestDistPlayer)
                        {
                            smallestDistPlayer = dist; closestPlayer = p;
                        }
                    }
                    
                }
                Cover closestCover = new Cover(new Vector2(0,0),0);
                float smallestDistCover = 1000000;
                foreach (Cover c in covers)
                {
                    if (!e.isBehindCover)
                    {
                        float dist = Vector2.Distance(e.Position, c.Position);
                        if (dist < smallestDistCover)
                        {
                            smallestDistCover = dist; closestCover = c;
                        }
                    }
                    if (e.Rectangle.Intersects(c.ObjRect)) { e.isBehindCover = true; }
                }
                e.destination = closestCover.Position;
                e.update(closestPlayer.Position, players, covers);
            }
            base.Update(gameTime);
            previousMS = Mouse.GetState();
        }

        
        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            //if (startScreenActive) {(Draw Start Screen)} // leaving this untouched incase we need it later on
            
            // Menu Drawing 
            if (menuToggle == Menus.Main)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                spriteBatch.Draw(mainMenu, new Rectangle(0, 0, 1280, 720), Color.White);
            }

            // Help screen Drawing
            if (menuToggle == Menus.Help)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                spriteBatch.Draw(helpMenu, new Rectangle(0, 0, 1280, 720), Color.White);
            }

            if (menuToggle == Menus.Play)
            {
                // clear screen of main menu
                GraphicsDevice.Clear(Color.CornflowerBlue);

                //Player Drawing
                spriteBatch.Draw(blueSprite, player1.Position, new Rectangle(0, 0, 256, 256), Color.White, player1.Rotation, new Vector2(128, 128), .25f, SpriteEffects.None, 0F);
                spriteBatch.Draw(brownSprite, player2.Position, new Rectangle(0, 0, 256, 256), Color.White, player2.Rotation, new Vector2(128, 128), .25f, SpriteEffects.None, 0F);
                spriteBatch.Draw(orangeSprite, player3.Position, new Rectangle(0, 0, 256, 256), Color.White, player3.Rotation, new Vector2(128, 128), .25f, SpriteEffects.None, 0F);
                spriteBatch.Draw(scottSprite, player4.Position, new Rectangle(0, 0, 256, 256), Color.White, player4.Rotation, new Vector2(128, 128), .25f, SpriteEffects.None, 0F);

                //Enemy Drawing
                if (enemies != null)
                {
                    foreach (Enemy enem in enemies)
                    {
                        if (!enem.IsDead)
                        {
                            spriteBatch.Draw(enemy1Sprite, enem.Position, new Rectangle(0, 0, 256, 256), Color.White, enem.Rotation, new Vector2(128, 128), .25f, SpriteEffects.None, 0F);
                        }
                        //spriteBatch.Draw(hitbox, enem.Position, new Rectangle(0, 0, 256, 256), Color.White, enem.Rotation, new Vector2(128, 128), .25f, SpriteEffects.None, 0F);
                        foreach(Bullet b in enem.Weapon.bullets)
                        {
                            if (b.canDraw)
                            {
                                spriteBatch.Draw(bulletSprite, b.Position, new Rectangle(0, 0, 64, 64), Color.White, b.Rotation, new Vector2(32, 32), .5f, SpriteEffects.None, 0F);

                            }
                        }
                    }
                }


                //Bullet Drawing
                foreach (Player wElement in players)
                {
                    if (wElement.Weapons[0].isActiveWeap)
                    {
                        foreach (Bullet bElement in wElement.Weapons[0].bullets)
                        {
                            if (bElement.canDraw)
                            {

                                spriteBatch.Draw(bulletSprite, bElement.Position, new Rectangle(0, 0, 64, 64), Color.White, bElement.Rotation, new Vector2(32, 32), .5f, SpriteEffects.None, 0F);
                            }
                        }
                    }
                }


                // Wall/Cover drawing 
                foreach (Cover o in covers)
                {
                    if (o.ObjectID == 2) { spriteBatch.Draw(hitbox, o.Position, o.ObjRect, Color.White); } // draw a wall
                    if (o.ObjectID == 3) { spriteBatch.Draw(hitbox, o.Position, o.ObjRect, Color.White); } // draw a couch/long cover
                }
            }
            //spriteBatch.Draw(hitbox, player1.Position, new Rectangle(0, 0, 256, 256), Color.White, player1.Rotation, new Vector2(128, 128), .25f, SpriteEffects.None, 0F);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
