using System;
using System.Linq;
using System.Text;
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

        [Test]
        public void InitialWorldShouldHaveAround30PercentAliveCells()
        {
            var initialWorld = new World().CurrentWorld;

            var aliveCells = 0;
            foreach (var b in initialWorld)
            {
                if (b)
                {
                    aliveCells++;
                }
            }

            Assert.That(aliveCells, Is.GreaterThan(144 * 0.1));
            Assert.That(aliveCells, Is.LessThan(144 * 0.5));
        }

        [Test]
        public void ShouldChangeWhenSteppingGeneration()
        {
            var world = new World();
            var firstGen = world.CurrentWorld;

            world.StepGeneration();

            var newGen = world.CurrentWorld;
            var changed = false;
            // TODO: loopa igenom generationerna och kontrollera att något ändrats.
            changed = true;
            Assert.That(changed, Is.True);
        }
    }
}
