using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour 
{
	[SerializeField]
	SpriteRenderer m_Attack;
	[SerializeField]
	CapsuleCollider2D m_AttackCollider;
	[SerializeField]
	Animator m_PlayerAttackAnimator;

	Timer m_SlashTimer = new Timer();
	float SLASH_DURATION = 0.15f;

	GameData m_GameData;

	void Start()
	{
		m_GameData = GameController.instance.ReturnGameData();

	}

	void Update()
	{
		if (Input.GetButtonDown("Attack"))
		{
			SetAttackingAnimDirection();
			m_Attack.enabled = true;
			m_AttackCollider.enabled = true;
			m_SlashTimer.Set(SLASH_DURATION);
		}

		if(m_SlashTimer.Update(Time.deltaTime))
		{
			m_Attack.enabled = false;
			m_AttackCollider.enabled = false;
		}
	}

	void OnTriggerEnter2D(Collider2D myCol)
	{
		if (myCol.gameObject.tag == "Enemy")
		{
			EnemyStats enemyHP = myCol.gameObject.GetComponent<EnemyStats>();
			enemyHP.TakeDamage(m_GameData.GetPlayerCurrentStrength());
		}
	}

	public bool PlayerAttacking()
	{
		return m_Attack.isVisible;
	}

	void SetAttackingAnimDirection()
	{
		//Vector2 direction = GameController.instance.ReturnPlayerMoveScript().ReturnFacingDirection();
		m_PlayerAttackAnimator.SetTrigger("IsAttackHorizontal");
	}
}