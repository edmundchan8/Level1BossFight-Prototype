using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour 
{
	public static LevelManager instance;
	float LOAD_NEXT_SCENE_DURATION = 2f;
	public static int m_CurrentSceneCount;
	GameObject m_Instructions;

	void Awake()
	{
		if (!instance)
		{
			instance = this;
		}
		else
		{
			Destroy(this.gameObject);
		}
	}

	void Start()
	{
		if (SceneManager.GetActiveScene().buildIndex == 0)
		{
			StartCoroutine("LoadTitle");
		}
		if (SceneManager.GetActiveScene().buildIndex == 2)
		{
			Debug.Log("GameLevel loaded");
			m_Instructions = GameObject.FindGameObjectWithTag("instructions");
			m_Instructions.SetActive(false);
			StartCoroutine("ReloadScene");
			StartCoroutine("LoadWin");
		}
	}

	void Update()
	{
		if (m_CurrentSceneCount == 1 && SceneManager.GetActiveScene().buildIndex == 2)
		{
			Debug.Log("Reset Text");
			m_Instructions.SetActive(true);
			GameController.instance.ReturnGameData().ResetTextPlayerPrefs();
		}
		m_CurrentSceneCount = SceneManager.GetActiveScene().buildIndex;
	}

	IEnumerator LoadTitle()
	{
		yield return new WaitForSeconds(LOAD_NEXT_SCENE_DURATION);
		LoadLevel("Title");
	}

	IEnumerator ReloadScene()
	{
		yield return new WaitUntil(() => GameController.instance.ReturnGameOverPanel().GameOver());
		Debug.Log("Should reload Scene");
		yield return new WaitForSeconds(LOAD_NEXT_SCENE_DURATION);
		LoadLevel("Game");
	}

	IEnumerator LoadWin()
	{
		yield return new WaitUntil(() => GameController.instance.ReturnGameOverPanel().Win());
		Debug.Log("Should start loading win scene");
		yield return new WaitForSeconds(LOAD_NEXT_SCENE_DURATION);
		Debug.Log("This should load the win scene");
	}

	public void LoadLevel(string levelName)
	{
		SceneManager.LoadScene(levelName);
	}

	public void StartNewGame()
	{
		SceneManager.LoadScene("Game");
	}
}