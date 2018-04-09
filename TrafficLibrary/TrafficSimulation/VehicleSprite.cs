﻿using System;
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
    public class VehicleSprite : DrawableGameComponent
    {
        private Intersection intersection;
        private TrafficControl trafficControl;
        private Simulation game;
        private Texture2D carDownImg;
        private Texture2D carUpImg;
        private Texture2D carLeftImg;
        private Texture2D carRightImg;
        private Texture2D motoDownImg;
        private Texture2D motoUpImg;
        private Texture2D motoLeftImg;
        private Texture2D motoRightImg;
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
            foreach(Vehicle v in intersection)
            {
                if(v is Car)
                {
                    switch (v.Direction)
                    {
                        case Direction.Down:
                            spriteBatch.Draw(carDownImg, new Vector2(v.X * 30, v.Y * 30), Color.Bisque);
                            break;
                        case Direction.Up:
                            spriteBatch.Draw(carUpImg, new Vector2(v.X * 30, v.Y * 30), Color.Bisque);
                            break;
                        case Direction.Left:
                            spriteBatch.Draw(carLeftImg, new Vector2(v.X * 30, v.Y * 30), Color.Bisque);
                            break;
                        case Direction.Right:
                            spriteBatch.Draw(carRightImg, new Vector2(v.X * 30, v.Y * 30), Color.Bisque);
                            break;
                        default:
                            spriteBatch.Draw(carRightImg, new Vector2(v.X * 30, v.Y * 30), Color.Bisque);
                            break;
                    }
                }
                else
                {
                    switch (v.Direction)
                    {
                        case Direction.Down:
                            spriteBatch.Draw(motoDownImg, new Vector2(v.X * 30, v.Y * 30), Color.Bisque);
                            break;
                        case Direction.Up:
                            spriteBatch.Draw(motoUpImg, new Vector2(v.X * 30, v.Y * 30), Color.Bisque);
                            break;
                        case Direction.Left:
                            spriteBatch.Draw(motoLeftImg, new Vector2(v.X * 30, v.Y * 30), Color.Bisque);
                            break;
                        case Direction.Right:
                            spriteBatch.Draw(motoRightImg, new Vector2(v.X * 30, v.Y * 30), Color.Bisque);
                            break;
                        default:
                            spriteBatch.Draw(motoRightImg, new Vector2(v.X * 30, v.Y * 30), Color.Bisque);
                            break;
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
            carDownImg = game.Content.Load<Texture2D>("carDown");
            carUpImg = game.Content.Load<Texture2D>("carUp");
            carLeftImg = game.Content.Load<Texture2D>("carLeft");
            carRightImg = game.Content.Load<Texture2D>("carRight");
            motoDownImg = game.Content.Load<Texture2D>("motorcycleDown");
            motoUpImg = game.Content.Load<Texture2D>("motorcycleUp");
            motoLeftImg = game.Content.Load<Texture2D>("motorcycleLeft");
            motoRightImg = game.Content.Load<Texture2D>("motorcycleRight");
            base.LoadContent();
        }
    }
}
