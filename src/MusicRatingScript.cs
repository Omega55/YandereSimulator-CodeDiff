using System;
using UnityEngine;

public class MusicRatingScript : MonoBehaviour
{
	public Renderer MyRenderer;

	public AudioSource SFX;

	public float Speed;

	public float Timer;

	private void Start()
	{
		if (this.SFX != null)
		{
			this.SFX.pitch = Random.Range(0.9f, 1.1f);
		}
	}

	private void Update()
	{
		base.transform.localPosition += new Vector3(0f, this.Speed * Time.deltaTime, 0f);
		base.transform.localScale = Vector3.MoveTowards(base.transform.localScale, new Vector3(0.2f, 0.1f, 0.1f), Time.deltaTime);
		this.Timer += Time.deltaTime * 5f;
		if (this.Timer > 1f)
		{
			this.MyRenderer.material.color = new Color(1f, 1f, 1f, 2f - this.Timer);
			if (this.MyRenderer.material.color.a <= 0f)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
