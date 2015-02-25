using System;
namespace AssemblyCSharp
{
	public class BlockNeedDestroy : IComparable<BlockNeedDestroy>
	{
	    public int x;
	    public int y;
	    public int type;
		public BlockNeedDestroy(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public int CompareTo(BlockNeedDestroy other)
		{
			// If other is not a valid object reference, this instance is greater. 
			if (other == null) return 1;
			
			// The temperature comparison depends on the comparison of  
			// the underlying Double values.  
			return y.CompareTo(other.y);
		}

	}

}