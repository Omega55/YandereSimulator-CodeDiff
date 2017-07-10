using System;
using UnityEngine;

public class ParticleDeathScript : MonoBehaviour
{
	public ParticleSystem Particles;

	private void LateUpdate()
	{
		if (this.Particles.isPlaying && this.Particles.particleCount == 0)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
