#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Breach_Of_Contract
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        //Attributes
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
        Bullet bullet;
        bool bulletActive = false;
        
        //Constructor
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
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
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
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
            enemy1Sprite = Content.Load<Texture2D>("Enemies/Enemy1");
            enemy2Sprite = Content.Load<Texture2D>("Enemies/Enemy2");
            enemy3Sprite = Content.Load<Texture2D>("Enemies/Enemy3");
            bulletSprite = Content.Load<Texture2D>("Bullet");
            bullet = new Bullet();
            rgen = new Random();
            float enemyX = rgen.Next(0, 721);
            float enemyY = rgen.Next(0, 1281);
            testEnemy = new Enemy(new Vector2(enemyX, enemyY));
            foreach (object element in objectList)
            {
            }
            
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
            mousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            if (Mouse.GetState().LeftButton == ButtonState.Pressed) // move selected character with LMB
            {
                if (player1.ID == currentPlayer) { p1Destination = mousePosition; }
                if (player2.ID == currentPlayer) { p2Destination = mousePosition; }
                if (player3.ID == currentPlayer) { p3Destination = mousePosition; }
                if (player4.ID == currentPlayer) { p4Destination = mousePosition; }
            }
            if (Mouse.GetState().RightButton == ButtonState.Pressed) // select character with RMB
            {
                mousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                if (player1.PlayerRect.Contains(mousePosition)) {currentPlayer = player1.ID;}
                if (player2.PlayerRect.Contains(mousePosition)) {currentPlayer = player2.ID;}
                if (player3.PlayerRect.Contains(mousePosition)) {currentPlayer = player3.ID;}
                if (player4.PlayerRect.Contains(mousePosition)) {currentPlayer = player4.ID;}
            }
            
            if(Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                bulletActive = true;
                if (player1.ID == currentPlayer) { bullet.Position = player1.Position; bulletDest = testEnemy.Position; }
                if (player2.ID == currentPlayer) { bullet.Position = player2.Position; bulletDest = testEnemy.Position; }
                if (player3.ID == currentPlayer) { bullet.Position = player3.Position; bulletDest = testEnemy.Position; }
                if (player4.ID == currentPlayer) { bullet.Position = player1.Position; bulletDest = testEnemy.Position; }
            }
            
            player1.move(p1Destination); player1Rot = player1.Rotation;
            player2.move(p2Destination); player2Rot = player2.Rotation;
            player3.move(p3Destination); player3Rot = player3.Rotation;
            player4.move(p4Destination); player4Rot = player4.Rotation;
            if (bulletActive) bullet.move(bulletDest); bulletRot = bullet.Rotation;
            if ((player1.Position.X > p1Destination.X - 1) && (player1.Position.X < p1Destination.X + 1) && (player1.Position.Y > p1Destination.Y - 1) && (player1.Position.Y < p1Destination.Y + 1)) p1Destination = new Vector2(0, 0);
            if ((player2.Position.X > p2Destination.X - 1) && (player2.Position.X < p2Destination.X + 1) && (player2.Position.Y > p2Destination.Y - 1) && (player2.Position.Y < p2Destination.Y + 1)) p2Destination = new Vector2(0, 0);
            if ((player3.Position.X > p3Destination.X - 1) && (player3.Position.X < p3Destination.X + 1) && (player3.Position.Y > p3Destination.Y - 1) && (player3.Position.Y < p3Destination.Y + 1)) p3Destination = new Vector2(0, 0);
            if ((player4.Position.X > p4Destination.X - 1) && (player4.Position.X < p4Destination.X + 1) && (player4.Position.Y > p4Destination.Y - 1) && (player4.Position.Y < p4Destination.Y + 1)) p4Destination = new Vector2(0, 0);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            //if (startScreenActive) {(Draw Start Screen)}
            spriteBatch.Draw(blueSprite, player1.Position, new Rectangle(0,0,256,256), Color.White, player1Rot, new Vector2(128, 128), .25f, SpriteEffects.None, 0F);
            spriteBatch.Draw(brownSprite, player2.Position, new Rectangle(0, 0, 256, 256), Color.White, player2Rot, new Vector2(128, 128), .25f, SpriteEffects.None, 0F);
            spriteBatch.Draw(orangeSprite, player3.Position, new Rectangle(0, 0, 256, 256), Color.White, player3Rot, new Vector2(128, 128), .25f, SpriteEffects.None, 0F);
            spriteBatch.Draw(scottSprite, player4.Position, new Rectangle(0, 0, 256, 256), Color.White, player4Rot, new Vector2(128, 128), .25f, SpriteEffects.None, 0F);
            

            spriteBatch.Draw(enemy1Sprite, testEnemy.Position,new Rectangle(0, 0, 256, 256), Color.White, bulletRot - 180, new Vector2(128, 128), .25f, SpriteEffects.None, 0F);
            spriteBatch.Draw(bulletSprite, bullet.Position, new Rectangle(0, 0, 64, 64), Color.White, bulletRot, new Vector2(32, 32), .5f, SpriteEffects.None, 0F);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
