using NUnit.Framework;

namespace TankGame.UnitTest
{
    [TestFixture]
    class VehicleUnitTest
    {
        private TankSprint_3.TankGame _tankGame;

        [SetUp]
        public void SetUp()
        {
            _tankGame = new TankSprint_3.TankGame(null);

        }

    }
}
