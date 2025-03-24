using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SzkolaTestowJednostkowych.Basics;

namespace SzkolaTestowJednostkowych_UnitTests.Basics
{
    internal class TicTacToeTests
    {

        [TestCase(1)]
        [TestCase(2)]
        public void SolveGame_WhenPlayerWinsInRow_ShouldReturnPlayerNumber(int player)
        {
            var ticTacToe = new TicTacToe();
            var board = new[,]
            {
                {player, player, player},
                { 0,0,0},
                { 2,1,0}
            };

            var result = ticTacToe.SolveGame(board);
            result.Should().Be(player);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void SolveGame_WhenPlayerWinsInColumn_ShouldReturnPlayerNumber(int player)
        {
            var ticTacToe = new TicTacToe();
            var board = new[,]
            {
                {player, 2, 1},
                {player,0,0},
                {player,1,0}
            };

            var result = ticTacToe.SolveGame(board);
            result.Should().Be(player);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void SolveGame_WhenPlayerWinsInDiagonal_ShouldReturnPlayerNumber(int player)
        {
            var ticTacToe = new TicTacToe();
            var board = new[,]
            {
                {player, 2, 1},
                {1,player,0},
                {0,1,player}
            };

            var result = ticTacToe.SolveGame(board);
            result.Should().Be(player);
        }

        [Test]
        public void SolveGame_WhenGameIsNotSolved_ShouldReturnMinusOne()
        {
            var ticTacToe = new TicTacToe();
            var board = new[,]
            {
                {1,2,1},
                {1,2,0},
                {0,1,2}
            };

            var result = ticTacToe.SolveGame(board);
            result.Should().Be(-1);
        }

        [Test]
        public void SolveGame_WhenGameIsNotSolved_ShouldReturnZero()
        {
            var ticTacToe = new TicTacToe();
            var board = new[,]
            {
                {1,2,1},
                {1,2,1},
                {2,1,2}
            };

            var result = ticTacToe.SolveGame(board);
            result.Should().Be(0);
        }
    }
}
