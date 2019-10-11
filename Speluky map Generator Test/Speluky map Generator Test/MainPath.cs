using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speluky_map_Generator_Test
{
    class MainPath : Initialize
    {

        public void CreateMainPath(int[,] _pathArray)
        {
            // SelectStartingRoom


            int[] _roomType = new int[5] { 1, 1, 2, 2, 3 };            // Original Array
            // 1 = left
            // 2 = right
            // 3 = down

            // 7 = PitFall

            // 8 = Enterance
            // 9 = Exit

            int[] _roomTypeLeft = new int[3] { 1, 1, 3 };               // Left array Standard
            int[] _roomTypeLeftStep = new int[4] { 1, 1, 1, 3 };        // Left array favouring left
            int[] _roomTypeRight = new int[3] { 2, 2, 3 };              // Right array Standard
            int[] _roomTypeRightStep = new int[4] { 2, 2, 2, 3 };       // Right array favouring right

            var _currentYPosition = 0;              // Initialize as starting point Y
            var _currentXPosition = rnd.Next(0, 4); // Initialize as starting point X
            var _newDirection = 0;                  // Keep Track of what direction to move
            var _newDirectionRndTemp = 0;           // Temp value for array direction

            _pathArray[_currentYPosition, _currentXPosition] = 8; // RoomType w/ exit Left And Right


            // Generation Loop
            while (_currentYPosition < 4) // Anything after 3 breaks the loop
            {

                // Initial Random Direction
                if (_newDirection == 0)
                {
                    // Normal distribution allows for room to be chosen, favoring left or right
                    _newDirectionRndTemp = rnd.Next(0, 5);
                    _newDirection = _roomType[_newDirectionRndTemp];
                }


                // Move Left if direction = 1
                if (_newDirection == 1)
                {



                    if (_currentXPosition > 0)
                    {
                        _currentXPosition--;
                        _pathArray[_currentYPosition, _currentXPosition] = 1; // set room to one with exits left and right
                        _newDirectionRndTemp = rnd.Next(0, 4);
                        _newDirection = _roomTypeLeftStep[_newDirectionRndTemp];
                    }
                    else
                    {
                        // cant move left, need to move down, current room to a 2 and next room to a 3
                        if (_currentYPosition < 3)
                        {
                            _pathArray[_currentYPosition, _currentXPosition] = 2; // type 2 gives exit on floor

                            _currentYPosition++;
                            _pathArray[_currentYPosition, _currentXPosition] = 3; // type 3 gives exit on roof
                            _newDirection = 2;
                        }
                        else
                        {
                            _pathArray[_currentYPosition, _currentXPosition] = 9;
                            _currentYPosition++; // exit out of loop
                        }
                    }



                }


                // Move right if direction = 2
                else if (_newDirection == 2)
                {



                    if (_currentXPosition < 3)
                    {
                        _currentXPosition++;
                        _pathArray[_currentYPosition, _currentXPosition] = 1;
                        _newDirectionRndTemp = rnd.Next(0, 4);
                        _newDirection = _roomTypeRightStep[_newDirectionRndTemp];
                    }
                    else
                    {
                        // cant move left, need to move down, current room to a 2 and next room to a 3
                        if (_currentYPosition < 3)
                        {
                            _pathArray[_currentYPosition, _currentXPosition] = 2;

                            _currentYPosition++;
                            _pathArray[_currentYPosition, _currentXPosition] = 3;
                            _newDirection = 1;
                        }
                        else
                        {
                            _pathArray[_currentYPosition, _currentXPosition] = 9;
                            _currentYPosition++; // exit out of loop
                        }

                    }



                }

                //Move down if direction = 3
                else if (_newDirection == 3)
                {



                    if (_currentYPosition < 3)
                    {
                        _pathArray[_currentYPosition, _currentXPosition] = 2;

                        _currentYPosition++;
                        _pathArray[_currentYPosition, _currentXPosition] = 3;
                        _newDirection = 0;

                        if (_currentXPosition == 3)
                        {
                            _newDirectionRndTemp = rnd.Next(0, 3);
                            _newDirection = _roomTypeLeft[_newDirectionRndTemp];
                        }
                        else if (_currentXPosition == 0)
                        {
                            _newDirectionRndTemp = rnd.Next(0, 3);
                            _newDirection = _roomTypeRight[_newDirectionRndTemp];
                        }
                    }
                    else
                    {
                        _pathArray[_currentYPosition, _currentXPosition] = 9;
                        _currentYPosition++; // break out of loop
                    }

                }



            }

            StartTop(_pathArray);
            PitFall(_pathArray);
            ShopAdd(_pathArray);
            ItemRoomAdd(_pathArray);

        }


        public void StartTop(int[,] _pathArray)
        {
            var _topCount = 0;
            var _topEnterance = 0;
            for (int _top = 0; _top < 4; _top++)
            {
                if (_pathArray[0, _top] == 0)
                {
                    _topCount++;
                }
                else
                {
                    _topEnterance = _top;
                }
            }

            if (_topCount == 3)
            {
                _pathArray[0, _topEnterance] = 8;
            }

        }


        public void PitFall(int[,] _pathArray)
        {
            bool _pitFall = false;

            int[] _collum1 = new int[4];
            int[] _collum2 = new int[4];
            int[] _collum3 = new int[4];
            int[] _collum4 = new int[4];

            int _pitCount = 0;

            for (int _x = 0; _x < 4; _x++)
            {
                for (int _y = 0; _y < 4; _y++)
                {
                    if (_x == 0)
                    {
                        _collum1[_y] = _pathArray[_y, _x];
                    }

                    else if (_x == 1)
                    {
                        _collum2[_y] = _pathArray[_y, _x];
                    }

                    else if (_x == 2)
                    {
                        _collum3[_y] = _pathArray[_y, _x];
                    }

                    else if (_x == 3)
                    {
                        _collum4[_y] = _pathArray[_y, _x];
                    }
                }
            }

            for (int j = 0; j < 4; j++)
            {
                if (j == 0)
                {
                    _pitCount = CollumCount(_collum1);
                    if (_pitCount >= 3)
                    {
                        AmmendCollum(0, _collum1, _pathArray);
                    }
                }

                else if (j == 1)
                {
                    _pitCount = CollumCount(_collum2);
                    if (_pitCount >= 3)
                    {
                        AmmendCollum(1, _collum2, _pathArray);
                    }
                }

                else if (j == 2)
                {
                    _pitCount = CollumCount(_collum3);
                    if (_pitCount >= 3)
                    {
                        AmmendCollum(2, _collum3, _pathArray);
                    }
                }

                else if (j == 3)
                {
                    _pitCount = CollumCount(_collum4);
                    if (_pitCount >= 3)
                    {
                        AmmendCollum(3, _collum4, _pathArray);
                    }
                }

            }

        }


        public void AmmendCollum(int _x, int[] _collum, int[,] _pathArray)
        {

            for (int _y = 0; _y < 4; _y++)
            {

                _pathArray[_y, _x] = _collum[_y];

            }

        }


        public int[] PitCheck(int[] _collum)
        {
            //_pitFall = true;
            char[] _willbePit = new char[10] { 'P', 'P', 'P', 'Z', 'Z', 'Z', 'Z', 'Z', 'Z', 'Z' };

            char _tmp = _willbePit[rnd.Next(0, 10)];
            if (_tmp == 'P')
            {
                for (int i = 0; i < 4; i++)
                {
                    if (_collum[i] == 0)
                    {
                        _collum[i] = 7;
                    }
                }
            }

            return _collum;

        }


        public int CollumCount(int[] _collum)
        {
            int _zeroCount = 0;

            for (int i = 0; i < 4; i++)
            {
                if (_collum[i] == 0)
                {
                    _zeroCount++;

                    if (_zeroCount == 4)
                    {
                        PitCheck(_collum);
                    }

                    else if (_zeroCount == 3 && i == 3)
                    {
                        PitCheck(_collum);
                    }
                }
                else
                {
                    _zeroCount = 0;
                }
            }

            return _zeroCount;
        }


        public void ShopAdd(int[,] _pathArray)
        {
            bool _shopAdded = false;

            while (_shopAdded == false)
            {
                int _randomY = rnd.Next(0, 4);
                int _randomX = rnd.Next(0, 4);
                if (_pathArray[_randomY, _randomX] == 0 || _pathArray[_randomY, _randomX] != 8 || _pathArray[_randomY, _randomX] != 9)
                {
                    _pathArray[_randomY, _randomX] = 5;
                    _shopAdded = true;
                }
            }
        }


        public void ItemRoomAdd(int[,] _pathArray)
        {
            bool _itemRoomAdded = false;

            while (_itemRoomAdded == false)
            {
                int _randomY = rnd.Next(0, 4);
                int _randomX = rnd.Next(0, 4);
                if (_pathArray[_randomY, _randomX] != 5 || _pathArray[_randomY, _randomX] != 8 || _pathArray[_randomY, _randomX] != 9)
                {
                    _pathArray[_randomY, _randomX] = 6;
                    _itemRoomAdded = true;
                }
            }
        }


        public void PrintGrid()
        {
            for (int i = 0; i < 4; i++)
            {

                for (int j = 0; j < 4; j++)
                {
                    Console.Write(_pathArray[i, j] + " ");
                }

                Console.WriteLine("");
            }

            Console.ReadKey();
        }

    }
}