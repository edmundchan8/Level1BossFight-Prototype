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
		m_AttacksBeforeDazed = GameController.instance.ReturnBossStats().ReturnBossAttacksBeforeDazed();
	}

	void OnTriggerStay2D(Collider2D myCol)
	{
		if (myCol.gameObject.tag == "Player" && GameController.instance.GetTerrainState() == BOSS_TERRAIN_ESTATE && !GameController.instance.ReturnBossDaze().GetDazed())
		{
			if ((DistanceFromPlayer() > CHARGE_DISTANCE) && (DistanceFromPlayer() < FIRE_ATTACK_DISTANCE) && m_IsAttacking)
			{
				Debug.Log("Fireball attack");
				Attacking();
				int shots = GameController.instance.ReturnBossStats().GetShots();
				GameController.instance.ReturnBossShooter().SetShotLimit(shots);
			}
			else if ((DistanceFromPlayer() > CLOSE_DISTANCE) && (DistanceFromPlayer() < CHARGE_DISTANCE) && m_IsAttacking)
			{
				Debug.Log("Charge Attack");
				Attacking();
				GameController.instance.ReturnBossChargeAttack().StartChargeAttack();
			}
			else if ((DistanceFromPlayer() < CLOSE_DISTANCE) && m_IsAttacking)
			{
				Debug.Log("AOE attack");
				Attacking();
				GameController.instance.ReturnAOEAttack().StartCharging();
			}
		}
	}

	float DistanceFromPlayer()
	{
		float distance;
		distance = (GameController.instance.ReturnPlayerPos() - transform.position).sqrMagnitude;
		return distance;
	}

	void Attacking()
	{
		m_AttacksBeforeDazed--;
		SetAttacking(false);
		if (m_AttacksBeforeDazed <= 0)
		{
			GameController.instance.ReturnBossDaze().SetDazed(true);
		}
	}

	public bool SetAttacking(bool choice)
	{
		m_IsAttacking = choice;
		return m_IsAttacking;
	}
}
