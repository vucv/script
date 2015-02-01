using System;
namespace AssemblyCSharp
{
	public class Board
	{
		//Board

		private static Board INSTANCE; 
		public static Board getInstance()
		{
			if (INSTANCE!=null){
				INSTANCE = new Board();
			}
			return INSTANCE;
		}
		public Board ()
		{
		}

		public void moveBlock(int x1, int y1, int x2, int y2)
		{
		}

		public void genarateBoard()
		{
		}


	}
}

