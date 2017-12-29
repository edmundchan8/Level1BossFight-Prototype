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

	bool m_CanSetTextState = true;

	enum estate{gameStart, postGame, bossSeen, LostBoss, Win}

	estate m_GameState = estate.gameStart;

	int GAME_START = 0;
	int POST_GAME = 5;
	int BOSS_SEEN = 7;
	int LOST_BOSS = 10;
	int WIN = 13;

	void Awake () 
	{
		m_TextLines = m_OldManText.text.Split('\n');
		SetSpeechBoxOff();
	}

	void Start()
	{
		GameController.instance.ReturnGameData().ResetTextPlayerPrefs();
	}
		
	void Update()
	{
		if (Input.GetKeyUp(KeyCode.Return))
		{
			m_CurrentLine++;
			print("Current " + m_CurrentLine + " m_End " + m_EndLine);
			m_Text.text = m_TextLines[m_CurrentLine];
			if (m_CurrentLine == m_EndLine)
			{
				SetGameState();
				m_CanSetTextState = true;
				SetSpeechBoxOff();
			}
		}
	}

	public void SetSpeechBoxActive()
	{
		gameObject.SetActive(true);
		if (m_CanSetTextState)
		{
			SetGameState();
			print(m_CurrentLine);
			m_Text.text = m_TextLines[m_CurrentLine];
			m_CanSetTextState = false;
		}
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

	public void SetGameState()
	{
		if (GameController.instance.ReturnGameData().GetTextStarted() == 0)
		{
			print("Setting start game");
			GameController.instance.ReturnGameData().SaveTextStarted();
			SetDialogueState(0);
		}
		else if (GameController.instance.ReturnGameData().GetTextStarted() == 1 && GameController.instance.ReturnGameData().GetBossSeen() == 0 && GameController.instance.ReturnGameData().GetBossDied() == 0 && GameController.instance.ReturnGameData().GetHasDied() == 0)
		{
			print("Setting post game");
			SetDialogueState(1);
		}
		else if (GameController.instance.ReturnGameData().GetBossSeen() == 1 && GameController.instance.ReturnGameData().GetHasDied() == 0 && GameController.instance.ReturnGameData().GetBossDied() == 0)
		{
			print("Setting seen boss");
			SetDialogueState(2);
		}
		else if (GameController.instance.ReturnGameData().GetHasDied() == 1 && GameController.instance.ReturnGameData().GetBossDied() == 0 && GameController.instance.ReturnGameData().GetHasDied() == 1)
		{
			print("Setting player died");
			SetDialogueState(3);
		}
		else if(GameController.instance.ReturnGameData().GetBossDied() == 1)
		{
			print("setting win");
			SetDialogueState(4);
		}
	}
}
