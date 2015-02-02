using System;
namespace AssemblyCSharp
{
	public class Player
	{
		//Player data
		private int heath;
		private int energy;
		public Player ()
		{
		}

		public void moveBlock(int x1, int y1, int x2, int y2)
		{
			Board.getInstance ().moveBlock (x1,x2,y1,y2);
			//Check match at block1, block2

		}
	}
}

