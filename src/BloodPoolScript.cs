using System;
using UnityEngine;

public class BloodPoolScript : MonoBehaviour
{
	public float TargetSize;

	public bool Blood = true;

	public bool Grow;

	public Renderer MyRenderer;

	public Texture Flower;

	private void Start()
	{
		if (PlayerGlobals.PantiesEquipped == 7 && this.Blood)
		{
			this.TargetSize *= 0.5f;
		}
		if (GameGlobals.CensorBlood)
		{
			this.MyRenderer.material.color = new Color(1f, 1f, 1f, 1f);
			this.MyRenderer.material.mainTexture = this.Flower;
		}
		base.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
		Vector3 position = base.transform.position;
		if (position.x > 125f || position.x < -125f || position.z > 200f || position.z < -100f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		if (Application.loadedLevelName == "IntroScene" || Application.loadedLevelName == "NewIntroScene")
		{
			this.MyRenderer.material.SetColor("_TintColor", new Color(0.1f, 0.1f, 0.1f));
		}
	}

	private void Update()
	{
		if (this.Grow)
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(this.TargetSize, this.TargetSize, this.TargetSize), Time.deltaTime);
			if (base.transform.localScale.x > this.TargetSize * 0.99f)
			{
				this.Grow = false;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodSpawner")
		{
			this.Grow = true;
		}
	}
}
