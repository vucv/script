using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
namespace AssemblyCSharp
{
	public class Board
	{
		//Board
		public bool isMoving = false;
		public bool isDetroying = false;
		public bool processing = false;
		int [,] blocks;
		List<BlockNeedCheck> blockNeedChecks;
		List<BlockNeedDestroy> blockNeedDestroys;
		List<BlockCanMove> blockCanMoves;
		public GameObject [,] listGameObject;
		public int multiply;
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
			listGameObject = new GameObject[8, 8];
			this.blocks = new int[8,8];

				for (int i = 0; i < 8; i++) {
					for (int j = 0; j < 8; j++) {
						this.blocks[i,j] = -1;
				}
				}

		}

		public void moveBlock(int x1, int y1, int x2, int y2)
		{
			if(this.blocks[x1,y1] == this.blocks[x2,y2]) return;
			this.swapBlock(x1,y1,x2,y2);
			blockNeedChecks.Add(new BlockNeedCheck(x1,y1));
			blockNeedChecks.Add(new BlockNeedCheck(x2,y2));

			//Call check ...
			multiply = 1;
			processing = true;
			isMoving = true;
			processBlocks ();
		}

		public void processBlocks()
		{

			if (isMoving || isDetroying)
				return;
			checkMatch();
			destroysBlock();

			if (blockNeedChecks.Count == 0) {
				multiply = 1;
				processing = false;

				Match.getInstance().changeTurn();
				updateListCanMove ();
			}
			else
			{
				multiply++;
			}

		}

		public void updateListCanMove()
		{
		    blockCanMoves.Clear ();
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

		public void checkAllBlock()
		{
			for (int i = 0; i < 8; i++) {
				for (int j = 0; j < 8; j++) {
					blockNeedChecks.Add(new BlockNeedCheck(i,j));
				}
			}
		}


		private BlockCanMove checkCanMove(int x1, int y1, int x2, int y2) {
			if(this.blocks[x1,y1] == this.blocks[x1,y1]
			{
			    return null;
			}

			if(x2 > 8 || y2 >8)
            {
                return null;
            }

            //swap
            this.swapBlock(x1,y1,x2,y2);

            BlockNeedCheck block1 = new BlockNeedCheck(x1,y1));
            BlockNeedCheck block2 = new BlockNeedCheck(x2,y2));

            int H1 = block1.left + block1.right -1;
            int V1 = block1.top + block1.bottom -1;

            int H2 = block2.left + block2.right -1;
            int V2 = block2.top + block2.bottom -1;
            int point = 0;
            if(V1 > 3 || H1 > 3)
            {
                point+=1;
            }

            if(V1 > 3 || H1 > 3)
            {
                point+=1;
            }

            if(H1>4 || V1>4 )
            {
               point+=1;
            }

            if(H2>4 || V2>4 )
            {
               point+=1;
            }

            if(H1>5 || V1>5 )
            {
               point+=1;
            }

            if(H2>5 || V2>5 )
            {
               point+=1;
            }


            //Re swap
            this.swapBlock(x1,y1,x2,y2);
            if(point > 0)
            {
                BlockCanMove blockCanMove = new BlockCanMove();
                blockCanMove.x1 = x1;
                blockCanMove.y1 = y1;
                blockCanMove.x2 = x2;
                blockCanMove.y2 = y2;
                blockCanMove.point = point;

                return blockCanMove;
            }
            else
            {
                return null;
            }
		}

		private void swap(int x1, int y1, int x2, int y2)
		{
		    int temp = this.blocks[x1,y1];
            this.blocks[x1,y1] = this.blocks[x2,y2];
            this.blocks[x2,y2] = temp;
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
				int H = block.left + block.right -1;
				int V = block.top + block.bottom -1;
				int j = 0;
				if(H >=3)
				{
					j = block.left -1;
					while (j>0)
					{
						blockNeedDestroys.Add(new BlockNeedDestroy(block.x-j,block.y));
						j--;
					}
					j = block.right -1;
					while (j>0)
					{
						blockNeedDestroys.Add(new BlockNeedDestroy(block.x+j,block.y));
						j--;
					}
				}

				if(V >=3)
				{
					j = block.top -1;
					while (j>0)
					{
						blockNeedDestroys.Add(new BlockNeedDestroy(block.x,block.y-j));
						j--;
					}
					j = block.bottom -1;
					while (j>0)
					{
						blockNeedDestroys.Add(new BlockNeedDestroy(block.x,block.y+j));
						j--;
					}
				}

				if(V >=3 || H >= 3)
				{
					blockNeedDestroys.Add(new BlockNeedDestroy(block.x,block.y));
				}

				if(H>4 || V>4)
				{
					//scores.turn ++;
				}
			}
			//Clean list need check
			blockNeedChecks.Clear ();
		}

        private void swordRedExplore(int x, int y)
        {
            int countX = blockDestroy.x > 1: blockDestroy.x: 0;
            int countY = blockDestroy.y > 1: blockDestroy.y: 0;

            for(int i = countX; i<3 || countX <8; i++ )
            {
                for(int j = countY; j<3 || countY <8; j++ )
                {
                    blockNeedDestroys.Add(new BlockNeedDestroy(i,j));
                    countY++;
                }
                countX++;
            }
        }

		public void destroysBlock()
		{
			//blockNeedDestroys.Sort();
			//Get list destroys , add scores
			for(int i = 0; i< blockNeedDestroys.Count; i++)
			{
				//TODO : Destroy game object & create effect
				BlockNeedDestroy blockDestroy = blockNeedDestroys[i];

				BasicBlock scriptBlock = listGameObject [blockDestroy.x,blockDestroy.y].GetComponent<BasicBlock> ();
				scriptBlock.destroysBlock();
				this.blocks[blockDestroy.x,blockDestroy.y] = -1;

				if(scriptBlock.type == 6)
				{
				    swordRedExplore(blockDestroy.x,blockDestroy.y);
				}
				isDetroying = true;
				isMoving = true;
			}

            blockNeedDestroys.Sort();
			for(int i = 0; i< blockNeedDestroys.Count; i++)
			{
				BlockNeedDestroy blockDestroy = blockNeedDestroys[i];
				updatePlayer(blockDestroy.type);
				if(this.blocks[blockDestroy.x,blockDestroy.y] == -1)
				{
					moveDown(blockDestroy.x,blockDestroy.y);
				}
			}
			if(blockNeedDestroys.Count != 0)
			{
				checkAllBlock();
			}
			blockNeedDestroys.Clear ();
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

			for(int i = y; i > 0; i--)
			{
				this.blocks[x,i] = this.blocks[x,i-1];
				//TODO : Update position game object
				listGameObject [x, i] = listGameObject [x, i-1];
				BasicBlock scriptBlock = listGameObject [x, i].GetComponent<BasicBlock> ();
				scriptBlock.updatePosition (x,i);
			}

			int newTypeBlock = generateBlockType();
			this.blocks[x,0] = newTypeBlock == 6? 0: newTypeBlock;
			//TODO : Create game object
			this.generateBlockTypeAt(x,0,newTypeBlock);
		}

		public void generateBlockTypeAt(int x, int y, int type)
		{

			listGameObject[x,y] = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("prefabs/BlockBasic"));
			BasicBlock scriptBlock = listGameObject [x, y].GetComponent<BasicBlock> ();
			scriptBlock.init(x,y,type);

			BasicBlock scriptBlockBelow = listGameObject [x, 1].GetComponent<BasicBlock> ();
			float fixPositionY = scriptBlockBelow.transform.position.y + 0.84f;
			if (fixPositionY < 4f)
				fixPositionY += 0.84f;
			scriptBlock.transform.position = new Vector3 (x * 0.84f - 2.95f, fixPositionY, 0f);
			//set...
		}

		public void generateBlockType(int x, int y, int type)
		{

			listGameObject[x,y] = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("prefabs/BlockBasic"));
			BasicBlock scriptBlock = listGameObject [x, y].GetComponent<BasicBlock> ();
			scriptBlock.init(x,y,type);
			//set...
		}

		public int generateBlockType()
		{
			int typeBlock = UnityEngine.Random.Range(0,6);
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


			BasicBlock scriptBlock = listGameObject [x1, y1].GetComponent<BasicBlock> ();
			scriptBlock.updatePosition (x2,y2);
			BasicBlock scriptBlock1 = listGameObject [x2, y2].GetComponent<BasicBlock> ();
			scriptBlock1.updatePosition (x1,y1);

			GameObject tempObject = listGameObject [x1, y1];
			listGameObject [x1, y1] = listGameObject [x2, y2];
			listGameObject [x2, y2] = tempObject;

		}

		public void generateBoard()
		{
			int blockTypeList = 6;
			int m;
			int i;
			bool opp = true;
			for (i = 0; i < 8; i++) {
				m = opp ? 1 : 0;// xen ke
				opp = !opp;//
				while (m < 8) {
					this.blocks[i,m] = UnityEngine.Random.Range(0,blockTypeList);//0->5.0
					//this.generateBlockType(i,m,this.blocks[i,m]);
					m += 2;
				}
			}

			i = UnityEngine.Random.Range(0,3) + 2 + 2;
			m = UnityEngine.Random.Range(0,4) + 1 + 2;
			//Maybe default 7
			if (this.blocks[i,m] != -1) {
				i--;
			}
			int n = UnityEngine.Random.Range(0,3);
			Debug.Log(i +"/"+m+"/"+ n);
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
					bool[] arrayOfBoolean = new bool[blockTypeList];
					int i3,i4,i5,i6,i7,i8,i9,i10;
					if(i2 > 1)
						 i3 = this.blocks[i1,(i2 - 1)];
					else i3 = -1;

					if(i2 > 2)
						 i4 = this.blocks[i1,(i2 - 2)];
					else  i4 = -1;

					if(i2 < 7)
						 i5 = this.blocks[i1,(i2 + 1)];
					else  i5 = -1;

					if(i2 < 6)
						 i6 = this.blocks[i1,(i2 + 2)];
					else  i6 = -1;

					if (i3 != -1 && i3 == i4) {
						arrayOfBoolean[i3] = true;
					}
					if (i5 != -1 && i5 == i6) {
						arrayOfBoolean[i5] = true;
					}
					if (i3 != -1 && i5 == i3) {
						arrayOfBoolean[i3] = true;
					}

					if(i1 > 1)
						 i7 = this.blocks[(i1 - 1),i2];
					else  i7 = -1;

					if(i1 > 2)
						 i8 = this.blocks[(i1 - 2),i2];
					else  i8 = -1;

					if(i1 < 7)
						 i9 = this.blocks[(i1 + 1),i2];
					else  i9 = -1;

					if(i1 < 6)
						 i10 = this.blocks[(i1 + 2),i2];
					else  i10 = -1;

					if (i7 != -1 && i7 == i8) {
						arrayOfBoolean[i7] = true;
					}
					if (i9 != -1 && i9 == i10) {
						arrayOfBoolean[i9] = true;
					}
					if (i7 != -1 && i7 == i9) {
						arrayOfBoolean[i7] = true;
					}
					int i11 = UnityEngine.Random.Range(0,blockTypeList);
					if (arrayOfBoolean[i11]) {
						do {
							i11 = (i11 + 1) % arrayOfBoolean.Length;
						} while (arrayOfBoolean[i11]);
					}
					this.blocks[i1,i2] = i11;
					//this.generateBlockType(i1,i2,i11);
					i2 += 2;
				}
			}

			for (i = 0; i < 8; i++) {
				for (int j = 0; j < 8; j++) {
					this.generateBlockType(i,j,this.blocks[i,j]);
				}
			}
		}

		public void checkMatchAt(BlockNeedCheck block)
		{
			//check top ...
			checkMatchVertical(block);
			checkMatchHorizontal(block);
		}

		//check match V
		public int checkMatchVertical(BlockNeedCheck block) {
			int x = block.x;
			int y = block.y;

			int countMatch = 1;
			int numberBlock = 1;
			int typeBlock = this.blocks[x,y];

			//Check bot
			while (y >= numberBlock && typeBlock == this.blocks[x,(y - numberBlock)]) {
				numberBlock++;
				countMatch++;
			}
			block.top = numberBlock;
			numberBlock = 1;

			//Check top
			while ((y + numberBlock) < 8 && typeBlock == this.blocks[x,(y + numberBlock)]) {
				numberBlock++;
				countMatch++;
			}
			block.bottom = numberBlock;
			return countMatch;
		}

		//check match H
		public int checkMatchHorizontal(BlockNeedCheck block) {
			int x = block.x;
			int y = block.y;
			int countMatch = 1;
			int numberBlock = 1;
			int typeBlock = this.blocks[x,y];

			//Check left
			while (x >= numberBlock && typeBlock == this.blocks[(x - numberBlock),y]) {
				numberBlock++;
				countMatch++;
			}
			block.left = numberBlock;
			numberBlock = 1;

			//Check right
			while ((x + numberBlock) < 8 && typeBlock == this.blocks[(x + numberBlock),y]) {
				numberBlock++;
				countMatch++;
			}
			block.right = numberBlock;
			return countMatch;
		}
	}
}

