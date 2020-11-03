# cmpt-tile-cs

Library for reading/writing composite 3D Tiles (cmpt)

Specs: https://github.com/CesiumGS/3d-tiles/blob/master/specification/TileFormats/Composite/README.md

## NuGet

https://www.nuget.org/packages/cmpt-tile/

## Sample code

1] sample code of reading composite tile containing batched and instanced model.

```
var cmpt = CmptReader.Read(cmptfile);
Assert.IsTrue(cmpt.CmptHeader.TilesLength == 2);
Assert.IsTrue(cmpt.Tiles.Count == 2);
Assert.IsTrue(cmpt.Magics[1] == "i3dm");
var i3dm = I3dmReader.Read(new MemoryStream(cmpt.Tiles.First()));
Assert.IsTrue(i3dm.Positions.Count == 25);
```

2] Writing - sample code

```
var tileBytes= I3dmWriter.Write(i3dm);
var tiles = new List<byte[]>();
tiles.Add(tileBytes);
var cmptBytes = CmptWriter.Write(tiles);

```

## History

2020-11-02: Initial version - reading composite tiles
