using System;
using UnityEngine;

public class TributeScript : MonoBehaviour
{
	public YandereScript Yandere;

	public GameObject Rainey;

	public string[] AzurLane;

	public string[] Letter;

	public int AzurID;

	public int ID;

	private void Start()
	{
		this.Rainey.SetActive(false);
	}

	private void Update()
	{
		if (Input.GetKeyDown(this.Letter[this.ID]))
		{
			this.ID++;
			if (this.ID == this.Letter.Length)
			{
				this.Rainey.SetActive(true);
				base.enabled = false;
			}
		}
		if (Input.GetKeyDown(this.AzurLane[this.AzurID]))
		{
			this.AzurID++;
			if (this.AzurID == this.AzurLane.Length)
			{
				this.Yandere.AzurLane();
				base.enabled = false;
			}
		}
	}
}
