﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class BasicBlock: MonoBehaviour{
	public int speed;
	public int x;
	public int y;
	public int type;
	public bool isSelected;
	public bool swap;

	public BasicBlock(int x, int y,int type)
	{
		this.x = x;
		this.y = y;
		this.type = type;
		//Create prefab
	}
	}
	// Use this for initialization
	void Start () {
		speed = 1;
		swap = false;
	}
	public void destroysBlock()
	{
		switch(type)
		{
			case 0:
				break;
		}
	}
	// Update is called once per frame
	void Update () {
		Vector3 fixPosition = new Vector3 (x * 0.84f - 2.95f, 3.9f - y * 0.84f, 0f);
		if(!Vector3.Equals(fixPosition, this.transform.position))
		{
			this.transform.position = fixPosition;
		}
		else
		{
			RuntimePlatform platform = Application.platform;
			if( platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer){
				if(Input.touchCount > 0) {
					if(checkTouch(Input.GetTouch(0).position)){
						Block select1 = Hero.getInstance().select1;
						if(select1 && Mathf.Abs(x- select1.x) + Mathf.Abs(y- select1.y) >1)
						{
							Hero.getInstance().select2 = new Block(x, y);
							Hero.getInstance().moveSelectBlock();
						}
						else
						{
							Hero.getInstance().select1 = new Block(x, y);
						}
				}
			}else if(platform == RuntimePlatform.WindowsEditor){
				if(Input.GetMouseButtonDown(0)) {
					if(checkTouch(Input.mousePosition)){
						Block select1 = Hero.getInstance().select1;
						if(select1 && Mathf.Abs(x- select1.x) + Mathf.Abs(y- select1.y) >1)
						{
							Hero.getInstance().select2 = new Block(x, y);
							Hero.getInstance().moveSelectBlock();
						}
						else
						{
							Hero.getInstance().select1 = new Block(x, y);
						}
					}
				}
			}
		}

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
