using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Tetris
{
    internal class Tile
    {
        public int x, y;

        public Tile()
        {
            Reset();
        }


        public void Reset()
        {
            x = 0;
            y = 0;
            GridController.Instance.FillCoordinates(x, y, 1);
        }
    }

    internal class TileController
    {
        public Tile currentTile { get; set; }


        private static TileController instance = null;
        private static readonly object padlock = new object();


        public TileController()
        {
            currentTile = new Tile();
        }

        public void Update()
        {
            MoveTile(0, 1);

            if (Console.KeyAvailable == false)
                return;

            ConsoleKeyInfo cki = Console.ReadKey(true);
            switch (cki.Key)
            {
                case ConsoleKey.RightArrow:
                    MoveTile(1,0);
                    break;

                case ConsoleKey.LeftArrow:
                    MoveTile(-1,0);
                    break;

                default:
                    break;
            }

            
        }

        void MoveTile(int x, int y)
        {
            int previousX = currentTile.x;
            int nextX = previousX + x;

            int previousY = currentTile.y;
            int nextY = previousY + y;

            if (GridController.Instance.IsGridFreeOn(nextX, nextY))
            {
                currentTile.x = nextX;
                currentTile.y = nextY;
                GridController.Instance.OnTileMoved(previousX, nextX, previousY, nextY);
                return;
            }

            if(y > 0 && !GridController.Instance.IsGridFreeOn(nextX, nextY))
            {
                GridController.Instance.FillCoordinates(currentTile.x, currentTile.y, 1);
                currentTile.Reset();
                return;
            }
        }

        public static TileController Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new TileController();
                    }
                    return instance;
                }
            }
        }
    }
   }
