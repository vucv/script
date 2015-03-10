using System;
namespace AssemblyCSharp
{
	public class Match
	{
		//Player
		//AI
		//Turn
		private int turnToken;
		private static Match INSTANCE;
		public static Match getInstance()
		{
			if (INSTANCE==null){
				INSTANCE = new Match();
			}
			return INSTANCE;
		}

		public Match ()
		{
			Board.getInstance ().generateBoard();
		}

		public void Update()
		{
			if (Board.getInstance ().processing) 
			{
				Board.getInstance ().processBlocks();
			} 
			else {
					//if(Board.getInstance())
					//{
					//rematch
					//}
					switch (turnToken) {
					case 0:
	//Player
							break;
					case 1:
	//AI
							AI.getInstance ().startAI ();
							break;
					}
			}
		}

		public void changeTurn()
		{
			if (turnToken == 0) turnToken = 1;
			else turnToken = 0;
		}

		public int getTurnToken()
		{
			return turnToken;
		}
	}
}

