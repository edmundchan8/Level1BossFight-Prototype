using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour 
{
	//Gameobject to hold the projectile prefab
	[SerializeField]
	GameObject m_Projectile;
	[SerializeField]
	GameObject m_Head;
	[SerializeField]
	GameObject m_Target;
	[SerializeField]
	GameObject m_ProjectileHolder;

	float WAIT_DURATION = 3f;

	[SerializeField]
	bool m_ShotLimit = true;

	int m_ShotCounter;
	[SerializeField]
	int m_NumberShots;

	Vector2 m_TargetPos; 

	Timer m_ShootTimer = new Timer();

	void Update()
	{
		if ((m_ShotCounter > 0) && m_ShootTimer.Update(Time.deltaTime))
		{
			Shoot();
			m_ShootTimer.Set(WAIT_DURATION);
			if (m_ShotCounter <= 0)
			{
				GameController.instance.ReturnBossDetect().SetAttacking(true);
			}
		}

		//TODO: So this code is so that, if you out this script onto an enemy that will be focused on just shooting at the player, 
		//and when the player is within close proximity of the player then this script will just cause the enemy to keep shooting at the player
		else if ((!m_ShotLimit) && m_ShootTimer.Update(Time.deltaTime) /* && m_PlayerWithinRange */)
		{
			SetShotLimit(1);
			Shoot();
			m_ShootTimer.Set(WAIT_DURATION);
		}	
	}
	//First, Follow the target position, keep a track of the targets position
	Vector2 TargetPosition()
	{
		m_TargetPos = new Vector2(m_Target.transform.localPosition.x, m_Target.transform.localPosition.y);
		return m_TargetPos;
	}

	Vector2 CurrentPosition()
	{
		Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
		return currentPos;
	}

	void Shoot()
	{
		GameObject projectile = Instantiate(m_Projectile, m_Head.transform.position, Quaternion.identity, m_ProjectileHolder.gameObject.transform) as GameObject;
		//Get access to the projectile script to tell it where you want to fire the projectile
		projectile.GetComponent<Projectile>().SetProjectileDirection(CurrentPosition(), TargetPosition());
		m_ShotCounter--;
	}

	public void SetShotLimit(int limit)
	{
		m_ShotCounter = limit;
	}
}
