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

	Vector2 m_SlashUpVector = new Vector2(0, 0.75f);
	Vector2 m_SlashDownVector = new Vector2(0, -0.75f);
	Vector2 m_SlashHorizontalVector = new Vector2(0.5f, 0);

	Quaternion m_SlashUpRot = Quaternion.Euler (0,0,90);
	Quaternion m_SlashDownRot = Quaternion.Euler(0,0,270);
	Quaternion m_SlashHorizontalRot = Quaternion.Euler(0,0,0);


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
		}
		else
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
		Vector2 direction = GameController.instance.ReturnPlayerMoveScript().ReturnFacingDirection();

		if (direction == Vector2.up)
		{
			m_PlayerAttackAnimator.SetTrigger("IsAttackUp");
			SetSlashPos(m_SlashUpVector);
			SetSlashRot(m_SlashUpRot);
		}
		else if (direction == Vector2.down)
		{
			m_PlayerAttackAnimator.SetTrigger("IsAttackDown");
			SetSlashPos(m_SlashDownVector);
			SetSlashRot(m_SlashDownRot);
		}
		else
		{
			m_PlayerAttackAnimator.SetTrigger("IsAttackHorizontal");
			SetSlashPos(m_SlashHorizontalVector);
			SetSlashRot(m_SlashHorizontalRot);
		}
	}

	Vector2 SetSlashPos(Vector2 pos)
	{
		return transform.localPosition = pos;
	}

	Quaternion SetSlashRot(Quaternion rot)
	{
		return transform.localRotation = rot;
	}

}