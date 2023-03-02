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
            if (pins == 10 && _currentRolls < 18)
                _currentRolls++;
        }
        public int Score()
        {
            //處理前九回合的分數計算
            for (int round = 1; round < 10; round++)
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
                    if (firstPinIndexInRound + 2 <= _rollRecords.Length - 1)
                        _score += _rollRecords[firstPinIndexInRound + 2];
                    if (firstPinIndexInRound + 3 <= _rollRecords.Length - 1)
                        _score += _rollRecords[firstPinIndexInRound + 3];
                }
            }

            //處理最後一回合的分數計算
            _score += CalculateLastRoundScore();

            return _score;
        }

        private int CalculateLastRoundScore()
        {
            var lastRoundScore = 0;

            //處理最後一回合
            int firstPinIndexInLastRound = GetFirstPinIndexInRound(10);
            lastRoundScore += _rollRecords[firstPinIndexInLastRound];
            lastRoundScore += _rollRecords[firstPinIndexInLastRound + 1];

            if (IsSpare(10))
            {
                lastRoundScore += _rollRecords[firstPinIndexInLastRound + 2];
                lastRoundScore += _rollRecords[firstPinIndexInLastRound + 2];
            }
            else if (IsStrike(10))
            {
                //計算第一球strike的額外分數
                lastRoundScore += _rollRecords[firstPinIndexInLastRound + 1];
                lastRoundScore += _rollRecords[firstPinIndexInLastRound + 2];

                //計算第二球如果是strike的額外分數
                if(_rollRecords[firstPinIndexInLastRound + 1] == 10)
                    lastRoundScore += _rollRecords[firstPinIndexInLastRound + 2];
                
                //第三球本身的分數
                lastRoundScore += _rollRecords[firstPinIndexInLastRound + 2];
            }

            return lastRoundScore;
        }

        private bool IsSpare(int round)
        {
            int firstPinIndexInRound = GetFirstPinIndexInRound(round);
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
