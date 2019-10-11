using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_Things
{
    public class ObjectManager
    {
        private static ObjectManager _singleton = new ObjectManager();

        public static ObjectManager GetObjectManager
        {
            get
            {
                return _singleton;
            }
        }

        public string exampleString { get; set; }

        public List<Tile> Tiles = new List<Tile>();
    }
}
