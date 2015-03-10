using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class MainGame : MonoBehaviour {

	bool alreadyWaiting  = false;
	// Use this for initialization
	void Start () {
		GameStage.getInstance().stage = Stage.MATCH;
	}

	// Update is called once per frame
	void Update () {


		if (!alreadyWaiting) 
		{
			switch (GameStage.getInstance ().stage) {
			case Stage.MENU:
					break;
			case Stage.MAP:
					break;
			case Stage.MATCH:
					Match.getInstance ().Update ();
					break;
			default:
			//Log err
					break;
			}

			if (Board.getInstance ().processing) 
			{
				StartCoroutine (wait (1f));
			}
		}
		

	}
	
	IEnumerator wait(float time)
	{
		alreadyWaiting = true;
		yield return new WaitForSeconds(time);
		alreadyWaiting = false;
	}
	
	
}
