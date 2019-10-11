using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using URL.ENTITY;

namespace URL.GRID
{
    class LoadGrid
    {        
        public int _ySection;
        public int _xSection;
        public int _yAddSection;
        public int _xAddSection;
        public int _yPosition;
        public int _xPosition;
        public int _yStarting;
        public int _xStarting;
        Item item = new Item();

        public void InitializeSectionMap(char[,] _2DLevelEntity, int[,] _levelPath, char[,] _2DlevelMap, PictureBox[,] _pbxGridMain, PictureBox[,] _pbxGridMini, int _yMiniMapPosition, int _xMiniMapPosition, int _ySectionPositionMap, int _xSectionPositionMap)
        {
            _yPosition = _yMiniMapPosition;
            _xPosition = _xMiniMapPosition;
            _ySection = _ySectionPositionMap;
            _xSection = _xSectionPositionMap;
            LoadMiniGrid(_levelPath, _pbxGridMini);          
            LoadMainGrid(_2DLevelEntity, _2DlevelMap, _pbxGridMain);           
        }

        public int AddMiniMapY(int _yMiniMapPosition)
        {
            _yMiniMapPosition = _yStarting;
            return _yMiniMapPosition;
        }

        public int AddMiniMapX(int _xMiniMapPosition)
        {
            _xMiniMapPosition = _xStarting;
            return _xMiniMapPosition;
        }

        public int AddMiniSectionY(int _ySectionPositionMap)
        {
            _ySectionPositionMap = _yAddSection;
            return _ySectionPositionMap;
        }

        public int AddMiniSectionX(int _xSectionPositionMap)
        {
            _xSectionPositionMap = _xAddSection;
            return _xSectionPositionMap;
        }

        public void LoadMainGrid(char[,] _2DLevelEntity, char[,] _2DlevelMap, PictureBox[,] _pbxGridMain)
        {
            int _yGrid = 0;
            int _xGrid = 0;
            AddCorrectPathSection();
            // Y Axis Generation
            for (int _y = _ySection ; _y < 14 + _ySection; _y++)
            {
                // X Axis Generation
                for (int _x = _xSection ; _x < 22 + _xSection; _x++)
                {
                    AddSectionValue(_y, _x, _yGrid, _xGrid, _2DlevelMap, _2DLevelEntity, _pbxGridMain);
                    _xGrid++;
                }
                _xGrid = 0;
                _yGrid++;
            }
        }

        public void AddSectionValue(int _y, int _x, int _yGrid, int _xGrid, char[,] _2DlevelMap, char[,] _2DLevelEntity, PictureBox[,] _pbxGridMain)
        {
            AddCorrectPathSection();
            char _zero = Convert.ToChar(0);
            if (_2DlevelMap[_y, _x] == '#' || _2DlevelMap[_y, _x] == _zero)
            {
                // add custom x , y
                _pbxGridMain[_yGrid, _xGrid].BackColor = Color.Brown;
            }
            else if (_2DlevelMap[_y, _x] == '@')
            {
                _pbxGridMain[_yGrid, _xGrid].BackColor = Color.Black;
            }
            else if (_2DLevelEntity[_y, _x] == 'K')
            {
                _pbxGridMain[_yGrid, _xGrid].BackColor = Color.LimeGreen;
            }
            else if (_2DLevelEntity[_y, _x] == 'C')
            {
                _pbxGridMain[_yGrid, _xGrid].BackColor = Color.Indigo;
            }
            else if (_2DLevelEntity[_y, _x] == 'B')
            {
                _pbxGridMain[_yGrid, _xGrid].BackColor = Color.HotPink;
            }
            else if (_2DLevelEntity[_y, _x] == '$')
            {
                _pbxGridMain[_yGrid, _xGrid].BackColor = Color.Gold;
            }
            else if (_2DLevelEntity[_y, _x] == 'S')
            {
                _pbxGridMain[_yGrid, _xGrid].BackColor = Color.SpringGreen;
            }
            else if (_2DLevelEntity[_y, _x] == 'V')
            {
                _pbxGridMain[_yGrid, _xGrid].BackColor = Color.Sienna;
            }
            else if (_2DlevelMap[_y, _x] == '.')
            {
                _pbxGridMain[_yGrid, _xGrid].BackColor = Color.Transparent;
            }
        }

        public void LoadMiniGrid(int[,] _levelPath, PictureBox[,] _pbxGridMini)
        {
            // Y Axis Generation
            for (int _y = 0; _y < 4; _y++)
            {
                // X Axis Generation
                for (int _x = 0; _x < 4; _x++)
                {
                    AddPathValue(_y, _x, _levelPath, _pbxGridMini);
                }
            }
        }

        public void AddPathValue(int _y, int _x, int[,] _levelPath, PictureBox[,] _pbxGridMini)
        {
            // 1 = left
            // 2 = right
            // 3 = down
            // 5 = shop
            // 6 = ItemRoom
            // 7 = PitFall
            // 8 = Enterance
            // 9 = Exit

            if (_levelPath[_y, _x] == 0)
            {
                _pbxGridMini[_y, _x].BackColor = Color.White;
            }
            else if (_levelPath[_y, _x] == 1)
            {
                _pbxGridMini[_y, _x].BackColor = Color.Aqua;
            }
            else if (_levelPath[_y, _x] == 2)
            {
                _pbxGridMini[_y, _x].BackColor = Color.Aqua;
            }
            else if (_levelPath[_y, _x] == 3)
            {
                _pbxGridMini[_y, _x].BackColor = Color.Aqua;
            }
            else if (_levelPath[_y, _x] == 5)
            {
                _pbxGridMini[_y, _x].BackColor = Color.Gold;
            }
            else if (_levelPath[_y, _x] == 6)
            {
                _pbxGridMini[_y, _x].BackColor = Color.Gold;
            }
            else if (_levelPath[_y, _x] == 7)
            {
                _pbxGridMini[_y, _x].BackColor = Color.HotPink;
            }
            else if (_levelPath[_y, _x] == 8)
            {
                _pbxGridMini[_y, _x].BackColor = Color.Green;
                    PlayerMiniMapPos(_y, _x);                
            }
            else if (_levelPath[_y, _x] == 9)
            {
                _pbxGridMini[_y, _x].BackColor = Color.Red;
            }
        }

        public void AddCorrectPathSection()
        {
            if (_yPosition == 0)
            {
                _ySection = 0;
                _yAddSection = _ySection;
            }
            else if (_yPosition == 1)
            {                
                _ySection = _yPosition * 14 - 2;
                _yAddSection = _ySection;
            }
            else if (_yPosition == 2)
            {
                _ySection = _yPosition * 14 - 4;
                _yAddSection = _ySection;
            }
            else if (_yPosition == 3)
            {
                _ySection = _yPosition * 14 - 6;
                _yAddSection = _ySection;
            }
            if (_xPosition == 0)
            {
                _xSection = 0;
                _xAddSection = _xSection;
            }
            else if (_xPosition == 1)
            {
                _xSection = _xPosition * 22 - 2;
                _xAddSection = _xSection;
            }

            else if (_xPosition == 2)
            {
                _xSection = _xPosition * 22 - 4;
                _xAddSection = _xSection;
            }

            else if (_xPosition == 3)
            {
                _xSection = _xPosition * 22 - 6;
                _xAddSection = _xSection;
            }
        }

        public void PlayerMiniMapPos(int _yInput, int _xInput)
        {
            _yStarting = _yInput;
            _xStarting = _xInput;
        }

        public char[,] LoadEntityGrid(char[,] _2DlevelEntity, char[,] _2Dlevel)
        {
            for (int _y = 0; _y < 50; _y++)
            {
                for (int _x = 0; _x < 82; _x++)
                {
                    if (_2Dlevel[_y,_x] == '@')
                    {
                        _2Dlevel[_y, _x] = '@';
                    }
                    else if (_2Dlevel[_y, _x] == 'B')
                    {
                        _2Dlevel[_y, _x] = '.';
                        _2DlevelEntity[_y, _x] = item.AddItemBomb(); ;
                    }
                    else if (_2Dlevel[_y, _x] == 'K')
                    {
                        _2Dlevel[_y, _x] = '.';
                        _2DlevelEntity[_y, _x] = item.AddItemKey();
                    }
                    else if (_2Dlevel[_y, _x] == 'C')
                    {
                        _2Dlevel[_y, _x] = '.';
                        _2DlevelEntity[_y, _x] = item.AddItemChest();
                    }
                    else if (_2Dlevel[_y, _x] == '$')
                    {
                        _2Dlevel[_y, _x] = '.';
                        _2DlevelEntity[_y, _x] = item.AddItemCoin();
                    }
                    else if (_2Dlevel[_y, _x] == 'S')
                    {
                        _2Dlevel[_y, _x] = '.';
                        _2DlevelEntity[_y, _x] = item.AddItemSpecial();
                    }
                    else if (_2Dlevel[_y, _x] == 'V')
                    {
                        _2Dlevel[_y, _x] = '.';
                        _2DlevelEntity[_y, _x] = item.AddItemBuyable();
                    }
                }
            }
            return _2DlevelEntity;
        }
    }
}
