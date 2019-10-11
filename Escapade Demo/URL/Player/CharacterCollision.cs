using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL.Player
{
    class CharacterCollision : Character
    {

        char _zero = Convert.ToChar(0);


        public bool ItemCollision(char[,] _2DlevelEntity, bool _collision = false)
        {


            if (_2DlevelEntity[_yPlayerPositionMap, _xPlayerPositionMap] == 'B')
            {

                _2DlevelEntity[_yPlayerPositionMap, _xPlayerPositionMap] = _zero;
                Character._bomb++;
                _collision = true;

            }

            else if (_2DlevelEntity[_yPlayerPositionMap, _xPlayerPositionMap] == 'K')
            {

                _2DlevelEntity[_yPlayerPositionMap, _xPlayerPositionMap] = _zero;
                Character._key ++;
                _collision = true;

            }

            else if (_2DlevelEntity[_yPlayerPositionMap, _xPlayerPositionMap] == 'C')
            {

                _2DlevelEntity[_yPlayerPositionMap, _xPlayerPositionMap] = 'Z';
                Character._chest ++;
                MainGame._gameIdle = true;
                _collision = true;

            }

            else if (_2DlevelEntity[_yPlayerPositionMap, _xPlayerPositionMap] == '$')
            {

                _2DlevelEntity[_yPlayerPositionMap, _xPlayerPositionMap] = _zero;
                Character._coin ++;
                _collision = true;

            }

            else if (_2DlevelEntity[_yPlayerPositionMap, _xPlayerPositionMap] == 'S')
            {



            }

            else if (_2DlevelEntity[_yPlayerPositionMap, _xPlayerPositionMap] == 'V')
            {



            }

            return _collision;
        }


        public bool EnemyCollision(char[,] _2DlevelPlayerEnemies, bool _collision)
        {

            if (_2DlevelPlayerEnemies[_yPlayerPositionMap, _xPlayerPositionMap] == 'E')
            {

                _playerHealth--;
                return true;

            }
            else if (_2DlevelPlayerEnemies[_yPlayerPositionMap, _xPlayerPositionMap + 1] == 'E')
            {

                _playerHealth--;
                return true;

            }
            else if (_2DlevelPlayerEnemies[_yPlayerPositionMap, _xPlayerPositionMap - 1] == 'E')
            {

                _playerHealth--;
                return true;
            }
            else if (_2DlevelPlayerEnemies[_yPlayerPositionMap + 1, _xPlayerPositionMap] == 'E')
            {

                _playerHealth--;
                return true;
            }
            else if (_2DlevelPlayerEnemies[_yPlayerPositionMap- 1, _xPlayerPositionMap] == 'E')
            {

                _playerHealth--;
                return true;

            }
            return false;
        }

    }
}
