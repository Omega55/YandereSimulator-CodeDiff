using System;
using UnityEngine;

public class CensorBloodScript : MonoBehaviour
{
	public ParticleSystem MyParticles;

	public Texture Flower;

	private void Start()
	{
		if (GameGlobals.CensorBlood)
		{
			this.MyParticles.main.startColor = new Color(1f, 1f, 1f, 1f);
			this.MyParticles.colorOverLifetime.enabled = false;
			this.MyParticles.GetComponent<Renderer>().material.mainTexture = this.Flower;
		}
	}
}
