using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL.MAP
{
    class LevelReadWrite
    {
        public void LevelWrite(char[,] _levelMap)
        {
            StreamWriter _sw = new StreamWriter("LevelMap.txt");
            for (int _y = 0; _y < 48; _y++)
            {
                for (int _x = 0; _x < 80; _x++)
                {
                    _sw.Write(_levelMap[_y, _x] + " ");
                }
                _sw.WriteLine();
            }
            _sw.Close();
        }

        public void PathWrite(int[,] _pathArray)
        {
            StreamWriter _sw = new StreamWriter("PathMap.txt");
            for (int _y = 0; _y < 4; _y++)
            {
                for (int _x = 0; _x < 4; _x++)
                {
                    _sw.Write(_pathArray[_y, _x] + " ");
                }
                _sw.WriteLine();
            }
            _sw.Close();
        }
    }
}
