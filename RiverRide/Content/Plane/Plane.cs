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

            Location = new Vector2(Globals.mapArea.Width / 2 - size.X / 2, Globals.mapArea.Height - 5 * size.Y);
            Bounds = new Rectangle((int)Location.X, (int)Location.Y, (int)size.X, (int)size.Y);
        }
        public void DrawPlane()
        {
            if (isTurningLeft)
            {
                Globals.spriteBatch.Draw(Globals.planeTextureLeft, Bounds, Colors.player);

            }
            else if (isTurningRight)
            {
                Globals.spriteBatch.Draw(Globals.planeTextureRight, Bounds, Colors.player);
            }
            else
            {
                Globals.spriteBatch.Draw(Globals.planeTexture, Bounds, Colors.player);
            }
        }
        public void CheckCollision()
        {
            foreach(Rectangle element in Globals.collisionList)
            {
                if (Bounds.Intersects(element))
                {                    
                    Globals.activeState = Globals.States.GAMEOVER;
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
                        if (Globals.inputRight.Contains(action.Position))
                        {
                            Location += new Vector2(5, 0);
                            isTurningRight = true;
                            isTurningLeft = false;
                        }
                        else if (Globals.inputLeft.Contains(action.Position))
                        {
                            Location += new Vector2(-5, 0);
                            isTurningLeft = true;
                            isTurningRight = false;
                        }
                        else if (Globals.inputUp.Contains(action.Position))
                        {
                            if(Location.Y + 5 > Globals.mapArea.Height/3)
                            Location += new Vector2(0, -5);
                          
                        }
                        else if (Globals.inputDown.Contains(action.Position))
                        {
                            if(Location.Y - 5 < Globals.mapArea.Height - 5 * Size.Y)
                            Location += new Vector2(0, 5);
                       
                        }
                        else if (Globals.bulletsBtn.Contains(action.Position))
                        {
                            Globals.blockade = false;
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

    
    }
}