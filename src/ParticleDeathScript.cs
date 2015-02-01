using System;
using UnityEngine;

[Serializable]
public class ParticleDeathScript : MonoBehaviour
{
	public ParticleSystem Particles;

	public virtual void LateUpdate()
	{
		if (this.Particles.particleCount == 0)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
