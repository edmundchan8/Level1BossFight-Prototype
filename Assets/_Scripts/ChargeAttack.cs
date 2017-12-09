using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAttack : MonoBehaviour 
{
	Timer m_ChargeTimer = new Timer();
	Timer m_MoveTimer = new Timer();
	[SerializeField]
	float m_ChargeDuration;
	[SerializeField]
	float m_MoveDuration;
	[SerializeField]
	int m_ChargeAttempts = 0;
	int MIN_ATTEMPTS = 1;
	int MAX_ATTEMPTS = 3;

	void Update()
	{
		if (m_ChargeAttempts > 0 && m_ChargeTimer.Update(Time.deltaTime))
		{
			//Charge at player
			Debug.Log("Can Charge");
			m_ChargeAttempts--;
			Debug.Log("Charge Attempts = " + m_ChargeAttempts);
			m_ChargeTimer.Set(m_ChargeDuration);
		}
	}

	public void StartChargeAttack()
	{
		m_ChargeTimer.Set(m_ChargeDuration);
		m_ChargeAttempts = Random.Range(MIN_ATTEMPTS, MAX_ATTEMPTS);
	}
}
