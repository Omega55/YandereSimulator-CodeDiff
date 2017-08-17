using System;
using UnityEngine;

public class FootprintScript : MonoBehaviour
{
	public YandereScript Yandere;

	public Texture Footprint;

	private void Start()
	{
		if (this.Yandere.Schoolwear == 0 || this.Yandere.Schoolwear == 2 || (this.Yandere.ClubAttire && Globals.Club == 6))
		{
			base.GetComponent<Renderer>().material.mainTexture = this.Footprint;
		}
		UnityEngine.Object.Destroy(this);
	}
}
