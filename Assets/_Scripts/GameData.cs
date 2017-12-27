using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour 
{
	public Vector2 LoadPlayerPos()
	{
		return GetPlayerPrefsPlayerPos();
	}

	public float LoadPlayerHealth()
	{
		return GetPlayerPrefsHealth();
	}

	public void SaveCurrentGameState()
	{
		int health = GetPlayerPrefsHealth();
		Vector2 playerPos = GameController.instance.ReturnPlayerPos();
		SavePlayerCurrentHealth(health);
		float x = playerPos.x;
		float y = playerPos.y;
		SavePlayerCurrentXPos(x);
		SavePlayerCurrentYPos(y);
	}

	public void SavePlayerCurrentHealth(int hp)
	{
		PlayerPrefs.SetInt("PlayerHealth", hp);
	}

	public int GetPlayerPrefsHealth()
	{
		return PlayerPrefs.GetInt("PlayerHealth");
	}

	public void SavePlayerCurrentXPos(float XPos)
	{
		PlayerPrefs.SetFloat("PlayerXPos", XPos);
	}

	public void SavePlayerCurrentYPos(float YPos)
	{
		PlayerPrefs.SetFloat("PlayerYPos", YPos);
	}

	public Vector2 GetPlayerPrefsPlayerPos()
	{
		return new Vector2(PlayerPrefs.GetFloat("PlayerXPos"), PlayerPrefs.GetFloat("PlayerYPos"));
	}

	public void SavePlayerCurrentStrength(int strength)
	{
		PlayerPrefs.SetInt("PlayerStrength", strength);
	}

	public int GetPlayerCurrentStrength()
	{
		return PlayerPrefs.GetInt("PlayerStrength");
	}

	public void SavePlayerCurrentDefence(int defence)
	{
		PlayerPrefs.SetInt("PlayerDefence", defence);
	}

	public int GetPlayerCurrentDefence()
	{
		return PlayerPrefs.GetInt("PlayerDefence");
	}

	public void SaveCurrentMeatAmount(int amount)
	{
		PlayerPrefs.SetInt("PlayerPrefsMeat", amount);
	}

	public int GetCurrentMeatAmount()
	{
		return PlayerPrefs.GetInt("PlayerPrefsMeat");
	}

	public void SaveCurrentWoodAmount(int amount)
	{
		PlayerPrefs.SetInt("PlayerPrefsWood", amount);
	}

	public int GetCurrentWoodAmount()
	{
		return PlayerPrefs.GetInt("PlayerPrefsWood");
	}

	public void SaveCurrentStoneAmount(int amount)
	{
		PlayerPrefs.SetInt("PlayerPrefsStone", amount);
	}

	public int GetCurrentStoneAmount()
	{
		return PlayerPrefs.GetInt("PlayerPrefsStone");
	}
		
	public void SaveCurrentLeatherAmount(int amount)
	{
		PlayerPrefs.SetInt("PlayerPrefsLeather", amount);
	}

	public int GetCurrentLeatherAmount()
	{
		return PlayerPrefs.GetInt("PlayerPrefsLeather");
	}

	public void SaveTextStarted()
	{
		PlayerPrefs.SetInt("textStarted", 1);
	}

	public int GetTextStarted()
	{
		return PlayerPrefs.GetInt("textStarted");
	}

	public void SaveBossSeen()
	{
		PlayerPrefs.SetInt("bossSeen", 1);
	}

	public int GetBossSeen()
	{
		return PlayerPrefs.GetInt("bossSeen");
	}

	public void SaveHasDied()
	{
		PlayerPrefs.SetInt("hasLost", 1);
	}

	public int GetHasDied()
	{
		return PlayerPrefs.GetInt("hasLost");
	}

	public void SaveBossDied()
	{
		PlayerPrefs.SetInt("bossDied", 1);
	}

	public int GetBossDied()
	{
		return PlayerPrefs.GetInt("bossDied");
	}

	public void ResetTextPlayerPrefs()
	{
		PlayerPrefs.SetInt("textStarted", 0);
		PlayerPrefs.SetInt("bossSeen", 0);
		PlayerPrefs.SetInt("hasLost", 0);
		PlayerPrefs.SetInt("bossDied", 0);
	}
}