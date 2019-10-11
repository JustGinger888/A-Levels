using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL.MAP
{
    class Sections : InitializeMap
    {
        private LevelCreate lvlMap = new LevelCreate();
        private Populate populate = new Populate();
        public char[,] CreateSection1LeftRight()
        {
            CreateSectionFill();
            HorizontalCorridor();
            //populate.PopulateItems(_section);
            return _section;
            //PrintSection();
        }

        public char[,] CreateSection2LeftRightDown()
        {
            CreateSectionFill();
            HorizontalCorridor();
            DownwardsCorridor();
            //populate.PopulateItems(_section);
            return _section;
            //PrintSection();
        }

        public char[,] CreateSection3LeftRightUp()
        {
            CreateSectionFill();
            HorizontalCorridor();
            UpwardsCorridor();
            //populate.PopulateItems(_section);
            return _section;
            //PrintSection();
        }

        public char[,] CreateSection5Shop()
        {
            SectionLoader("Shop.txt");
            return _section;
            //PrintSection();
        }


        public char[,] CreateSection6Item()
        {
            SectionLoader("ItemRoom.txt");
            return _section;
            //PrintSection();
        }

        public char[,] CreateSection7Pit()
        {
            CreateSectionFill();
            HorizontalCorridor();
            DownwardsCorridor();
            PitFall();
            //populate.PopulateItems(_section);
            return _section;
            //PrintSection();
        }

        public char[,] CreateSectionEntrance()
        {
            CreateSectionFill();
            HorizontalCorridor();
            DownwardsCorridor();
            EnteranceExit();
            return _section;
            //PrintSection();
        }


        public char[,] CreateSectionExit()
        {
            CreateSectionFill();
            HorizontalCorridor();
            UpwardsCorridor();
            EnteranceExit();
            return _section;
            //PrintSection();
        }

        public char[,] CreateSectionFill()
        {
            // Initialize section by filling it with #
            InitializeSection();
            int _percentageFill = 0;
            double _tileFill = 0;
            double _sectionSize = 12 * 20;
            // Generates the STARTING room on random location In Middel 2x2
            int _roomY = rnd.Next(6, 8);
            int _roomX = rnd.Next(9, 11);
            _section[_roomY, _roomX] = '.';
            // Determine initial direction
            Direction();
            // Continues making Rooms till 40% of room is filled with tiles
            while (_percentageFill < 40)
            {
                // Calculating Fill Perventage
                _percentageFill = (int)Math.Round((double)(_tileFill / _sectionSize) * 100);
                // Initial Direction
                Direction();
                //Choosing Direction
                switch (newDirection)
                {
                    case 'N':
                        _roomY--;
                        if (_roomY == -1)
                        {
                            _roomY++;
                        }
                        else
                        {
                            if (_section[_roomY, _roomX] == '.')
                            {
                            }
                            else
                            {
                                _tileFill++;
                                _section[_roomY, _roomX] = '.';
                            }
                        }
                        break;

                    case 'E':
                        _roomX++;
                        if (_roomX == 20)
                        {
                            _roomX--;
                        }
                        else
                        {
                            if (_section[_roomY, _roomX] == '.')
                            {
                            }
                            else
                            {
                                _tileFill++;
                                _section[_roomY, _roomX] = '.';
                            }
                        }
                        break;
                    case 'S':
                        _roomY++;
                        if (_roomY == 12)
                        {
                            _roomY--;
                        }
                        else
                        {
                            if (_section[_roomY, _roomX] == '.')
                            {
                            }
                            else
                            {
                                _tileFill++;
                                _section[_roomY, _roomX] = '.';
                            }
                        }
                        break;
                    case 'W':
                        _roomX--;
                        if (_roomX == -1)
                        {
                            _roomX++;
                        }
                        else
                        {
                            if (_section[_roomY, _roomX] == '.')
                            {
                            }
                            else
                            {
                                _tileFill++;
                                _section[_roomY, _roomX] = '.';
                            }
                        }
                        break;
                }
            }
            populate.PopulateItems(_section);
            return _section;
        }

        private void InitializeSection()
        {
            for (int _y = 0; _y < 12; _y++)
            {
                for (int _x = 0; _x < 20; _x++)
                {
                    _section[_y, _x] = '#';
                }
            }
        }

        private void PrintSection()
        {
            for (int _y = 0; _y < 12; _y++)
            {
                for (int _x = 0; _x < 20; _x++)
                {
                    Console.Write(_section[_y, _x] + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        private char Direction()
        {
            //Direction Values
            char[] _directionValues = new char[] { 'N', 'E', 'S', 'W' };
            int _directionChoice = rnd.Next(0, 4);
            newDirection = _directionValues[_directionChoice];
            return newDirection;
        }

        private void HorizontalCorridor()
        {
            for (int _x = 0; _x < 20; _x++)
            {
                _section[5, _x] = '.';
                _section[6, _x] = '.';
            }
        }

        private void UpwardsCorridor()
        {
            for (int _y = 8; _y >= 0; _y--)
            {
                _section[_y, 9] = '.';
                _section[_y, 10] = '.';
            }
        }

        private void EnteranceExit()
        {
            for (int _y = 4; _y < 8; _y++)
            {
                for (int _x = 8; _x < 12; _x++)
                {
                    _section[_y, _x] = '@';
                }
            }
        }

        private void DownwardsCorridor()
        {
            for (int _y = 7; _y < 12; _y++)
            {
                _section[_y, 9] = '.';
                _section[_y, 10] = '.';
            }
        }

        private void PitFall()
        {
            for (int _y = 0; _y < 12; _y++)
            {
                int _randomXStart = rnd.Next(4, 8);
                int _randomXEnd = rnd.Next(12, 16);
                for (int _x = _randomXStart; _x < _randomXEnd; _x++)
                {
                    _section[_y, _x] = '.';
                }
            }
        }

        public void SectionLoader(string _fileName)
        {
            int _xLoad = 0;
            int _yLoad = 0;
            using (StreamReader _reader = new StreamReader(_fileName))
            {
                while (!_reader.EndOfStream)
                {
                    string csvline = _reader.ReadLine();
                    foreach (char value in csvline)
                    {
                        if (value != ' ')
                        {
                            _section[_yLoad, _xLoad] = value;
                            _xLoad++;
                        }
                    }
                    _xLoad = 0;
                    _yLoad++;
                }
                Console.WriteLine();
            }
        }
    }
}
