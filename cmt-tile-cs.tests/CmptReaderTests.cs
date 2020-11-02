using NUnit.Framework;
using System.IO;

namespace Cmpt.Tile.Tests
{
    public class CmptReaderTests
    {

        string expectedMagicHeader = "cmpt";
        int expectedVersionHeader = 1;

        [Test]
        public void ReadFirstCompositeTest()
        {
            // arrange
            // source: https://github.com/CesiumGS/cesium/tree/master/Specs/Data/Cesium3DTiles/Composite/Composite
            var cmptfile = File.OpenRead(@"testfixtures/composite.cmpt");
            Assert.IsTrue(cmptfile != null);

            var cmpt = CmptReader.Read(cmptfile);
            Assert.IsTrue(cmpt != null);
            Assert.IsTrue(cmpt.CmptHeader.Magic == expectedMagicHeader);
            Assert.IsTrue(cmpt.CmptHeader.Version == expectedVersionHeader);
            Assert.IsTrue(cmpt.CmptHeader.ByteLength == 13472); // The length of the entire Composite tile, including this header and each inner tile, in bytes.
            Assert.IsTrue(cmpt.CmptHeader.TilesLength == 2);
            Assert.IsTrue(cmpt.InstancedTiles.Count == 1);
            Assert.IsTrue(cmpt.InstancedTiles[0].Positions.Count == 25);
            Assert.IsTrue(cmpt.BatchedTiles.Count == 1);
        }

        [Test]
        public void ReadCompositeOfInstancedTest()
        {
            // source: https://github.com/CesiumGS/cesium/blob/master/Specs/Data/Cesium3DTiles/Composite/CompositeOfInstanced/
            var cmptfile = File.OpenRead(@"testfixtures/compositeOfInstanced.cmpt");
            Assert.IsTrue(cmptfile != null);
            var cmpt = CmptReader.Read(cmptfile);
            Assert.IsTrue(cmpt != null);
            Assert.IsTrue(cmpt.CmptHeader.Magic == expectedMagicHeader);
            Assert.IsTrue(cmpt.CmptHeader.Version == expectedVersionHeader);
            Assert.IsTrue(cmpt.CmptHeader.TilesLength== 2);
            Assert.IsTrue(cmpt.InstancedTiles[0].Positions.Count == 25);
            Assert.IsTrue(cmpt.InstancedTiles[0].GlbUrl.Replace("\0", string.Empty) == "box.glb");
            Assert.IsTrue(cmpt.InstancedTiles[1].Positions.Count == 25);
            Assert.IsTrue(cmpt.InstancedTiles[1].GlbUrl.Replace("\0", string.Empty) == "box.glb");
        }
    }
}
