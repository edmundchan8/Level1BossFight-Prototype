using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour 
{
	[SerializeField]
	SpriteRenderer m_Attack;
	[SerializeField]
	CapsuleCollider2D m_AttackCollider;

	void Update()
	{
		if (Input.GetButtonDown("Attack"))
		{
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
			enemyHP.TakeDamage(GameController.instance.ReturnPlayerStrength());
		}
	}

	public bool PlayerAttacking()
	{
		return m_Attack.isVisible;
	}
}
