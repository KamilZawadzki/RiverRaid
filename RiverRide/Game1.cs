using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RiverRide
{

    public class Game1 : Game
    {
        StatesMng manager;

        public Game1()
        {
            Globals.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Globals.graphics.IsFullScreen = true;

           

        }

      
        protected override void Initialize()
        {
            //Globals.screenSizeX = Globals.graphics.GraphicsDevice.Viewport.Width;
           // Globals.screenSizeY = Globals.graphics.GraphicsDevice.Viewport.Height;
            Globals.screenSize = new Vector2(Globals.graphics.GraphicsDevice.Viewport.Width, Globals.graphics.GraphicsDevice.Viewport.Height);
            base.Initialize();
        }

 
        protected override void LoadContent()
        {
           
            


            Globals.planeTexture = Content.Load<Texture2D>("textures/plane_texture");
            Globals.planeTextureLeft = Content.Load<Texture2D>("textures/plane_texture_left");
            Globals.planeTextureRight = Content.Load<Texture2D>("textures/plane_texture_right");
            Globals.planeBulletTexture = Content.Load<Texture2D>("textures/plane_bullet_texture");
            Globals.tileTexture = Content.Load<Texture2D>("textures/tile_texture");
            Globals.fuelIndicatorBox = Content.Load<Texture2D>("textures/fuel_indicator_box");
            Globals.inputButtonsTexture = Content.Load<Texture2D>("textures/shadedLight04");
            Globals.bulletButtonTexture = Content.Load<Texture2D>("textures/shadedLight");

            Globals.mapArea = new Rectangle(0, 0, (int)Globals.screenSize.X, (int)Globals.screenSize.Y *75/100);
            Globals.userInterfaceArea = new Rectangle(0, (int)Globals.screenSize.Y * 75/100, (int)Globals.screenSize.X, (int)Globals.screenSize.Y - Globals.mapArea.Height);

            Globals.bulletsBtn = new Rectangle(0, Globals.userInterfaceArea.Y, (int)Globals.screenSize.X / 3, Globals.userInterfaceArea.Height);

            Globals.inputUp = new Rectangle((int)(Globals.screenSize.X * 3 / 4 - Globals.inputButtonsTexture.Width * 2)+ Globals.inputButtonsTexture.Width*4/3, (Globals.bulletsBtn.Center.Y - Globals.inputButtonsTexture.Height * 2), Globals.inputButtonsTexture.Width * 4 / 3, Globals.inputButtonsTexture.Height * 4 / 3);
            Globals.inputDown = new Rectangle((int)(Globals.screenSize.X * 3 / 4 - Globals.inputButtonsTexture.Width * 2)+ Globals.inputButtonsTexture.Width*4/3, (Globals.bulletsBtn.Center.Y - Globals.inputButtonsTexture.Height * 2) + Globals.inputButtonsTexture.Height * 4 * 2 / 3, Globals.inputButtonsTexture.Width * 4 / 3, Globals.inputButtonsTexture.Height * 4 / 3);
            Globals.inputRight = new Rectangle((int)(Globals.screenSize.X * 3 / 5 - Globals.inputButtonsTexture.Width * 2)+ Globals.inputButtonsTexture.Width*4*2/3, (Globals.bulletsBtn.Center.Y - Globals.inputButtonsTexture.Height * 2) + Globals.inputButtonsTexture.Height * 4 / 3, Globals.inputButtonsTexture.Width * 4 / 3, Globals.inputButtonsTexture.Height * 4 / 3);
            Globals.inputLeft = new Rectangle((int)Globals.screenSize.X * 3 / 3 - Globals.inputButtonsTexture.Width * 2, (Globals.bulletsBtn.Center.Y - Globals.inputButtonsTexture.Height * 2)+ Globals.inputButtonsTexture.Height*4/3, Globals.inputButtonsTexture.Width * 4 / 3, Globals.inputButtonsTexture.Height*4/3);

            

            Globals.defaultFont = Content.Load<SpriteFont>("Font/Font");


            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);


        


            Globals.activeState = Globals.States.MENU;
            manager = new StatesMng();
        }


        protected override void UnloadContent()
        {
          
        }

        protected override void Update(GameTime gameTime)
        {
            if (Globals.activeState == Globals.States.EXIT_GAME)
                Exit();

            manager.Update();
        }

        protected override void Draw(GameTime gameTime)
        {

        }
    }
}
