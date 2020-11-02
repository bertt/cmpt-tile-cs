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
            var cmptfile = File.OpenRead(@"testfixtures/composite.cmpt");
            Assert.IsTrue(cmptfile != null);

            var cmpt = CmptReader.Read(cmptfile);
            
            Assert.IsTrue(cmpt != null);
            Assert.IsTrue(cmpt.CmptHeader.Magic == expectedMagicHeader);
            Assert.IsTrue(cmpt.CmptHeader.Version== expectedVersionHeader);
        }
    }
}