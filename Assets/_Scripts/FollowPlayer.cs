using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour 
{
	Vector3 m_Offset;

	void Start()
	{
		m_Offset = transform.position - GameController.instance.ReturnPlayerPos();
	}

	void Update()
	{
		transform.position = GameController.instance.ReturnPlayerPos() + m_Offset;
	}
}
