﻿using System.Collections;
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
		m_IsDead = true;
		DisableBoxCollider2D();
		m_Animator.SetBool("IsDead", true);
		Invoke("DestroyEnemy", DEATH_DURATION);
	}

	void DestroyEnemy()
	{
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
