using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warning : MonoBehaviour 
{
	Image m_Image;
	void Start()
	{
		//Disable the image
		m_Image = Getcomponent<Image>();
		m_Image.enabled = false;

	}

	void FixedUpdate()
	{
		//We we get the panel alpha to jump from 0 - 120 and back again
		//When finished, set the panel - disabled.
	}
}
