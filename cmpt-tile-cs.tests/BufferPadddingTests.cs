﻿using NUnit.Framework;

namespace Cmpt.Tile.Tests
{
    public class BufferPadddingTests
    {
        [Test]
        public void Initial()
        {
            var featureTableJson = "{\"INSTANCES_LENGTH\":2,\"POSITION\":{\"byteOffset\":0},\"EAST_NORTH_UP\":false,\"RTC_CENTER\":{\"byteOffset\":24}}";
            var paddedJson = BufferPadding.AddPadding(featureTableJson, 2);
            Assert.IsTrue(paddedJson == "{\"INSTANCES_LENGTH\":2,\"POSITION\":{\"byteOffset\":0},\"EAST_NORTH_UP\":false,\"RTC_CENTER\":{\"byteOffset\":24}}       ");
        }

    }
}
