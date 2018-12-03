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
        public static bool fire = false;

        public static SpriteBatch spriteBatch = null;
        public static GraphicsDeviceManager graphics = null;

        public static int screenSizeX;
        public static int screenSizeY;

        public static Color waterColor = new Color(0x58, 0x4f, 0xda);
        public static Color grassColor = new Color(0x64, 0x92, 0x28);
        public static Color lightGrayColor = new Color(0xcd, 0xcd, 0xcd);
        public static Color grayColor = new Color(0xab, 0xab, 0xab);    //GUI
        public static Color darkGrayColor = new Color(0x79, 0x79, 0x79);
        public static Color textColor = new Color(0xff, 0xf4, 0x56);    //TEXT + PLANE

        public static Texture2D planeTexture = null;
        public static Texture2D planeTextureLeft = null;
        public static Texture2D planeTextureRight = null;
        public static Texture2D planeBulletTexture = null;
        public static Texture2D bridgeTexture = null;
        public static Texture2D fuelTexture = null;
        public static Texture2D shipTexture = null;
        public static Texture2D tileTexture = null;
        public static Texture2D fuelIndicatorBox = null;
        public static Texture2D joystickTexture = null;
        public static Texture2D fireButtonTexture = null;

        public static Rectangle tileRect;
        public static Rectangle guiRect;
        public static Rectangle joyStickRight;
        public static Rectangle joyStickLeft;
        public static Rectangle fireButton;

        public static List<MapReader> mapList = new List<MapReader>();
        public static List<Rectangle> collisionList = new List<Rectangle>();

        public static bool doUpdate = true;

        public static States activeState = States.MENU;
        public enum States
        {
            MENU,
            GAME,
            PAUSE,
            GAMEOVER,
            EXIT
        }
    }
}