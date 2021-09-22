using I3dm.Tile;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace Cmpt.Tile.Tests
{
    public class CmptWriterTests
    {
        [Test]
        public void FirstCmptWriterTest()
        {
            // arrange
            var treeUrlGlb = "https://bertt.github.io/mapbox_3dtiles_samples/samples/instanced/trees_external_gltf/tree.glb";
            var pos1 = new Vector3(100, 101, 102);
            var pos2 = new Vector3(200, 201, 202);
            var positions = new List<Vector3>() { pos1, pos2 };

            var i3dm = new I3dm.Tile.I3dm(positions, treeUrlGlb);
            i3dm.RtcCenter = new Vector3(100, 100, 100);

            var tileBytes= I3dmWriter.Write(i3dm);
            var tiles = new List<byte[]>();
            tiles.Add(tileBytes);

            // act
            var cmptBytes = CmptWriter.Write(tiles);

            // assert
            Assert.IsTrue(cmptBytes.Length > 0);
        }
    }
}
