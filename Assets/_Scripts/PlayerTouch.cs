using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouch : MonoBehaviour 
{
	void OnTriggerEnter2D (Collider2D myCol)
	{
		if (myCol.gameObject.tag == "Home")
		{
			Debug.Log("You've reached your home.");
		}
	}
}
