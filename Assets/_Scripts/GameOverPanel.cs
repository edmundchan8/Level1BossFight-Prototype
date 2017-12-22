using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour 
{
	Image m_Panel;
	Timer m_FadeTimer = new Timer();
	[SerializeField]
	float FADE_DURATION;

	void Start()
	{
		m_Panel = GetComponent<Image>();
		StartCoroutine("SetDeadTimer");
	}

	void Update()
	{

		m_FadeTimer.Update(Time.deltaTime);
		if (GameController.instance.ReturnPlayerStats().PlayerDead())
		{
			if (!m_FadeTimer.HasCompleted())
			{
				float alpha = (FADE_DURATION - m_FadeTimer.GetTime()) / FADE_DURATION;
				Color currentColor = m_Panel.color;
				currentColor.a = alpha;
				m_Panel.color = currentColor;
			}
		}
	}

	public void SetPanelColor (Color color)
	{
		Color currentColor = m_Panel.color;
		currentColor = color;
		float alpha = 0f;
		currentColor.a = alpha;
		m_Panel.color = currentColor;
	}

	IEnumerator SetDeadTimer()
	{
		yield return new WaitUntil(() => GameController.instance.ReturnPlayerStats().PlayerDead());
		SetPanelColor(Color.black);
		m_FadeTimer.Set(FADE_DURATION);
	}
}
