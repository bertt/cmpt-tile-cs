﻿using I3dm.Tile;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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


        [Test]
        public void MultipleInnertilesCmptWriterTest()
        {
            // arrange
            var treeUrlGlb = "https://bertt.github.io/mapbox_3dtiles_samples/samples/instanced/trees_external_gltf/tree.glb";
            var pos1 = new Vector3(100, 101, 102);
            var pos2 = new Vector3(200, 201, 202);
            var positions = new List<Vector3>() { pos1, pos2 };

            var i3dm = new I3dm.Tile.I3dm(positions, treeUrlGlb);
            i3dm.RtcCenter = new Vector3(100, 100, 100);

            var i3dm1 = new I3dm.Tile.I3dm(positions, treeUrlGlb);
            i3dm1.RtcCenter = new Vector3(200, 200, 200);

            var i3dmBytes = I3dmWriter.Write(i3dm);

            File.WriteAllBytes(@"d:\aaa\i3dmvalid.i3dm", i3dmBytes);

            var i3dm1Bytes = I3dmWriter.Write(i3dm1);

            var tiles = new List<byte[]>();
            tiles.Add(i3dmBytes);
            tiles.Add(i3dm1Bytes);

            // act
            var cmptBytes = CmptWriter.Write(tiles);

            // assert
            Assert.IsTrue(cmptBytes.Length > 0);

            var ms = new MemoryStream(cmptBytes);
            var cmpt = CmptReader.Read(ms);
            Assert.IsTrue(cmpt.Tiles.Count() == 2);
        }

    }
}
