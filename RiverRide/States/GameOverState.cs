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

namespace RiverRide.States
{
    //#deprecated zaciągnąłem z poprzednich gier, tutaj raczej nie znajdzie zastosowania - trzeba chyba zrobić na activities ale pluje błędami meh? :o
    class GameOverState : StateInterface
    {
        private List<Button> _buttons;
        private Button newGameButton, quitGameButton, infoButton;
        const int buttons_count = 3;
        public GameOverState(){

            float middleX = (Globals.screenSize.X - Globals.tileTexture.Width) / 2;
            float posY = (Globals.screenSize.Y - (Globals.tileTexture.Height * buttons_count) - (50 * buttons_count - 1)) / 2;
            newGameButton = new Button(Globals.tileTexture, Globals.defaultFont, "NewGame")
            {
                Position = new Vector2(middleX, posY),
                Text = "New Game",
            };
            infoButton = new Button(Globals.tileTexture, Globals.defaultFont, "INFO")
            {
                Position = new Vector2(middleX, newGameButton.Position.Y + Globals.tileTexture.Height + 50),
                Text = "Info",
            };
            quitGameButton = new Button(Globals.tileTexture, Globals.defaultFont, "Quit")
            {
                Position = new Vector2(middleX, infoButton.Position.Y + Globals.tileTexture.Height + 50),
                Text = "Quit",
            };

            _buttons = new List<Button>()
            {
                newGameButton,
                infoButton,
                quitGameButton,
            };
            _buttons[0]._isSelected = true;
        }

        public void Update()
        {
            Draw();
        }

        public void Draw()
        {
            Globals.spriteBatch.Begin();
            String pauseScreenText = "PAUSED";
            String pauseScreenText2 = "press BACK to return";
            //Vector2 measureString = Globals.defaultFont.MeasureString(pauseScreenText);
            Globals.spriteBatch.DrawString(Globals.defaultFont, pauseScreenText, new Vector2((Globals.screenSize.X / 2) - Globals.defaultFont.MeasureString(pauseScreenText).X / 2, Globals.screenSize.Y / 2), Color.White);
            Globals.spriteBatch.DrawString(Globals.defaultFont, pauseScreenText2, new Vector2((Globals.screenSize.X / 2) - Globals.defaultFont.MeasureString(pauseScreenText2).X / 2, (Globals.screenSize.Y / 2) + (Globals.defaultFont.MeasureString(pauseScreenText).X)), Color.White);
            Globals.spriteBatch.End();
        }

        
    }
}