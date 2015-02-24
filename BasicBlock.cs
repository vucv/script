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
		Destroy (this.gameObject);
		switch(type)
		{
			case 0:
				break;
		}
	}
	// Update is called once per frame
	void Update () 
	{
		Vector3 fixPosition = new Vector3 (x * 0.84f - 2.95f, 3.9f - y * 0.84f, 0f);
		if (!Vector3.Equals (fixPosition, this.transform.position)) {
				this.transform.position = fixPosition;
		} else {
				RuntimePlatform platform = Application.platform;
				if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer) {
						if (Input.touchCount > 0) {
								if (checkTouch (Input.GetTouch (0).position)) {
										Block select1 = Hero.getInstance ().select1;
										if (select1 != null && Mathf.Abs (x - select1.x) + Mathf.Abs (y - select1.y) > 1) {
											Hero.getInstance ().select2 = new Block (x, y);
											Hero.getInstance ().moveSelectBlock ();
										} else {
											Hero.getInstance ().select1 = new Block (x, y);
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
							Debug.Log("Click 2: ("+x+","+y+")");
												} else {
														Hero.getInstance ().select1 = new Block (x, y);
							Debug.Log("Click 1: ("+x+","+y+")");
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
