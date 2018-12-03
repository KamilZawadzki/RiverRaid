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
    class Gui
    {
        public Rectangle fuelIndicatorBounds;
        public Rectangle fuelLineBounds;
        public Gui()
        {
            fuelIndicatorBounds = new Rectangle(Globals.guiRect.Center.X - Globals.fuelIndicatorBox.Width / 2, Globals.guiRect.Top + Globals.fuelIndicatorBox.Height * 3 / 2, Globals.fuelIndicatorBox.Width, Globals.fuelIndicatorBox.Height); ;
            fuelLineBounds = new Rectangle(fuelIndicatorBounds.X + fuelIndicatorBounds.Width - 20, fuelIndicatorBounds.Y, 20, fuelIndicatorBounds.Height / 2);
        }

        public void Draw()
        {
            //TODO: jak zrobisz zbieranie fuela to reset fuela bedzie do wyjebania
            if (fuelLineBounds.X-- < fuelIndicatorBounds.X) fuelLineBounds.X += fuelIndicatorBounds.Width - fuelLineBounds.Width;
            //GUI SQUARE
            Globals.spriteBatch.Draw(Globals.tileTexture, Globals.guiRect, Globals.grayColor);
            //CONTROL INDICATORS
            Globals.spriteBatch.Draw(Globals.joystickTexture, new Rectangle(Globals.joyStickLeft.X, Globals.joyStickLeft.Bottom - Globals.joyStickLeft.Height / 2, Globals.joyStickLeft.Width + Globals.joyStickRight.Width, Globals.joyStickLeft.Height / 2), Globals.lightGrayColor);
            Globals.spriteBatch.Draw(Globals.fireButtonTexture, new Rectangle(Globals.fireButton.X + Globals.fireButton.Width / 5, Globals.fireButton.Center.Y, Globals.fireButton.Width / 2, Globals.fireButton.Width / 2), Globals.lightGrayColor);
            //FUEL INDICATOR
            Globals.spriteBatch.Draw(Globals.tileTexture, fuelLineBounds, Globals.textColor);
            Globals.spriteBatch.Draw(Globals.fuelIndicatorBox, fuelIndicatorBounds, Color.Black);
        }
    }
}