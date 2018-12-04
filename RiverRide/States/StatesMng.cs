﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RiverRide
{
    class StatesMng
    {
        GamePlay gamePlay;
        PauseState pauseState;

        public StatesMng()
        {
            gamePlay = new GamePlay();
            pauseState = new PauseState();
        }


        public void Update()
        {
            switch (Globals.activeState)
            {
                case Globals.States.MENU:
                    Globals.activeState = Globals.States.GAME;
                    break;
                case Globals.States.GAME:
                    gamePlay.Update();
                    break;
                case Globals.States.GAMEOVER:
                    break;
                case Globals.States.PAUSE:
                    pauseState.Update();
                    break;
            }
        }
    }
}