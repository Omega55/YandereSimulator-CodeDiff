using System;
using UnityEngine;

public class HologramScript : MonoBehaviour
{
	public GameObject[] Holograms;

	public void UpdateHolograms()
	{
		foreach (GameObject gameObject in this.Holograms)
		{
			gameObject.SetActive(this.TrueFalse());
		}
	}

	private bool TrueFalse()
	{
		return UnityEngine.Random.value >= 0.5f;
	}
}
