using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackPackScript : MonoBehaviour 
{
	[SerializeField]
	Text m_MeatIcon;

	[SerializeField]
	GameData m_GameData;

	static Text m_CurrentIcon;

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
					m_CurrentIcon = m_MeatIcon;
					int currentMeat = m_GameData.GetCurrentMeatAmount();
					currentMeat += amount;
					m_GameData.SaveCurrentMeatAmount(currentMeat);
					m_CurrentIcon.text = currentMeat.ToString();
					break;	
				}
			default:
				{
					Debug.Log("Icon doesn't match anything we have in the game");
					break;
				}
		}
	}
}
