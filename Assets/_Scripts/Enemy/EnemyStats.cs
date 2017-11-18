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
	float DEATH_DURATION = 2f;

	[Header ("Accessor")]
	EnemyMove m_EnemyMove;
	Animator m_Animator;
	SpriteRenderer m_SpriteRenderer;

	void Start()
	{
		m_Animator = GetComponent<Animator>();
		m_SpriteRenderer = GetComponent<SpriteRenderer>();
		m_SpriteRenderer.enabled = true;
		m_EnemyHealth = HEALTH_AMOUNT;
		m_EnemyAttack = ATTACK_DAMAGE;
		m_EnemyMove = gameObject.GetComponent<EnemyMove>();
	}

	void Update()
	{
		if (m_EnemyHealth <= 0)
		{
			m_EnemyHealth = 0;
			EnemyDies();
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

	void EnemyDies()
	{
		//DisableSpriteRenderer();
		//TODO: Stop enemy moving/disable their attacking ability as the gameobject there can still cause player damage
		m_Animator.SetBool("IsDead", true);
		Invoke("DestroyEnemy", DEATH_DURATION);
	}

	void DestroyEnemy()
	{
		Destroy(gameObject);
	}

	void DisableSpriteRenderer()
	{
		m_SpriteRenderer.enabled = false;
	}
}
