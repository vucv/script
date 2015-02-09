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
		BasicBlock [,] listGameObject;
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
			int multiply = 1;
			scores = new ();
			while (blockNeedChecks.length != 0)
			{
				checkMatch();
				destroysBlock();
				updateUser();
				multiply++;
			}

			updateListCanMove();
		}

		public void updateListCanMove()
		{
			for (int i = 0; i < 8; i++) {
				for (int j = 0; j < 8; j++) {
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
				if (this.block[paramInt1,paramInt2] == this.block[paramInt3][paramInt4]) {
					return null;
				}
				if ((this.block[paramInt1][paramInt2] >= 7) || (this.block[paramInt3][paramInt4] >= 7)) {
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
					BlockCanMove block = new BlockCanMove();
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
				//TODO : Destroy game object & create effect

			}
			for(int i = 0; i< length; i++)
			{
				blockNeedDestroys
				this.block[x,y] = -1;
				updatePlayer(blockNeedDestroys.type);
				moveDown(x,y);
			}
		}

		public void updatePlayer(int typeBlock)
		{
			Match.getInstance().turn

			switch(typeBlock)
			{


			}
		}
		public void moveDown()
		{
			for(int i = y; i < 1; i--)
			{
				this.block[x,i] = this.block[x,i-1];
				//TODO : Update position game object
				listGameObject[x,i].setY(i-1);
				//Add this block to list need check
				blockNeedChecks.add(new blockNeedChecks(x,i));
			}

			this.block[x,0] = generateBlockType();
			//TODO : Create game object
			this.generateBlockType(x,0,this.block[x,0]);
		}

		public void generateBlockType(int x, int y, int type)
		{
			listGameObject[x,y] = new BasicBlock;
			//set...
		}

		public int generateBlockType()
		{
			int typeBlock = ay.a(e.h.length);
			if ((typeBlock == 0) && (ay.a(100) < 11)) {
				typeBlock = 6;
			}
			return typeBlock;
		}

		public void swapBlock(int x1, int y1, int x2, int y2)
		{
			int temp = this.blocks[x1,y1];
			this.blocks[x1,y1] = this.blocks[x2,y2];
			this.blocks[x2,y2] = temp;
		}

		public void generateBoard()
		{
			this.blocks = new int[8,8];
			int blockTypeList = 5;
			boolean opp = true;
			for (int i = 0; i < 8; i++) {
				m = opp ? 1 : 0;// xen ke
				opp = !opp;//
				while (m < 8) {
					this.blocks[i,m] = ay.a(blockTypeList);//0->5.0
					this.generateBlockType(i,m,this.blocks[i,m]);
					m += 2;
				}
			}
			i = ay.a(3) + 2 + 2;
			int m = ay.a(4) + 1 + 2;
			//Maybe default 7
			if (paramArrayOfInt[i][m] != 7) {
				i--;
			}
			int n = ay.a(4);
			//Random can move
			switch (n) {
				case 0:
					int tmp169_168 = this.blocks[(i - 1),m];
					this.blocks[i,(m + 1)] = tmp169_168;
					this.blocks[i,(m - 1)] = tmp169_168;
					break;
				case 1:
					int tmp200_199 = this.blocks[(i + 1),m];
					this.blocks[i,(m + 1)] = tmp200_199;
					this.blocks[i,(m - 1)] = tmp200_199;
					break;
				case 2:
					int tmp231_230 = this.blocks[i,(m - 1)];
					this.blocks[(i + 1),m] = tmp231_230;
					this.blocks[(i - 1),m] = tmp231_230;
					break;
				default:
					int tmp262_261 = this.blocks[i,(m + 1)];
					this.blocks[(i + 1),m] = tmp262_261;
					this.blocks[(i - 1),m] = tmp262_261;
			}
			opp = false;
			// Random other, not match
			for (int i1 = 0; i1 < 8; i1++) {
				int i2 = opp ? 1 : 0;
				opp = !opp;//
				while (i2 < 8) {
					boolean[] arrayOfBoolean = new boolean[e.h.length];
					int i3 = this.blocks[i1][(i2 - 1)];
					int i4 = this.blocks[i1][(i2 - 2)];
					int i5 = this.blocks[i1][(i2 + 1)];
					int i6 = this.blocks[i1][(i2 + 2)];
					if (i3 == i4) {
						arrayOfBoolean[i3] = true;
					}
					if (i5 == i6) {
						arrayOfBoolean[i5] = true;
					}
					if (i5 == i3) {
						arrayOfBoolean[i3] = true;
					}
					int i7 = this.blocks[(i1 - 1)][i2];
					int i8 = this.blocks[(i1 - 2)][i2];
					int i9 = this.blocks[(i1 + 1)][i2];
					int i10 = this.blocks[(i1 + 2)][i2];
					if (i7 == i8) {
						arrayOfBoolean[i7] = true;
					}
					if (i9 == i10) {
						arrayOfBoolean[i9] = true;
					}
					if (i7 == i9) {
						arrayOfBoolean[i7] = true;
					}
					int i11 = ay.a(arrayOfBoolean.length);
					if (arrayOfBoolean[i11] != 0) {
						do {
							i11 = (i11 + 1) % arrayOfBoolean.length;
						} while (arrayOfBoolean[i11] != 0);
					}
					this.blocks[i1][i2] = i11;
					this.generateBlockType(i1,i2,i11);
					i2 += 2;
				}
			}
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

