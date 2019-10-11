using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL.PathFinding
{

    class AStar
    {

        public static char[,] map = new char[50, 82];


        public static void PathFinder(int _yPlayerPositionMap, int _xPlayerPositionMap, int _yEnemyPositionMap, int _xEnemyPositionMap)
        {



            //MapToStringArray();



            MapOutput();

            // algorithm



            Location current = null;

            var start = new Location { _xPosition = _xEnemyPositionMap, _yPosition = _yEnemyPositionMap };
            var target = new Location { _xPosition = _xPlayerPositionMap, _yPosition = _yPlayerPositionMap };
            var openList = new List<Location>();
            var closedList = new List<Location>();
            int g = 0;

            // start by adding the original position to the open list
            openList.Add(start);

            while (openList.Count > 0)
            {
                // get the square with the lowest F score
                var lowest = openList.Min(l => l._pathF);
                current = openList.First(l => l._pathF == lowest);

                // add the current square to the closed list
                closedList.Add(current);

                // show current square on the map
                //Console.SetCursorPosition(current.X, current.Y);
                //Console.Write('.');
                //Console.SetCursorPosition(current.X, current.Y);
                //System.Threading.Thread.Sleep(1);

                // remove it from the open list
                openList.Remove(current);

                // if we added the destination to the closed list, we've found a path
                if (closedList.FirstOrDefault(l => l._xPosition == target._xPosition && l._yPosition == target._yPosition) != null)
                    break;

                var adjacentSquares = GetWalkableAdjacentSquares(current._xPosition, current._yPosition, map);
                g++;

                foreach (var adjacentSquare in adjacentSquares)
                {
                    // if this adjacent square is already in the closed list, ignore it
                    if (closedList.FirstOrDefault(l => l._xPosition == adjacentSquare._xPosition
                            && l._yPosition == adjacentSquare._yPosition) != null)
                        continue;

                    // if it's not in the open list...
                    if (openList.FirstOrDefault(l => l._xPosition == adjacentSquare._xPosition
                            && l._yPosition == adjacentSquare._yPosition) == null)
                    {
                        // compute its score, set the parent
                        // compute adjacenits score, set the parent
                        adjacentSquare._movementCostG = g;
                        adjacentSquare._estimatedMovementCostH = ComputeHScore(adjacentSquare._xPosition, adjacentSquare._yPosition, target._xPosition, target._yPosition);
                        adjacentSquare._pathF = adjacentSquare._movementCostG + adjacentSquare._estimatedMovementCostH;
                        adjacentSquare.Parent = current;

                        // and add it to the open list
                        openList.Insert(0, adjacentSquare);
                    }
                    else
                    {
                        // test if using the current G score makes the adjacent square's F score
                        // lower, if yes update the parent because it means it's a better path
                        if (g + adjacentSquare._estimatedMovementCostH < adjacentSquare._pathF)
                        {
                            adjacentSquare._movementCostG = g;
                            adjacentSquare._pathF = adjacentSquare._movementCostG + adjacentSquare._estimatedMovementCostH;
                            adjacentSquare.Parent = current;
                        }
                    }
                }
            }

            // assume path was found; let's show it
            while (current != null)
            {
                //Console.ForegroundColor = ConsoleColor.White;
                //Console.SetCursorPosition(current.X, current.Y);
                //Console.Write('*');
                ///Console.SetCursorPosition(current.X, current.Y);
                map[current._yPosition, current._xPosition] = '*';
                current = current.Parent;
                //System.Threading.Thread.Sleep(10);
            }

            // end

            PathMapWrite(map);

        }


        static List<Location> GetWalkableAdjacentSquares(int x, int y, char[,] map)
        {
            var proposedLocations = new List<Location>()
            {
                new Location { _xPosition = x, _yPosition = y - 1 },
                new Location { _xPosition = x, _yPosition = y + 1 },
                new Location { _xPosition = x - 1, _yPosition = y },
                new Location { _xPosition = x + 1, _yPosition = y },
            };

            return proposedLocations.Where(l => map[l._yPosition, l._xPosition] == ' ' || map[l._yPosition, l._xPosition] == 'P').ToList();
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

                        map[yLoad, xLoad] = Convert.ToChar(value);

                        xLoad++;
                    }

                    yLoad++;
                    xLoad = 0;
                }
            }

        }


        static void PathMapWrite(char[,] map)
        {
            StreamWriter _sw = new StreamWriter("AStarPath.txt");

            for (int _y = 0; _y < 50; _y++)
            {

                for (int _x = 0; _x < 82; _x++)
                {

                    _sw.Write(map[_y, _x] + " ");


                }
                _sw.WriteLine();
            }

            _sw.Close();

        }

    }

}