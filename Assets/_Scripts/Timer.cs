using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer 
{
	float m_Timer;

	public void Set(float time)
	{
		m_Timer = time;
	}

	public bool Update(float tick)
	{
		if (m_Timer >= 0f)
		{
			m_Timer -= tick;
			return false;
		}
		else
		{
			return true;
		}
	}

	public bool HasCompleted()
	{
		return m_Timer <= 0f;
	}

	public float GetTime()
	{
		return m_Timer;
	}
}
