using System.Xml.Linq;

namespace TDD.Bowling.Kata.Test
{
    public class GameTests
    {
        Game _game;

        [SetUp]
        public void Setup()
        {
            _game = new Game();
        }

        [TearDown]
        public void EndGame()
        {
            _game = null;
        }

        [Test]
        public void Score_RollOneTimeAndMiss_ReturnZero()
        {
            _game.Roll(0);
            Assert.AreEqual(_game.Score(), 0);
        }

        [Test]
        public void Score_RollAllMiss_ReturnZero()
        {
            RollMuitiTimes(0, 20);
            Assert.AreEqual(_game.Score(), 0);
        }

        [Test]
        public void Score_RollTenTimesAndHitOneEveryTime_ReturnTen()
        {
            RollMuitiTimes(1, 10);
            Assert.AreEqual(10, _game.Score());
        }

        [Test]
        public void Score_TestSpare_RollFiveFiveThree_ReturnSixteen()
        {
            _game.Roll(5);
            _game.Roll(5);
            _game.Roll(3);
            Assert.AreEqual(16, _game.Score());
        }

        [Test]
        public void Score_TestStrike_RollTenSixOne_ReturnTwentyFour()
        {
            _game.Roll(10);
            _game.Roll(6);
            _game.Roll(1);
            Assert.AreEqual(24, _game.Score());
        }

        [Test]
        public void Score_TestSpareAtLastRound_RollSixFourFive_ReturnTwenty()
        {
            RollMuitiTimes(0, 18);
            _game.Roll(6);
            _game.Roll(4);
            _game.Roll(5);
            Assert.AreEqual(20, _game.Score());
        }

        [Test]
        public void Score_TestSpareAtLastRound_RollSixFourTen_ReturnThirty()
        {
            RollMuitiTimes(0, 18);
            _game.Roll(6);
            _game.Roll(4);
            _game.Roll(10);
            Assert.AreEqual(30, _game.Score());
        }

        [Test]
        public void Score_TestStrikeAtLastRound_RollTurkey_ReturnSixty()
        {
            RollMuitiTimes(0, 18);
            _game.Roll(10);
            _game.Roll(10);
            _game.Roll(10);
            Assert.AreEqual(60, _game.Score());
        }

        [Test]
        public void Score_TestStrikeAtLastRound_RollTenTenSix_ReturnFourtyEight()
        {
            RollMuitiTimes(0, 18);
            _game.Roll(10);
            _game.Roll(10);
            _game.Roll(6);
            Assert.AreEqual(48, _game.Score());
        }

        [Test]
        public void Score_TestStrike_RollAllStrike()
        {
            RollMuitiTimes(10, 12);
            Assert.AreEqual(300, _game.Score());
        }

        private void RollMuitiTimes(int downPins, int times)
        {
            for (int i = 0; i < times; i++)
                _game.Roll(downPins);
        }
    }
}