using System;
using UnityEngine;

public class MemeManagerScript : MonoBehaviour
{
	[SerializeField]
	private GameObject[] Memes;

	private void Start()
	{
		if (GameGlobals.LoveSick)
		{
			foreach (GameObject gameObject in this.Memes)
			{
				gameObject.SetActive(false);
			}
		}
	}
}
