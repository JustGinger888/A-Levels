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
using System.Windows.Input;
using URL.GRID;
using System.Media;

namespace URL.Player
{
    partial class Character
    {
        public static int _yPlayerPosition = 7;
        public static int _xPlayerPosition = 11;
        public static int _yPlayerPositionMap;
        public static int _xPlayerPositionMap;
        public static int _bomb;
        public static int _key;
        public static int _chest;
        public static int _coin;
        public int interval = 150;
        char _zero = Convert.ToChar(0);
        public static int _playerHealth = 20;

        public int PlayerPositionMapY(int _ySectionPositionMap)
        {
            _yPlayerPositionMap = _ySectionPositionMap + 7;
            return _yPlayerPositionMap;
        }

        public int PlayerPositionMapX(int _xSectionPositionMap)
        {
            _xPlayerPositionMap = _xSectionPositionMap + 11;
            return _xPlayerPositionMap;
        }
    }
}
