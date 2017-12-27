using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDialogue : MonoBehaviour 
{
	[SerializeField]
	TextAsset m_OldManText;
	string[] m_TextLines;
	[SerializeField]
	Text m_Text;

	int m_CurrentLine;
	int m_EndLine;

	bool m_CanStartCoroutine = true;

	enum estate{gameStart, postGame, bossSeen, LostBoss, Win}

	estate m_GameState = estate.gameStart;

	int GAME_START = 0;
	int POST_GAME = 5;
	int BOSS_SEEN = 8;
	int LOST_BOSS = 10;
	int WIN = 13;

	void Awake () 
	{
		StartCoroutine(SetGameState());
		m_TextLines = m_OldManText.text.Split('\n');
		SetSpeechBoxOff();
	}
		
	void Update()
	{
		print("Current " + m_CurrentLine + " End " + m_EndLine);
		if (Input.GetKeyUp(KeyCode.Return))
		{
			m_CurrentLine++;
			m_Text.text = m_TextLines[m_CurrentLine];
			if (m_CurrentLine == m_EndLine)
			{
				m_CanStartCoroutine = true;
				SetSpeechBoxOff();
			}
		}
	}

	public void SetSpeechBoxActive()
	{
		gameObject.SetActive(true);
		if (m_CanStartCoroutine)
		{
			StartCoroutine(SetGameState());
		}
		m_CanStartCoroutine = false;
		m_Text.text = m_TextLines[m_CurrentLine];
	}

	public void SetSpeechBoxOff()
	{
		gameObject.SetActive(false);
	}

	public void SetSpeechLine(int speechLine)
	{
		m_CurrentLine = speechLine;
	}

	public void SetDialogueState(int state)
	{
		m_GameState = (estate)state;
		switch(m_GameState)
		{
			case estate.gameStart:
				m_CurrentLine = GAME_START;
				m_EndLine = POST_GAME - 1;
				break;
			case estate.postGame:
				m_CurrentLine = POST_GAME;
				m_EndLine = BOSS_SEEN - 1;
				break;
			case estate.bossSeen:
				m_CurrentLine = BOSS_SEEN;
				m_EndLine = LOST_BOSS - 1;
				break;
			case estate.LostBoss:
				m_CurrentLine = LOST_BOSS;
				m_EndLine = WIN - 1;
				break;
			case estate.Win:
				m_CurrentLine = WIN;
				break;
			default:
				Debug.Log("Should not see this");
				break;
		}
	}

	IEnumerator SetGameState()
	{
		yield return new WaitUntil(() => gameObject.activeSelf);
		if (GameController.instance.ReturnGameData().GetTextStarted() == 0)
		{
			SetDialogueState(GAME_START);
			GameController.instance.ReturnGameData().SaveTextStarted();
		}
		else if (GameController.instance.ReturnGameData().GetTextStarted() == 1 && GameController.instance.ReturnGameData().GetBossSeen() == 0)
		{
			SetDialogueState(POST_GAME);
		}
		else if (GameController.instance.ReturnGameData().GetBossSeen() == 1 && GameController.instance.ReturnGameData().GetHasDied() == 0)
		{
			SetDialogueState(BOSS_SEEN);
		}
		else if (GameController.instance.ReturnGameData().GetHasDied() == 1 && GameController.instance.ReturnGameData().GetBossDied() == 0)
		{
			SetDialogueState(LOST_BOSS);
		}
		else
		{
			SetDialogueState(WIN);
		}
	}
}
