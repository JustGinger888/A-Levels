using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speluky_map_Generator_Test
{

    // Initaalizwes the grid as a whole

    class Initialize
    {

        protected Random rnd = new Random();

        protected int[,] _pathArray = new int[4, 4];                    // Path Layout 
        protected char[,] _section = new char[12, 20];                  // Section Layout
        protected char[,] _levelMapText = new char[48, 80];             // Map Layout for text files
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
            lvlMap.TextMapWrite(_levelMapText);
            lvlMap.ThreeDimensionalMapWrite(_levelMapSections);

            // Read Map and path for testing purposes
            LevelReadWrite lvlReadWrite = new LevelReadWrite();
            lvlReadWrite.LevelWrite(_levelMapText);
            lvlReadWrite.PathWrite(_pathArray);
            Display();

            Console.WriteLine();

            //Clean Up Memory
            GC.Collect();

        }


        public void Display()
        {

                for (int _y = 0; _y < 12; _y++)
                {

                    for (int _x = 0; _x < 20; _x++)
                    {
                    System.Threading.Thread.Sleep(20);
                    Console.Write(_levelMapSections[0, _y, _x] + " ");
                    }
                    Console.WriteLine();
                }
            

            Console.ReadKey();
        }
            
    }
}
