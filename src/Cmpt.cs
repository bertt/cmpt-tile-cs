using System.Collections.Generic;

namespace Cmpt.Tile
{
    public class Cmpt
    {
        public CmptHeader CmptHeader { get; set; }

        public List<byte[]> Tiles { get; set; }

        public List<string> Magics { get; set; }
    }
}
