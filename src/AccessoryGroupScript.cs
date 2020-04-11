using System;
using UnityEngine;

public class AccessoryGroupScript : MonoBehaviour
{
	public GameObject[] Parts;

	public void SetPartsActive(bool active)
	{
		GameObject[] parts = this.Parts;
		for (int i = 0; i < parts.Length; i++)
		{
			parts[i].SetActive(active);
		}
	}
}
