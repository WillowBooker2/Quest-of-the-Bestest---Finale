using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Quest_of_the_Bestest;
using Quest_of_the_Bestest__Finale;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Quest_of_the_Bestest___Finale
{
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        Texture2D chiyTexture, fireTexture, bulletTexture, introTexture, selectTexture, globTexture, slimeTexture, carshoeTexture, butterTexture, bakaTexture, floorTexture;
        Rectangle introRect, selectRect, carshoeRect, butterRect, bakaRect, floorRect;
        Player chiy, fire;
        Enemy glob, slime;
        Bullet bullet;
        bool chiyari, fireball;
        int character;
        int damage, speed;
        bool shoot = true;
        bool hold = false;
        float charge, firerate;
        KeyboardState keyboardState;
        Random enemy = new Random();
        Random spawn = new Random();
        int random;
        float seconds;
        float startTime;
        SoundEffectInstance desiredrive, lunatic, shinmy, greed;
        bool driven, bnuuy, teeny = false;

        enum Screen
        {
            Intro,
            Choose,
            Start,
            Boss,
            Treasure,
            Next
        }
        Screen screen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 800;
            
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screen = Screen.Intro;

            introRect = new Rectangle(0, 0, 1000, 800);
            selectRect = new Rectangle(0, 0, 1000, 800);
            base.Initialize();
            chiy = new Player(chiyTexture, 440, 260);
            fire = new Player(fireTexture, 440, 260);
            bullet = new Bullet(bulletTexture, 440, 260);
            floorRect = new Rectangle(1000, 8000, 1, 1);
            glob = new Enemy(globTexture, 30, 60, spawn.Next(1,7));
            slime = new Enemy(slimeTexture, 30, 60, spawn.Next(1,7));
            carshoeRect = new Rectangle(800, 300, 100, 100);
            butterRect = new Rectangle(800, 300, 100, 100);
            bakaRect = new Rectangle(800, 300, 100, 100);


        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            chiyTexture = Content.Load<Texture2D>("chiy");
            fireTexture = Content.Load<Texture2D>("fire");
            globTexture = Content.Load<Texture2D>("globlinA");
            slimeTexture = Content.Load<Texture2D>("slimeA");
            bulletTexture = Content.Load<Texture2D>("bang");
            floorTexture = Content.Load<Texture2D>("floor");
            introTexture = Content.Load<Texture2D>("beginning");
            selectTexture = Content.Load<Texture2D>("select");
            desiredrive = Content.Load<SoundEffect>("desiredrive").CreateInstance();
            lunatic = Content.Load<SoundEffect>("lunatic").CreateInstance();
            shinmy = Content.Load<SoundEffect>("shinmy").CreateInstance();
            greed = Content.Load<SoundEffect>("greed").CreateInstance();
            carshoeTexture = Content.Load<Texture2D>("carsho");
            butterTexture = Content.Load<Texture2D>("butter");
            bakaTexture = Content.Load<Texture2D>("baka");


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            seconds = (float)gameTime.TotalGameTime.TotalSeconds;
            keyboardState = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (screen == Screen.Intro)
            {
                desiredrive.Play();
                if (keyboardState.IsKeyDown(Keys.Space))
                {
                    screen = Screen.Choose;
                }
            }

            else if (screen == Screen.Choose)
            {
                if (keyboardState.IsKeyDown(Keys.A))
                {
                    screen = Screen.Start;
                    character = 1;
                }

                if (keyboardState.IsKeyDown(Keys.D))
                {
                    screen = Screen.Start;
                    character = 2;
                }


                if (fireball)
                {
                    fire.health = 3;
                    bullet.damage = 2;
                }

                if (chiyari)
                {
                    chiy.health = 1;
                    bullet.damage = 3;
                }

                
            }

            else if (screen == Screen.Start)
            {
                desiredrive.Stop();
                fire.HSpeed = 0;
                fire.VSpeed = 0;
                chiy.HSpeed = 0;
                chiy.VSpeed = 0;


                chiy.Update(keyboardState, glob);
                fire.Update(keyboardState, glob);
                bullet.Update(keyboardState, glob);

                if (fireball)
                {
                    shinmy.Play();
                }

                if (chiyari)
                {
                    lunatic.Play();
                }

                if (fire.health == 2)
                {
                    shinmy.Stop();
                    screen = Screen.Intro;
                }

                if (chiy.health == 2)
                {
                    lunatic.Stop();
                    screen = Screen.Intro;
                }

                
           
                // checks to see if player goes right off screen to next level
                if (fire.Location.Left >= _graphics.PreferredBackBufferWidth || chiy.Location.Left >= _graphics.PreferredBackBufferWidth)
                {
                    shinmy.Stop();
                    lunatic.Stop();
                    greed.Play();
                    screen = Screen.Treasure;
                }
            }

            else if (screen == Screen.Treasure) 
            {
                fire.HSpeed = 0;
                fire.VSpeed = 0;
                chiy.HSpeed = 0;
                chiy.VSpeed = 0;


                chiy.Update(keyboardState, glob);
                fire.Update(keyboardState, glob);
                bullet.Update(keyboardState, glob);
            }
            // TODO: Add your update logic here
            
            base.Update(gameTime);
            }
        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.PaleVioletRed);


            // TODO: Add your drawing code here
            
            _spriteBatch.Begin();
            
            if (screen == Screen.Intro) 
            {
                _spriteBatch.Draw(introTexture, introRect, Color.White);
            }

            else if (screen == Screen.Choose)
            {
                _spriteBatch.Draw(selectTexture, selectRect, Color.White);
                
            }

            else if (screen == Screen.Start)
            {
                
                if (character == 1)
                {

                    chiy.Draw(_spriteBatch);
                    chiyari = true;
                    fireball = false;
                }

                if (character == 2)
                {
                    fire.Draw(_spriteBatch);
                    fireball = true;
                    chiyari = false;
                }
                
                bullet.Draw(_spriteBatch); 
            }

            else if (screen == Screen.Treasure)
            {
                glob.Draw(_spriteBatch);
                if (character == 1)
                {

                    chiy.Draw(_spriteBatch);
                    chiyari = true;
                    fireball = false;
                }

                if (character == 2)
                {
                    fire.Draw(_spriteBatch);
                    fireball = true;
                    chiyari = false;
                }
                bullet.Draw(_spriteBatch);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}