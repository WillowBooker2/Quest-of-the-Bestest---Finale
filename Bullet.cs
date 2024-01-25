using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Quest_of_the_Bestest__Finale
{
    internal class Bullet
    {
         Texture2D _texture;
         Rectangle _bulletlocation;
        Rectangle _size;
        private Vector2 _speed;
        public int damage;

        public Bullet(Texture2D texture, int x, int y)
        {
            _texture = texture;
            _bulletlocation = new Rectangle(x, y, 100, 100);
            _speed = new Vector2();

        }

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

        public Rectangle location {get { return _bulletlocation; } }
         
            
        
        private void Move()
        {

            _bulletlocation.X += (int)_speed.X;
            _bulletlocation.Y += (int)_speed.Y;
            _bulletlocation.X += (int)_speed.X;
            if (_bulletlocation.Right >= 900)
            {
                _speed.X -= 1;
            }

            if (_bulletlocation.Left <= 100)
            {
                _speed.X += 1;
            }
            if (_bulletlocation.Top <= 1)
            {
                _speed.Y -= -1;
            }
            if (_bulletlocation.Bottom >= 800)
            {  
                _speed.Y += -1;
            }
        }


        public void Update(KeyboardState keyboardState, Enemy bad)
        {
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                VSpeed = -10;
                HSpeed = 0;
                if (_bulletlocation.Intersects(bad._location))
                {
                    bad._location = new Rectangle (0, 0, 0, 0);
                   
                }
            }

            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                VSpeed = 10;
                HSpeed = 0;
                if (_bulletlocation.Intersects(bad._location))
                {
                    bad._location = new Rectangle(0, 0, 0, 0);

                }
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                HSpeed = -10;
                VSpeed = 0;
                if (_bulletlocation.Intersects(bad._location))
                {
                    bad._location = new Rectangle(0, 0, 0, 0);

                }
            }

            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                HSpeed = 10;
                VSpeed = 0;
                if (_bulletlocation.Intersects(bad._location))
                {
                    bad._location = new Rectangle(0, 0, 0, 0);

                }
            }
            Move();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _bulletlocation, Color.White);
        }
    }
}
