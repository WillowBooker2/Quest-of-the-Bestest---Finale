using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Quest_of_the_Bestest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Quest_of_the_Bestest__Finale
{
    internal class Enemy
    {
        private Texture2D _texture;
        public Rectangle _location;
        private Vector2 _speed;
        public static Random _movement = new Random();
        int shmoove;
        public int hp = 10;


        public Enemy(Texture2D texture, int x, int y, int randomnumber)
        {
            _texture = texture;

            shmoove = randomnumber;
            if (shmoove == 1) 
            {
                x = 342;
                y = 100;
                _location = new Rectangle(x, y, 100, 140);
            }

            else if (shmoove == 2)
            {
                x = 135;
                y = 500;
                _location = new Rectangle(x, y, 100, 140);
            }

            else if (shmoove == 3)
            {
                x = 590;
                y = 500;
                _location = new Rectangle(x, y, 100, 140);
            }

            else if (shmoove == 4)
            {
                x = 860;
                y = 562;
                _location = new Rectangle(x, y, 100, 140);
            }

            else if (shmoove == 5)
            {
                x = 600;
                y = 200;
                _location = new Rectangle(x, y, 100, 140);
            }

            else if (shmoove == 6)
            {
                x = 753;
                y = 563;
                _location = new Rectangle(x, y, 100, 140);
            }
            _speed = new Vector2();
        }

        public Rectangle Location { get { return _location; } }
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
            _location.X += (int)_speed.X;
            _location.Y += (int)_speed.Y;

        }
        public void Update(Rectangle playerLoc)
        {
            if (_location.X < playerLoc.X)
            {
                _location.X += (int)_speed.X;
            }
            else 
            {
                _location.X -= (int)_speed.X;
            }

            if (_location.Y < playerLoc.Y)
            {
                _location.Y += (int)_speed.Y;
            }
            else
            {
                _location.Y -= (int)_speed.Y;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.White);
        }

    }
}


