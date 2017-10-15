using System;
using UnityEngine;

public class LargeTextScript : MonoBehaviour
{
	public UILabel Label;

	public string[] String;

	public int ID;

	private void Start()
	{
		this.Label.text = this.String[this.ID];
	}

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.ID++;
			this.Label.text = this.String[this.ID];
		}
	}
}
