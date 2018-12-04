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
            fuelIndicatorBounds = new Rectangle(Globals.userInterfaceArea.Center.X - Globals.fuelIndicatorBox.Width / 2, Globals.userInterfaceArea.Top + Globals.fuelIndicatorBox.Height * 3 / 2, Globals.fuelIndicatorBox.Width, Globals.fuelIndicatorBox.Height); ;
            fuelLineBounds = new Rectangle(fuelIndicatorBounds.X + fuelIndicatorBounds.Width - 20, fuelIndicatorBounds.Y, 20, fuelIndicatorBounds.Height / 2);
        }

        public void Draw()
        {
            //TODO: jak zrobisz zbieranie fuela to reset fuela bedzie do wyjebania
            if (fuelLineBounds.X-- < fuelIndicatorBounds.X) fuelLineBounds.X += fuelIndicatorBounds.Width - fuelLineBounds.Width;
            //GUI SQUARE
            Globals.spriteBatch.Draw(Globals.tileTexture, Globals.userInterfaceArea, Colors.userInterfaceBackground);
            //CONTROL INDICATORS
           Globals.spriteBatch.Draw(Globals.inputButtonsTexture, new Rectangle(Globals.screenSizeX*3/4- Globals.inputButtonsTexture.Width * 2, Globals.bulletsBtn.Center.Y - Globals.inputButtonsTexture.Height*2, Globals.inputButtonsTexture.Width*4, Globals.inputButtonsTexture.Height*4), Color.White);
           Globals.spriteBatch.Draw(Globals.bulletButtonTexture, new Rectangle(Globals.screenSizeX/4 - Globals.bulletButtonTexture.Width*5, Globals.bulletsBtn.Center.Y- (Globals.bulletButtonTexture.Width * 5/2), Globals.bulletButtonTexture.Width*5, Globals.bulletButtonTexture.Width * 5),Color.White);
            //FUEL INDICATOR
            Globals.spriteBatch.Draw(Globals.tileTexture, fuelLineBounds, Colors.player);
            Globals.spriteBatch.Draw(Globals.fuelIndicatorBox, fuelIndicatorBounds, Color.Black);
        }
    }
}