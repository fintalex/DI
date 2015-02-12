using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Bowling;

[TestFixture]
public class GameTest
{
	private Game game;
	[SetUp]
	public void SetUp()
	{
		game = new Game();
	}

	[Test]
	public void TestOneThrow()
	{
		game.Add(5);
		Assert.AreEqual(5, game.Score);
		Assert.AreEqual(1, game.CurrentFrame);
	}
	[Test]
	public void TestTwoThrowsNoMark()
	{
		game.Add(5);
		game.Add(4);
		Assert.AreEqual(9, game.Score);
		Assert.AreEqual(2, game.CurrentFrame);
	}
	[Test]
	public void testFourThrowsNoMark()
	{
		game.Add(5);
		game.Add(4);
		game.Add(7);
		game.Add(2);
		Assert.AreEqual(18, game.Score);
		Assert.AreEqual(9, game.ScoreForFrame(1));
		Assert.AreEqual(18, game.ScoreForFrame(2));
		Assert.AreEqual(3, game.CurrentFrame);
	}
	[Test]
	public void TestSimpleSpare()
	{
		game.Add(3);
		game.Add(7);
		game.Add(3);
		Assert.AreEqual(13, game.ScoreForFrame(1));
		Assert.AreEqual(2, game.CurrentFrame);
	}

	[Test]
	public void TestSimpleFrameAfterSpare()
	{
		game.Add(3);
		game.Add(7);
		game.Add(3);
		game.Add(2);
		Assert.AreEqual(13, game.ScoreForFrame(1));
		Assert.AreEqual(18, game.ScoreForFrame(2));
		Assert.AreEqual(3, game.CurrentFrame);
	}

}
