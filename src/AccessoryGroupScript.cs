using System;
using UnityEngine;

public class AccessoryGroupScript : MonoBehaviour
{
	public GameObject[] Parts;

	public void SetPartsActive(bool active)
	{
		foreach (GameObject gameObject in this.Parts)
		{
			gameObject.SetActive(active);
		}
	}
}
