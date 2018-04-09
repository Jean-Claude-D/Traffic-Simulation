using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLibrary;

namespace TrafficSimulation
{
    class TotalSprite : DrawableGameComponent
    {

        private Total total;

        //to render
        private SpriteBatch spriteBatch;
        private Texture2D totalImage;
        private Simulation sim;

        public TotalSprite(Simulation sim, Total total) : base(sim)
        {
            this.sim = sim;
            this.total = total;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }


    }
}
