using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour 
{
	[SerializeField]
	float m_PlayerSpeed;

	void FixedUpdate () 
	{
		//Move Player with WASD / UDLR
		transform.Translate(Input.GetAxis("Horizontal") * m_PlayerSpeed, Input.GetAxis("Vertical") * m_PlayerSpeed, 0f);
	}
}
