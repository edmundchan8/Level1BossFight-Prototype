using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour 
{
	float expiryDate = 8f;
	private enum ePickUp {Rubbish, Meat, Wood, Stone, Herb, Sword, Shield, Leather, Scale, Bone}

	[SerializeField]
	ePickUp m_PickUpState = ePickUp.Rubbish;

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
