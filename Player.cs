using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Quest_of_the_Bestest__Finale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Quest_of_the_Bestest
{
    internal class Player
    {

        private Texture2D _texture;
        private static Rectangle _playerlocation;
        private Vector2 _speed;
        public int health;
       

        public Player(Texture2D texture, int x, int y)
        {
            _texture = texture;
            _playerlocation = new Rectangle(x, y, 60, 140);
            _speed = new Vector2();
        }

        public Rectangle Location { get { return _playerlocation; } }

        public float HSpeed
        {
            get { return _speed.X; }
            set { _speed.X = value; }
        }

        public float VSpeed
        {
            get { return _speed.Y; }
            set { _speed.Y = value; }
        }
        private void Move()
        {
            _playerlocation.X += (int)_speed.X;
            _playerlocation.Y += (int)_speed.Y;

        }

        public void Update(KeyboardState keyboardState, Enemy bad)
        {
            

            if (keyboardState.IsKeyDown(Keys.W))
            {
                VSpeed = -5;
                
            }

            else if (keyboardState.IsKeyDown(Keys.S))
            {
                VSpeed = 5;
                if (_playerlocation.Intersects(bad._location))
                {
                    health = health - 1;
                }
            }

            if (keyboardState.IsKeyDown(Keys.A))
            {
                HSpeed = -5;
                
            }

            else if (keyboardState.IsKeyDown(Keys.D))
            {
                HSpeed = 5;
            }
            Move();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _playerlocation, Color.White);
        }

    }
}


