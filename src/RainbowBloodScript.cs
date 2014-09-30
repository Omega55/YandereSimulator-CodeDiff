using System;
using UnityEngine;

[Serializable]
public class RainbowBloodScript : MonoBehaviour
{
	public ParticleSystem particle;

	public int R;

	public int G;

	public int B;

	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("RainbowBlood") == 0)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	public virtual void Update()
	{
		this.R = UnityEngine.Random.Range(0, 2);
		this.G = UnityEngine.Random.Range(0, 2);
		this.B = UnityEngine.Random.Range(0, 2);
		if (this.R == 0 && this.G == 0 && this.B == 0)
		{
			this.R = 1;
		}
		if (this.R == 1 && this.G == 1 && this.B == 1)
		{
			this.R = 0;
		}
		this.particle.startColor = new Color((float)this.R, (float)this.G, (float)this.B, (float)1);
	}

	public virtual void Main()
	{
	}
}
