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
			if (INSTANCE!=null){
				INSTANCE = new Match();
			}
			return INSTANCE;
		}

		public Match ()
		{
		}

		public void Update()
		{
			switch (turnToken) 
			{
			case 0:
				//Player
				break;
			case 1:
				//AI
				break;
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
