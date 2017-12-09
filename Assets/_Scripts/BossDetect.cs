using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDetect : MonoBehaviour 
{
	int BOSS_TERRAIN_ESTATE = 6;

	float FIRE_ATTACK_DISTANCE = 90f;
	float CHARGE_DISTANCE = 55f;
	float CLOSE_DISTANCE = 0.5f;

	bool IsAttacking = false;

	void OnTriggerStay2D(Collider2D myCol)
	{
		if (myCol.gameObject.tag == "Player" && GameController.instance.GetTerrainState() == BOSS_TERRAIN_ESTATE)
		{
			if ((DistanceFromPlayer() > FIRE_ATTACK_DISTANCE) && !IsAttacking)
			{
				Debug.Log("Fireball attack");
				int shots = GameController.instance.ReturnBossStats().GetShots();
				GameController.instance.ReturnBossShooter().SetShotLimit(shots);
				IsAttacking = true;
			}
			else if (DistanceFromPlayer() > CHARGE_DISTANCE)
			{
				Debug.Log("Charge Attack");
				IsAttacking = true;
			}
			else if (DistanceFromPlayer() > CLOSE_DISTANCE)
			{
				Debug.Log("AOE attack");
				IsAttacking = true;
			}
		}
	}

	float DistanceFromPlayer()
	{
		float distance;
		distance = (GameController.instance.ReturnPlayerPos() - transform.position).sqrMagnitude;
		return distance;
	}

	public void SetAttackingFalse()
	{
		IsAttacking = false;
		Debug.Log("Attack stopped");
	}
}
