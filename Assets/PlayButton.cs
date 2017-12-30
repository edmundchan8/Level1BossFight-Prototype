using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour 
{
	void Start() 
	{
		StartCoroutine("StartGame");
	}

	IEnumerator StartGame()
	{
		yield return new WaitUntil(() => Input.GetKey(KeyCode.Return));
		LevelManager.instance.StartNewGame();
	}
}
