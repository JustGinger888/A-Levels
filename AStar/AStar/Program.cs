using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    class Location
    {
        public int X;
        public int Y;
        public int F;
        public int G;
        public int H;
        public Location Parent;
    }

    class Program
    {
        static char[,] map = new char[50, 82];

        static void Main()
        {

            System.Threading.Thread.Sleep(5);

            int _yPlayerPositionMap = 7;
            int _xPlayerPositionMap = 11;
            int _yEnemyPositionMap = 42;
            int _xEnemyPositionMap = 11;



            MapToStringArray();



            MapOutput();
            System.Threading.Thread.Sleep(5000);
            // algorithm



            Location current = null;

            var start = new Location { X = _xEnemyPositionMap, Y = _yEnemyPositionMap };
            var target = new Location { X = _xPlayerPositionMap, Y = _yPlayerPositionMap };
            var openList = new List<Location>();
            var closedList = new List<Location>();
            int g = 0;

            // start by adding the original position to the open list
            openList.Add(start);

            while (openList.Count > 0)
            {
                // get the square with the lowest F score
                var lowest = openList.Min(l => l.F);
                current = openList.First(l => l.F == lowest);

                // add the current square to the closed list
                closedList.Add(current);

                // show current square on the map
                Console.SetCursorPosition(current.X, current.Y);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write('.');
                Console.SetCursorPosition(current.X, current.Y);
                //System.Threading.Thread.Sleep(20);

                // remove it from the open list
                openList.Remove(current);

                // if we added the destination to the closed list, we've found a path
                if (closedList.FirstOrDefault(l => l.X == target.X && l.Y == target.Y) != null)
                    break;

                var adjacentSquares = GetWalkableAdjacentSquares(current.X, current.Y, map);
                g++;

                foreach (var adjacentSquare in adjacentSquares)
                {
                    // if this adjacent square is already in the closed list, ignore it
                    if (closedList.FirstOrDefault(l => l.X == adjacentSquare.X
                            && l.Y == adjacentSquare.Y) != null)
                        continue;

                    // if it's not in the open list...
                    if (openList.FirstOrDefault(l => l.X == adjacentSquare.X
                            && l.Y == adjacentSquare.Y) == null)
                    {
                        // compute its score, set the parent
                        adjacentSquare.G = g;
                        adjacentSquare.H = ComputeHScore(adjacentSquare.X, adjacentSquare.Y, target.X, target.Y);
                        adjacentSquare.F = adjacentSquare.G + adjacentSquare.H;
                        adjacentSquare.Parent = current;

                        // and add it to the open list
                        openList.Insert(0, adjacentSquare);
                    }
                    else
                    {
                        // test if using the current G score makes the adjacent square's F score
                        // lower, if yes update the parent because it means it's a better path
                        if (g + adjacentSquare.H < adjacentSquare.F)
                        {
                            adjacentSquare.G = g;
                            adjacentSquare.F = adjacentSquare.G + adjacentSquare.H;
                            adjacentSquare.Parent = current;
                        }
                    }
                }
            }

            // assume path was found; let's show it
            while (current != null)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(current.X, current.Y);
                Console.Write('*');
                Console.SetCursorPosition(current.X, current.Y);
                map[current.Y, current.X] = '*';
                current = current.Parent;
                //System.Threading.Thread.Sleep(100);
            }

            // end

            PathMapWrite();

            Console.ReadLine();


        }

        static List<Location> GetWalkableAdjacentSquares(int x, int y, char[,] map)
        {
            var proposedLocations = new List<Location>()
            {
                new Location { X = x, Y = y - 1 },
                new Location { X = x, Y = y + 1 },
                new Location { X = x - 1, Y = y },
                new Location { X = x + 1, Y = y },
            };

            return proposedLocations.Where(l => map[l.Y,l.X] == ' ' || map[l.Y,l.X] == 'P').ToList();
        }

        static int ComputeHScore(int x, int y, int targetX, int targetY)
        {
            return Math.Abs(targetX - x) + Math.Abs(targetY - y);
        }


        static void MapOutput()
        {
            int xLoad = 0;
            int yLoad = 0;

            foreach (char value in map)
            {

                Console.Write(map[yLoad, xLoad]);

                xLoad++;

                if (xLoad >= 82)
                {
                    Console.WriteLine();
                    yLoad++;
                    xLoad = 0;
                }
            }

            


        }


        static void MapToStringArray()
        {
            int xLoad = 0;
            int yLoad = 0;



            using (StreamReader reader = new StreamReader("AStar.txt"))
            {


                while (!reader.EndOfStream)
                {
                    string csvline = reader.ReadLine();

                    foreach (string value in csvline.Split(','))
                    {

                        map[yLoad, xLoad] = Convert.ToChar( value);

                        xLoad++;
                    }

                    yLoad++;
                    xLoad = 0;
                }
            }

        }


        static void PathMapWrite()
        {
            StreamWriter _sw = new StreamWriter("AStarPath.txt");

            for (int _y = 0; _y < 50; _y++)
            {

                for (int _x = 0; _x < 82; _x++)
                {

                            _sw.Write(map[_y,_x] + " ");


                }
                _sw.WriteLine();
            }

            _sw.Close();

        }
    }
    
}
