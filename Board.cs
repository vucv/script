using System;
namespace AssemblyCSharp
{
	public class Board
	{
		//Board
		int [,] blocks;
		BlockNeedCheck[] blockNeedChecks;
		BlockNeedDestroy[] blockNeedDestroys;
		BlockCanMove[] blockCanMoves;
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
			combo = 1;
			scores = new ();
			while (blockNeedChecks.length != 0)
			{
				checkMatch();
				destroysBlock();
				updateUser();
				combo++;
			}

			updateListCanMove();
		}

		public void updateListCanMove()
		{
			for (int i = 2; i < 10; i++) {
				for (int j = 2; j < 10; j++) {
					BlockCanMove block = checkCanMove(i, j, i + 1, j);
					if (block != null) {
						blockCanMoves.add(block);
					}
					block = checkCanMove(i, j, i, j + 1);
					if (block != null) {
						blockCanMoves.add(block);
					}
				}
			}
		}

		private BlockCanMove checkCanMove(int paramInt1, int paramInt2, int paramInt3, int paramInt4) {
			try {
				if (this.e[paramInt1][paramInt2] == this.e[paramInt3][paramInt4]) {
					return null;
				}
				if ((this.e[paramInt1][paramInt2] >= 7) || (this.e[paramInt3][paramInt4] >= 7)) {
					return null;
				}
				//swap for check score
				swapBlock(paramInt1, paramInt2, paramInt3, paramInt4);
				int i = 0;
				//check move 4 de
				int j = checkMatchVertical(paramInt1, paramInt2);
				int i1 = checkMatchHorizontal(paramInt1, paramInt2);
				int i2 = checkMatchVertical(paramInt3, paramInt4);
				int i3 = checkMatchHorizontal(paramInt3, paramInt4);
				if (((j & 0xFF) >= 3) || ((i1 & 0xFF) >= 3) || ((i2 & 0xFF) >= 3) || ((i3 & 0xFF) >= 3)) {
					i = 1;
				}
				//reswap
				swapBlock(paramInt1, paramInt2, paramInt3, paramInt4);
				if (i != 0) {
					int[] arrayOfInt = {j, i1, i2, i3};
					a locala = new a();
					locala.a = paramInt1;
					locala.b = paramInt2;
					locala.c = paramInt3;
					locala.d = paramInt4;
					locala.e = arrayOfInt;
					return locala;
				}
			} catch (Exception localException) {
				localException.printStackTrace();
			}
			return null;
		}

		//Check all list needed
		public void checkMatch()
		{
			int length = blockNeedChecks.length;
			for(int i = 0; i< length; i++)
			{
				//Check block
				this.checkMatchAt(blockNeedChecks[i]);

				//Check destroys
				H = blockNeedChecks[i].left + blockNeedChecks[i].right;
				V = blockNeedChecks[i].top + blockNeedChecks[i].bottom;
				if(H >=3)
				{
					i = blockNeedChecks[i].left
					while (i>0)
					{
						blockNeedDestroys.add(x-i,y);
						i--;
					}
					i = blockNeedChecks[i].right;
					while (i>0)
					{
						blockNeedDestroys.add(x+i,y);
						i--;
					}
				}

				if(V >=3)
				{
					i = blockNeedChecks[i].top
					while (i>0)
					{
						blockNeedDestroys.add(x,y-i);
						i--;
					}
					i = blockNeedChecks[i].bottom;
					while (i>0)
					{
						blockNeedDestroys.add(x,y+i);
						i--;
					}
				}

				if(H>4 || V>4)
				{
					scores.turn ++;
				}
			}
			//Clean list need check
		}

		public void destroysBlock()
		{
			//Get list destroys , add scores
			int length = blockNeedDestroys.length;
			for(int i = 0; i< length; i++)
			{
				blockNeedDestroys
				this.block[x,y] = -1;
				moveDown(x,y);
			}
			return scores;
		}

		public void moveDown()
		{
			for(int i = y; i < 1; i--)
			{
				this.block[x,i] = this.block[x,i-1];
				//Add this block to list need check
				blockNeedChecks.add(new blockNeedChecks(x,i));
			}

			this.block[x,0] = generateBlockType();
		}

		public int generateBlockType()
		{
			return type;
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

		public BlockNeedCheck checkMatchAt(BlockNeedCheck block)
		{
			//check top ...
			return BlockNeedCheck;
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

