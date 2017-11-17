using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	public void SetPlayerPrefsHealth()
	{
		m_GameData.SavePlayerCurrentHealth(m_PlayerStats.ReturnPlayerHealth());
	}

	public Vector2 GetPlayerPos()
	{
		return m_Player.transform.position;
	}

	public void SetPlayerPrefsStrength(int strength)
	{
		m_GameData.SavePlayerCurrentStrength(strength);
	}

	public int ReturnPlayerStrength()
	{
		return m_GameData.GetPlayerCurrentStrength();
	}

	public void SetPlayerPrefsDefence(int defence)
	{
		m_GameData.SavePlayerCurrentDefence(defence);
	}

	public int ReturnPlayerDefence()
	{
		return m_GameData.GetPlayerCurrentDefence();
	}

	public PlayerAttack ReturnPlayerAttackScript()
	{
		return m_PlayerAttack;
	}
}
