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
using Microsoft.Xna.Framework.Input;

namespace RiverRide
{
    class PauseState : StateInterface
    {      

        public void Update()
        {
            Draw();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Globals.activeState = Globals.States.GAME;
        }

        public void Draw()
        {
            Globals.spriteBatch.Begin();
            String pauseScreenText = "PAUSED";
            String pauseScreenText2 = "press BACK to return";
            //Vector2 measureString = Globals.defaultFont.MeasureString(pauseScreenText);
            Globals.spriteBatch.DrawString(Globals.defaultFont, pauseScreenText, new Vector2((Globals.screenSize.X/2)- Globals.defaultFont.MeasureString(pauseScreenText).X/2, Globals.screenSize.Y / 2), Color.White);
            Globals.spriteBatch.DrawString(Globals.defaultFont, pauseScreenText2, new Vector2((Globals.screenSize.X/2)- Globals.defaultFont.MeasureString(pauseScreenText2).X/2, (Globals.screenSize.Y / 2) + (Globals.defaultFont.MeasureString(pauseScreenText).X)), Color.White);
            Globals.spriteBatch.End();
        }
    }
}
