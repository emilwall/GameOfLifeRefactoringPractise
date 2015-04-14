using System;
using NUnit.Framework;

namespace GameOfLife.UnitTests
{
    [TestFixture]
    public class WorldSpecification
    {
        [Test]
        public void ShouldGenerateWorld()
        {
            var world = new World();

            Assert.That(world.CurrentWorld.Length, Is.EqualTo(144));
            Assert.That(world.CurrentWorld[7, 7], Is.Not.Null);
        }
    }
}
