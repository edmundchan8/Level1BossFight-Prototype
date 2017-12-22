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
		StartCoroutine("SetTimer");
	}

	void Update()
	{

		m_FadeTimer.Update(Time.deltaTime);
		if (GameController.instance.ReturnPlayerStats().PlayerDead())
		{
			SetPanelColor(Color.black);
			float alpha = (FADE_DURATION - m_FadeTimer.GetTime()) / FADE_DURATION;
			do
			{
				Color currentColor = m_Panel.color;
				currentColor.a = alpha;
				m_Panel.color = currentColor;
			} while (alpha < 1f);
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

	IEnumerator SetTimer()
	{
		yield return new WaitUntil(() => GameController.instance.ReturnPlayerStats().PlayerDead());
		m_FadeTimer.Set(FADE_DURATION);
	}
}
