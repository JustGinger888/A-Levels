using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace URL.Enemies
{
    class EnemyHealthGrid : Enemy
    {
        private int _drawingCo = 0;
        public PictureBox[] AddEnemyHealthGrid(PictureBox[] _enemyHealthGrid)
        {
            Array.Clear(_enemyHealthGrid, 0, 10);
            for (int i = 0; i < _enemyHealth; i++)
            {
                _enemyHealthGrid[i] = new PictureBox
                {
                    Size = new System.Drawing.Size(25, 25),
                    BackColor = Color.Red,
                    Location = new System.Drawing.Point(_drawingCo),
                    BorderStyle = BorderStyle.Fixed3D
            };
                _drawingCo += 25;
            }
            return _enemyHealthGrid;
        }
    }
}
