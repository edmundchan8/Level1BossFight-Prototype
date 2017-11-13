using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	[SerializeField]
	GameObject m_Player;
	[SerializeField]
	GameObject m_SaveButton;
	[SerializeField]
	GameData m_GameData;

	public static GameController instance;

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

	public Vector3 ReturnPlayerPos()
	{
		return new Vector3(m_Player.transform.localPosition.x, m_Player.transform.localPosition.y, 0f);
	}

	public void OnPlayerHome()
	{
		m_SaveButton.SetActive(true);
	}

	public void OnPlayerLeftHome()
	{
		m_SaveButton.SetActive(false);
	}

	public int GetPlayerHealth()
	{
		return m_GameData.GetPlayerPrefsHealth();
	}

	public Vector2 GetPlayerPos()
	{
		return m_Player.transform.position;
	}
}
