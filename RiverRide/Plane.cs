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
using Microsoft.Xna.Framework.Input.Touch;

namespace RiverRide
{
    class Plane
    {
        TouchCollection touchCollection;

        bool isTurningRight = false;
        bool isTurningLeft = false;

        public Vector2 Size { get; }
        public int Velocity { get; }

        public Vector2 Location { get; set; }
        public Rectangle Bounds { get; set; }

        public Plane(Vector2 size, int velocity)
        {
            Size = size;
            Velocity = velocity;

            Location = new Vector2(Globals.tileRect.Width / 2 - size.X / 2, Globals.tileRect.Height - 3 * size.Y);
            Bounds = new Rectangle((int)Location.X, (int)Location.Y, (int)size.X, (int)size.Y);
        }

        public void Behaviour()
        {
            foreach(Rectangle terrain in Globals.collisionList)
            {
                if (Bounds.Intersects(terrain))
                {
                    Globals.doUpdate = false;
                    break;
                }
            }


            touchCollection = TouchPanel.GetState();

            if (touchCollection.Count > 0)
            {
                foreach (var action in touchCollection)
                {
                    if (action.State == TouchLocationState.Moved || action.State == TouchLocationState.Pressed)
                    {
                        if (Globals.joyStickRight.Contains(action.Position))
                        {
                            Location += new Vector2(5, 0);
                            isTurningRight = true;
                            isTurningLeft = false;
                        }
                        else if (Globals.joyStickLeft.Contains(action.Position))
                        {
                            Location += new Vector2(-5, 0);
                            isTurningLeft = true;
                            isTurningRight = false;
                        }
                        else if (Globals.fireButton.Contains(action.Position))
                        {
                            Globals.fire = true;
                        }
                    }
                    Bounds = new Rectangle((int)Location.X, (int)Location.Y, (int)Size.X, (int)Size.Y);
                }
            }
            else
            {
                isTurningRight = false;
                isTurningLeft = false;
            }
        }

        public void DrawPlane()
        {
            if (isTurningLeft)
            {
                Globals.spriteBatch.Draw(Globals.planeTextureLeft, Bounds, Globals.textColor);

            }
            else if (isTurningRight)
            {
                Globals.spriteBatch.Draw(Globals.planeTextureRight, Bounds, Globals.textColor);
            }
            else
            {
                Globals.spriteBatch.Draw(Globals.planeTexture, Bounds, Globals.textColor);
            }
        }
    }
}