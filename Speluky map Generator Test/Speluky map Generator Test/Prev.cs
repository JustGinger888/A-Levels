using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speluky_map_Generator_Test
{
    class Prev
    {
        public void Previous(){

        bool _endingRoom = false;
        bool _randomDIrection = true;
        bool _leftRoomAdded = true;
        bool _rightRoomAdded = true;
        bool _downRoomAdded = true;
        bool _leftEdgeHit = false;
        bool _rightEdgeHit = false;

        char _caseSwitch = ' ';

        int _currentRoomYLocation = 0;
        int _roomDown = 1;
        int _randomRoomCount = 0;

        // Gameboard
        int[,] grid = new int[4, 4];

        //Starting Room Loaction
        Random rnd = new Random();
        int _stratingRoomLocation = rnd.Next(0, 4);

        Console.WriteLine("Location 0-"+_stratingRoomLocation);
            
            //Choose Starting Room Type
            int _startingRoomType = rnd.Next(8, 10);

        Console.WriteLine("Room Type = "+_startingRoomType);

            //Startin Room Location As Starting Room Type
            grid[0, _stratingRoomLocation] = _startingRoomType;

            //XLocation As Starting Room Location
            int _currentRoomXLocation = _stratingRoomLocation;

            do
            {

                //Room Direction through NOrmal distribution
                int _RoomDirection = rnd.Next(1, 6);

               
                

                if (_randomDIrection == true)
                {

                    if ((_RoomDirection == 1 || _RoomDirection == 2) && _leftRoomAdded == true)
                    {
                        _caseSwitch = 'L';
                        _rightRoomAdded = false;

                    }
                
            
                    if ((_RoomDirection == 3 || _RoomDirection == 4) && _rightRoomAdded == true)
                    {
                        _caseSwitch = 'R';
                        _leftRoomAdded = false;

                    }

                    if (_RoomDirection == 5 && _downRoomAdded == true)
                    {
                        _caseSwitch = 'D';
                        _rightRoomAdded = false;
                        _leftRoomAdded = false;
                    }

                    

                }

                switch (_caseSwitch)
                {
                    case 'L':


                        _currentRoomXLocation -= 1;
                        _leftRoomAdded = true;
                        _randomDIrection = true;

                        if (_currentRoomXLocation == -1 )
                        {
                            _currentRoomXLocation += 1;
                            _randomDIrection = false;
                            _leftEdgeHit = true;
                            _caseSwitch = 'D';
                            break;
                        }

                        grid[_currentRoomYLocation, _currentRoomXLocation] = 1;
                        break;



                    case 'R':


                        _currentRoomXLocation += 1;
                        _rightRoomAdded = true;
                        _randomDIrection = true;

                        if (_currentRoomXLocation == 4)
                        {
                            _currentRoomXLocation -= 1;
                            _randomDIrection = false;
                            _rightEdgeHit = true;
                            _caseSwitch = 'D';
                            break;
                        }

                        grid[_currentRoomYLocation, _currentRoomXLocation] = 1;
                        break;



                    case 'D':

                        grid[_currentRoomYLocation, _currentRoomXLocation] = 2;
                        _currentRoomYLocation += 1;
                        _roomDown++;



                        if (_leftEdgeHit == true)
                        {
                            _caseSwitch = 'R';
                            _rightEdgeHit = false;
                            _randomDIrection = false;
                        }

                        else if (_rightEdgeHit == true)
                        {
                            _caseSwitch = 'L';
                            _leftEdgeHit = false;
                            _randomDIrection = false;
                        }

                        if (_roomDown == 5)
                        {
                            _endingRoom = true;
                        }
                        

                        break;
                }


            } while (_endingRoom == false);

            for (int i = 0; i< 4; i++)
            {

                

                for (int j = 0; j< 4; j++)
                {
                    Console.Write(grid[i, j]);
                }

                Console.WriteLine("");
            }

            Console.ReadKey();
        }

    }
}
