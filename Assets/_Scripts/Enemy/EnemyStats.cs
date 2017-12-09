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

	[SerializeField]
	int m_BossAttackBeforeDazed;

	float CAN_DROP_VALUE = 0.75f;

	int m_EnemyHealth;
	int m_EnemyAttack;
	float DEATH_DURATION = 1f;
	bool m_IsDead = false;

	[Header ("Accessor")]
	EnemyMove m_EnemyMove;
	Animator m_Animator;
	CircleCollider2D m_CircleCollider2D;
	[SerializeField]
	GameObject m_HealthBar;
	[SerializeField]
	GameObject m_HealthBarBackGround;

	[Header ("Shooter")]
	[SerializeField]
	int m_Shots;

	void Start()
	{
		m_Animator = GetComponent<Animator>();
		m_CircleCollider2D = GetComponent<CircleCollider2D>();
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
		GameObject enemyHealthbar = m_HealthBar;
		Vector3 localScale = enemyHealthbar.transform.localScale;
		float xValue = (float)m_EnemyHealth / (float)m_HealthAmount;
		localScale.x = xValue;
		enemyHealthbar.transform.localScale = localScale;
		m_HealthBar = enemyHealthbar;
		m_EnemyMove.EnemyPushBack();
	}

	void EnemyDies()
	{
		m_IsDead = true;
		DisableCollider2D();
		DisableHealthBarBackGround();
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

	void DisableCollider2D()
	{
		m_CircleCollider2D.enabled = false;
	}

	public bool IsEnemyDead()
	{
		return m_IsDead;
	}

	void DisableHealthBarBackGround()
	{
		m_HealthBarBackGround.SetActive(false);
	}

	public int GetShots()
	{
		return m_Shots;
	}

	public int ReturnBossAttacksBeforeDazed()
	{
		return m_BossAttackBeforeDazed;
	}
}
