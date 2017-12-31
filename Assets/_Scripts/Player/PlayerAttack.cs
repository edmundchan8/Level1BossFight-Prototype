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

	Vector3 SLASH_UP = new Vector3(0, 0.75f, 0);
	Quaternion SLASH_ROT_UP = Quaternion.Euler (0,0,90);

	Vector3 SLASH_DOWN = new Vector3(0,-0.75f,0);
	Quaternion SLASH_ROT_DOWN = Quaternion.Euler(0, 0, 270);

	Vector3 SLASH_FORWARD = new Vector3(0.5f, 0, 0);
	Quaternion SLASH_ROT_FORWARD = Quaternion.Euler(0, 0, 0);

	GameData m_GameData;

	void Start()
	{
		m_GameData = GameController.instance.ReturnGameData();

	}

	void Update()
	{
		if (Input.GetButtonDown("Attack") && !GameController.instance.ReturnPlayerStats().PlayerDead() && !GameController.instance.ReturnGameDialogue().IsSpeechBoxActive())
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
			enemyHP.TakeDamage(m_GameData.GetPlayerCurrentStrength(), myCol.gameObject.tag.ToString());
		}

		else if (myCol.gameObject.tag == "EnemyBoss" && GameController.instance.ReturnBossDaze().GetDazed())
		{
			EnemyStats enemyHP = myCol.gameObject.GetComponent<EnemyStats>();
			enemyHP.TakeDamage(m_GameData.GetPlayerCurrentStrength(), myCol.gameObject.tag.ToString());
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
			transform.localPosition = SLASH_UP;
			transform.localRotation = SLASH_ROT_UP;
			m_PlayerAttackAnimator.SetTrigger("IsAttackUp");
		}
		else if (direction == Vector2.down)
		{
			transform.localPosition = SLASH_DOWN;
			transform.localRotation = SLASH_ROT_DOWN;
			m_PlayerAttackAnimator.SetTrigger("IsAttackDown");
		}
		else
		{
			transform.localPosition = SLASH_FORWARD;
			transform.localRotation = SLASH_ROT_FORWARD;
			m_PlayerAttackAnimator.SetTrigger("IsAttackHorizontal");
		}
	}
}