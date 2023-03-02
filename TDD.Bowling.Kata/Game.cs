using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Bowling.Kata
{
    public class Game
    {
        private int[] _rollRecords;
        private int _currentRolls;

        public Game()
        {
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
            var totalScore = 0;

            totalScore += CalculateScoreBesideLastRound();
            totalScore += CalculateLastRoundScore();

            return totalScore;
        }

        private int CalculateScoreBesideLastRound()
        {
            var scoreBesideLastRound = 0;

            for (int round = 1; round < 10; round++)
            {
                int firstPinIndexInRound = GetFirstPinIndexInRound(round);
                scoreBesideLastRound += _rollRecords[firstPinIndexInRound];
                scoreBesideLastRound += _rollRecords[firstPinIndexInRound + 1];

                if (IsSpare(round))
                {
                    scoreBesideLastRound += _rollRecords[GetNextRollIndex(firstPinIndexInRound + 1)];
                }

                if (IsStrike(round))
                {
                    var indexOfNextRoll = GetNextRollIndex(firstPinIndexInRound);
                    var indexOfNextTwoRoll = GetNextRollIndex(indexOfNextRoll);

                    if (indexOfNextRoll <= _rollRecords.Length - 1)
                        scoreBesideLastRound += _rollRecords[indexOfNextRoll];
                    if (indexOfNextTwoRoll <= _rollRecords.Length - 1)
                        scoreBesideLastRound += _rollRecords[indexOfNextTwoRoll];
                }
            }
            return scoreBesideLastRound;
        }

        private int GetNextRollIndex(int nowIndex)
        {
            if (_rollRecords[nowIndex] == 10 &&
                nowIndex < 18)
            {
                nowIndex++;
            }

            if (nowIndex < 18)
            {
                return nowIndex + 1;
            }
            else
                return nowIndex + 1;

        }

        private int CalculateLastRoundScore()
        {
            var lastRoundScore = 0;

            int firstPinIndexInLastRound = GetFirstPinIndexInRound(10);
            lastRoundScore += _rollRecords[firstPinIndexInLastRound];
            lastRoundScore += _rollRecords[firstPinIndexInLastRound + 1];
            lastRoundScore += _rollRecords[firstPinIndexInLastRound + 2];

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
