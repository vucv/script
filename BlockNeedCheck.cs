using System;
namespace AssemblyCSharp
{
	public class BlockNeedCheck
	{
	    public int x;
	    public int y;

		public int top;
		public int bottom;
		public int left;
		public int right;

		public bool isMatch;

		public BlockNeedCheck(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

	}

}