using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL.Enemies
{
    class Enemy
    {
        public static int _yEnemyPositionMap= 0;
        public static int _xEnemyPositionMap = 0;
        public static int _yEnemyPosition = 0;
        public static int _xEnemyPosition = 0;
        public static int _yEnemyMiniMapPosition = 0;
        public static int _xEnemyMiniMapPosition = 0;
        public int interval = 100;
        char _zero = Convert.ToChar(0);
        Random rnd = new Random();
        public static int _enemyHealth = 10;
        public void InitializeEnemy(char[,] map)
        {
            var _y = rnd.Next(1, 50);
            var _x = rnd.Next(1, 82);
            while (map[_y,_x] != '.')
            {
                 _y = rnd.Next(1, 50);
                 _x = rnd.Next(1, 82);
            }
            if (map[_y, _x] == '.')
            {
                _yEnemyPosition = _y;
                _xEnemyPosition = _x;
            }
        }

        public int EnemyPositionMapY(int _yEnemyPositionMap)
        {
            _yEnemyPositionMap = _yEnemyPosition;
            return _yEnemyPositionMap;
        }

        public int EnemyPositionMapX(int _xEnemyPositionMap)
        {
            _xEnemyPositionMap = _xEnemyPosition;
            return _xEnemyPositionMap;
        }

        public char[,] AStarPathMapWriter(char[,] _2DlevelMap, char[,] _AStarMap, char[,] _2DlevelEntity, char[,] _2DlevelPlayerEnemies, char[,] _2DlevelPlayer)
        {
            for (int _y = 0; _y < 50; _y++)
            {
                for (int _x = 0; _x < 82; _x++)
                {
                    if (_2DlevelMap[_y, _x] == '#' || _2DlevelMap[_y, _x] == _zero)
                    {
                        _AStarMap[_y, _x] = '#';
                    }
                    else
                    {
                        if (_2DlevelEntity[_y, _x] != _zero)
                        {
                            _AStarMap[_y, _x] = '#';
                        }
                        else
                        {
                            if (_2DlevelPlayerEnemies[_y, _x] == 'E')
                            {
                                _AStarMap[_y, _x] = _2DlevelPlayerEnemies[_y, _x];
                            }
                            else if (_2DlevelPlayer[_y, _x] == 'P')
                            {
                                _AStarMap[_y, _x] = _2DlevelPlayer[_y, _x];
                            }
                            else
                            {
                                _AStarMap[_y, _x] = ' ';
                            }
                        }
                    }
                }
            }
            return _AStarMap;
        }
    }
}
