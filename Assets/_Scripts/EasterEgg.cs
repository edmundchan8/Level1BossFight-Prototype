using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour 
{
	void Awake()
	{
		CloseTextBox();
	}

	public void EnableTextBox()
	{
		gameObject.SetActive(true);
	}

	public void CloseTextBox()
	{
		gameObject.SetActive(false);
	}
}
