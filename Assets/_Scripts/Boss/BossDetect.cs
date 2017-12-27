using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDetect : MonoBehaviour 
{
	int BOSS_TERRAIN_ESTATE = 6;

	float FIRE_ATTACK_DISTANCE = 170f;
	float CHARGE_DISTANCE = 115f;
	float CLOSE_DISTANCE = 20f;

	bool m_IsAttacking = true;

	int m_AttacksBeforeDazed;


	void Start()
	{
		SetAttacksBeforeDazed();
	}

	void OnTriggerStay2D(Collider2D myCol)
	{
		if (myCol.gameObject.tag == "Player" && GameController.instance.GetTerrainState() == BOSS_TERRAIN_ESTATE && !GameController.instance.ReturnBossDaze().GetDazed() && BossCanAttack())
		{
			if ((DistanceFromPlayer() > CHARGE_DISTANCE) && (DistanceFromPlayer() < FIRE_ATTACK_DISTANCE) && m_IsAttacking)
			{
				Debug.Log("Fireball attack");
				SetAttacking(false);
				int shots = GameController.instance.ReturnBossStats().GetShots();
				GameController.instance.ReturnBossShooter().SetShotLimit(shots);
			}
			else if ((DistanceFromPlayer() > CLOSE_DISTANCE) && (DistanceFromPlayer() < CHARGE_DISTANCE) && m_IsAttacking)
			{
				Debug.Log("Charge Attack");
				SetAttacking(false);
				GameController.instance.ReturnBossChargeAttack().StartChargeAttack();
			}
			else if ((DistanceFromPlayer() < CLOSE_DISTANCE) && m_IsAttacking)
			{
				Debug.Log("AOE attack");
				SetAttacking(false);
				GameController.instance.ReturnAOEAttack().StartCharging();
			}
		}
		if (!BossCanAttack())
		{
			print("Can't attack");
		}
	}

	float DistanceFromPlayer()
	{
		float distance;
		distance = (GameController.instance.ReturnPlayerPos() - transform.position).sqrMagnitude;
		return distance;
	}

	public bool SetAttacking(bool choice)
	{
		//Only when we set the attack to true, thats when we reduce the attacksbefore dazed.
		if (choice)
		{
			m_AttacksBeforeDazed--;
			if (m_AttacksBeforeDazed <= 0)
			{
				GameController.instance.ReturnBossDaze().SetDazed(true);
			}
		}
		m_IsAttacking = choice;
		return m_IsAttacking;
	}

	public void SetAttacksBeforeDazed()
	{
		m_AttacksBeforeDazed = GameController.instance.ReturnBossStats().ReturnBossAttacksBeforeDazed();
	}

	public bool BossCanAttack()
	{
		GameController.instance.ReturnGameData().SaveBossSeen();
		return !GameController.instance.ReturnBossStats().IsEnemyDead();
	}
}
