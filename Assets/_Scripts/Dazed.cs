using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dazed : MonoBehaviour 
{
	bool m_Dazed;

	[SerializeField]
	float DazedTime;

	//Set Dazed to be true
	public void SetDazed(bool choice)
	{
		m_Dazed = choice;
		if (m_Dazed)
		{
			//BossAnmation.SetTrigger("Dazed");
			Debug.Log("Dazed");
			StartCoroutine("SetDazedOff");
		}
		else
		{
			return;
		}
	}

	public bool GetDazed()
	{
		return m_Dazed;
	}

	IEnumerator SetDazedOff()
	{
		yield return new WaitForSeconds(DazedTime);
		SetDazed(false);
		GameController.instance.ReturnBossDetect().SetAttacksBeforeDazed();
		Debug.Log("Not Dazed");
	}
}