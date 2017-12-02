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

	[SerializeField]
	Timer m_ShooterTimer = new Timer();
	float WAIT_DURATION = 3f;

	[SerializeField]
	bool m_ShotLimit;

	int m_ShotCounter;

	Vector2 m_TargetPos; 

	//Call shooting script, or more like, if we are able to shoot, begin the shooting protocol, the shooting method
		//note, reset the m_ShotLimit.
		//Set the timer.
	void Update()
	{
		//Test
		if(Input.GetKeyUp(KeyCode.Z))
		{
			SetShotLimit(3);
		}

		if (m_ShotCounter > 0 && m_ShooterTimer.Update(Time.deltaTime))
		{
			Shoot();
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
		if (m_ShotCounter > 0)
		{
			GameObject projectile = Instantiate(m_Projectile, m_Head.transform.position, Quaternion.identity, m_ProjectileHolder.gameObject.transform) as GameObject;
			//Get access to the projectile script to tell is where you want to fire the projectile
			projectile.GetComponent<Projectile>().SetProjectileDirection(CurrentPosition(), TargetPosition());
			m_ShooterTimer.Set(WAIT_DURATION);
			m_ShotCounter--;
		}
		else
		{
			Debug.Log("Shooter script, Shoot(), m_ShotLimit is below 0, we should not see this.");
		}
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
