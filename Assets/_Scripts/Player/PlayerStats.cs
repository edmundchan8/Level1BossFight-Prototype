using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour 
{
	int HEALTH_IMAGE_HEIGHT = 20;
	int MIN_HEALTH = 0;
	int MAX_HEALTH = 100;

	int m_PlayerHealth;
	[SerializeField]
	RectTransform m_HealthImage;

	int m_PlayerStrength = 10;
	int m_PlayerDefence = 10;

	void Start()
	{
		m_PlayerHealth = MAX_HEALTH;
		m_HealthImage.sizeDelta = new Vector2(m_PlayerHealth, HEALTH_IMAGE_HEIGHT);
		GameController.instance.SetPlayerPrefsHealth();
		//These two methods set the player strength and defence
		//These two should only be for when we start the game for the first time
		//Later on, when we load a saved state, we need to either call these first, then call the playerprefs ones
		//On on loading a saved state, ignore these and call the ones from the playerprefs.
		SetPlayerStrength();
		SetPlayerDefence();
	}

	public void OnPlayerHit(int damageAmount)
	{
		m_PlayerHealth -= damageAmount;
		if (m_PlayerHealth <= MIN_HEALTH)
		{
			PlayerDead();
			m_PlayerHealth = MIN_HEALTH;
		}
		SetPlayerHealth();
	}

	void OnHealthRecover(int recoverAmount) 
	{
		m_PlayerHealth += recoverAmount;
		if (m_PlayerHealth > MAX_HEALTH)
		{
			m_PlayerHealth = MAX_HEALTH;
		}
		SetPlayerHealth();
	}

	void SetPlayerHealth()
	{
		m_HealthImage.sizeDelta = new Vector2(m_PlayerHealth, HEALTH_IMAGE_HEIGHT);
		GameController.instance.SetPlayerPrefsHealth();
	}

	void SetPlayerStrength()
	{
		GameController.instance.SetPlayerPrefsStrength(m_PlayerStrength);
	}

	void SetPlayerDefence()
	{
		GameController.instance.SetPlayerPrefsDefence(m_PlayerDefence);
	}

	public int ReturnPlayerHealth()
	{
		return m_PlayerHealth;
	}

	public void PlayerDead()
	{
		Debug.Log("Player dead");
	}

	public void IncreasePlayerStrength(int increaseStrength)
	{
		m_PlayerStrength += increaseStrength;
		GameController.instance.SetPlayerPrefsStrength(m_PlayerStrength);
	}

	public void IncreasePlayerDefence(int increaseDefence)
	{
		m_PlayerDefence += increaseDefence;
	}

	public int ReturnPlayerStrength()
	{
		return m_PlayerStrength;
	}

	public int ReturnPlayerDefence()
	{
		return m_PlayerDefence;
	}
}
