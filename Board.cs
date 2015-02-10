using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AssemblyCSharp
{
	public class Board
	{
		//Board
		int [,] blocks;
		List<BlockNeedCheck> blockNeedChecks;
		List<BlockNeedDestroy> blockNeedDestroys;
		List<BlockCanMove> blockCanMoves;
		BasicBlock [,] listGameObject;
		int multiply;
		private static Board INSTANCE;
		public static Board getInstance()
		{
			if (INSTANCE==null){
				INSTANCE = new Board();
			}
			return INSTANCE;
		}
		public Board ()
		{
			blockNeedChecks = new List<BlockNeedCheck> ();
			blockNeedDestroys = new List<BlockNeedDestroy> ();
			blockCanMoves = new List<BlockCanMove> ();
			listGameObject = new BasicBlock[8, 8];
		}

		public void moveBlock(int x1, int y1, int x2, int y2)
		{
			this.swapBlock(x1,y2,x1,y2);
			blockNeedChecks.Add(new BlockNeedCheck(x1,y1));
			blockNeedChecks.Add(new BlockNeedCheck(x2,y2));

			//Call check ...
			multiply = 1;
			while (blockNeedChecks.Count != 0)
			{
				checkMatch();
				destroysBlock();
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
						blockCanMoves.Add(block);
					}
					block = checkCanMove(i, j, i, j + 1);
					if (block != null) {
						blockCanMoves.Add(block);
					}
				}
			}
		}

		private BlockCanMove checkCanMove(int paramInt1, int paramInt2, int paramInt3, int paramInt4) {
			return null;
		}

		//Check all list needed
		public void checkMatch()
		{
			int length = blockNeedChecks.Count;
			for(int i = 0; i< length; i++)
			{
				BlockNeedCheck block = blockNeedChecks[i];
				//Check block
				this.checkMatchAt(block);

				//Check destroys
				int H = block.left + block.right;
				int V = block.top + block.bottom;
				if(H >=3)
				{
					i = block.left;
					while (i>0)
					{
						blockNeedDestroys.Add(new BlockNeedDestroy(block.x-i,block.y));
						i--;
					}
					i = block.right;
					while (i>0)
					{
						blockNeedDestroys.Add(new BlockNeedDestroy(block.x+i,block.y));
						i--;
					}
				}

				if(V >=3)
				{
					i = block.top;
					while (i>0)
					{
						blockNeedDestroys.Add(new BlockNeedDestroy(block.x,block.y-i));
						i--;
					}
					i = block.bottom;
					while (i>0)
					{
						blockNeedDestroys.Add(new BlockNeedDestroy(block.x,block.y+i));
						i--;
					}
				}

				if(H>4 || V>4)
				{
					//scores.turn ++;
				}
			}
			//Clean list need check
		}

		public void destroysBlock()
		{
			//Get list destroys , add scores
			int length = blockNeedDestroys.Count;
			for(int i = 0; i< length; i++)
			{
				//TODO : Destroy game object & create effect
				BlockNeedDestroy blockDestroy = blockNeedDestroys[i];
				listGameObject[blockDestroy.x,blockDestroy.y].destroysBlock();
			}

			for(int i = 0; i< length; i++)
			{
				BlockNeedDestroy blockDestroy = blockNeedDestroys[i];
				this.blocks[blockDestroy.x,blockDestroy.y] = -1;
				updatePlayer(blockDestroy.type);
				moveDown(blockDestroy.x,blockDestroy.y);
			}
		}

		public void updatePlayer(int typeBlock)
		{
			//Match.getInstance().turn

			//switch(typeBlock)
			//{


			//}
		}
		public void moveDown(int x, int y)
		{
			for(int i = y; i < 1; i--)
			{
				this.blocks[x,i] = this.blocks[x,i-1];
				//TODO : Update position game object
				listGameObject[x,i].y = i-1;
				//Add this block to list need check
				blockNeedChecks.Add(new BlockNeedCheck(x,i));
			}

			this.blocks[x,0] = generateBlockType();
			//TODO : Create game object
			this.generateBlockType(x,0,this.blocks[x,0]);
		}

		public void generateBlockType(int x, int y, int type)
		{
			listGameObject[x,y] = new BasicBlock(x,y,type);
			//set...
		}

		public int generateBlockType()
		{
			int typeBlock = UnityEngine.Random.Range(0,5);
			if ((typeBlock == 0) && (UnityEngine.Random.Range(0,100) < 11)) {
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
			int m;
			int i;
			bool opp = true;
			for (i = 0; i < 8; i++) {
				m = opp ? 1 : 0;// xen ke
				opp = !opp;//
				while (m < 8) {
					this.blocks[i,m] = UnityEngine.Random.Range(0,blockTypeList);//0->5.0
					this.generateBlockType(i,m,this.blocks[i,m]);
					m += 2;
				}
			}
			i = UnityEngine.Random.Range(0,3) + 2 + 2;
			m = UnityEngine.Random.Range(0,4) + 1 + 2;
			//Maybe default 7
			if (this.blocks[i,m] != 7) {
				i--;
			}
			int n = UnityEngine.Random.Range(0,4);
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
					break;
			}
			opp = false;
			// Random other, not match
			for (int i1 = 0; i1 < 8; i1++) {
				int i2 = opp ? 1 : 0;
				opp = !opp;//
				while (i2 < 8) {
					bool[] arrayOfBoolean = new bool[5];
					int i3 = this.blocks[i1,(i2 - 1)];
					int i4 = this.blocks[i1,(i2 - 2)];
					int i5 = this.blocks[i1,(i2 + 1)];
					int i6 = this.blocks[i1,(i2 + 2)];
					if (i3 == i4) {
						arrayOfBoolean[i3] = true;
					}
					if (i5 == i6) {
						arrayOfBoolean[i5] = true;
					}
					if (i5 == i3) {
						arrayOfBoolean[i3] = true;
					}
					int i7 = this.blocks[(i1 - 1),i2];
					int i8 = this.blocks[(i1 - 2),i2];
					int i9 = this.blocks[(i1 + 1),i2];
					int i10 = this.blocks[(i1 + 2),i2];
					if (i7 == i8) {
						arrayOfBoolean[i7] = true;
					}
					if (i9 == i10) {
						arrayOfBoolean[i9] = true;
					}
					if (i7 == i9) {
						arrayOfBoolean[i7] = true;
					}
					int i11 = UnityEngine.Random.Range(0,arrayOfBoolean.Length);
					if (arrayOfBoolean[i11]) {
						do {
							i11 = (i11 + 1) % arrayOfBoolean.Length;
						} while (arrayOfBoolean[i11]);
					}
					this.blocks[i1,i2] = i11;
					this.generateBlockType(i1,i2,i11);
					i2 += 2;
				}
			}
		}

		public BlockNeedCheck checkMatchAt(BlockNeedCheck block)
		{
			//check top ...
			return null;
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
			while (typeBlock == this.blocks[(x - numberBlock),y]) {
				numberBlock++;
				countMatch++;
			}

			numberBlock = 1;
			//Check right
			while (typeBlock == this.blocks[(x + numberBlock),y]) {
				numberBlock++;
				countMatch++;
			}

			return countMatch;
		}
	}
}

