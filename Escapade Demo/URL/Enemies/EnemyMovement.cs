using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL.PathFinding;

namespace URL.Enemies
{
    class EnemyMovement : Enemy
    {
        /// <summary>
        /// Moves The enemy according to A* Path
        /// </summary>
        /// <param name="_2DlevelEnemies"></param>
        /// <param name="_yPlayerMiniMapPosition"></param>
        /// <param name="_xPlayerMiniMapPosition"></param>
        /// <param name="_ySectionPositionMap"></param>
        /// <param name="_xSectionPositionMap"></param>
        public void EnemyMove(char[,] _2DlevelEnemies, int _yPlayerMiniMapPosition, int _xPlayerMiniMapPosition, int _ySectionPositionMap, int _xSectionPositionMap)
        {
            if (AStar.map[_yEnemyPositionMap - 1, _xEnemyPositionMap] == '*')
            {
                _2DlevelEnemies[_yEnemyPositionMap, _xEnemyPositionMap] = ' ';
                EnemyTransparent(_yPlayerMiniMapPosition, _xPlayerMiniMapPosition, _ySectionPositionMap, _xSectionPositionMap);
                _yEnemyPositionMap--;
            }
            else if (AStar.map[_yEnemyPositionMap + 1, _xEnemyPositionMap] == '*')
            {
                _2DlevelEnemies[_yEnemyPositionMap, _xEnemyPositionMap] = ' ';
                EnemyTransparent(_yPlayerMiniMapPosition, _xPlayerMiniMapPosition, _ySectionPositionMap, _xSectionPositionMap);
                _yEnemyPositionMap++;
            }
            else if (AStar.map[_yEnemyPositionMap, _xEnemyPositionMap - 1] == '*')
            {
                _2DlevelEnemies[_yEnemyPositionMap, _xEnemyPositionMap] = ' ';
                EnemyTransparent(_yPlayerMiniMapPosition, _xPlayerMiniMapPosition, _ySectionPositionMap, _xSectionPositionMap);
                _xEnemyPositionMap--;
            }
            else if (AStar.map[_yEnemyPositionMap, _xEnemyPositionMap + 1] == '*')
            {
                _2DlevelEnemies[_yEnemyPositionMap, _xEnemyPositionMap] = ' ';
                EnemyTransparent(_yPlayerMiniMapPosition, _xPlayerMiniMapPosition, _ySectionPositionMap, _xSectionPositionMap);
                _xEnemyPositionMap++;
            }
            EnemyLoad(_yPlayerMiniMapPosition, _xPlayerMiniMapPosition, _ySectionPositionMap, _xSectionPositionMap);
        }

        /// <summary>
        /// Makes Enemy previous position transparent on display
        /// </summary>
        /// <param name="_yPlayerMiniMapPosition"></param>
        /// <param name="_xPlayerMiniMapPosition"></param>
        /// <param name="_ySectionPositionMap"></param>
        /// <param name="_xSectionPositionMap"></param>
        public void EnemyTransparent(int _yPlayerMiniMapPosition, int _xPlayerMiniMapPosition, int _ySectionPositionMap, int _xSectionPositionMap)
        {
            EnemySectionSwitch();
            if (_yEnemyMiniMapPosition == _yPlayerMiniMapPosition && _xEnemyMiniMapPosition == _xPlayerMiniMapPosition)
            {
                MainGame._pbxGridMain[_yEnemyPositionMap - _ySectionPositionMap, _xEnemyPositionMap - _xSectionPositionMap].BackColor = Color.Transparent;
            }
        }

        /// <summary>
        /// Switchis the section eenemy is in for display
        /// </summary>
        public void EnemySectionSwitch()
        {
            if (_yEnemyPositionMap < 13)
            {
                _yEnemyMiniMapPosition = 0;
            }
            else if (_yEnemyPositionMap < 25)
            {
                _yEnemyMiniMapPosition = 1;
            }
            else if (_yEnemyPositionMap < 37)
            {
                _yEnemyMiniMapPosition = 2;
            }
            else if (_yEnemyPositionMap < 50)
            {
                _yEnemyMiniMapPosition = 3;
            }

            if (_xEnemyPositionMap < 21)
            {
                _xEnemyMiniMapPosition = 0;
            }
            else if (_xEnemyPositionMap < 41)
            {
                _xEnemyMiniMapPosition = 1;
            }
            else if (_xEnemyPositionMap < 61)
            {
                _xEnemyMiniMapPosition = 2;
            }
            else if (_xEnemyPositionMap < 82)
            {
                _xEnemyMiniMapPosition = 3;
            }
            MainGame._pbxGridMini[_yEnemyMiniMapPosition, _xEnemyMiniMapPosition].BackColor = Color.DarkOrchid;
        }

        /// <summary>
        /// Load the enemy into the display
        /// </summary>
        /// <param name="_yPlayerMiniMapPosition"></param>
        /// <param name="_xPlayerMiniMapPosition"></param>
        /// <param name="_ySectionPositionMap"></param>
        /// <param name="_xSectionPositionMap"></param>
        public void EnemyLoad(int _yPlayerMiniMapPosition, int _xPlayerMiniMapPosition, int _ySectionPositionMap, int _xSectionPositionMap)
        {
            EnemySectionSwitch();
            if (_yEnemyMiniMapPosition == _yPlayerMiniMapPosition && _xEnemyMiniMapPosition == _xPlayerMiniMapPosition)
            {
                MainGame._pbxGridMain[Enemy._yEnemyPositionMap - _ySectionPositionMap, Enemy._xEnemyPositionMap - _xSectionPositionMap].BackColor = Color.Red;
            }
        }
    }
}
