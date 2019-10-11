using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL.MAP
{
    class Populate
    {
        public void PopulateItems(char[,] _section)
        {
            char[] _items = new char[] { 'K', 'B', 'C', '$', '$', '$', '$', '$', '$', '$', '$', '$', '$', '$', '$', '$', '$', '$', '$', '$' };
            // K_ey
            // B_omb
            // C_hest
            int _percentageFill = 0;
            double _tileFill = 0;
            double _sectionSize = CountWalkableTiles(_section);
            Random _rnd = new Random();
            int _randomItem = 0;
            int _randomY = 0;
            int _randomX = 0;
            while (_percentageFill < 5)
            {
                // Calculating Fill Percentage
                _percentageFill = (int)Math.Round((double)(_tileFill / _sectionSize) * 100);
                _randomItem = _rnd.Next(0, 20);
                _randomY = _rnd.Next(0, 12);
                _randomX = _rnd.Next(0, 20);
                if (_section[_randomY, _randomX] == '.')
                {
                    _section[_randomY, _randomX] = _items[_randomItem];
                    _tileFill++;
                }
            }
        }

        private int CountWalkableTiles(char[,] _section)
        {
            int _walkableTiles = 0;

            for (int _y = 0; _y < 12; _y++)
            {
                for (int _x = 0; _x < 20; _x++)
                {
                    if (_section[_y, _x] == '.')
                    {
                        _walkableTiles++;
                    }
                }
            }
            return _walkableTiles;
        }
    }
}
