using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour 
{

	void OnTriggerStay2D(Collider2D myCol)
	{
		if (myCol.gameObject.tag == "Player")
		{
			GameController.instance.OnPlayerHome();
		}
	}

	void OnTriggerExit2D(Collider2D myCol)
	{
		if (myCol.gameObject.tag == "Player")
		{
			GameController.instance.OnPlayerLeftHome();
		}
	}
}
