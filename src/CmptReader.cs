using System.Collections.Generic;
using System.IO;
using System.Text;

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
                cmpt.Tiles = new List<byte[]>();
                cmpt.Magics = new List<string>();


                for (var i=0;i< cmptHeader.TilesLength; i++)
                {
                    var currentPosition = reader.BaseStream.Position;
                    var magic = Encoding.UTF8.GetString(reader.ReadBytes(4));
                    cmpt.Magics.Add(magic);
                    var version = (int)reader.ReadUInt32();
                    var byteLength = (int)reader.ReadUInt32();

                    reader.BaseStream.Position = currentPosition;
                    var bytesInnertile = reader.ReadBytes(byteLength);
                    cmpt.Tiles.Add(bytesInnertile);
                }
                return cmpt;
            }
        }
    }
}