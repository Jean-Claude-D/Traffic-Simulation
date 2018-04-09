using TrafficLibrary;
using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TrafficSimulation
{
    /// <summary>
    /// Manages all the graphical
    /// representations of a traffic simulation
    /// </summary>
    public class Simulation : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private TrafficControl _trafficControl;
        
        /// <summary>
        /// The GridSprite graphically representing
        /// tiles in the simulation
        /// </summary>
        public GridSprite GridSprite
        {
            get;
            private set;
        }

        /// <summary>
        /// The TotalSprite graphically representing
        /// staistics of the simulation
        /// </summary>
        public TotalSprite TotalSprite
        {
            get;
            private set;
        }

        /// <summary>
        /// The VehicleSprite graphically representing
        /// all vehicles in the simulation
        /// </summary>
        public VehicleSprite VehicleSprite
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates a new Simulation object managing all the graphical
        /// representations of a traffic simulation
        /// </summary>
        public Simulation()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _trafficControl = new TrafficControl();
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

            string fileName = "grid.txt";
            string fileContent = null;
            try
            {
                fileContent = File.ReadAllText(fileName);
            }
            catch(IOException exc)
            {
                throw new Exception("Could not read \'" + fileName + "\'", exc);
            }

            _trafficControl.Parse(fileContent);

            
            GridSprite = new GridSprite(this, _trafficControl.Grid);
            Components.Add(GridSprite);

            TotalSprite = new TotalSprite(this, _trafficControl.Total);
            Components.Add(TotalSprite);

            VehicleSprite = new VehicleSprite(this, _trafficControl.Intersection);
            Components.Add(VehicleSprite);

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

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
