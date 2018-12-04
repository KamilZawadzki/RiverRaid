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

    class GamePlay : StateInterface
    {
        public Plane plane;
        private List<PlaneBullet> lPlaneBullets;
        private Fuel fuel;
        int Score = 0;

        private int fireCounter = 0;
        private int loadCounter = 0;

        public GamePlay()
        {
            plane = new Plane(new Vector2(Globals.planeTexture.Width, Globals.planeTexture.Height), 8);
            lPlaneBullets = new List<PlaneBullet>();
            fuel = new Fuel();

            Globals.mapList.Add(new MapReader(0,1));
            Globals.mapList.Add(new MapReader(Globals.mapArea.Height-25,2));
        }


        public void Update()
        {
            if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)            
                Globals.activeState = Globals.States.PAUSE;
            
            if (!Globals.doUpdate) return;
         

            if (Globals.fire && fireCounter>=60)
            {
                lPlaneBullets.Add(new PlaneBullet(plane, new Vector2(Globals.planeBulletTexture.Width, Globals.planeBulletTexture.Height) * 6, 10));
                Globals.fire = false;
                fireCounter = 0;
            }
            Globals.fire = false;
            fireCounter++;
            plane.Behaviour();
            
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

            Globals.spriteBatch.Draw(Globals.inputButtonsTexture, new Rectangle(Globals.screenSizeX * 3 / 4 - Globals.inputButtonsTexture.Width * 2, Globals.bulletsBtn.Center.Y - Globals.inputButtonsTexture.Height * 2, Globals.inputButtonsTexture.Width * 4, Globals.inputButtonsTexture.Height * 4), Color.White);
            Globals.spriteBatch.Draw(Globals.bulletButtonTexture, new Rectangle(Globals.screenSizeX / 4 - Globals.bulletButtonTexture.Width * 5/2, Globals.bulletsBtn.Center.Y - (Globals.bulletButtonTexture.Width * 5 / 2), Globals.bulletButtonTexture.Width * 5, Globals.bulletButtonTexture.Width * 5), Color.White);
            String ScoreText = "Score: " + Score++;
            Globals.spriteBatch.DrawString(Globals.defaultFont, ScoreText, new Vector2((Globals.screenSizeX / 2) - Globals.defaultFont.MeasureString(ScoreText).X / 2, 40), Colors.player);

            if (loadCounter++ > 30)
            {
                foreach (PlaneBullet bullet in lPlaneBullets)
                {
                    bullet.Draw();
                }
            }

            plane.DrawPlane();



            Globals.spriteBatch.End();
        }
    }
}