using System;

namespace GameofLife
{
    public class LifeSimulation
    {
        private int Height;
        private int Width;
        private bool[,] cells;

        public LifeSimulation(int Height, int Width)
        {
            this.Height = Height;
            this.Width = Width;
            cells = new bool[Height, Width];
            GenerateField();
        }
        public void DrawAndGrow()
        {
            DrawGame();
            Grow();
        }
        private void Grow()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int numOfAliveNeighbors = GetNeighbors(i, j);

                    if (cells[i, j])
                    {
                        if (numOfAliveNeighbors < 2)
                        {
                            cells[i, j] = false;
                        }

                        if (numOfAliveNeighbors > 3)
                        {
                            cells[i, j] = false;
                        }
                    }
                    else
                    {
                        if (numOfAliveNeighbors == 3)
                        {
                            cells[i, j] = true;
                        }
                    }
                }
            }
        }
        
        private int GetNeighbors(int x, int y)
        {
            int NumOfAliveNeighbors = 0;

            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    if (!((i < 0 || j < 0) || (i >= Height || j >= Width)))
                    {
                        if (!((i == x) && (j == y)))
                        {
                            if (cells[i, j] == true) NumOfAliveNeighbors++;
                        }
                    }
                }
            }
            return NumOfAliveNeighbors;
        }
        private void DrawGame()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(cells[i, j] ? "x" : "o");                    
                    if (j == Width - 1) Console.WriteLine("\r");
                }
            }
            Console.WriteLine();
            Console.SetCursorPosition(0, Console.WindowTop);
        }
        private void GenerateField()
        {
            Random generator = new Random();
            int number;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    number = generator.Next(2);
                    cells[i, j] = ((number == 0) ? false : true);
                }
            }
        }
    }

    public class Program
    { 
        public static void Main(string[] args)
        {
            int MaxRuns = 30;
            int Height = 25;
            int Width = 25;
            int runs = 0;
            LifeSimulation sim = new LifeSimulation(Height, Width);

            while (runs++ < MaxRuns)
            {
                sim.DrawAndGrow();
            }
            //Console.WriteLine("Enter any key to exit");
            Console.ReadLine();
        }
    }
}
