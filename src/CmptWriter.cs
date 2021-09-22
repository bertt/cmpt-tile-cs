using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cmpt.Tile
{
    public struct CmptWriter
    {
        public static byte[] Write(IEnumerable<byte[]> tiles)
        {
            var stream = new MemoryStream();
            var binaryWriter = new BinaryWriter(stream);

            var header = new CmptHeader();
            header.TilesLength = tiles.Count();

            var paddedTiles = new List<byte[]>();
            foreach (var tile in tiles)
            {
                var tilePadded = BufferPadding.AddPadding(tile);
                paddedTiles.Add(tilePadded);
            }

            header.ByteLength = 16 + paddedTiles.Sum(i => i.Length);
            var headerBytes = header.AsBinary();

            binaryWriter.Write(headerBytes);

            foreach (var paddedTile in paddedTiles)
            {
                binaryWriter.Write(paddedTile);
            }

            binaryWriter.Flush();
            binaryWriter.Close();

            return stream.ToArray();
        }
    }
}
