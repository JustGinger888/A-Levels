using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL.MAP
{
    // Initaalizwes the grid as a whole
    class InitializeMap
    {
        protected Random rnd = new Random();
        protected int[,] _pathArray = new int[4, 4];                    // Path Layout 
        protected char[,] _section = new char[12, 20];                  // Section Layout
        protected char[,] _levelMap2D = new char[48, 80];               // Map Layout for text files
        protected char[,,] _levelMapSections = new char[16, 12, 20];    // Map Layout for sections
        // Sections
        protected char newDirection;
        // LevelCreate
        protected int _lvlMapY = 0;
        protected int _lvlMapYCheck = 0;
        protected int _lvlMapX = 0;
        protected int _lvlMapXCheck = 0;
        protected int _count = 0;
        protected char[,] _tmpLevelMap = new char[48, 80];
        protected char[,] _tmpSection = new char[12, 20];
        protected char[,,] _tmpLevelMapSections = new char[16, 12, 20];

        public void InitializeGrid()
        {
            // State pbx Size XxY
            // Define Section size; X_20 x Y_12
            // Section Size X_20 x pbx Size & Y_12 x pbx Size
            // Full Map Width = SectionXSize x XRooms + pbxSize * 2 (Border)
            // Full Map Height = SectionYSize x YRooms + pbxSize * 2 (Border)
            //SetupPathGrid();
            //Create Main Path
            MainPath mainPath = new MainPath();
            mainPath.CreateMainPath(_pathArray);
            //mainPath.PrintGrid();
            // Create Level
            LevelCreate lvlMap = new LevelCreate();
            lvlMap.SectionAdd(_pathArray);
            lvlMap.TextMapWrite(_levelMap2D);
            lvlMap.ThreeDimensionalMapWrite(_levelMapSections);
            // Read Map and path for testing purposes
            LevelReadWrite lvlReadWrite = new LevelReadWrite();
            lvlReadWrite.LevelWrite(_levelMap2D);
            lvlReadWrite.PathWrite(_pathArray);
            //Display();
            //Clean Up Memory
            GC.Collect();
        }

        public void Display()
        {
            for (int _y = 0; _y < 12; _y++)
            {
                for (int _x = 0; _x < 20; _x++)
                {
                    Console.Write(_levelMapSections[0, _y, _x] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        public int[,] AddPath(int[,] _formPathArray)
        {
            for (int _y = 0; _y < 4; _y++)
            {
                for (int _x = 0; _x < 4; _x++)
                {
                    _formPathArray[_y, _x] = _pathArray[_y, _x];
                }
            }
            return _pathArray;
        }

        public char[,,] AddMap3D(char[,,] _formLevelMapSections)
        {
            for (int _z = 0; _z < 16; _z++)
            {
                for (int _y = 0; _y < 12; _y++)
                {
                    for (int _x = 0; _x < 20; _x++)
                    {
                        _formLevelMapSections[_z, _y, _x] = _levelMapSections[_z, _y, _x];
                    }
                }
            }
            return _formLevelMapSections;
        }

        public char[,] AddMap2D(char[,] _formLevelMapSections)
        {    
                for (int _y = 1; _y < 49; _y++)
                {
                    for (int _x = 1; _x < 81; _x++)
                    {
                        _formLevelMapSections[ _y, _x] = _levelMap2D[ _y - 1, _x - 1];
                    }
                }            
            return _formLevelMapSections;
        }
    }
}
