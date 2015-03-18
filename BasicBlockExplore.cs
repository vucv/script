using UnityEngine;
using System.Collections;

public class BasicBlockExplore : MonoBehaviour {

	public Sprite[] listSprites;
	float startTime = Time.time;
	int frame = 0;
	// Use this for initialization
	void Start () {
		this.GetComponent<SpriteRenderer>().sprite = listSprites[0];
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - startTime > 0.1f) 
		{
			startTime = Time.time;
			frame ++;
			if(frame < listSprites.Length)
			{
				this.GetComponent<SpriteRenderer>().sprite = listSprites[frame];
			}
			else
			{
				Destroy (this.gameObject);
			}
		}
	}
}
