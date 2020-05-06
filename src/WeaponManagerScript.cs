using System;
using UnityEngine;

public class WeaponManagerScript : MonoBehaviour
{
	public WeaponScript[] DelinquentWeapons;

	public WeaponScript[] Weapons;

	public YandereScript Yandere;

	public JsonScript JSON;

	public int[] Victims;

	public int MisplacedWeapons;

	public int MurderWeapons;

	public int Fingerprints;

	public int YandereWeapon1;

	public int YandereWeapon2;

	public Texture Flower;

	public Texture Blood;

	public bool YandereGuilty;

	public void Start()
	{
		for (int i = 0; i < this.Weapons.Length; i++)
		{
			this.Weapons[i].GlobalID = i;
			if (WeaponGlobals.GetWeaponStatus(i) == 1)
			{
				this.Weapons[i].gameObject.SetActive(false);
			}
		}
		this.ChangeBloodTexture();
	}

	public void UpdateLabels()
	{
		WeaponScript[] weapons = this.Weapons;
		for (int i = 0; i < weapons.Length; i++)
		{
			weapons[i].UpdateLabel();
		}
	}

	public void CheckWeapons()
	{
		this.MurderWeapons = 0;
		this.Fingerprints = 0;
		for (int i = 0; i < this.Victims.Length; i++)
		{
			this.Victims[i] = 0;
		}
		foreach (WeaponScript weaponScript in this.Weapons)
		{
			if (weaponScript != null && weaponScript.Blood.enabled && !weaponScript.AlreadyExamined)
			{
				this.MurderWeapons++;
				if (weaponScript.FingerprintID > 0)
				{
					this.Fingerprints++;
					for (int k = 0; k < weaponScript.Victims.Length; k++)
					{
						if (weaponScript.Victims[k])
						{
							this.Victims[k] = weaponScript.FingerprintID;
						}
					}
				}
			}
		}
	}

	public void CleanWeapons()
	{
		foreach (WeaponScript weaponScript in this.Weapons)
		{
			if (weaponScript != null)
			{
				weaponScript.Blood.enabled = false;
				weaponScript.FingerprintID = 0;
			}
		}
	}

	public void ChangeBloodTexture()
	{
		foreach (WeaponScript weaponScript in this.Weapons)
		{
			if (weaponScript != null)
			{
				if (!GameGlobals.CensorBlood)
				{
					weaponScript.Blood.material.mainTexture = this.Blood;
					weaponScript.Blood.material.SetColor("_TintColor", new Color(0.25f, 0.25f, 0.25f, 0.5f));
				}
				else
				{
					weaponScript.Blood.material.mainTexture = this.Flower;
					weaponScript.Blood.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0.5f));
				}
			}
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Z))
		{
			this.CheckWeapons();
			for (int i = 0; i < this.Victims.Length; i++)
			{
				if (this.Victims[i] != 0)
				{
					if (this.Victims[i] == 100)
					{
						Debug.Log("The student named " + this.JSON.Students[i].Name + " was killed by Yandere-chan!");
					}
					else
					{
						Debug.Log(string.Concat(new string[]
						{
							"The student named ",
							this.JSON.Students[i].Name,
							" was killed by ",
							this.JSON.Students[this.Victims[i]].Name,
							"!"
						}));
					}
				}
			}
		}
	}

	public void TrackDumpedWeapons()
	{
		for (int i = 0; i < this.Weapons.Length; i++)
		{
			if (this.Weapons[i] == null)
			{
				Debug.Log("Weapon #" + i + " was destroyed! Setting status to 1!");
			}
		}
	}

	public void SetEquippedWeapon1(WeaponScript Weapon)
	{
		for (int i = 0; i < this.Weapons.Length; i++)
		{
			if (this.Weapons[i] == Weapon)
			{
				this.YandereWeapon1 = i;
			}
		}
	}

	public void SetEquippedWeapon2(WeaponScript Weapon)
	{
		for (int i = 0; i < this.Weapons.Length; i++)
		{
			if (this.Weapons[i] == Weapon)
			{
				this.YandereWeapon2 = i;
			}
		}
	}

	public void EquipWeaponsFromSave()
	{
		if (this.YandereWeapon1 > -1)
		{
			this.Weapons[this.YandereWeapon1].Prompt.Circle[3].fillAmount = 0f;
			if (this.Yandere.Equipped != 1)
			{
				this.Weapons[this.YandereWeapon1].UnequipImmediately = true;
			}
		}
		if (this.YandereWeapon2 > -1)
		{
			this.Weapons[this.YandereWeapon2].Prompt.Circle[3].fillAmount = 0f;
			if (this.Yandere.Equipped != 2)
			{
				this.Weapons[this.YandereWeapon2].UnequipImmediately = true;
			}
		}
	}
}
