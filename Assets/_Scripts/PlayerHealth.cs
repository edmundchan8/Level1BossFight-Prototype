using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour 
{
	int HEALTH_IMAGE_HEIGHT = 20;
	int MIN_HEALTH = 0;
	int MAX_HEALTH = 100;

	int m_PlayerHealth;
	[SerializeField]
	RectTransform m_HealthImage;

	void Start()
	{
		m_PlayerHealth = MAX_HEALTH;
		m_HealthImage.sizeDelta = new Vector2(m_PlayerHealth, HEALTH_IMAGE_HEIGHT);
		GameController.instance.SetPlayerPrefsHealth();
	}

	void OnPlayerHit(int damageAmount)
	{
		m_PlayerHealth -= damageAmount;
		if (m_PlayerHealth <= MIN_HEALTH)
		{
			PlayerDead();
			m_PlayerHealth = MIN_HEALTH;
		}
		SetPlayerHealth();
		ReturnPlayerHealth();
	}

	void OnHealthRecover(int recoverAmount) 
	{
		m_PlayerHealth += recoverAmount;
		if (m_PlayerHealth > MAX_HEALTH)
		{
			m_PlayerHealth = MAX_HEALTH;
		}
		SetPlayerHealth();
		ReturnPlayerHealth();
	}

	void SetPlayerHealth()
	{
		m_HealthImage.sizeDelta = new Vector2(m_PlayerHealth, HEALTH_IMAGE_HEIGHT);
		GameController.instance.SetPlayerPrefsHealth();
	}

	public int ReturnPlayerHealth()
	{
		return m_PlayerHealth;
	}

	public void PlayerDead()
	{
		Debug.Log("Player dead");
	}
}
