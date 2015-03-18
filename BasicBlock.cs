using UnityEngine;
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
	public bool moving;
	Vector2 screenPoint;
	GameObject zoomfocus;

	public void init(int x, int y,int type)
	{
		this.x = x;
		this.y = y;
		this.type = type;
		//Create prefab
		this.transform.position = new Vector2(x*0.84f -2.95f, 3.9f - y*0.84f);
		this.gameObject.GetComponent<SpriteRenderer>().sprite = GameData.getInstance().sprites[type];
	}

	public void updatePosition(int x, int y)
	{
		this.x = x;
		this.y = y;
	}
	// Use this for initialization
	void Start () {
		speed = 1;
		swap = false;
	}
	public void destroysBlock()
	{
		string exploreType ="";
		if (Board.getInstance ().multiply < 2) {
			switch (this.type) {
				case 0:
					exploreType = "prefabs/explodesword";
					break;
				case 1:
					exploreType = "prefabs/exploderice";
					break;
				case 2:
					exploreType = "prefabs/explodegold";
					break;
				case 3:
					exploreType = "prefabs/explodeheart";
					break;
				case 4:
					exploreType = "prefabs/explodebook";
					break;
				case 5:
					exploreType = "prefabs/explodeyinyang";
					break;
				default:
					exploreType = "prefabs/explodesword";
				break;
			}
		} else {
			switch (this.type) {
				case 0:
					exploreType = "prefabs/explodesword";
					break;
				case 1:
					exploreType = "prefabs/explodericex2";
					break;
				case 2:
					exploreType = "prefabs/explodegoldx2";
					break;
				case 3:
					exploreType = "prefabs/explodeheartx2";
					break;
				case 4:
					exploreType = "prefabs/explodebookx2";
					break;
				case 5:
					exploreType = "prefabs/explodeyinyangx2";
					break;
				default:
					exploreType = "prefabs/explodesword";
				break;
			}
		}

		GameObject exploreBlock = (GameObject)GameObject.Instantiate (Resources.Load<GameObject> (exploreType));
		BasicBlockExplore scriptBlock = exploreBlock.GetComponent<BasicBlockExplore> ();
		scriptBlock.transform.position = this.transform.position;
		Destroy (this.gameObject);
	}

	public bool checkMoving()
	{
		GameObject [,] listGameObject = Board.getInstance ().listGameObject;
		foreach(GameObject block in listGameObject)
		{
			BasicBlock scriptBlock = block.GetComponent<BasicBlock> ();
			if(scriptBlock.moving)
				return false;
		}
		return true;

	}
	bool alreadyWaiting = false;
	IEnumerator wait(float time)
	{
		bool alreadyWaiting = true;
		yield return new WaitForSeconds(time);
		Board.getInstance ().isDetroying = false;
		alreadyWaiting = false;
	}
	// Update is called once per frame
	void Update () 
	{
		if (Board.getInstance ().isDetroying && !alreadyWaiting) {
			alreadyWaiting = true;
			StartCoroutine (wait (0.4f));
			return;
		} else if(Board.getInstance ().isDetroying) {
			return;
		}
		Vector3 fixPosition = new Vector3 (x * 0.84f - 2.95f, 3.9f - y * 0.84f, 0f);
		if (!Vector3.Equals(fixPosition, this.transform.position)) {
			if(zoomfocus)
			{
				Destroy (zoomfocus);
			}

			if(Vector3.Distance(fixPosition, this.transform.position) > 0.1f)
			{
				moving = true;
				Board.getInstance ().isMoving = true;
				Vector3 direction = fixPosition - this.transform.position;
				Vector3 newPosition = this.transform.position;
				if(this.transform.position.y != fixPosition.y)
					newPosition.y += 5f*Time.deltaTime *(direction.y>0?1:-1);
				if(this.transform.position.x != fixPosition.x)
					newPosition.x += 5f*Time.deltaTime *(direction.x>0?1:-1);
				this.transform.position = newPosition;							
			}
			else
			{
				moving = false;
				this.transform.position = fixPosition;
				if(checkMoving())
				{
					Board.getInstance ().isMoving = false;
				}
			}
		} else {
			if (Board.getInstance ().processing) 
			{
				return;
			}
			RuntimePlatform platform = Application.platform;
			if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer) {
				if (Input.touchCount > 0) {
					if (Input.touchCount > 0) {
						if (Input.GetTouch (0).phase == TouchPhase.Began) {
							Debug.Log ("Move down: " + Input.mousePosition);
							screenPoint = Input.GetTouch (0).position;
							if (checkTouch (Input.GetTouch (0).position)) {
								Hero.getInstance ().select1 = new Block (x, y);
								zoomfocus = (GameObject)GameObject.Instantiate (Resources.Load<GameObject> ("prefabs/zoomfocus"));
								zoomfocus.transform.position = this.transform.position;
							}
						}
						if(Input.GetTouch (0).phase == TouchPhase.Moved)
						{
							Vector2 curScreenPoint = Input.GetTouch (0).position - screenPoint;
							if(Vector2.Distance(Vector2.zero,curScreenPoint) < 80.0f)
								return;
							Debug.Log ("Drag: " + Input.GetTouch (0).position);
							//Block select1 = Hero.getInstance ().select1;
							//if (select1 != null && (Mathf.Abs (x - select1.x) + Mathf.Abs (y - select1.y)) == 1) {
							int moveX = 0;
							int moveY = 0;
							if (Mathf.Abs (curScreenPoint.x) > Mathf.Abs (curScreenPoint.y)) 
							{
								moveX = curScreenPoint.x > 0? 1 : -1;
							} 
							else 
							{
								moveY = curScreenPoint.y > 0? -1 : 1;
							}
							
							Hero.getInstance ().select2 = new Block (Hero.getInstance ().select1.x + moveX, Hero.getInstance ().select1.y + moveY);
							Hero.getInstance ().moveSelectBlock ();
						}
					}
				}
			}
			else if (platform == RuntimePlatform.WindowsEditor) {
				if (Input.GetMouseButtonDown (0)) {
					if (checkTouch (Input.mousePosition)) {
						Block select1 = Hero.getInstance ().select1;
						if (select1 != null && (Mathf.Abs (x - select1.x) + Mathf.Abs (y - select1.y)) == 1) {
							Hero.getInstance ().select2 = new Block (x, y);
							
							Hero.getInstance ().moveSelectBlock ();
							//Debug.Log("Click 2: ("+x+","+y+")");
						} else {
							Hero.getInstance ().select1 = new Block (x, y);
							zoomfocus = (GameObject)GameObject.Instantiate (Resources.Load<GameObject> ("prefabs/zoomfocus"));
							zoomfocus.transform.position = this.transform.position;
						}
					}
				}
			}
		}
	}


	bool checkTouch(Vector3 pos){
		Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
		Vector2 touchPos = new Vector2(wp.x, wp.y);
		return collider2D == Physics2D.OverlapPoint(touchPos);
	}
}
