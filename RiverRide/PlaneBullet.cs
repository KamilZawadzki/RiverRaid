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

namespace RiverRide
{
    class PlaneBullet
    {

        private Plane Plane;
        private Vector2 Size { get; }
        private int Velocity { get; }

        private Vector2 Location { get; set; }
        private Rectangle Bounds { get; set; }

        public PlaneBullet(Plane plane, Vector2 size, int velocity)
        {
            Size = size;
            Velocity = velocity;
            Plane = plane;

            Location = new Vector2(Plane.Location.X + Plane.Size.X / 2, Plane.Location.Y - Size.Y);
            Bounds = new Rectangle((int)Location.X - (int)Size.X / 2, (int)Location.Y, (int)Size.X, (int)Size.Y);
        }

        public void Draw()
        {
            Globals.spriteBatch.Draw(Globals.planeBulletTexture, Bounds, Colors.player);

            Location += new Vector2(0,-Velocity);
            Bounds = new Rectangle((int)Location.X - (int)Size.X / 2, (int)Location.Y, (int)Size.X, (int)Size.Y);
        }
    }
}