using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour 
{
	Image m_Panel;
	Timer m_FadeTimer = new Timer();
	[SerializeField]
	float GAMEOVER_FADE_DURATION;
	[SerializeField]
	float WIN_FADE_DURATION;
	[SerializeField]
	Button m_GameOver;
	[SerializeField]
	Button m_Win;

	void Start()
	{
		m_Panel = GetComponent<Image>();
		StartCoroutine("SetDeadTimer");
		StartCoroutine("SetWinTimer");
		m_GameOver.gameObject.SetActive(false);
		m_Win.gameObject.SetActive(false);
	}

	void Update()
	{
		if (GameController.instance.ReturnPlayerStats().PlayerDead())
		{
			float alpha = (GAMEOVER_FADE_DURATION - m_FadeTimer.GetTime()) / GAMEOVER_FADE_DURATION;
			if (!m_FadeTimer.Update(Time.deltaTime))
			{
				Color currentColor = m_Panel.color;
				currentColor.a = alpha;
				m_Panel.color = currentColor;
			}
			else if (m_FadeTimer.Update(Time.deltaTime) && m_FadeTimer.HasCompleted())
			{
				m_GameOver.gameObject.SetActive(true);
			}
		}
		else if (GameController.instance.ReturnBossStats().IsEnemyDead())
		{
			float alpha = (WIN_FADE_DURATION - m_FadeTimer.GetTime()) / WIN_FADE_DURATION;
			if (!m_FadeTimer.Update(Time.deltaTime))
			{
				Color currentColor = m_Panel.color;
				currentColor.a = alpha;
				m_Panel.color = currentColor;
			}
			else if (m_FadeTimer.Update(Time.deltaTime) && m_FadeTimer.HasCompleted())
			{
				m_Win.gameObject.SetActive(true);
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
		m_FadeTimer.Set(GAMEOVER_FADE_DURATION);
		SetPanelColor(Color.black);
	}

	IEnumerator SetWinTimer()
	{
		yield return new WaitUntil(() => GameController.instance.ReturnBossStats().IsEnemyDead());
		m_FadeTimer.Set(WIN_FADE_DURATION);
		SetPanelColor(Color.white);
	}

	public bool GameOver()
	{
		return m_GameOver.IsActive();
	}
	public bool Win()
	{
		return m_Win.IsActive();
	}
}
