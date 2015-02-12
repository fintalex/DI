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
		
		
		private int score;
		private int[] throws = new int[21];
		private int currentThrow;

		public int Score
		{
			get { return score; }
		}

		public void Add(int pins)
		{
			throws[currentThrow++] = pins;
			score += pins;

			AdjustCurrentFrame();
		}

		private void AdjustCurrentFrame()
		{
			if (isFirstThrow)
			{
				isFirstThrow = false;
			}
			else
			{
				isFirstThrow = true;
				currentFrame++;
			}
		}

		public int CurrentFrame
		{
			get { return currentFrame; }
		}

		public int ScoreForFrame(int frame)
		{
			int ball = 0;
			int score = 0;
			for (int curFrame = 0; curFrame < frame; curFrame++)
			{
				int firstThrow = throws[ball++];
				int secondThrow = throws[ball++];
				int frameScore = firstThrow + secondThrow;

				// для обработки спэа необходим первый бросок в следудющем фрейме
				if (frameScore == 10)
					score += frameScore + throws[ball];
				else
					score += frameScore;
			}
			return score;
		}
	}
}
