using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Input;

namespace RiverRide
{

    class GameState : StateInterface
    {
        public Plane plane;
        private List<Bullet> planeBulletsList;
        private Fuel fuel;
        int Score = 0;

        private int fireDelay = 0;
        private int loadCounter = 0;

        public GameState()
        {
            plane = new Plane(new Vector2(Globals.planeTexture.Width, Globals.planeTexture.Height), 8);
            planeBulletsList = new List<Bullet>();
            fuel = new Fuel();

            Globals.mapList.Add(new MapReader(0,1));
            Globals.mapList.Add(new MapReader(Globals.mapArea.Height-25,2));
        }


        public void Update()
        {
            if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)            
                Globals.activeState = Globals.States.PAUSE;

            plane.CheckCollision(); 

            if (!Globals.blockade && fireDelay++>=30)
            {
                planeBulletsList.Add(new Bullet(plane, new Vector2(Globals.planeBulletTexture.Width, Globals.planeBulletTexture.Height) * 6, 15));
                Globals.blockade = true;
                fireDelay = 0;
            }
            Globals.blockade = true;
            
            
            
            Draw();
        }

        public void Draw()
        {
            Globals.graphics.GraphicsDevice.Clear(Color.Black);
            Globals.spriteBatch.Begin();
            Globals.spriteBatch.Draw(Globals.tileTexture, Globals.mapArea, Colors.grass);

            foreach(MapReader map in Globals.mapList)
            {
                map.Draw();
            }


            Globals.spriteBatch.Draw(Globals.tileTexture, new Rectangle(0,Globals.mapArea.Height-25,Globals.mapArea.Width,25), Color.Black);

            



            Globals.spriteBatch.Draw(Globals.tileTexture, Globals.userInterfaceArea, Colors.userInterfaceBackground);

            fuel.Draw();

            Globals.spriteBatch.Draw(Globals.inputButtonsTexture, new Rectangle((int)Globals.screenSize.X  - Globals.inputButtonsTexture.Width * 2, Globals.bulletsBtn.Center.Y - Globals.inputButtonsTexture.Height , Globals.inputButtonsTexture.Width * 2-40, Globals.inputButtonsTexture.Height * 2-40), Color.White);
            Globals.spriteBatch.Draw(Globals.bulletButtonTexture, new Rectangle((int)Globals.screenSize.X / 4 - Globals.bulletButtonTexture.Width * 5/2, Globals.bulletsBtn.Center.Y - (Globals.bulletButtonTexture.Width * 2), Globals.bulletButtonTexture.Width *2, Globals.bulletButtonTexture.Width *2), Color.White);
            String ScoreText = "Score: " + Score++;
            Globals.spriteBatch.DrawString(Globals.defaultFont, ScoreText, new Vector2((Globals.screenSize.X / 2) - Globals.defaultFont.MeasureString(ScoreText).X / 2, 40), Colors.player);

            if (loadCounter++ > 30)
            {
                foreach (Bullet bullet in planeBulletsList)
                {
                    bullet.Draw();
                }
            }

            plane.DrawPlane();



            Globals.spriteBatch.End();
        }
    }
}