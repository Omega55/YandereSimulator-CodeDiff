using System;
using UnityEngine;

public class TributeScript : MonoBehaviour
{
	public HenshinScript Henshin;

	public YandereScript Yandere;

	public GameObject Rainey;

	public string[] MiyukiLetters;

	public string[] AzurLane;

	public string[] Letter;

	public int MiyukiID;

	public int AzurID;

	public int ID;

	private void Start()
	{
		if (GameGlobals.LoveSick || !MissionModeGlobals.MissionMode)
		{
			base.enabled = false;
		}
		this.Rainey.SetActive(false);
	}

	private void Update()
	{
		if (!this.Yandere.PauseScreen.Show)
		{
			if (Input.GetKeyDown(this.Letter[this.ID]))
			{
				this.ID++;
				if (this.ID == this.Letter.Length)
				{
					this.Rainey.SetActive(true);
					base.enabled = false;
				}
			}
			if (Input.GetKeyDown(this.AzurLane[this.AzurID]))
			{
				this.AzurID++;
				if (this.AzurID == this.AzurLane.Length)
				{
					this.Yandere.AzurLane();
					base.enabled = false;
				}
			}
			if (this.Yandere.Armed && this.Yandere.EquippedWeapon.WeaponID == 14 && Input.GetKeyDown(this.MiyukiLetters[this.MiyukiID]))
			{
				this.MiyukiID++;
				if (this.MiyukiID == this.MiyukiLetters.Length)
				{
					this.Henshin.TransformYandere();
					this.Yandere.CanMove = false;
					base.enabled = false;
				}
			}
		}
	}
}
