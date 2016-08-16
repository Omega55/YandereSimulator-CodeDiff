using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class WeaponManagerScript : MonoBehaviour
{
	public WeaponScript[] Weapons;

	public JsonScript JSON;

	public int[] Victims;

	public int MurderWeapons;

	public int Fingerprints;

	public bool YandereGuilty;

	public virtual void UpdateLabels()
	{
		for (int i = 0; i < Extensions.get_length(this.Weapons); i++)
		{
			this.Weapons[i].UpdateLabel();
		}
	}

	public virtual void CheckWeapons()
	{
		this.MurderWeapons = 0;
		this.Fingerprints = 0;
		for (int i = 0; i < Extensions.get_length(this.Victims); i++)
		{
			this.Victims[i] = 0;
		}
		for (int i = 0; i < Extensions.get_length(this.Weapons); i++)
		{
			if (this.Weapons[i] != null && this.Weapons[i].Blood.enabled)
			{
				this.MurderWeapons++;
				if (this.Weapons[i].FingerprintID > 0)
				{
					this.Fingerprints++;
					for (int j = 0; j < Extensions.get_length(this.Weapons[i].Victims); j++)
					{
						if (this.Weapons[i].Victims[j])
						{
							this.Victims[j] = this.Weapons[i].FingerprintID;
						}
					}
				}
			}
		}
	}

	public virtual void CleanWeapons()
	{
		for (int i = 0; i < Extensions.get_length(this.Weapons); i++)
		{
			if (this.Weapons[i] != null)
			{
				this.Weapons[i].Blood.enabled = false;
				this.Weapons[i].FingerprintID = 0;
			}
		}
	}

	public virtual void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.CheckWeapons();
			for (int i = 0; i < Extensions.get_length(this.Victims); i++)
			{
				if (this.Victims[i] != 0)
				{
					if (this.Victims[i] == 100)
					{
						Debug.Log("The student named " + this.JSON.StudentNames[i] + " was killed by Yandere-chan!");
					}
					else
					{
						Debug.Log("The student named " + this.JSON.StudentNames[i] + " was killed by " + this.JSON.StudentNames[this.Victims[i]] + "!");
					}
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
