using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour 
{
	[SerializeField]
	float WAIT_DURATION;

	void Start()
	{
		Destroy(gameObject, WAIT_DURATION);
	}
}
