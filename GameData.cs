using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace AssemblyCSharp
{
	public class GameData
	{
		public Sprite[] sprites;
		private static GameData INSTANCE; 
		public static GameData getInstance()
		{
			if (INSTANCE == null){
				INSTANCE = new GameData();
			}
			return INSTANCE;
		}
		public GameData()
		{
			this.sprites = new Sprite[7]{
				Resources.Load<Sprite>("loan12/a/sword"),

				Resources.Load<Sprite>("loan12/a/rice"),
				Resources.Load<Sprite>("loan12/a/gold"),
				Resources.Load<Sprite>("loan12/a/heart"),
				Resources.Load<Sprite>("loan12/a/book"),
				Resources.Load<Sprite>("loan12/a/yinyang"),
				Resources.Load<Sprite>("loan12/a/swordred")
			};
		}
	}
}

