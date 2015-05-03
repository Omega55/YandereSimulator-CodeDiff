using System;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class AccessoryGroupScript : MonoBehaviour
{
	public GameObject[] Parts;

	public virtual void ActivateParts()
	{
		for (int i = 0; i < Extensions.get_length(this.Parts); i++)
		{
			this.Parts[i].active = true;
		}
	}

	public virtual void DeactivateParts()
	{
		for (int i = 0; i < Extensions.get_length(this.Parts); i++)
		{
			this.Parts[i].active = false;
		}
	}

	public virtual void Main()
	{
	}
}
