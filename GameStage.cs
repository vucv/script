using UnityEngine;
using System.Collections;
namespace AssemblyCSharp
{
	public enum Stage {MENU,MAP,MATCH};
	public class GameStage {
		private static GameStage INSTANCE; 
		public static GameStage getInstance()
		{
			if (INSTANCE == null){
				INSTANCE = new GameStage();
			}
			return INSTANCE;
		}
		public Stage stage;
	}
}
