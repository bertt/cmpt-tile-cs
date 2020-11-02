using System;
using System.Collections.Generic;

namespace Cmpt.Tile
{
    public class Cmpt
    {
        public CmptHeader CmptHeader { get; set; }

        public List<I3dm.Tile.I3dm> InstancedTiles { get; set; }
        public List<B3dm.Tile.B3dm> BatchedTiles { get; set; }


    }
}
