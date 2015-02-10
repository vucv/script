using System;
namespace AssemblyCSharp
{
	public class Hero : Player
	{
		public Block select1;
		public Block select2;
		private static Hero INSTANCE;
    	public static Hero getInstance()
    	{
			if (INSTANCE==null){
    			INSTANCE = new Hero();
    		}
    		return INSTANCE;
    	}
		public Hero ()
		{
		}

		public void moveSelectBlock()
		{
			this.moveBlock(select1.x,select1.y,select2.x,select2.y);
		}

	}
}

