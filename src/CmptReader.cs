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
                return cmpt;
            }
        }
    }
}