using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace URL.Player
{
    class CharacterHealthGrid : Character
    {


        private int _drawingCo = 0;

        public PictureBox[] AddCharacterHealthGrid(PictureBox[] _playerHealthGrid)
        {
            Array.Clear(_playerHealthGrid, 0, 10);

            for (int i = 0; i < _playerHealth; i++)
            {
                _playerHealthGrid[i] = new PictureBox
                {

                    Size = new System.Drawing.Size(25, 25),
                    BackColor = Color.DeepSkyBlue,
                    Location = new System.Drawing.Point(_drawingCo),
                    BorderStyle = BorderStyle.Fixed3D

            };
                _drawingCo += 25;
            }

            return _playerHealthGrid;
        }

    }
}


