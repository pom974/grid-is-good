
namespace Tetris
{
    internal class Game
    {
        bool isAppRunning = true;

        double deltaTime = 1000;

        private GridController gridController;
        private TileController tileController;
        private System.Timers.Timer timer;

        public Game()
        {
            gridController = GridController.Instance;
            tileController = TileController.Instance;
            isAppRunning = true;

            timer = new System.Timers.Timer(deltaTime);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
        }

        public void StartTimer()
        {
            timer.Enabled = true;
        }

        public void OnTimedEvent(object sender, EventArgs e)
        {
            Update();
        }

        private void Update()
        {
            //gridController.Update();
            tileController.Update();
            UpdateRender();
        }

        public void UpdateRender()
        {
            Console.Clear();

            for (int i = 0; i < GridController.Instance.sizeY; i++)
            {
                for (int j = 0; j < GridController.Instance.sizeX; j++)
                {
                    Console.Write(GridController.Instance.GetCoordinatesValue(j,i));
                }

                Console.Write("\r\n");
            }
        }

        public void Run()
        {
            StartTimer();

            while (isAppRunning)
            {
                
            }
        }

    }
}
