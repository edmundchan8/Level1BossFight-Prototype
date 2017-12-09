using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDetect : MonoBehaviour 
{
	int BOSS_TERRAIN_ESTATE = 6;

	float FIRE_ATTACK_DISTANCE = 150f;
	float CHARGE_DISTANCE = 75f;
	float CLOSE_DISTANCE = 20f;

	bool IsAttacking = true;

	void Update()
	{

	}

	void OnTriggerStay2D(Collider2D myCol)
	{
		if (myCol.gameObject.tag == "Player" && GameController.instance.GetTerrainState() == BOSS_TERRAIN_ESTATE)
		{
			//if ((!bossDazed())
			if ((DistanceFromPlayer() > CHARGE_DISTANCE) && (DistanceFromPlayer() < FIRE_ATTACK_DISTANCE) && IsAttacking)
			{
				Debug.Log("Fireball attack");
				SetAttacking(false);
				int shots = GameController.instance.ReturnBossStats().GetShots();
				GameController.instance.ReturnBossShooter().SetShotLimit(shots);
			}
			else if ((DistanceFromPlayer() > CLOSE_DISTANCE) && (DistanceFromPlayer() < CHARGE_DISTANCE) && IsAttacking)
			{
				Debug.Log("Charge Attack");
				SetAttacking(false);
				GameController.instance.ReturnBossChargeAttack().StartChargeAttack();
			}
			else if ((DistanceFromPlayer() < CLOSE_DISTANCE) && IsAttacking)
			{
				Debug.Log("AOE attack");
				SetAttacking(false);
				GameController.instance.ReturnAOEAttack().StartCharging();
			}
			//else run bossDazed(), boss is succeptible for damage
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
		IsAttacking = choice;
		return IsAttacking;
	}
}
