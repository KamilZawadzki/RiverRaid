using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RiverRide
{
    public class MapReader
    {
        private List<List<int>> Map = new List<List<int>>();
        private List<int> Row = new List<int>();
        Rectangle location = new Rectangle();
        private int mapMove = 0;
        private int startingPos;
        private int mapNr;

        private Random rand = new Random();

        private Dictionary<int, Color> ColorList = new Dictionary<int, Color>();

        public MapReader(int startingPos, int mapNr)
        {
            ColorList.Add(0, Globals.waterColor);  //WATER
            ColorList.Add(1, Globals.grassColor);  //GRASS
            ColorList.Add(2, Globals.lightGrayColor);  //LIGHT GRAY
            ColorList.Add(12, Globals.darkGrayColor); //DARK GRAY
            ColorList.Add(13, Globals.textColor); //YELLOW

            this.startingPos = startingPos;
            this.mapNr = mapNr;

            onLoad();
        }

        private void onLoad()
        {
            mapMove = 0;
            string fileName = "Content/map/map" + mapNr + ".csv";
            ReadMapTile(fileName);
        }

        public void ReadMapTile(string fileName)
        {
            Stream file = TitleContainer.OpenStream(fileName);
            Map = new List<List<int>>();
            using (StreamReader reader = new StreamReader(file))
            {
                reader.ReadLine();
                do
                {
                    string[] values = reader.ReadLine().Split(',');
                    Row = new List<int>();
                    foreach (string tile in values)
                    {
                        Row.Add(Convert.ToInt32(tile));
                    }

                    Map.Add(Row);
                } while (!reader.EndOfStream);

                location.Height = Globals.tileRect.Height / Map.Count;
                float width = Globals.screenSizeX / 30;
                location.Width = (int)Math.Ceiling(width);
            }
        }

        public void Draw()
        {
            int tileCounter = 0;
            int rowCounter = 0;
            location.Y = 1;
            if (location.Y < Globals.tileRect.Height)
            {
                Globals.collisionList.Clear();
                foreach (List<int> row in Map)
                {
                    foreach (int tile in row)
                    {
                        location.X = (location.Width) * tileCounter++;
                        location.Y = Globals.tileRect.Height / Map.Count * rowCounter - startingPos + mapMove;

                        Globals.spriteBatch.Draw(Globals.tileTexture, location, ColorList[tile]);
                        if(tile != 0)
                        {
                            Globals.collisionList.Add(location);
                        }

                    }
                    tileCounter = 0;
                    rowCounter++;
                }
            }
            mapMove += 7;

            if (mapMove > Globals.tileRect.Height - 25 && startingPos == 0)
            {
                mapNr = rand.Next(2, 6);
                onLoad();
                startingPos = Globals.tileRect.Height - 25;
            }
            else if (mapMove > 2 * (Globals.tileRect.Height - 25))
            {
                mapNr = rand.Next(2, 6);
                onLoad();
                startingPos = Globals.tileRect.Height - 25;
            }
        }
    }
}
