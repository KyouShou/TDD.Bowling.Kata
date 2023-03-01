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
        public void Score_RollTenTimesAndHitOneEveryTime_ReturnZero()
        {
            for (int i = 0; i < 10; i++)
            {
                _game.Roll(1);
            }
            Assert.AreEqual(10 , _game.Score());
        }

        [Test]
        public void Score_TestSpare_RollFiveFiveThree_ReturnSixteen()
        {
            _game.Roll(5);
            _game.Roll(5);
            _game.Roll(3);
            Assert.AreEqual(16 , _game.Score());
        }

        [Test]
        public void Score_TestStrike_RollTenSixOne_ReturnTwentyFour()
        {
            _game.Roll(10);
            _game.Roll(6);
            _game.Roll(1);
            Assert.AreEqual(24, _game.Score());
        }
    }
}