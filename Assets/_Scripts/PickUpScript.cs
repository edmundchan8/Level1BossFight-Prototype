using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour 
{
	float expiryDate = 8f;
	private enum ePickUp {rubbish, meat, wood, stone, herb, sword, shield, leather, scale, bone}

	[SerializeField]
	ePickUp m_PickUpState = ePickUp.rubbish;

	void Start()
	{
		Invoke("Destroy", expiryDate);
	}

	void Destroy()
	{
		Destroy(this.gameObject);
	}

	public string ReturnPickUpState()
	{
		return m_PickUpState.ToString();
	}

	public void PickedUpDestroy()
	{
		Destroy(this.gameObject);
	}
}
