using I3dm.Tile;
using NUnit.Framework;
using System.IO;
using System.Linq;

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

            // act
            var cmpt = CmptReader.Read(cmptfile);

            // assert
            Assert.IsTrue(cmpt != null);
            Assert.IsTrue(cmpt.CmptHeader.Magic == expectedMagicHeader);
            Assert.IsTrue(cmpt.CmptHeader.Version == expectedVersionHeader);
            Assert.IsTrue(cmpt.CmptHeader.ByteLength == 13472); // The length of the entire Composite tile, including this header and each inner tile, in bytes.
            Assert.IsTrue(cmpt.CmptHeader.TilesLength == 2);
            Assert.IsTrue(cmpt.Tiles.Count() == 2);
            Assert.IsTrue(cmpt.Magics.ToArray()[0] == "b3dm");
            Assert.IsTrue(cmpt.Magics.ToArray()[1] == "i3dm");

            var i3dm = I3dmReader.Read(new MemoryStream(cmpt.Tiles.First()));
            Assert.IsTrue(i3dm.Positions.Count == 25);
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

            var i3dm = I3dmReader.Read(new MemoryStream(cmpt.Tiles.First()));
            Assert.IsTrue(i3dm.Positions.Count == 25);
        }
    }
}
