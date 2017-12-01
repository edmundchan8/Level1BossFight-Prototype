using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouch : MonoBehaviour 
{
	public enum eTerrain
	{
		ground, home, grass, mountain, snow, desert, boss
	};
	private eTerrain eState = eTerrain.grass;

	[Header("CONST SETTINGS")]
	int ADD_ONE = 1;
	int REMOVE_ONE = -1;

	void Update()
	{
		eTerrain currentState = eState;

		switch(currentState)
		{
			case eTerrain.ground:
				{
					Debug.Log("You are on the ground.");
				}
				break;
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
			case eTerrain.mountain:
				{
					Debug.Log("You are on the mountain");
				}
				break;
			case eTerrain.snow:
				{
					Debug.Log("You are on the snow");
				}
				break;			
			case eTerrain.home:
				{
					GameController.instance.OnPlayerHome();
				}
				break;
			case eTerrain.boss:
				{
					GameController.instance.ReturnFollowPlayer().OnBossTile();
				}
				break;
			default:
				{
					Debug.Log("You are not stepping on anything");
					break;
				}
		}
	}

	void OnTriggerStay2D (Collider2D myCol)
	{
		if (myCol.gameObject.tag == "Home")
		{
			eState = eTerrain.home;
		}
		else if (myCol.gameObject.tag == "Desert")
		{
			eState = eTerrain.desert;
		}
		else if (myCol.gameObject.tag == "Grass")
		{
			eState = eTerrain.grass;
		}
		else if (myCol.gameObject.tag == "Mountain")
		{
			eState = eTerrain.mountain;
		}
		else if (myCol.gameObject.tag == "Snow")
		{
			eState = eTerrain.snow;
		}
		else if (myCol.gameObject.tag == "Boss")
		{
			eState = eTerrain.boss;
		}
	}

	void OnTriggerEnter2D(Collider2D myCol)
	{
		if (myCol.gameObject.tag == "PickUp")
		{
			PickUpScript pickUp = myCol.gameObject.GetComponent<PickUpScript>();
			string pickUpName = pickUp.ReturnPickUpState();
			pickUp.PickedUpDestroy();
			GameController.instance.ReturnBackPack().SetIcon(pickUpName, ADD_ONE);
		}
	}
}
