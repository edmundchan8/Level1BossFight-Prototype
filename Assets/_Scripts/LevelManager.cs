using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour 
{
	public static LevelManager instance;
	float TIME_TILL_GAME_SCENE = 2f;

	void Awake()
	{
		if (!instance)
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
		
	void Update()
	{
		if (Time.time >= TIME_TILL_GAME_SCENE && SceneManager.GetActiveScene().buildIndex == 0)
		{
			print("loading");
			LoadLevel("Game");
		}
	}

	public void LoadLevel(string levelName)
	{
		SceneManager.LoadScene(levelName);
	}
}