using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TankSprint_3;
using TankSprint_3.Interface;
using TankSprint_3.Classes;

namespace TankGame.UnitTest
{
    [TestFixture]
    public class TankUnittest
    {
        private Tank _uut;
        private ICanon FakeCanon;
        private IVehicle FakeVehicle;
        private IBullet FakeBullet;
        private IGameTimer FakeTimer;

        [SetUp]
        public void Setup()
        {
            FakeBullet = Substitute.For<IBullet>();
            FakeCanon = Substitute.For<ICanon>();
            FakeVehicle = Substitute.For<IVehicle>();
            FakeTimer = Substitute.For<IGameTimer>();
            FakeCanon.Bullet = FakeBullet;

            _uut = new Tank("Player1", FakeCanon, FakeVehicle);
            _uut._gameTimer = FakeTimer;
        }

        [Test]
        public void SettingNameToPlayer1_NameIsPlayer1()
        {
            Assert.That(_uut.Name, Is.EqualTo("Player1"));
        }

        [Test]
        public void BulletListCountIs2_BulletUpdateCalledTwice()
        {
            _uut._bullets.Add(FakeBullet);
            _uut._bullets.Add(FakeBullet);
            FakeTimer.TotalSeconds.Returns<double>(1);

            _uut.Update();

            FakeBullet.Received(2).Update();
        }

        [Test]
        public void IsSpeedingTrue_MoveForwardIsCalled()
        {
            _uut.isSpeeding = true;
            _uut.Update();

            FakeVehicle.Received().MoveForward();           
        }

        [Test]
        public void IsSpeedingFalse_MoveForwardIsNotCalled()
        {
            _uut.isSpeeding = false;
            _uut.Update();

            FakeVehicle.DidNotReceive().MoveForward();
        }

        [Test]
        public void IsShootingTrue_ShootIsCalled()
        {
            _uut.isShooting = true;
            _uut.Update();

            FakeCanon.ReceivedWithAnyArgs().Shoot(Vector2.Zero, Vector2.Zero);
        }

        [Test]
        public void IsShootingFalse_ShootIsNotCalled()
        {
            _uut.isShooting = false;
            _uut.Update();

            FakeCanon.DidNotReceive().Shoot(Vector2.Zero, Vector2.Zero);
        }

        [Test]
        public void ShootIsCalled_ReturnsNewBullet_NewBulletAddedToList()
        {
            _uut.Shoot();

            Assert.That(_uut._bullets.Count, Is.EqualTo(1));            
        }

        //[Test]
        //public void ShootIsCalled_ReturnNullBullet_BulletNotAddedToList()
        //{
        //    FakeCanon.CurrentTime.Returns<float>(1);
        //    FakeCanon.ShootDelay.Returns<float>(5);

        //    _uut.Shoot();

        //    Assert.That(_uut._bullets.Count, Is.EqualTo(0));
        //}

        [Test]
        public void DrawIsCalled_BulletRecievedDrawCall()
        {
            _uut._bullets.Add(FakeBullet);
            _uut.Draw();
            FakeBullet.Received().Draw();
        }

        [Test]
        public void DrawIsCalled_VehicleReceivedDrawCall()
        {
            _uut.Draw();
            FakeVehicle.Received().Draw();
        }
    }
}
