using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Bowling.Kata
{
    public class Game
    {
        private int _score;

        public Game()
        {
            _score = 0;
        }

        /// <summary>
        /// 執行此方法代表擊出一球
        /// </summary>
        /// <param name="pins">擊倒幾個瓶子</param>
        public void Roll(int pins)
        {
            _score += pins;
        }
        public int Score()
        {
            return _score;
        }
    }
}
