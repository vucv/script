using System;
namespace AssemblyCSharp
{
	public class Board
	{
		//Board
		int [,] blocks;
		BlockNeedCheck[] blockNeedChecks;
		BlockNeedDestroy[] blockNeedDestroy;
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
			this.swapBlock(x1,y2,x1,y2);
			blockNeedChecks.add(new blockNeedChecks(x1,y1));
			blockNeedChecks.add(new blockNeedChecks(x2,y2));

			//Call check ...
		}

		//Check all list needed
		public void checkMatch()
		{

		}


		public void getScores()
		{

		}

		public void swapBlock(int x1, int y1, int x2, int y2)
		{
			int temp = this.blocks[x1,y1];
			this.blocks[x1,y1] = this.blocks[x2,y2];
			this.blocks[x2,y2] = temp;
		}

		public void generateBoard()
		{
		}

		//check match V
		public int checkMatchVertical(int x, int y) {
			if (this.blocks[x,y] >= 7) {
				return 0;
			}
			int countMatch = 1;
			int numberBlock = 1;
			int typeBlock = this.blocks[x,y];
			//Check bot
			while (typeBlock == this.blocks[x,(y - numberBlock)]) {
				numberBlock++;
				countMatch++;
			}

			numberBlock = 1;
			//Check top
			while (typeBlock == this.blocks[x,(y + numberBlock)]) {
				numberBlock++;
				countMatch++;
			}

			return countMatch;
		}

		//check match H
		public int checkMatchHorizontal(int x, int y) {
			if (this.blocks[x,y] >= 7) {
				return 0;
			}
			int countMatch = 1;
			int numberBlock = 1;
			int typeBlock = this.blocks[x,y];
			//Check left
			while (typeBlock == this.blocks[(x - i1),y]) {
				numberBlock++;
				countMatch++;
			}

			numberBlock = 1;
			//Check right
			while (typeBlock == this.blocks[(x + i1),y]) {
				numberBlock++;
				countMatch++;
			}

			return countMatch;
		}
	}
}

