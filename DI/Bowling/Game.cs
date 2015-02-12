using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
	public class Game
	{
		private int ball;
		private int firstThrow;
		private int secondThrow;
		private int currentFrame = 1;
		private bool isFirstThrow = true;
		private int score;
		private int[] throws = new int[21];
		private int currentThrow;

		public int Score
		{
			get { return ScoreForFrame(CurrentFrame -1); }
		}

		public void Add(int pins)
		{
			throws[currentThrow++] = pins;
			score += pins;

			AdjustCurrentFrame(pins);
		}

		private void AdjustCurrentFrame(int pins)
		{
			if (isFirstThrow)
			{
				if (pins == 10) // страйк
					currentFrame++;
				else
					isFirstThrow = false;
			}
			else
			{
				isFirstThrow = true;
				currentFrame++;
			}
			if (currentFrame > 11)
				currentFrame = 11;
		}

		public int CurrentFrame
		{
			get { return currentFrame; }
		}

		public int ScoreForFrame(int frame)
		{
			ball = 0;
			int score = 0;
			for (int curFrame = 0; curFrame < frame; curFrame++)
			{
				firstThrow = throws[ball];
				if (Strike()) // strike
				{
					ball++;
					score += 10 + NextTwoBalls;
				}
				else
				{
					score += HandleSecondThrow();
				}
			}
			return score;
		}

		private bool Strike()
		{
			return firstThrow == 10;
		}
		public int NextTwoBalls 
		{
			get { return (throws[ball] + throws[ball + 1]); }
		}

		private int HandleSecondThrow()
		{
			int score = 0;
			secondThrow = throws[ball+1];
			int frameScore = firstThrow + secondThrow;

			// для обработки спэа необходим первый бросок в следудющем фрейме
			if (Spare())
			{
				ball += 2;
				score += 10 + NextBall;
			}
			else
			{
				ball += 2;
				score += frameScore;
			}
			return score;
		}

		private bool Spare()
		{
			return throws[ball] + throws[ball + 1] == 10;
		}

		private int NextBall
		{
			get { return throws[ball]; }
		}
	}
}
