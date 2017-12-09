using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEAttack : MonoBehaviour 
{
	Timer m_ChargeTimer = new Timer();
	[SerializeField]
	float m_ChargeDuration;

	[SerializeField]
	int m_TailSpins;
	bool m_CanAttack = false;

	[SerializeField]
	Animator m_BossAnimator;

	void Update()
	{
		if(m_ChargeTimer.Update(Time.deltaTime) && m_CanAttack)
		{
			print("triggered");
			m_BossAnimator.SetTrigger("TailWhip");
			m_CanAttack = false;
		}
	}

	public void StartCharging()
	{
		m_ChargeTimer.Set(m_ChargeDuration);
		m_CanAttack = true;
	}

	void StopTailWhip()
	{
		GameController.instance.ReturnBossDetect().SetAttacking(true);
	}
}
