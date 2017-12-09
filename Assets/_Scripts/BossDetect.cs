using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDetect : MonoBehaviour 
{
	int BOSS_TERRAIN_ESTATE = 6;

	float FIRE_ATTACK_DISTANCE = 90f;
	float CHARGE_DISTANCE = 55f;
	float CLOSE_DISTANCE = 0.5f;

	void OnTriggerStay2D(Collider2D myCol)
	{
		if (myCol.gameObject.tag == "Player" && GameController.instance.GetTerrainState() == BOSS_TERRAIN_ESTATE)
		{
			Debug.Log("Player detected within boss tile range");
			//print(DistanceFromPlayer());

			if (DistanceFromPlayer() > FIRE_ATTACK_DISTANCE)
			{
				Debug.Log("Fireball attack");
			}
			else if (DistanceFromPlayer() > CHARGE_DISTANCE)
			{
				Debug.Log("Charge Attack");
			}
			else if (DistanceFromPlayer() > CLOSE_DISTANCE)
			{
				Debug.Log("AOE attack");
			}
		}
	}

	float DistanceFromPlayer()
	{
		float distance;
		distance = (GameController.instance.ReturnPlayerPos() - transform.position).sqrMagnitude;
		return distance;
	}
}
