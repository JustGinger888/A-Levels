using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL.PathFinding
{
    class Location
    {
        public int _xPosition;
        public int _yPosition;
        //Aside from the tile coordinates, each visited tile has three scores(F, G and H). 
        //The G score is the distance from the starting point, 
        //H score is the estimated distance from the destination(calculated as the city block distance). 
        //The F score is just G + H.
        public int _pathF;                  
        public int _movementCostG;              
        public int _estimatedMovementCostH;
        public Location Parent;
    }
}
