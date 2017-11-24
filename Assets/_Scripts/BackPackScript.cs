using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackPackScript : MonoBehaviour 
{
	[SerializeField]
	Text m_MeatIcon;
	[SerializeField]
	Text m_WoodIcon;
	[SerializeField]
	Text m_StoneIcon;
	[SerializeField]
	Text m_LeatherIcon;

	[Header("Item Numbers")]
	int m_Meat = 0;
	int m_Wood = 0;
	int m_Stone = 0;
	int m_Leather = 0;

	public void ResetPickUps()
	{
		m_GameData.SaveCurrentLeatherAmount(m_Meat);
		m_GameData.SaveCurrentMeatAmount(m_Wood);
		m_GameData.SaveCurrentStoneAmount(m_Stone);
		m_GameData.SaveCurrentWoodAmount(m_Leather);
		SetTextIcons();
	}

	[SerializeField]
	GameData m_GameData;

	void Start()
	{
		m_GameData = GameController.instance.ReturnGameData();
	}

	public void SetIcon(string icon, int amount)
	{
		string choice = icon;

		switch (choice)
		{
			case "Meat":
				{
					int currentMeat = m_GameData.GetCurrentMeatAmount();
					currentMeat += amount;
					m_GameData.SaveCurrentMeatAmount(currentMeat);
					SetTextIcons();
					break;	
				}
			case "Wood":
				{
					int currentWood = m_GameData.GetCurrentWoodAmount();
					currentWood += amount;
					m_GameData.SaveCurrentWoodAmount(currentWood);
					SetTextIcons();
					break;
				}

			case "Stone":
				{
					int currentStone = m_GameData.GetCurrentStoneAmount();
					currentStone += amount;
					m_GameData.SaveCurrentStoneAmount(currentStone);
					SetTextIcons();
					break;
				}

			case "Leather":
				{
					int currentLeather = m_GameData.GetCurrentLeatherAmount();
					currentLeather += amount;
					m_GameData.SaveCurrentLeatherAmount(currentLeather);
					SetTextIcons();
					break;
				}

			default:
				{
					Debug.Log("Icon doesn't match anything we have in the game");
					break;
				}
		}
	}

	public void SetTextIcons()
	{
		m_MeatIcon.text = m_GameData.GetCurrentMeatAmount().ToString();
		m_WoodIcon.text = m_GameData.GetCurrentWoodAmount().ToString();
		m_StoneIcon.text = m_GameData.GetCurrentStoneAmount().ToString();
		m_LeatherIcon.text = m_GameData.GetCurrentLeatherAmount().ToString();
	}
}
