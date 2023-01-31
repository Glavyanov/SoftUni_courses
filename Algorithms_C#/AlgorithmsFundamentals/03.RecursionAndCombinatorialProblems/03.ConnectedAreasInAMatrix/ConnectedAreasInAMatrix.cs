namespace _03.ConnectedAreasInAMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ConnectedAreasInAMatrix
    {
        private static char[,] output;

        private static int size = 0;

        public static void Main(string[] args)
        {
            int nRow = int.Parse(Console.ReadLine());
            int nCol = int.Parse(Console.ReadLine());

            output = new char[nRow, nCol];

            var areas = new List<Area>();

            for (int r = 0; r < nRow; r++)
            {
                string symbols = Console.ReadLine();
                for (int c = 0; c < nCol; c++)
                {
                    output[r, c] = symbols[c];
                }
            }

            for (int row = 0; row < output.GetLength(0); row++)
            {
                for (int col = 0; col < output.GetLength(1); col++)
                {
                    size = 0;
                    FindArea(row, col);

                    if (size != 0)
                    {
                        areas.Add(new Area
                        {
                            Row = row,
                            Col = col,
                            Size = size
                        });
                    }

                }
            }

            Console.WriteLine($"Total areas found: {areas.Count}");
            int count = 1;
            foreach (var area in areas.OrderByDescending(a => a.Size).ThenBy(a => a.Row).ThenBy(a => a.Col))
            {
                Console.WriteLine($"Area #{count++} at ({area.Row}, {area.Col}), size: {area.Size}");
            }

        }

        private static void FindArea(int row, int col)
        {
            if (InvalidCell(row, col) || WallImpact(row, col) || Visited(row, col))
            {
                return;
            }

            size++;
            output[row, col] = 'v';

            FindArea(row - 1, col); //Up
            FindArea(row + 1, col); //Down
            FindArea(row, col - 1); //Left
            FindArea(row, col + 1); //Right

        }

        private static bool Visited(int row, int col)
        {
            return output[row, col] == 'v';
        }

        private static bool WallImpact(int row, int col)
        {
            return output[row, col] == '*';
        }

        private static bool InvalidCell(int row, int col)
        {
            return row < 0 || row >= output.GetLength(0) || col < 0 || col >= output.GetLength(1);
        }
    }
}