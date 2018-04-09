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


namespace TrafficSimulation
{
    public class GridSprite : DrawableGameComponent
    {


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


        //keyboard input
        private Grid g;
        private Simulation s;
        private int counter;

        /// <summary>
        /// GridSprite constructor that takes simulation and grid passed by the simulation
        /// </summary>
        /// <param name="s"></param>
        /// <param name="g"></param>
        public GridSprite(Simulation s,Grid g)
            : base(s)
        {
            this.s = s;
            this.g = g;
        }
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Loads the image file into the class
        /// </summary>
        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

            grass = s.Content.Load<Texture2D>("grass");
            intersection = s.Content.Load<Texture2D>("intersection");
            roadDown = s.Content.Load<Texture2D>("roaddown");
            roadUp = s.Content.Load<Texture2D>("roadup");
            roadLeft = s.Content.Load<Texture2D>("roadleft");
            roadRight = s.Content.Load<Texture2D>("roadright");
            redLight = s.Content.Load<Texture2D>("red");
            amberLight = s.Content.Load<Texture2D>("yellow");
            greenLight = s.Content.Load<Texture2D>("green");

            base.LoadContent();
        }

        /// <summary>
        /// Re-updates the grid based on other clases
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }


        /// <summary>
        /// Draws the grid based on the tile array passed into the parameters
        /// Draws depending on which type the tile is in the array
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            for (int i = 0; i < g.Size; i++)
            {
                for (int j = 0; j < g.Size; j++)
                {
                    if (g[i, j] is Grass)
                    {
                        spriteBatch.Draw(grass, new Rectangle(i * 30, j * 30, 30, 30), Color.Green);
                    }
                    else if (g[i, j] is Road && (g[i, j].Direction == Direction.Down))
                    {
                        spriteBatch.Draw(roadDown, new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                    }
                    else if (g[i, j] is Road && (g[i, j].Direction == Direction.Left))
                    {
                        spriteBatch.Draw(roadLeft, new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                    }
                    else if (g[i, j] is Road && (g[i, j].Direction == Direction.Right))
                    {
                        spriteBatch.Draw(roadRight, new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                    }
                    else if (g[i, j] is Road && (g[i, j].Direction == Direction.Up))
                    {
                        spriteBatch.Draw(roadUp, new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                    }
                    else if (g[i, j] is IntersectionTile)
                    {
                        spriteBatch.Draw(intersection, new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                    }
                    else if (g[i, j] is Light && ((Light)g[i,j]).Colour == Colour.Amber)
                    {
                        spriteBatch.Draw(amberLight, new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                    }
                    else if (g[i, j] is Light && ((Light)g[i, j]).Colour == Colour.Green)
                    {
                        spriteBatch.Draw(greenLight, new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                    }
                    else if (g[i, j] is Light && ((Light)g[i, j]).Colour == Colour.Red)
                    {
                        spriteBatch.Draw(redLight, new Rectangle(i * 30, j * 30, 30, 30), Color.White);
                    }
                }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

    }

}