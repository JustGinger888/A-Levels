using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS
{
    public class Grid
    {

        int _mapYLineLoad = 0;
        int _mapXLineLoad = 0;

        int _gridMaxYSize;
        int _gridMaxXSize;
        int _gridDrawYCo;
        int _gridDrawXCo;
        int _gridSizeYCo;
        int _gridSizeXCo;
        int _gridDrawXCoNewLine;
        int _gridCurrentGridBuilding = 0;
        int _direction;

        PictureBox[,] _GridArrayTemp;
        PictureBox[,] _RoomGrid;
        PictureBox[,] _LayoutGrid;
        char[,] _GridLayout = new char[4, 4];


        private int GridSetup()
        {

            if (_gridCurrentGridBuilding == 0)
            {


                _gridMaxYSize = 11;
                _gridMaxXSize = 21;

                _gridDrawYCo = 156;
                _gridDrawXCo = 270;

                _gridSizeYCo = 28;
                _gridSizeXCo = 28;

                _gridDrawXCoNewLine = 270;

                _gridCurrentGridBuilding++;

                _RoomGrid = new PictureBox[_gridMaxYSize, _gridMaxXSize];

            }

            else if (_gridCurrentGridBuilding == 1)
            {

                _gridMaxYSize = 4;
                _gridMaxXSize = 4;

                _gridDrawYCo = 144;
                _gridDrawXCo = 930;

                _gridSizeYCo = 28;
                _gridSizeXCo = 28;

                _gridDrawXCoNewLine = 930;

                _gridCurrentGridBuilding++;

                _LayoutGrid = new PictureBox[_gridMaxYSize, _gridMaxXSize];

            }

            return _gridCurrentGridBuilding;

        }



        public Grid(Form Form1)
        {
            while (_gridCurrentGridBuilding <= 1)
            {

                GridSetup();

                _GridArrayTemp = new PictureBox[_gridMaxYSize, _gridMaxXSize];

                // Y Axis Generation
                for (int y = 0; y < _gridMaxYSize; y++)
                {
                    // X Axis Generation
                    for (int x = 0; x < _gridMaxXSize; x++)
                    {

                        _GridArrayTemp[y, x] = new PictureBox();
                        _GridArrayTemp[y, x].Location = new System.Drawing.Point(_gridDrawXCo, _gridDrawYCo);
                        _GridArrayTemp[y, x].Size = new System.Drawing.Size(_gridSizeXCo, _gridSizeYCo);
                        _GridArrayTemp[y, x].SizeMode = PictureBoxSizeMode.StretchImage;
                        _GridArrayTemp[y, x].BorderStyle = BorderStyle.Fixed3D;
                        //_GridArrayTemp[y, x].BackColor = Color.DarkBlue;

                        Form1.Controls.Add(_GridArrayTemp[y, x]);
                        _gridDrawXCo += _gridSizeXCo;

                    }

                    _gridDrawXCo = _gridDrawXCoNewLine;
                    _gridDrawYCo += _gridSizeYCo;

                }

            }

            WriteLayout();
            PlayableMapLoader();

        }



        public void LayoutGrid()
        {
            // 0 = Random Room
            // 1 = LEFT & RIGHT Exit
            // 2 = LEFT & RIGHT & BOTTOM Exit
            // 3 = LEFT & RIGHT & TOP Exit
            // 4 = LEFT & RIGHT & TOP & BOTTOM Exit

            char[] _RoomsValues = new char[] { '1', '2', '3' };

            bool _exit = false;
            bool _generate = true;
            int _direction;
            int _roomType;
            int _currentYLine = 0;
            int _currentXLine;

            Random rnd = new Random();

            // Generates the STARTING room in the TOP row
            int _RoomStart = rnd.Next(0, 4);
            _GridLayout[0, _RoomStart] = '8';

            _currentXLine = _RoomStart;

            // Continues making Rooms til the end is reached
            //while (_exit == false)

            // Through uniform distribution the decision is made to either go Left Right or Down
            int _RoomChoice = rnd.Next(1, 6);
            char _newRoom;

            if (_RoomChoice == 1 || _RoomChoice == 2)
            {
                _newRoom = 'L';
            }
            else if (_RoomChoice == 3 || _RoomChoice == 5)
            {
                _newRoom = 'R';
            }
            else
            {
                _newRoom = 'D';
            }

            while (_exit == false)
            {



                //Choosing Direction
                switch (_newRoom)
                {

                    // Room goes DOWN
                    case 'L':
                        // Adds the DOWN value to the Grid Layout Array while making sure that it does not reach the MAX DOWN
                        if (_currentXLine - 1 == _RoomStart)
                        {
                            _newRoom = 'R';
                        }

                        else
                        {

                            if (_currentXLine - 1 == -1)
                            {
                                _newRoom = 'R';
                            }

                            else
                            {
                                _roomType = rnd.Next(0, 2);
                                _currentXLine -= 1;
                                _GridLayout[_currentYLine, _currentXLine] = _RoomsValues[_roomType];
                                _direction = rnd.Next(1, 3);

                                if (_direction == 1)
                                {
                                    _newRoom = 'R';
                                }
                                else
                                {
                                    _newRoom = 'D';
                                }
                            }

                        }
                        break;

                    // Room goes RIGHT
                    case 'R':
                        // Adds the RIGHT value to the Grid Layout Array while making sure that it does not reach the MAX RIGHT
                        if (_currentXLine + 1 == _RoomStart)
                        {
                            _newRoom = 'L';
                        }

                        else
                        {
                            if (_currentXLine + 1 == 4)
                            {
                                _newRoom = 'L';
                            }

                            else
                            {
                                _currentXLine += 1;
                                _roomType = rnd.Next(0, 2);
                                _GridLayout[_currentYLine, _currentXLine] = _RoomsValues[_roomType];
                                _direction = rnd.Next(1, 3);

                                if (_direction == 1)
                                {
                                    _newRoom = 'L';
                                }
                                else
                                {
                                    _newRoom = 'D';
                                }
                            }
                        }
                        break;

                    // Room goes LEFT
                    case 'D':
                        // Adds the LEFT value to the Grid Layout Array while making sure that it does not reach the MAX LEFT
                        _GridLayout[_currentYLine, _currentXLine] = '3';

                        if (_currentYLine + 1 == 4)
                        {
                            _exit = true;
                        }

                        else
                        {
                            _roomType = rnd.Next(0, 2);
                            _currentYLine += 1;
                            _GridLayout[_currentYLine, _currentXLine] = _RoomsValues[_roomType];
                            _direction = rnd.Next(1, 3);
                            if (_roomType == 1)
                            {
                                _GridLayout[_currentYLine, _currentXLine] = '3';

                                int _tempnewRoom = rnd.Next(0, 2);

                                //Left
                                if (_tempnewRoom == 0)
                                {
                                    if (_currentXLine - 1 == -1)
                                    {
                                        _newRoom = 'R';
                                    }

                                    else
                                    {
                                        _newRoom = 'L';
                                    }
                                }

                                //Right
                                if (_tempnewRoom == 1)
                                {
                                    if (_currentXLine + 1 == 4)
                                    {
                                        _newRoom = 'L';
                                    }

                                    else
                                    {
                                        _newRoom = 'R';
                                    }
                                }

                            }
                            else if (_roomType == 2)
                            {
                                _GridLayout[_currentYLine, _currentXLine] = '4';

                                int _tempnewRoom = rnd.Next(0, 2);

                                //Left
                                if (_tempnewRoom == 0)
                                {
                                    if (_currentXLine - 1 == -1)
                                    {
                                        _newRoom = 'R';
                                    }

                                    else
                                    {
                                        _newRoom = 'L';
                                    }
                                }

                                //Right
                                if (_tempnewRoom == 1)
                                {
                                    if (_currentXLine + 1 == 4)
                                    {
                                        _newRoom = 'L';
                                    }

                                    else
                                    {
                                        _newRoom = 'R';
                                    }
                                }
                            }
                        }

                        break;

                }
            }
        }



        public int RandomDirection()
        {
            Random rnd = new Random();
            _direction = rnd.Next(1, 3);
            return _direction;
        }



        public void WriteLayout()
        {

            LayoutGrid();

            //Pass the filepath and filename to the StreamWriter Constructor
            StreamWriter _writer = new StreamWriter("LayoutGrid.txt");


            for (int i = 0; i < _gridMaxYSize; i++)
            {

                for (int j = 0; j < _gridMaxXSize; j++)
                {

                    _writer.Write(_GridLayout[i, j] + ",");

                }

                //this is the code that you change, this will make a new line between each y value in the array
                _writer.Write("\r\n");   // write new line
            }
            //_writer.Write("\r\n");

            _writer.Close();

        }



        public void PlayableMapLoader()
        {

            //PlayableMapWriter();

            using (StreamReader reader = new StreamReader("LayoutGrid.txt"))
            {

                while (!reader.EndOfStream)
                {

                    string csvline = reader.ReadLine();

                    foreach (string value in csvline.Split(','))
                    {

                        //_playerMiniMapPosYco = 3;
                        //playerMiniMapPosXco = 3;

                        if (value == "1")
                        {

                            _GridArrayTemp[_mapYLineLoad, _mapXLineLoad].BackColor = Color.Green;

                        }

                        else if (value == "2")
                        {

                            _GridArrayTemp[_mapYLineLoad, _mapXLineLoad].BackColor = Color.Blue;

                        }

                        else if (value == "3")
                        {

                            _GridArrayTemp[_mapYLineLoad, _mapXLineLoad].BackColor = Color.Black;

                        }

                        else if (value == "4")
                        {

                            _GridArrayTemp[_mapYLineLoad, _mapXLineLoad].BackColor = Color.Red;

                        }

                        else if (value == "8")
                        {

                            _GridArrayTemp[_mapYLineLoad, _mapXLineLoad].BackColor = Color.Yellow;

                        }


                        _mapXLineLoad++;

                    }

                    _mapYLineLoad++;
                    _mapXLineLoad = 0;

                }
            }

        }




    }
}