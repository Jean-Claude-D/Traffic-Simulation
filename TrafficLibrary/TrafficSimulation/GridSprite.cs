using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLibrary;

namespace Game
{
    public class GridSprite : DrawableGameComponent
    {
        private string file2;

        private TrafficControl tc = new TrafficControl();
        private Grid grid;

        //to render
        private SpriteBatch spriteBatch;

        private Texture2D grass;
        private Texture2D intersection;
        private Texture2D roadLeft;
        private Texture2D roadRight;
        private Texture2D roadUp;
        private Texture2D roadDown;
        private Texture2D redLight;
        private Texture2D greenLight;
        private Texture2D amberLight;
        private Game1 game;

        //keyboard input
        private KeyboardState oldState;
        private int counter;
        private int threshold;

        public GridSprite(Game1 game)
            : base(game)
        {
            this.game = game;
        }
        public override void Initialize()
        {
            oldState = Keyboard.GetState();
            threshold = 6;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            file2 = File.ReadAllText(@"..\..\..\TrafficTest\Properties\grid.txt");

            spriteBatch = new SpriteBatch(GraphicsDevice);

            grass = game.Content.Load<Texture2D>("grass");
            intersection = game.Content.Load<Texture2D>("intersection");
            roadDown = game.Content.Load<Texture2D>("roaddown");
            roadUp = game.Content.Load<Texture2D>("roadup");
            roadLeft = game.Content.Load<Texture2D>("roadleft");
            roadRight = game.Content.Load<Texture2D>("roadright");
            redLight = game.Content.Load<Texture2D>("red");
            amberLight = game.Content.Load<Texture2D>("yellow");
            greenLight = game.Content.Load<Texture2D>("green");

            base.LoadContent();
            tc.Parse(file2);
            grid = tc.Grid;
        }



        public override void Draw(GameTime gameTime)
        {
            int lightCount = 1;
            spriteBatch.Begin();
            for (int i = 0; i < grid.Size; i++)
            {
                for (int j = 0; j < grid.Size; j++)
                {
                    if (grid[i, j] is Grass)
                    {
                        spriteBatch.Draw(grass, new Rectangle(i * 30, j * 30, 30, 30), Color.Green);
                    }
                    else if (grid[i, j] is Road && (grid[i, j].Direction == Direction.Down))
                    {
                        spriteBatch.Draw(roadDown, new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                    }
                    else if (grid[i, j] is Road && (grid[i, j].Direction == Direction.Left))
                    {
                        spriteBatch.Draw(roadLeft, new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                    }
                    else if (grid[i, j] is Road && (grid[i, j].Direction == Direction.Right))
                    {
                        spriteBatch.Draw(roadRight, new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                    }
                    else if (grid[i, j] is Road && (grid[i, j].Direction == Direction.Up))
                    {
                        spriteBatch.Draw(roadUp, new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                    }
                    else if (grid[i, j] is IntersectionTile)
                    {
                        spriteBatch.Draw(intersection, new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                    }
                    else if (grid[i, j] is Light && (lightCount % 2 == 1))
                    {
                        spriteBatch.Draw(greenLight, new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                        lightCount++;
                    }
                    else if (grid[i, j] is Light && (lightCount % 2 == 0))
                    {
                        spriteBatch.Draw(redLight, new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                        lightCount++;
                    }
                }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

    }

}