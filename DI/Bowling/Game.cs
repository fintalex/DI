using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
	public class Game
	{
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
		}
		public int ScoreForFrame(int frame)
		{
			int ball = 0;
			int score = 0;
			for (int curFrame = 0; curFrame < frame; curFrame++)
			{
				score += throws[ball++ ] + throws[ball++ ];
			}
			return score;
		}
	}
}
