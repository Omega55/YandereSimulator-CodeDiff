using System;
using UnityEngine;

public class CheckmarkScript : MonoBehaviour
{
	public GameObject[] Checkmarks;

	public int ID;

	private void Start()
	{
		while (this.ID < this.Checkmarks.Length)
		{
			this.Checkmarks[this.ID].SetActive(false);
			this.ID++;
		}
		this.ID = 0;
	}

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID = UnityEngine.Random.Range(0, this.Checkmarks.Length);
			while (this.Checkmarks[this.ID].active)
			{
				this.ID = UnityEngine.Random.Range(0, this.Checkmarks.Length);
			}
			this.Checkmarks[this.ID].SetActive(true);
		}
	}
}
