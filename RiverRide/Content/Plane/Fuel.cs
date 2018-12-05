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
    class Fuel
    {
        public Rectangle fuelIndicatorBounds;
        public Rectangle fuelLineBounds;
        public Fuel()
        {
            fuelIndicatorBounds = new Rectangle((int)Globals.screenSize.X/4 - Globals.fuelIndicatorBox.Width / 2, Globals.userInterfaceArea.Bottom- Globals.fuelIndicatorBox.Height * 3 / 2, Globals.fuelIndicatorBox.Width, Globals.fuelIndicatorBox.Height); ;
            fuelLineBounds = new Rectangle(fuelIndicatorBounds.X + fuelIndicatorBounds.Width - 20, fuelIndicatorBounds.Y, 20, fuelIndicatorBounds.Height / 2);
        }

        public void Draw()
        {            
            if (fuelLineBounds.X-- < fuelIndicatorBounds.X) fuelLineBounds.X += fuelIndicatorBounds.Width - fuelLineBounds.Width;
      
            Globals.spriteBatch.Draw(Globals.tileTexture, fuelLineBounds, Colors.player);
            Globals.spriteBatch.Draw(Globals.fuelIndicatorBox, fuelIndicatorBounds, Color.Black);
        }
    }
}