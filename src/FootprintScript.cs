using System;
using UnityEngine;

[Serializable]
public class FootprintScript : MonoBehaviour
{
	public YandereScript Yandere;

	public Texture Footprint;

	public virtual void Start()
	{
		if (this.Yandere.Schoolwear == 0 || this.Yandere.Schoolwear == 2 || (this.Yandere.ClubAttire && PlayerPrefs.GetInt("Club") == 6))
		{
			this.renderer.material.mainTexture = this.Footprint;
		}
		UnityEngine.Object.Destroy(this);
	}

	public virtual void Main()
	{
	}
}
