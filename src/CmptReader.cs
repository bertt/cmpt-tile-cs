using B3dm.Tile;
using System.Collections.Generic;
using System.IO;

namespace Cmpt.Tile
{
    public struct CmptReader
    {
        public static Cmpt Read(Stream stream)
        {
            using (var reader = new BinaryReader(stream))
            {
                var cmpt = new Cmpt();
                var cmptHeader = new CmptHeader(reader);
                cmpt.CmptHeader = cmptHeader;
                cmpt.InstancedTiles = new List<I3dm.Tile.I3dm>();
                cmpt.BatchedTiles = new List<B3dm.Tile.B3dm>();

                for (var i=0;i< cmptHeader.TilesLength; i++)
                {
                    var peekchar = (char)reader.PeekChar();
                    if (peekchar == 'b') {
                        var b3dm = B3dmReader.ReadB3dm(reader);
                        cmpt.BatchedTiles.Add(b3dm);
                    }
                    else if(peekchar == 'i')
                    {
                        var i3dm = I3dm.Tile.I3dmReader.Read(reader);
                        cmpt.InstancedTiles.Add(i3dm);
                    }
                }
                return cmpt;
            }
        }
    }
}