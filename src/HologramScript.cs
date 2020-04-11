using System;
using UnityEngine;

public class HologramScript : MonoBehaviour
{
	public GameObject[] Holograms;

	public void UpdateHolograms()
	{
		GameObject[] holograms = this.Holograms;
		for (int i = 0; i < holograms.Length; i++)
		{
			holograms[i].SetActive(this.TrueFalse());
		}
	}

	private bool TrueFalse()
	{
		return Random.value >= 0.5f;
	}
}
