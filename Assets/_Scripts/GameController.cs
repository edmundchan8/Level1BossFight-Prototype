using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	[Header ("Player")]
	[SerializeField]
	GameObject m_Player;
	[SerializeField]
	GameObject m_PlayerBody;
	[SerializeField]
	PlayerStats m_PlayerStats;
	[SerializeField]
	PlayerAttack m_PlayerAttack;
	[SerializeField]
	PlayerMove m_PlayerMove;
	[SerializeField]
	PlayerTouch m_PlayerTouch;
	[SerializeField]
	Flashing m_PlayerFlashing;

	[Header ("Boss")]
	[SerializeField]
	GameObject m_Boss;
	[SerializeField]
	Shooter m_BossShooter;
	[SerializeField]
	EnemyStats m_BossStats;
	[SerializeField]
	BossDetect m_BossDetect;
	[SerializeField]
	ChargeAttack m_BossChargeAttack;
	[SerializeField]
	AOEAttack m_BossAOEAttack;
	[SerializeField]
	Dazed m_BossDaze;
	[SerializeField]
	Flashing m_BossFlashing;

	[Header("Save Data")]
	/* Disable the save button for the time being */
	//[SerializeField]
	//GameObject m_SaveButton;
	[SerializeField]
	GameData m_GameData;

	[Header("Talk")]
	[SerializeField]
	GameObject m_TalkButton;
	[SerializeField]
	Image m_SpeechBox;
	[SerializeField]
	GameDialogue m_GameDialogue;

	[Header("UI")]
	[SerializeField]
	Warning m_WarningScript;
	[SerializeField]
	BackPackScript m_BackPack;

	[SerializeField]
	FollowPlayer m_FollowPlayerScript;

	public static GameController instance;

	void Awake()
	{
		if (!instance)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	/*public void SetGameObjectScriptAssignment()
	{
		m_Player = GameObject.FindGameObjectWithTag("Player");
		m_PlayerBody = GameObject.FindGameObjectWithTag("PlayerBody");
		m_PlayerFlashing = m_PlayerBody.GetComponent<Flashing>();
	}*/

	public GameData ReturnGameData()
	{
		return m_GameData;
	}

	public PlayerStats ReturnPlayerStats()
	{
		return m_PlayerStats;
	}

	public PlayerAttack ReturnPlayerAttackScript()
	{
		return m_PlayerAttack;
	}

	public Vector3 ReturnPlayerPos()
	{
		return new Vector3(m_Player.transform.localPosition.x, m_Player.transform.localPosition.y, 0f);
	}

	public PlayerMove ReturnPlayerMoveScript()
	{
		return m_PlayerMove;
	}

	public void OnPlayerHome()
	{
		//m_SaveButton.SetActive(true);
		m_TalkButton.SetActive(true);
	}

	public void OnPlayerLeftHome()
	{
		//m_SaveButton.SetActive(false);
		m_TalkButton.SetActive(false);
	}

	public Warning ReturnWarningScript()
	{
		return m_WarningScript;
	}

	public BackPackScript ReturnBackPack()
	{
		return m_BackPack;
	}

	public Flashing ReturnPlayerFlashingScript()
	{
		return m_PlayerFlashing;
	}

	public FollowPlayer ReturnFollowPlayer()
	{
		return m_FollowPlayerScript;
	}

	public int GetTerrainState()
	{
		return m_PlayerTouch.ReturnTerrainState();
	}

	public Shooter ReturnBossShooter()
	{
		return m_BossShooter;
	}

	public EnemyStats ReturnBossStats()
	{
		return m_BossStats;
	}

	public BossDetect ReturnBossDetect()
	{
		return m_BossDetect;
	}

	public ChargeAttack ReturnBossChargeAttack()
	{
		return m_BossChargeAttack;
	}

	public AOEAttack ReturnAOEAttack()
	{
		return m_BossAOEAttack;
	}

	public Dazed ReturnBossDaze()
	{
		return m_BossDaze;
	}

	public Flashing ReturnBossFlashing()
	{
		return m_BossFlashing;
	}

	public GameDialogue ReturnGameDialogue()
	{
		return m_GameDialogue;
	}

	public bool IsTalkButtonActive()
	{
		return m_TalkButton.activeSelf;
	}
}