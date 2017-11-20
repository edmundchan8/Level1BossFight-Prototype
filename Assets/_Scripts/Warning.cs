using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warning : MonoBehaviour 
{
	[SerializeField]
	Image m_Image;

	void Start()
	{
		//Disable the image
		m_Image = GetComponent<Image>();
		m_Image.enabled = false;
	}

	void FixedUpdate()
	{
		if (m_Image.enabled)
		{
			Color currentColor = m_Image.color;
			currentColor.a = Mathf.PingPong(Time.time, .5f);
			m_Image.color = currentColor;
		}
	}

	public void StartWarningPanel()
	{
		m_Image.enabled = true;
	}

	public void DisableWarningPanel()
	{
		Color tempImage = m_Image.color;
		tempImage.a = 0f;
		m_Image.color = tempImage;
		m_Image.enabled = false;
	}
}
