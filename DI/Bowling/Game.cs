﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
	public class Game
	{
		private int score;
		public int Score
		{
			get { return score; }
		}
		public void Add(int pins)
		{
			score += pins;
		}
	}
}
