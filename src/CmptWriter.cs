using System;
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
            header.ByteLength = 16 + tiles.Sum(i => i.Length);
            var headerBytes = header.AsBinary();

            binaryWriter.Write(headerBytes);

            foreach (var tile in tiles)
            {
                binaryWriter.Write(tile);
            }
            binaryWriter.Flush();
            binaryWriter.Close();

            return stream.ToArray();
        }
    }
}
