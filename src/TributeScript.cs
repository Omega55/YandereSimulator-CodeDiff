using System;
using UnityEngine;

public class TributeScript : MonoBehaviour
{
	public GameObject Rainey;

	public string[] Letter;

	public int ID;

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
	}
}
