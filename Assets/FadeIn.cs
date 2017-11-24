using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour 
{
	float FADE_DURATION = 1f;
	Timer m_FadeTimer = new Timer();
	SpriteRenderer m_SpriteRender;

	void Start()
	{
		m_SpriteRender = this.gameObject.GetComponent<SpriteRenderer>();
		m_FadeTimer.Set(FADE_DURATION);
	}

	void Update()
	{
		m_FadeTimer.Update(Time.deltaTime);
		if (!m_FadeTimer.HasCompleted())
		{
			Color currentColor = m_SpriteRender.color;
			currentColor.a = (FADE_DURATION - m_FadeTimer.GetTime()) / FADE_DURATION;
			m_SpriteRender.color = currentColor;
		}
	}

}
