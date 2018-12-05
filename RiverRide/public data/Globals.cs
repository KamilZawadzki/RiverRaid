using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace RiverRide
{
    public static class Globals
    {
        public static bool blockade = true;

        public static SpriteBatch spriteBatch = null;
        public static GraphicsDeviceManager graphics = null;

        public static SpriteFont defaultFont;

        //public static int screenSizeX;
       // public static int screenSizeY;

        public static Texture2D planeTexture = null;
        public static Texture2D planeTextureLeft = null;
        public static Texture2D planeTextureRight = null;
        public static Texture2D planeBulletTexture = null;
        public static Texture2D tileTexture = null;
        public static Texture2D fuelIndicatorBox = null;
        public static Texture2D inputButtonsTexture = null;
        public static Texture2D bulletButtonTexture = null;

        public static Rectangle mapArea;
        public static Rectangle userInterfaceArea;
        public static Rectangle inputRight;
        public static Rectangle inputUp;
        public static Rectangle inputDown;
        public static Rectangle inputLeft;
        public static Rectangle bulletsBtn;

        public static List<MapReader> mapList = new List<MapReader>();
        public static List<Rectangle> collisionList = new List<Rectangle>();

        public static States activeState = States.GAME;
        internal static Vector2 screenSize;

        public enum States
        {
            MENU,
            GAME,
            GAMEOVER,
            PAUSE,            
            EXIT_GAME
        }
    }
}