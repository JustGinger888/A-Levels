using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL.Enemies;
using URL.Player;

namespace URL.BULLET
{
    class BulletShoot : Bullets
    {
        int _yCounterPositionMinus;
        int _yCounterPositionPlus;
        int _xCounterPositionMinus;
        int _xCounterPositionPlus;
        int _yCounterPositionMinusMap;
        int _yCounterPositionPlusMap;
        int _xCounterPositionMinusMap;
        int _xCounterPositionPlusMap;
        int _bulletCounter = 1;
        bool _bulletCollide = true;
        EnemyCollision _enemyCollide = new EnemyCollision();
        public static bool _attack = false;

        /// <summary>
        /// Shootts the bullet in the appropriate direction
        /// </summary>
        /// <param name="_bulletShot"></param>
        /// <param name="_2DlevelEntity"></param>
        /// <param name="_2DlevelMap"></param>
        /// <param name="_keyPressedIsUp"></param>
        /// <param name="_keyPressedIsLeft"></param>
        /// <param name="_keyPressedIsRight"></param>
        /// <param name="_keyPressedIsDown"></param>
        /// <param name="_zero"></param>
        /// <returns></returns>
        public bool BulletShot(bool _bulletShot, char[,] _2DlevelEntity, char[,]_2DlevelMap, bool _keyPressedIsUp, bool _keyPressedIsLeft, bool _keyPressedIsRight, bool _keyPressedIsDown, char _zero)
        {
            _yCounterPositionMinusMap = _yBulletPositionMap - _bulletCounter;
            _yCounterPositionPlusMap = _yBulletPositionMap + _bulletCounter;
            _xCounterPositionMinusMap = _xBulletPositionMap - _bulletCounter;
            _xCounterPositionPlusMap = _xBulletPositionMap + _bulletCounter;
            _yCounterPositionMinus = _yBulletPosition - _bulletCounter;
            _yCounterPositionPlus = _yBulletPosition + _bulletCounter;
            _xCounterPositionMinus = _xBulletPosition - _bulletCounter;
            _xCounterPositionPlus = _xBulletPosition + _bulletCounter;
            if (_bulletCounter <= 3)
            {
                if (_keyPressedIsUp == true)
                {
                    if (_2DlevelMap[_yCounterPositionMinusMap, _xBulletPositionMap] != '.' || _2DlevelEntity[_yCounterPositionMinusMap, _xBulletPositionMap] != _zero)
                    {
                        _bulletCollide = true;
                    }
                    else
                    {
                        _bulletSectionMap[_yCounterPositionMinusMap, _xBulletPositionMap] = 'B';

                        if (_yCounterPositionMinus == -1)
                        {
                            _bulletCollide = true;
                        }
                        else if (_yCounterPositionMinus == 0)
                        {
                            MainGame._pbxGridMain[_yCounterPositionMinus, _xBulletPosition].BackColor = Color.Transparent;
                            _bulletCollide = true;
                        }
                        else
                        {
                            MainGame._pbxGridMain[_yCounterPositionMinus, _xBulletPosition].BackColor = Color.WhiteSmoke;
                        }

                        if (_bulletCounter > 1)
                        {
                            MainGame._pbxGridMain[_yCounterPositionMinus + 1, _xBulletPosition].BackColor = Color.Transparent;
                        }
                    }
                }
                else if (_keyPressedIsRight == true)
                {
                    if (_2DlevelMap[_yBulletPositionMap, _xCounterPositionPlusMap] != '.' || _2DlevelEntity[_yBulletPositionMap, _xCounterPositionPlusMap] != _zero)
                    {
                        _bulletCollide = true;
                    }
                    else
                    {
                        _bulletSectionMap[_yBulletPositionMap, _xCounterPositionPlusMap] = 'B';
                        if (_xCounterPositionPlus >= 22)
                        {
                            _bulletCollide = true;
                        }
                        else if (_xCounterPositionPlus == 21)
                        {                           
                            MainGame._pbxGridMain[_yBulletPosition, _xCounterPositionPlus].BackColor = Color.Transparent;
                            _bulletCollide = true;
                        }
                        else
                        {
                            MainGame._pbxGridMain[_yBulletPosition, _xCounterPositionPlus].BackColor = Color.WhiteSmoke;
                        }
                        if (_bulletCounter > 1)
                        {
                            MainGame._pbxGridMain[_yBulletPosition, _xCounterPositionPlus - 1].BackColor = Color.Transparent;
                        }
                    }
                }
                else if (_keyPressedIsLeft == true)
                {
                    if (_2DlevelMap[_yBulletPositionMap, _xCounterPositionMinusMap] != '.' || _2DlevelEntity[_yBulletPositionMap, _xCounterPositionMinusMap] != _zero)
                    {
                        _bulletCollide = true;
                    }
                    else
                    {
                        _bulletSectionMap[_yBulletPositionMap, _xCounterPositionMinusMap] = 'B';
                        if (_xCounterPositionMinus == -1)
                        {
                            _bulletCollide = true;
                        }
                        else if (_xCounterPositionMinus == 0)
                        {
                            MainGame._pbxGridMain[_yBulletPosition, _xCounterPositionMinus].BackColor = Color.Transparent;
                            _bulletCollide = true;
                        }
                        else
                        {
                            MainGame._pbxGridMain[_yBulletPosition, _xCounterPositionMinus].BackColor = Color.WhiteSmoke;
                        }
                        if (_bulletCounter > 1)
                        {
                            MainGame._pbxGridMain[_yBulletPosition, _xCounterPositionMinus + 1].BackColor = Color.Transparent;
                        }
                    }
                }
                else if (_keyPressedIsDown == true)
                {
                    if (_2DlevelMap[_yCounterPositionPlusMap, _xBulletPositionMap] != '.' || _2DlevelEntity[_yCounterPositionPlusMap, _xBulletPositionMap] != _zero)
                    {
                        _bulletCollide = true;
                    }
                    else
                    {
                        _bulletSectionMap[_yCounterPositionPlusMap, _xBulletPositionMap] = 'B';
                        if (_yCounterPositionPlus == 14)
                        {
                            _bulletCollide = true;
                        }
                        else if (_yCounterPositionPlus == 13)
                        {                           
                            MainGame._pbxGridMain[_yCounterPositionPlus, _xBulletPosition].BackColor = Color.Transparent;
                            _bulletCollide = true;
                        }
                        else
                        {
                            MainGame._pbxGridMain[_yCounterPositionPlus, _xBulletPosition].BackColor = Color.WhiteSmoke;
                        }

                        if (_bulletCounter > 1)
                        {
                            MainGame._pbxGridMain[_yCounterPositionPlus - 1, _xBulletPosition].BackColor = Color.Transparent;
                        }
                    }
                }
                _bulletCounter++;
            }
            else if (_bulletCounter == 4)
            {
                if (_keyPressedIsUp == true)
                {
                    _keyPressedIsUp = false;
                    _attack = false;
                    MainGame._pbxGridMain[_yCounterPositionMinus + 1, _xBulletPosition].BackColor = Color.Transparent;
                }
                else if (_keyPressedIsRight == true)
                {
                    _keyPressedIsRight = false;
                    _attack = false;
                    MainGame._pbxGridMain[_yBulletPosition, _xCounterPositionPlus - 1].BackColor = Color.Transparent;
                }
                else if (_keyPressedIsLeft == true)
                {
                    _keyPressedIsLeft = false;
                    _attack = false;
                    MainGame._pbxGridMain[_yBulletPosition, _xCounterPositionMinus + 1].BackColor = Color.Transparent;
                }
                else if (_keyPressedIsDown == true)
                {
                    _keyPressedIsDown = false;
                    _attack = false;
                    MainGame._pbxGridMain[_yCounterPositionPlus - 1, _xBulletPosition].BackColor = Color.Transparent;
                }
                _bulletCollide = false;
                _bulletCounter = 1;
                MainGame._enemyCollided = _enemyCollide.EnemyCollide();
                Array.Clear(_bulletSectionMap, 0, _bulletSectionMap.Length);
                _bulletShot = true;
            }
            if (_bulletCollide == true)
            {
                if (_keyPressedIsUp == true)
                {
                    _keyPressedIsUp = false;
                    _attack = false;
                    if (_yCounterPositionMinus == -1)
                    {
                    }
                    else if (_yCounterPositionMinus == 0)
                    {
                        MainGame._pbxGridMain[_yCounterPositionMinus + 1, _xBulletPosition].BackColor = Color.Transparent;
                    }
                    else
                    {
                        MainGame._pbxGridMain[_yCounterPositionMinus + 1, _xBulletPosition].BackColor = Color.Transparent;
                    }
                }
                else if (_keyPressedIsRight == true)
                {
                    _keyPressedIsRight = false;
                    _attack = false;
                    if (_xCounterPositionPlus == 22)
                    {
                    }
                    else if (_xCounterPositionPlus == 19)
                    {
                        MainGame._pbxGridMain[_yBulletPosition, _xCounterPositionPlus - 1].BackColor = Color.Transparent;
                    }
                    else
                    {
                        MainGame._pbxGridMain[_yBulletPosition, _xCounterPositionPlus - 1].BackColor = Color.Transparent;
                    }
                }
                else if (_keyPressedIsLeft == true)
                {
                    _keyPressedIsLeft = false;
                    _attack = false;
                    if (_xCounterPositionMinus == -1)
                    {
                    }
                    else if (_xCounterPositionMinus == 0)
                    {
                        MainGame._pbxGridMain[_yBulletPosition, _xCounterPositionMinus + 1].BackColor = Color.Transparent;
                    }
                    else
                    {
                        MainGame._pbxGridMain[_yBulletPosition, _xCounterPositionMinus + 1].BackColor = Color.Transparent;
                    }
                }
                else if (_keyPressedIsDown == true)
                {
                    _keyPressedIsDown = false;
                    _attack = false;
                    if (_yCounterPositionPlus == 14)
                    {
                    }
                    else if (_yCounterPositionPlus == 14)
                    {
                        MainGame._pbxGridMain[_yCounterPositionPlus - 1, _xBulletPosition].BackColor = Color.Transparent;
                    }
                    else
                    {
                        MainGame._pbxGridMain[_yCounterPositionPlus - 1, _xBulletPosition].BackColor = Color.Transparent;
                    }
                }
                MainGame._enemyCollided = _enemyCollide.EnemyCollide();
                Array.Clear(_bulletSectionMap, 0, _bulletSectionMap.Length);
                _bulletCollide = false;
                _bulletCounter = 1;
                _bulletShot = true;
            }
            return _bulletShot;
        }
    }
}