///
/// Path Finder - An Implementation of the A* Algorithm for a 2D grid space.
/// 
/// (c) 24th November 2018 Kane Lean (Poole High School)
/// Code provided under GNUv3 Licensing. 
/// 

using System.Drawing;
using System.Windows.Forms;

namespace PathFinder
{
    public class GridSpace : PictureBox
    {
        public const int GRID_SPACE_WIDTH = 20;
        public const int GRID_SPACE_HEIGHT = 20;

        // Used for the A* Implementation
        public int FromWeighting { get; set; }
        public int ToWeighting { get; set;}
        public int SumWeight { get; set; }

        public int GridX { get; set; }
        public int GridY { get; set; }
        public GridSpace ParentSpace { get; set; } // A pointer to the previous chain item (A*)

        /// <summary>
        /// Setup the default sizes of each GRID square
        /// </summary>
        public GridSpace()
        {
            this.Width = GRID_SPACE_WIDTH;
            this.Height = GRID_SPACE_HEIGHT;
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        public void SelectSpace()
        {
            this.BorderStyle = BorderStyle.Fixed3D;
        }

        public void DeselectSpace()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        public void ResetSpace()
        {
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        public void HighlightSpace()
        {
            this.BackColor = Color.Yellow;
            this.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
