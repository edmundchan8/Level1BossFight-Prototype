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

	[SerializeField]
	float m_Speed;

	Vector2 m_Direction;

	void Update()
	{
		if (m_ChargeAttempts > 0 && m_ChargeTimer.Update(Time.deltaTime))
		{
			//Charge at player
			m_ChargeAttempts--;
			m_ChargeTimer.Set(m_ChargeDuration);
			Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
			Vector2 endPos = new Vector2(GameController.instance.ReturnPlayerPos().x, GameController.instance.ReturnPlayerPos().y);
			SetProjectileDirection(currentPos, endPos);
			m_MoveTimer.Set(m_MoveDuration);
		}

		if (!m_MoveTimer.Update(Time.deltaTime))
		{
			transform.Translate(m_Direction * m_Speed, Space.World);
		}
	}

	public void StartChargeAttack()
	{
		m_ChargeTimer.Set(m_ChargeDuration);
		m_ChargeAttempts = Random.Range(MIN_ATTEMPTS, MAX_ATTEMPTS);
	}

	public void SetProjectileDirection(Vector2 currentPos, Vector2 endPos)
	{
		m_Direction = (endPos - currentPos).normalized;
	}
}
