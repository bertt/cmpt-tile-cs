
using System.IO;
using System.Text;

namespace Cmpt.Tile
{
    public class CmptHeader
    {

        public CmptHeader(BinaryReader reader)
        {
            Magic = Encoding.UTF8.GetString(reader.ReadBytes(4));
            Version = (int)reader.ReadUInt32();
            ByteLength = (int)reader.ReadUInt32();
            TilesLength = (int)reader.ReadUInt32();
        }

        public string Magic { get; set; }
        public int Version { get; set; }
        public int ByteLength { get; set; }
        public int TilesLength { get; set; }
    }
}
