using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour 
{
	[SerializeField]
	int HEALTH_AMOUNT;
	int m_EnemyHealth;

	EnemyMove m_EnemyMove;

	void Start()
	{
		m_EnemyHealth = HEALTH_AMOUNT;
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
