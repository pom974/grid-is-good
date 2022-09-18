namespace Tetris
{
    internal class GridController
    {
        private static GridController _instance = null;
        private static readonly object _padlock = new object();

        public int sizeX = 21;
        public int sizeY = 30;
        public int[,] Grid { get; set; }

        public GridController()
        {
            Init();
        }

        private void Init()
        {
            Grid = new int[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
                for (int j = 0; j < sizeY; j++)
                    Grid[i, j] = 0;
        }

        public static GridController Instance
        {
            get
            {
                lock (_padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new GridController();
                    }
                    return _instance;
                }
            }
        }

        public void FillCoordinates(int x, int y, int value)
        {
            Grid[x, y] = value;
        }

        public int GetCoordinatesValue(int x, int y)
        {
            return Grid[x, y];
        }

        public bool IsGridFreeOn(int x, int y)
        {
            if (x < 0 || x >= sizeX)
                return false;
            if (y < 0 || y >= sizeY)
                return false;

            return (Grid[x, y] == 0);
        }
        
        public void OnTileMoved(int previousX, int nextX, int previousY, int nextY)
        {
            FillCoordinates(previousX, previousY, 0);
            FillCoordinates(nextX, nextY, 1);
        }


    }

 }
