using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicBlock: MonoBehaviour{
	public int speed;
	public int x;
	public int y;
	public int type;
	public bool isSelected;
	public bool swap;
	// Use this for initialization
	void Start () {
		speed = 1;
		swap = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 fixPosition = new Vector3 (x * 0.84f - 2.95f, 3.9f - y * 0.84f, 0f);
		if(!Vector3.Equals(fixPosition, this.transform.position))
		{
			this.transform.position = fixPosition;
		}
		else if(swap)
		{
			List<GameObject> checkSwap1 = GameData.swapBlock1.checkMatch();
			List<GameObject> checkSwap2 = this.checkMatch();

			if(checkSwap1.Count > 1 || checkSwap2.Count > 1)
			{
				//checkSwap1.Add (this);
				//checkSwap1.Add(


			}
			else
			{
				swapFunction(this.x,this.y,GameData.swapBlock1.x,GameData.swapBlock1.y);
			}
			GameData.swapBlock1 = null;
			swap = false;
		}
		else
		{
			RuntimePlatform platform = Application.platform;
			if( platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer){
				if(Input.touchCount > 0) {
					if(checkTouch(Input.GetTouch(0).position)){
						if(GameData.swapBlock1 != null) 
						{
							BasicBlock oldSelect = GameData.swapBlock1;
							if(Mathf.Abs(x- oldSelect.x) + Mathf.Abs(y- oldSelect.y) >1)
							{
								GameData.focusSelected.SetActive(true);
								GameData.focusSelected.transform.position = this.transform.position;
								GameData.swapBlock1 = this;
							}
							else if(x != oldSelect.x || y != oldSelect.y)
							{
								swapFunction(this.x,this.y,GameData.swapBlock1.x,GameData.swapBlock1.y);
								swap = true;
								GameData.focusSelected.SetActive(false);
							}
						}
						else
						{
							GameData.focusSelected.SetActive(true);
							GameData.focusSelected.transform.position = this.transform.position;
							GameData.swapBlock1 = this;
						}
					}
				}
			}else if(platform == RuntimePlatform.WindowsEditor){
				if(Input.GetMouseButtonDown(0)) {
					if(checkTouch(Input.mousePosition)){
						if(GameData.swapBlock1 != null) 
						{
							BasicBlock oldSelect = GameData.swapBlock1;
							if(Mathf.Abs(x- oldSelect.x) + Mathf.Abs(y- oldSelect.y) >1)
							{
								GameData.focusSelected.SetActive(true);
								GameData.focusSelected.transform.position = this.transform.position;
								GameData.swapBlock1 = this;
							}
							else if(x != oldSelect.x || y != oldSelect.y)
							{
								swapFunction(this.x,this.y,GameData.swapBlock1.x,GameData.swapBlock1.y);
								swap = true;
								GameData.focusSelected.SetActive(false);

							}
						}
						else
						{
							GameData.focusSelected.SetActive(true);
							GameData.focusSelected.transform.position = this.transform.position;
							GameData.swapBlock1 = this;
						}
						Debug.Log("Select "+type+"/"+GameData.board[x,y]+"/"+GameData.blocks[x,y].GetComponent<BasicBlock>().type);
					}
				}
			}
		}

	}

	void swapFunction(int x1, int y1,int x2,int y2)
	{
		this.x = x2;
		this.y = y2;
		GameData.swapBlock1.x = x1;
		GameData.swapBlock1.y = y1;

		GameObject tempBlock = GameData.blocks[x1,y1];
		GameData.blocks [x1, y1] = GameData.blocks [x2, y2];
		GameData.blocks [x2, y2] = tempBlock;

		int tempBoard = GameData.board[x1,y1];
		GameData.board [x1, y1] = GameData.board [x2, y2];
		GameData.board [x2, y2] = tempBoard;
	}

	List<GameObject> checkMatch()
	{
		List<GameObject> listDetroysV = new List<GameObject> (); 
		//Check swap 1
		for (int i = 1; i<3&&(x+i)<8; i++) 
		{
			//Debug.Log(listDetroysV.Count+":Check swap V "+type+""+GameData.board[x+i,y]);
			if(type == GameData.board[x+i,y])
			{
				listDetroysV.Add(GameData.blocks[x+i,y]);
			}
			else
			{
				break;
			}
		}

		for (int i = 1; i<3&&(x-i)>=0; i++) 
		{
			//Debug.Log(listDetroysV.Count+":Check swap V "+type+""+GameData.board[x-i,y]);
			if(type == GameData.board[x-i,y])
			{
				listDetroysV.Add(GameData.blocks[x-i,y]);
			}
			else
			{
				break;
			}
		}
		Debug.Log("listDetroysV.Count "+ listDetroysV.Count);
		if (listDetroysV.Count < 2) listDetroysV.Clear();

		List<GameObject> listDetroysH = new List<GameObject> (); 
		//Check swap 1
		for (int i = 1; i<3&&(y+i)<8; i++) 
		{
			//Debug.Log(listDetroysH.Count+":Check swap H "+type+""+GameData.board[x,y+i]);
			if(type == GameData.board[x,y+i])
			{
				listDetroysH.Add(GameData.blocks[x,y+i]);
			}
			else
			{
				break;
			}
		}
		
		for (int i = 1; i<3&&(y-i)>=0; i++) 
		{
			//Debug.Log(listDetroysH.Count+":Check swap H "+type+""+GameData.board[x,y-i]);
			if(type == GameData.board[x,y-i])
			{
				listDetroysH.Add(GameData.blocks[x,y-i]);
			}
			else
			{
				break;
			}
		}
		Debug.Log("listDetroysH.Count "+ listDetroysH.Count);
		if (listDetroysH.Count < 2) listDetroysH.Clear ();
		listDetroysH.AddRange(listDetroysV);
		Debug.Log("listDetroysALL.Count "+ listDetroysH.Count);
		return listDetroysH;
	}

	bool checkTouch(Vector3 pos){
		Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
		Vector2 touchPos = new Vector2(wp.x, wp.y);
		return collider2D == Physics2D.OverlapPoint(touchPos);
	}

	public void init(int x, int y, int type)
	{
		this.type = type;
		this.x = x;
		this.y = y;
		this.transform.position = new Vector2(x*0.84f -2.95f, 3.9f - y*0.84f);
		this.gameObject.GetComponent<SpriteRenderer>().sprite = GameData.sprites[type - 1];
	}
}
