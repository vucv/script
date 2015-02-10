using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameStage.getInstance().stage = Stage.MATCH;
	}

	// Update is called once per frame
	void Update () {
		switch(GameStage.getInstance().stage)
		{
		case Stage.MENU:
			break;
		case Stage.MAP:
			break;
		case Stage.MATCH:
			break;
		default:
			//Log err
			break;
		}
	}
}
