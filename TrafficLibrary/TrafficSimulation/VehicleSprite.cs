using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TrafficLibrary;

namespace TrafficSimulation
{
    public class VehicleSpriteImages
    {
        public Texture2D down;
        public Texture2D up;
        public Texture2D left;
        public Texture2D right;
    }

    public class VehicleSprite : DrawableGameComponent
    {
        private Intersection intersection;
        private TrafficControl trafficControl;
        private Simulation game;

        private VehicleSpriteImages _carA;
        private VehicleSpriteImages _electricCarA;
        private VehicleSpriteImages _motoA;
        private VehicleSpriteImages _electricMotoA;

        private SpriteBatch spriteBatch;

        public VehicleSprite(Simulation game, Intersection intersection, TrafficControl trafficControl) : base(game)
        {
            this.intersection = intersection;
            this.trafficControl = trafficControl;
            this.game = game;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            foreach(IVehicle v in intersection)
            {
                if(v is Car)
                {
                    if (typeof(Electric) == v.GetType())
                    {
                        drawVehicle(_electricCarA, v);
                    }
                    else
                    {
                        drawVehicle(_carA, v);
                    }
                }
                else if(v is Motorcycle)
                {
                    if (typeof(Electric) == v.GetType())
                    {
                        drawVehicle(_electricMotoA, v);
                    }
                    else
                    {
                        drawVehicle(_motoA, v);
                    }
                }
            }
            spriteBatch.End();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        private int _count = 0;
        private int _threshold = 1;

        public override void Update(GameTime gameTime)
        {
            if(_count++ >= _threshold)
            {
                trafficControl.Update();
                base.Update(gameTime);
                _count = 0;
            }
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _carA = new VehicleSpriteImages()
            {
                down = game.Content.Load<Texture2D>("c_A_NE_Down"),
                left = game.Content.Load<Texture2D>("c_A_NE_Left"),
                up = game.Content.Load<Texture2D>("c_A_NE_Up"),
                right = game.Content.Load<Texture2D>("c_A_NE_Right"),
            };
            _electricCarA = new VehicleSpriteImages()
            {
                down = game.Content.Load<Texture2D>("c_A_E_Down"),
                left = game.Content.Load<Texture2D>("c_A_E_Left"),
                up = game.Content.Load<Texture2D>("c_A_E_Up"),
                right = game.Content.Load<Texture2D>("c_A_E_Right"),
            };
            _motoA = new VehicleSpriteImages()
            {
                down = game.Content.Load<Texture2D>("m_A_NE_Down"),
                left = game.Content.Load<Texture2D>("m_A_NE_Left"),
                up = game.Content.Load<Texture2D>("m_A_NE_Up"),
                right = game.Content.Load<Texture2D>("m_A_NE_Right"),
            };
            _electricMotoA = new VehicleSpriteImages()
            {
                down = game.Content.Load<Texture2D>("m_A_E_Down"),
                left = game.Content.Load<Texture2D>("m_A_E_Left"),
                up = game.Content.Load<Texture2D>("m_A_E_Up"),
                right = game.Content.Load<Texture2D>("m_A_E_Right"),
            };

            base.LoadContent();
        }

        private void drawVehicle(VehicleSpriteImages vehicleImg, IVehicle vehicle)
        {
            switch(vehicle.Direction)
            {
                case Direction.Up:
                    spriteBatch.Draw(vehicleImg.up, new Vector2(vehicle.X * 30, vehicle.Y * 30), Color.White);
                    break;
                case Direction.Down:
                    spriteBatch.Draw(vehicleImg.down, new Vector2(vehicle.X * 30, vehicle.Y * 30), Color.White);
                    break;
                case Direction.Left:
                    spriteBatch.Draw(vehicleImg.left, new Vector2(vehicle.X * 30, vehicle.Y * 30), Color.White);
                    break;
                case Direction.Right:
                    spriteBatch.Draw(vehicleImg.right, new Vector2(vehicle.X * 30, vehicle.Y * 30), Color.White);
                    break;
                default:
                    throw new ArgumentException("Cannot draw Vehicle with Direction : " + vehicle.Direction);
            }
        }
    }
}
