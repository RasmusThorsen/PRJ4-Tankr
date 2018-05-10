using NSubstitute;
using NUnit.Framework;
using TankSprint_3;
using TankSprint_3.Interface;

namespace TankGame.UnitTest
{
    [TestFixture]
    class BulletUnitTest
    {
        private Bullet _uut;
        private IGameTimer _gameTimer;

        [SetUp]
        public void SetUp()
        {
            _gameTimer = Substitute.For<IGameTimer>();
            _gameTimer.TotalSeconds.Returns<double>(0);

            _uut = new Bullet
            {
                _gameTimer = _gameTimer
            };
        }

        [Test]
        public void Update_GameTimerTotalSecondsIsCalled_CurrentTimePropertyIsSet()
        {
            var tg = new TankSprint_3.TankGame("EDUH;4;1;Rasmus");
            _gameTimer.TotalSeconds.Returns<double>(8);
            _uut.Update();
            Assert.That(_uut._currentTime, Is.EqualTo(8));
        }

        [Test]
        public void Update_GameTimerReturnsBiggerTimerThenLifeSpan_IsRemovedIsTrue()
        {
            _gameTimer.TotalSeconds.Returns<double>(8);
            _uut.Update();
            Assert.That(_uut.IsRemoved, Is.True);
        }

        [Test]
        public void Update_PositionIsNotTheSameAsBefore()
        {
            var lastPosition = _uut.Position;
            _uut.Update();
            Assert.That(_uut.Position, Is.Not.EqualTo(lastPosition));
        }
    }
}
