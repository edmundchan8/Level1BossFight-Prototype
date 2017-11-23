using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	[Header ("Player")]
	[SerializeField]
	GameObject m_Player;
	[SerializeField]
	PlayerStats m_PlayerStats;
	[SerializeField]
	PlayerAttack m_PlayerAttack;

	[Header("Save Data")]
	[SerializeField]
	GameObject m_SaveButton;
	[SerializeField]
	GameData m_GameData;

	[Header("UI")]
	[SerializeField]
	Warning m_WarningScript;
	[SerializeField]
	BackPackScript m_BackPack;

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
		
	public GameData ReturnGameData()
	{
		return m_GameData;
	}

	public PlayerStats ReturnPlayerStats()
	{
		return m_PlayerStats;
	}

	public PlayerAttack ReturnPlayerAttackScript()
	{
		return m_PlayerAttack;
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

	public Warning ReturnWarningScript()
	{
		return m_WarningScript;
	}

	public BackPackScript ReturnBackPack()
	{
		return m_BackPack;
	}
}