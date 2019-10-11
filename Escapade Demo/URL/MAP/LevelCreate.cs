using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL.MAP
{
    class LevelCreate : InitializeMap
    {
        public void TmpTextMapWrite()
        {
            for (int _y = 0; _y < 12; _y++)
            {
                _lvlMapX = _lvlMapXCheck;
                for (int _x = 0; _x < 20; _x++)
                {
                    _tmpLevelMap[_lvlMapY, _lvlMapX] = _tmpSection[_y, _x];
                    _lvlMapX++;
                }
                _lvlMapY++;
            }
            if (_count < 3)
            {
                _lvlMapXCheck += 20;
                _lvlMapY = _lvlMapYCheck;
                _count++;
            }
            else if (_count == 3)
            {
                _lvlMapYCheck += 12;
                _lvlMapY = _lvlMapYCheck;
                _lvlMapX = 0;
                _lvlMapXCheck = 0;
                _count = 0;
            }
        }

        public void TmpSectionsMapWrite(int _z)
        {
            for (int _y = 0; _y < 12; _y++)
            {
                for (int _x = 0; _x < 20; _x++)
                {
                    _tmpLevelMapSections[_z, _y, _x] = _tmpSection[_y, _x];
                }
            }
        }

        public void SectionAdd(int[,] _pathArray, int _z = 0)
        {
            Sections sections = new Sections();
            for (int _y = 0; _y < 4; _y++)
            {
                for (int _x = 0; _x < 4; _x++)
                {
                    if (_pathArray[_y, _x] == 0)
                    {
                        _tmpSection = sections.CreateSectionFill();
                        TmpTextMapWrite();
                        TmpSectionsMapWrite(_z);
                    }
                    else if (_pathArray[_y, _x] == 1)
                    {
                        _tmpSection = sections.CreateSection1LeftRight();
                        TmpTextMapWrite();
                        TmpSectionsMapWrite(_z);
                    }
                    else if (_pathArray[_y, _x] == 2)
                    {
                        _tmpSection = sections.CreateSection2LeftRightDown();
                        TmpTextMapWrite();
                        TmpSectionsMapWrite(_z);
                    }
                    else if (_pathArray[_y, _x] == 3)
                    {
                        _tmpSection = sections.CreateSection3LeftRightUp();
                        TmpTextMapWrite();
                        TmpSectionsMapWrite(_z);
                    }
                    else if (_pathArray[_y, _x] == 5)
                    {
                        _tmpSection = sections.CreateSection5Shop();
                        TmpTextMapWrite();
                        TmpSectionsMapWrite(_z);
                    }
                    else if (_pathArray[_y, _x] == 6)
                    {
                        _tmpSection = sections.CreateSection6Item();
                        TmpTextMapWrite();
                        TmpSectionsMapWrite(_z);
                    }
                    else if (_pathArray[_y, _x] == 7)
                    {
                        _tmpSection = sections.CreateSection7Pit();
                        TmpTextMapWrite();
                        TmpSectionsMapWrite(_z);
                    }
                    else if (_pathArray[_y, _x] == 8)
                    {
                        _tmpSection = sections.CreateSectionEntrance();
                        TmpTextMapWrite();
                        TmpSectionsMapWrite(_z);
                    }
                    else if (_pathArray[_y, _x] == 9)
                    {
                        _tmpSection = sections.CreateSectionExit();
                        TmpTextMapWrite();
                        TmpSectionsMapWrite(_z);
                    }
                    _z++;
                }
            }
        }

        public char[,] TextMapWrite(char[,] _levelMapText)
        {
            for (int _y = 0; _y < 48; _y++)
            {
                for (int _x = 0; _x < 80; _x++)
                {
                    _levelMapText[_y, _x] = _tmpLevelMap[_y, _x];
                }
            }
            return _levelMapText;
        }

        public char[,,] ThreeDimensionalMapWrite(char[,,] _levelMapSections)
        {
            for (int _z = 0; _z < 16; _z++)
            {
                for (int _y = 0; _y < 12; _y++)
                {
                    for (int _x = 0; _x < 20; _x++)
                    {
                        _levelMapSections[_z, _y, _x] = _tmpLevelMapSections[_z, _y, _x];
                    }
                }
            }
            return _levelMapSections;
        }
    }
}
