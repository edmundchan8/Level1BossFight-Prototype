using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour 
{
	[Header("Stats")]
	[SerializeField]
	int m_HealthAmount;
	[SerializeField]
	int m_AttackDamage;
	[SerializeField]
	GameObject m_ItemDrop;

	float CAN_DROP_VALUE = 0.75f;

	int m_EnemyHealth;
	int m_EnemyAttack;
	float DEATH_DURATION = 1f;
	bool m_IsDead = false;

	[Header ("Accessor")]
	EnemyMove m_EnemyMove;
	Animator m_Animator;
	BoxCollider2D m_BoxCollider2D;

	void Start()
	{
		m_Animator = GetComponent<Animator>();
		m_BoxCollider2D = GetComponent<BoxCollider2D>();
		m_EnemyHealth = m_HealthAmount;
		m_EnemyAttack = m_AttackDamage;
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
		//Everytime the enemy deals damage, it will stop moving
		m_EnemyMove.StopEnemyMovement();
		//Then return the m_EnemyAttack damage amount
		return m_EnemyAttack;
	}

	public void TakeDamage(int damage)
	{
		m_EnemyHealth -= damage;
		m_EnemyMove.EnemyPushBack();
	}

	void EnemyDies()
	{
		m_IsDead = true;
		DisableBoxCollider2D();
		m_Animator.SetBool("IsDead", true);
		Invoke("DestroyEnemy", DEATH_DURATION);
	}

	void DestroyEnemy()
	{
		//Randomised the chance of a drop
		if (Random.value > CAN_DROP_VALUE)
		{
			Instantiate(m_ItemDrop, transform.localPosition, Quaternion.identity);
		}
		Destroy(gameObject);
	}

	void DisableBoxCollider2D()
	{
		m_BoxCollider2D.enabled = false;
	}

	public bool IsEnemyDead()
	{
		return m_IsDead;
	}
}
