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

	[SerializeField]
	bool m_PlayerWithinRange = false;

	int m_ShotCounter;
	[SerializeField]
	int m_NumberShots;

	Vector2 m_TargetPos; 

	Timer m_ShootTimer = new Timer();

	//Call shooting script, or more like, if we are able to shoot, begin the shooting protocol, the shooting method
		//note, reset the m_ShotLimit.
		//Set the timer.
	void Update()
	{
		//FOR DEBUG TESTING ONLY
		/*if(Input.GetKeyUp(KeyCode.Z))
		{
			m_PlayerWithinRange = !m_PlayerWithinRange;
			m_ShotLimit = !m_ShotLimit;
		}*/

		if ((m_ShotCounter > 0 && m_PlayerWithinRange) && m_ShootTimer.Update(Time.deltaTime))
		{
			Shoot();
			m_ShootTimer.Set(WAIT_DURATION);
		}
		else if ((!m_ShotLimit && m_PlayerWithinRange) && m_ShootTimer.Update(Time.deltaTime))
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
		//Get access to the projectile script to tell is where you want to fire the projectile
		projectile.GetComponent<Projectile>().SetProjectileDirection(CurrentPosition(), TargetPosition());
		m_ShotCounter--;
	}

	public void SetShotLimit(int limit)
	{
		m_ShotCounter = limit;
	}
		
	//At the same time as above, check if we have a shot limit, if we don't, run a timer
	//if there is a m_ShotLimit

	//When timer is reached, fire a bullet at target location (but do not follow the target, only go to their last target location 
	//Check our m_ShotLimit, if it has not been reached, reset the timer - to shoot again, increment the m_ShotLimitCounter
	//if the m_ShotLimit has been reached, don't reset the timer.

	//projectile has a method which causes the bullet to fade out slowy, eventually leading it to self destruct

}
