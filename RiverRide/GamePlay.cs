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

namespace RiverRide
{

    class GamePlay
    {
        public Plane plane;
        private List<PlaneBullet> lPlaneBullets;
        private Gui gui;

        private bool isLoaded = false;
        private int fireCounter = 0;
        private int loadCounter = 0;

        public void OnLoad()
        {
            plane = new Plane(new Vector2(Globals.planeTexture.Width, Globals.planeTexture.Height), 8);
            lPlaneBullets = new List<PlaneBullet>();
            gui = new Gui();

            Globals.mapList.Add(new MapReader(0,1));
            Globals.mapList.Add(new MapReader(Globals.tileRect.Height-25,2));
        }


        public void Update()
        {
            if (!Globals.doUpdate) return;


            if (!isLoaded)
            {
                OnLoad();
                isLoaded = true;
            }


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
            Globals.spriteBatch.Draw(Globals.tileTexture, Globals.tileRect, Globals.grassColor);

            foreach(MapReader map in Globals.mapList)
            {
                map.Draw();
            }


            Globals.spriteBatch.Draw(Globals.tileTexture, new Rectangle(0,Globals.tileRect.Height-25,Globals.tileRect.Width,25), Color.Black);

            gui.Draw();
            //PLACE DRAWING METHODS HERE
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