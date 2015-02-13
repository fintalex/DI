using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
	public class Game
	{
		private int currentFrame = 1;
		private bool isFirstThrow = true;
		public Scorer scorer = new Scorer();
		//private int[] throws = new int[21];
		//private int currentThrow;

		public int Score
		{
			get { return ScoreForFrame(CurrentFrame -1); }
		}
		public int CurrentFrame
		{
			get { return currentFrame; }
		}

		public void Add(int pins)
		{
			scorer.AddThrow(pins);
			AdjustCurrentFrame(pins);
		}
		private void AdjustCurrentFrame(int pins)
		{
			if (isFirstThrow)
			{
				if (AdjustFrameForStrike(pins) == false) 
					isFirstThrow = false;
			}
			else
			{
				isFirstThrow = true;
				AdvanceFrame();
			}			
		}
		private bool AdjustFrameForStrike(int pins)
		{
			if (pins == 10)
			{
				AdvanceFrame();
				return true;
			}
			return false;
		}

		private void AdvanceFrame()
		{
			currentFrame++;
			if (currentFrame > 11)
				currentFrame = 11;
		}

		public int ScoreForFrame(int theFrame)
		{
			return scorer.ScoreForFrame(theFrame);
		}
	}

	public class Scorer
	{
		private int ball;
		private int[] throws = new int[21];
		private int currentThrow;

		public void AddThrow(int pins)
		{
			throws[currentThrow++] = pins;
		}
		public int ScoreForFrame(int theFrame)
		{
			ball = 0;
			int score = 0;
			for (int curFrame = 0; curFrame < theFrame; curFrame++)
			{
				if (Strike()) // strike
				{
					score += 10 + NextTwoBallsForStrike;
					ball++;
				}
				else if (Spare())
				{
					score += 10 + NextBallForSpare;
					ball += 2;
				}
				else
				{
					score += TwoBallsInFlame;
					ball += 2;
				}
			}
			return score;
		}

		private int TwoBallsInFlame
		{
			get { return throws[ball] + throws[ball + 1]; }
		}

		private bool Strike()
		{
			return throws[ball] == 10;
		}

		public int NextTwoBallsForStrike
		{
			get { return (throws[ball + 1] + throws[ball + 2]); }
		}

		private int NextBallForSpare
		{
			get { return throws[ball + 2]; }
		}

		private bool Spare()
		{
			return throws[ball] + throws[ball + 1] == 10;
		}

	}
}
