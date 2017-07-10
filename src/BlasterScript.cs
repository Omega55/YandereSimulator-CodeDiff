using System;
using UnityEngine;

public class BlasterScript : MonoBehaviour
{
	public Transform Skull;

	public Renderer Eyes;

	public Transform Beam;

	public float Size;

	private void Start()
	{
		this.Skull.localScale = Vector3.zero;
		this.Beam.localScale = Vector3.zero;
	}

	private void Update()
	{
		AnimationState animationState = base.GetComponent<Animation>()["Blast"];
		if (animationState.time > 1f)
		{
			this.Beam.localScale = Vector3.Lerp(this.Beam.localScale, new Vector3(15f, 1f, 1f), Time.deltaTime * 10f);
			this.Eyes.material.color = new Color(1f, 0f, 0f, 1f);
		}
		if (animationState.time >= animationState.length)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void LateUpdate()
	{
		AnimationState animationState = base.GetComponent<Animation>()["Blast"];
		this.Size = ((animationState.time >= 1.5f) ? Mathf.Lerp(this.Size, 0f, Time.deltaTime * 10f) : Mathf.Lerp(this.Size, 2f, Time.deltaTime * 5f));
		this.Skull.localScale = new Vector3(this.Size, this.Size, this.Size);
	}
}
