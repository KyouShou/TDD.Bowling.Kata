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
        private int[] _rollRecords;
        private int _currentRolls;

        public Game()
        {
            _score = 0;
            _rollRecords = new int[21];
            _currentRolls = 0;
        }

        /// <summary>
        /// 執行此方法代表擊出一球
        /// </summary>
        /// <param name="pins">擊倒幾個瓶子</param>
        public void Roll(int pins)
        {
            _rollRecords[_currentRolls++] = pins;
            if (pins == 10)
                _currentRolls++;
        }
        public int Score()
        {
            for (int round = 1; round < 11; round++)
            {
                int firstPinIndexInRound = GetFirstPinIndexInRound(round);
                _score += _rollRecords[firstPinIndexInRound];
                _score += _rollRecords[firstPinIndexInRound + 1];

                if (IsSpare(round))
                {
                    _score += _rollRecords[firstPinIndexInRound + 2];
                }

                if (IsStrike(round))
                {
                    _score += _rollRecords[firstPinIndexInRound + 2];
                    _score += _rollRecords[firstPinIndexInRound + 3];
                }
            }
            return _score;
        }

        private bool IsSpare(int round)
        {
            //第一球
            int firstPinIndexInRound = GetFirstPinIndexInRound(round);

            //第二球
            int secondPinIndexInRound = firstPinIndexInRound + 1;

            int totalPinsHittedInRound = _rollRecords[firstPinIndexInRound] + _rollRecords[secondPinIndexInRound];

            if (totalPinsHittedInRound == 10 &&
                !IsStrike(round))
                return true;
            else
                return false;
        }

        private bool IsStrike(int round)
        {
            int firstPinIndexInRound = GetFirstPinIndexInRound(round);
            if (_rollRecords[firstPinIndexInRound] == 10)
                return true;
            else
                return false;
        }
        private int GetFirstPinIndexInRound(int round)
        {
            return (round - 1) * 2;
        }
    }
}
