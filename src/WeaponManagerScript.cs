using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class WeaponManagerScript : MonoBehaviour
{
	public WeaponScript[] Weapons;

	public virtual void UpdateLabels()
	{
		for (int i = 0; i < Extensions.get_length(this.Weapons); i++)
		{
			this.Weapons[i].UpdateLabel();
		}
	}

	public virtual void Main()
	{
	}
}
