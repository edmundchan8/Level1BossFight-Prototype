using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour 
{
	[SerializeField]
	int HEALTH_AMOUNT;
	[SerializeField]
	int ATTACK_DAMAGE;
	int m_EnemyHealth;
	int m_EnemyAttack;

	[Header ("Accessor")]
	EnemyMove m_EnemyMove;

	void Start()
	{
		m_EnemyHealth = HEALTH_AMOUNT;
		m_EnemyAttack = ATTACK_DAMAGE;
		m_EnemyMove = gameObject.GetComponent<EnemyMove>();
	}

	void Update()
	{
		if (m_EnemyHealth <= 0)
		{
			m_EnemyHealth = 0;
			DestroyEnemy();
		}
	}

	public int DealDamage()
	{
		return m_EnemyAttack;
	}

	public void TakeDamage(int damage)
	{
		m_EnemyHealth -= damage;
		m_EnemyMove.EnemyPushBack();
	}

	void DestroyEnemy()
	{
		Destroy(gameObject);
	}
}
