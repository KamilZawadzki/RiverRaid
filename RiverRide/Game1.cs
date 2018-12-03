using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RiverRide
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        StatesMng manager;

        public Game1()
        {
            Globals.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Globals.graphics.IsFullScreen = true;

            manager = new StatesMng();

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            // TODO: Add your initialization logic here
            Globals.screenSizeX = Globals.graphics.GraphicsDevice.Viewport.Width;
            Globals.screenSizeY = Globals.graphics.GraphicsDevice.Viewport.Height;
            Globals.tileRect = new Rectangle(0, 0, Globals.screenSizeX, Globals.screenSizeY * 3 / 4);
            Globals.guiRect = new Rectangle(0, Globals.screenSizeY * 3 / 4, Globals.screenSizeX, Globals.screenSizeY - Globals.tileRect.Height);

            Globals.joyStickRight = new Rectangle(Globals.screenSizeX * 3 / 4, Globals.screenSizeY * 3 / 4, Globals.screenSizeX * 1 / 4, Globals.guiRect.Height);
            Globals.joyStickLeft = new Rectangle(Globals.screenSizeX * 2 / 4, Globals.screenSizeY * 3 / 4, Globals.screenSizeX * 1 / 4, Globals.guiRect.Height);

            Globals.fireButton = new Rectangle(0, Globals.screenSizeY * 75 / 100, Globals.screenSizeX * 1 / 2, Globals.guiRect.Height);

            Globals.activeState = Globals.States.MENU;


            // Create a new SpriteBatch, which can be used to draw textures.
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);


            Globals.planeTexture = Content.Load<Texture2D>("textures/plane_texture");
            Globals.planeTextureLeft = Content.Load<Texture2D>("textures/plane_texture_left");
            Globals.planeTextureRight = Content.Load<Texture2D>("textures/plane_texture_right");
            Globals.planeBulletTexture = Content.Load<Texture2D>("textures/plane_bullet_texture");
            Globals.bridgeTexture = Content.Load<Texture2D>("textures/bridge_texture");
            Globals.fuelTexture = Content.Load<Texture2D>("textures/fuel_texture");
            Globals.shipTexture = Content.Load<Texture2D>("textures/ship_texture");
            Globals.tileTexture = Content.Load<Texture2D>("textures/tile_texture");
            Globals.fuelIndicatorBox = Content.Load<Texture2D>("textures/fuel_indicator_box");
            Globals.joystickTexture = Content.Load<Texture2D>("textures/joystick");
            Globals.fireButtonTexture = Content.Load<Texture2D>("textures/fire_button");



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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            manager.Update();

            // TODO: Add your update logic here

            //base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            // TODO: Add your drawing code here

            //base.Draw(gameTime);
        }
    }
}
