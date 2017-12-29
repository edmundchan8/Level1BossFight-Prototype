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
	GameObject m_Boss;

	SpriteRenderer m_Sprite;

	[SerializeField]
	Animator m_BossAnimator;

	[SerializeField]
	int m_Damage;

	[SerializeField]
	float m_Speed;

	Vector2 m_Direction;

	void Start()
	{
		m_Sprite = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		if (m_ChargeAttempts > 0 && !m_ChargeTimer.Update(Time.deltaTime))
		{
			m_BossAnimator.SetBool("Crouch", true);
		}
		if (m_ChargeAttempts > 0 && m_ChargeTimer.Update(Time.deltaTime))
		{
			m_ChargeTimer.Set(m_ChargeDuration + m_MoveDuration);
			m_BossAnimator.SetBool("Crouch", false);
			//Charge at player
			m_ChargeAttempts--;
			Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
			Vector2 endPos = new Vector2(GameController.instance.ReturnPlayerPos().x, GameController.instance.ReturnPlayerPos().y);
			SetProjectileDirection(currentPos, endPos);
			m_MoveTimer.Set(m_MoveDuration);
			if (m_ChargeAttempts <= 0)
			{
				GameController.instance.ReturnBossDetect().SetAttacking(true);
			}
		}

		if (!m_MoveTimer.Update(Time.deltaTime))
		{
			if (m_BossAnimator.GetBool("Charge") == false)
			{
				m_BossAnimator.SetBool("Charge", true);
			}
			m_Boss.transform.Translate(m_Direction * m_Speed);
			Vector2 moveDirection = m_Direction * m_Speed;
			if(moveDirection.x < 0f)
			{
				m_Sprite.flipX = true;
			}
			else
			{
				m_Sprite.flipX = false;
			}
		}
		else
		{
			m_BossAnimator.SetBool("Charge", false);
		}

		m_Boss.transform.position = new Vector3(Mathf.Clamp(m_Boss.transform.position.x, -7f, 16f), Mathf.Clamp(m_Boss.transform.position.y, -85f, -64), m_Boss.transform.position.z);
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

	void OnTriggerEnter2D(Collider2D myCol)
	{
		if (myCol.gameObject.tag == "PlayerBody")
		{
			GameController.instance.ReturnPlayerStats().OnPlayerHit(m_Damage);
		}
	}
}
