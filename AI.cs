using System;
namespace AssemblyCSharp
{
	public class AI : Player
	{
		public AI ()
		{
		}

		private static AI INSTANCE;
		public static AI getInstance()
		{
			if (INSTANCE!=null){
				INSTANCE = new AI();
			}
			return INSTANCE;
		}

		public void startAI()
		{
			listCanMove  = Board.getInstance().blockCanMoves;
			blockCanMove = listCanMove[0];

			moveBlock(blockCanMove.x1,blockCanMove.y1,blockCanMove.x2,blockCanMove.y2);
		}
	}
}

