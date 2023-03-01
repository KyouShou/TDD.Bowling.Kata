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
            Assert.AreEqual(_game.Score(), 10);
        }
    }
}