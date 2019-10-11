using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_Things
{
    public class Tile
    {
        public Guid TileID { get; set;}
        protected int TravelSpeed = 100;

        public Tile()
        {
            this.TileID = Guid.NewGuid();
        }

    }
}
