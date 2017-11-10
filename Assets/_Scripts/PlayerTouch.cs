using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouch : MonoBehaviour 
{
	public enum eTerrain
	{
		grass, mountain, snow, desert
	};
	private eTerrain eState = eTerrain.grass;

	void Update()
	{
		eTerrain currentState = eState;

		switch(currentState)
		{
			case eTerrain.grass:
				{
					Debug.Log("You are on grass.");
				}
				break;
			case eTerrain.desert:
				{
					Debug.Log("You are on the dessert");
				}
				break;
			default:
				{
					Debug.Log("You are not stepping on anything");
					break;
				}
		}
	}

	void OnTriggerEnter2D (Collider2D myCol)
	{
		if (myCol.gameObject.tag == "Home")
		{
			Debug.Log("You've reached your home.");
		}
		else if (myCol.gameObject.tag == "Desert")
		{
			eState = eTerrain.desert;
		}
	}
}
