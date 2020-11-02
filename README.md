# cmpt-tile-cs

Library for reading/writing composite 3D Tiles (cmpt)

Specs: https://github.com/CesiumGS/3d-tiles/blob/master/specification/TileFormats/Composite/README.md

## Reading - sample code

```
var cmpt = CmptReader.Read(cmptfile);
Assert.IsTrue(cmpt.CmptHeader.TilesLength == 2);
Assert.IsTrue(cmpt.InstancedTiles.Count == 1);
Assert.IsTrue(cmpt.InstancedTiles[0].Positions.Count == 25);
Assert.IsTrue(cmpt.BatchedTiles.Count == 1);
```

## Writing - sample code

todo

## History

2020-11-02: Initial version - reading composite tiles